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
        public IActionResult EditUser(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }
            user.Login = HttpContext.User.Identity.Name;
            _service.EditUserInfo(user);
            return RedirectToAction("Index", "MainMenu");
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            User currentUser = _service.GetUserByLogin(HttpContext.User.Identity.Name);
            UserModel userModel = _service.ConvertDBToModel(currentUser);
            return View(userModel);
        }
    }
}