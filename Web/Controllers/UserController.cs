using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Models;
using Services;
using Microsoft.AspNetCore.Http;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            TempData["Username"] = HttpContext.Session.GetString("Username");
            TempData["Kcal"] = HttpContext.Session.GetInt32("Kcal").ToString();
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserModel user)
        {

            if (user.Username == null || user.Password == null)
                return RedirectToAction("Login");

            LoginService service = new LoginService(user);
            if (service.SignIn())
            {
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("Password", user.Password);
                HttpContext.Session.SetInt32("Id", user.Id);
                HttpContext.Session.SetInt32("Kcal", user.Kcal);
                HttpContext.Session.SetInt32("signed", 1);

                return RedirectToAction("Index");

            }
            else
                return RedirectToAction("Login");

        }
        public IActionResult Logout()
        {

            HttpContext.Session.Clear(); 
            return RedirectToAction("Index","Home");

        }
        [HttpGet]
        public IActionResult EditUser()
        {
            TempData["Username"] = HttpContext.Session.GetString("Username");
            TempData["Password"] = HttpContext.Session.GetString("Password");
            TempData["Kcal"] = HttpContext.Session.GetInt32("Kcal").ToString();
            return View();
        }
        [HttpPost]
        public IActionResult EditUser(UserModel user)
        {
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Password", user.Password);
            HttpContext.Session.SetInt32("Kcal", user.Kcal);
            
            return RedirectToAction("Index", "User");
        }
    }
}