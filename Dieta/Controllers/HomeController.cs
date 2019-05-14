﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Microsoft.AspNetCore.Http;



namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            

            if (HttpContext.Session.GetString("Username") == null)
                //logged out
                return View();
            else
                //logged in, checking
                try
                {
                    var username = HttpContext.Session.GetString("Username");
                    var password = HttpContext.Session.GetString("Password");
                    return RedirectToAction("Index", "User");
                }
                catch (Exception)
                {
                    return View();
                }
            

           
        }

        public IActionResult Privacy()
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