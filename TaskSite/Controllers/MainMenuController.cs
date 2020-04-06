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
        public IActionResult Index(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            User currentUser = _service.GetUserByLogin(HttpContext.User.Identity.Name);
            UserModel userModel = new UserModel
            {
                Age = currentUser.Age,
                FavFood = currentUser.Favfood,
                Credentials = currentUser.Credentials,
                Pet = currentUser.Pet
            };
            return View(userModel);
        }
    }
}