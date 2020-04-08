using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModels;
using Microsoft.AspNetCore.Mvc;
using TaskSite.Models;
using TaskSite.Services;

namespace TaskSite.Controllers
{
    public class MainMenuController : Controller
    {
        private UserService _service;
        public MainMenuController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult EditUserInfo(UserModel user)
        {
            string userLogin = new string (HttpContext.User.Identity.Name);
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }
            _service.EditUserInfo(user, userLogin);
            return RedirectToAction("Index", "MainMenu");
        }
        [HttpPost]
        public IActionResult DeleteUserInfo()
        {
            string userLogin = new string(HttpContext.User.Identity.Name);
            _service.DeleteUserInfo(userLogin);
            return RedirectToAction("Index", "MainMenu");
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    User currentUser = _service.GetUserByLogin(HttpContext.User.Identity.Name);
                    ViewBag.Credentials = currentUser.Credentials;
                    ViewBag.Pet = currentUser.Pet;
                    ViewBag.Age = currentUser.Age;
                    ViewBag.Favfood = currentUser.Favfood;
                    return View();
                }
                //UserModel userModel = _service.ConvertDBToModel(currentUser);
                //return View(userModel);
            }
            else
            { 
                return RedirectToAction("Login", "Welcome"); 
            }
        }
    }
}