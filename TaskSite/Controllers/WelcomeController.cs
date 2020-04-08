﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using TaskSite.Models;
using TaskSite.Services;

namespace TaskSite.Controllers
{
    public class WelcomeController : Controller
    {
        private SiteService _siteservice;
        public WelcomeController(SiteService siteservice)
        {
            _siteservice = siteservice;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel currentUser)
        {

            if (!ModelState.IsValid)
            {
                return View(currentUser);
            }

            else

            if (!_siteservice.CheckIfLoginVacant(currentUser.Login))
            {
                ModelState.AddModelError("Login", "Такой логин уже существует");
            }

            else

            if (!_siteservice.CheckIfEmailVacant(currentUser.Email))
            {
                ModelState.AddModelError("Email", "Такой Email уже существует");
            }

            else

            {
                _siteservice.AddNewUser(currentUser.Login, currentUser.Password, currentUser.Email);
                return RedirectToAction("Login", "Welcome");
            }

            return View(currentUser);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Welcome");
        }

        public IActionResult DeleteAccount()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _siteservice.DeleteUserAccount(HttpContext.User.Identity.Name);
            return RedirectToAction("Login", "Welcome");
        }


        [HttpPost]
        public IActionResult Login(LoginModel currentUser)
        {
            var user = _siteservice.GetByLogin(currentUser.Login);

            if (!ModelState.IsValid)
            {
                return View(currentUser);
            }
            else if (user == null)
            {
                ModelState.AddModelError("Login", "Неправильно введено имя пользователя");
            }
            else if (user.Password != currentUser.Password)
            {
                ModelState.AddModelError("Password", "Неправильно введен пароль");
            }
            else
            {
                var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, user.Login),
                        new Claim("userId", Convert.ToString(user.Id))
                        //new Claim(ClaimTypes.Role, user.Role)
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                Thread.CurrentPrincipal = principal;

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "MainMenu");

                //if (User.HasClaim("Role", "Преподаватель"))
                //return RedirectToAction("TeacherMM", "MainMenu");
                //else return RedirectToAction("StudentMM", "MainMenu");
            }
            return View(currentUser);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}