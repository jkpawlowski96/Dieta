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
                HttpContext.Session.SetInt32("signed", 1);

                return RedirectToAction("Index");

            }
            else
                return RedirectToAction("Login");

        }
        public IActionResult Logout()
        {

            HttpContext.Session.Clear(); 
            return RedirectToAction("Login","Home");

        }

    }
}