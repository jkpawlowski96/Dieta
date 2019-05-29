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
using System.Threading;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        static List<Models.FitModel>[] fitTemps = new List<Models.FitModel>[999999] ;
            
            
        int IntFromBool(bool arg)
        {
            if (arg)
                return 1;
            else return 0;
        }
        bool BoolFromInt(int arg)
        {
            if (arg>0)
                return true;
            else return false;
        }
        public void MessageBox(string message)
        {
            Response.WriteAsync("<script>alert('"+ message + "');</script>");
        }
        private Models.UserModel UserFromSession()
        {
            try
            {
                var user = new UserModel()
                {
                    Id = HttpContext.Session.GetInt32("Id").Value,
                    Username = HttpContext.Session.GetString("Username"),
                    Password = HttpContext.Session.GetString("Password"),
                    Kcal = HttpContext.Session.GetInt32("Kcal").Value,
                    Lactose = BoolFromInt(HttpContext.Session.GetInt32("Lactose").Value),
                    Gluten = BoolFromInt(HttpContext.Session.GetInt32("Gluten").Value),
                    Meat = BoolFromInt(HttpContext.Session.GetInt32("Vege").Value)
                };
                return user;
            }
            catch (Exception)
            {
                Thread.Sleep(2000);
                return UserFromSession();
            }
            
        }
        
        private void SessionFromUser(UserModel user)
        {
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Password", user.Password);
            HttpContext.Session.SetInt32("Id", user.Id);
            HttpContext.Session.SetInt32("Kcal", user.Kcal);
            HttpContext.Session.SetInt32("Lactose", IntFromBool(user.Lactose));
            HttpContext.Session.SetInt32("Gluten", IntFromBool(user.Gluten));    
            HttpContext.Session.SetInt32("Vege", IntFromBool(user.Meat));
            HttpContext.Session.SetInt32("signed", 1);
        }


        public IActionResult Index()
        {
            var user = UserFromSession();
            TempData["Username"] = user.Username;
            TempData["Kcal"] = user.Kcal;

            /*
            TempData["CanEat"] = "Vegies Fruits ";
            TempData["CantEat"] = "";

            if (user.Meat)
                TempData["CanEat"] += "Meat ";
            else
                TempData["CantEat"] += "Meat ";
            if (user.Lactose)
                TempData["CanEat"] += "Lactose ";
            else
                TempData["CantEat"] += "Lactose ";
            if (user.Gluten)
                TempData["CanEat"] += "Gluten ";
            else
                TempData["CantEat"] += "Gluten ";
                */

            var eat = new EatCanCant();
            eat.can.Add("Vegies");
            eat.can.Add("Fruits");

            if (user.Meat)
                eat.can.Add("Meat");
            else
                eat.cant.Add("Meat");
            if (user.Lactose)
                eat.can.Add("Lactose");
            else
                eat.cant.Add("Lactose");
            if (user.Gluten)
                eat.can.Add("Gluten");
            else
                eat.cant.Add("Gluten");

            return View(eat);
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
                SessionFromUser(user);

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
        public IActionResult EditUser(string result="")
        {
            TempData["Username"] = HttpContext.Session.GetString("Username");
            TempData["Password"] = HttpContext.Session.GetString("Password");
            TempData["Kcal"] = HttpContext.Session.GetInt32("Kcal").ToString();
            TempData["Lactose"] = BoolFromInt(HttpContext.Session.GetInt32("Lactose").Value);
            TempData["Gluten"] = BoolFromInt(HttpContext.Session.GetInt32("Gluten").Value);
            TempData["Vege"] = BoolFromInt(HttpContext.Session.GetInt32("Vege").Value);

            TempData["command"] = result;
            return View();
        }
        [HttpPost]
        public IActionResult EditUser(UserModel user)
        {
            if (user.Username == null || user.Password == null)
                return EditUser("please fill all data");
            if (user.Kcal <= 0)
                return EditUser("You have to eat something :)");
            var service = new Services.RegisterService(UserFromSession());
            var result = service.Update(user);
            if (result == "succes")
            {
                SessionFromUser(user);

                return RedirectToAction("Index", "User");
            }


            return EditUser(result);
        }
        public IActionResult History(List<History> history)
        {
            var user = UserFromSession();
            var service = new Services.HistoryService(user);
            history = service.UserHistory();
            return View(history);
        }
        [HttpGet]
        public IActionResult Register(string result="")
        {
            TempData["command"] = result;
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            if (user.Username == null || user.Password == null)
                return EditUser("please fill all data");
            if (user.Kcal <= 0)
                return EditUser("You have to eat something :)");
            var service = new Services.RegisterService(user);
            var result = service.Register();

            //MessageBox(result);
            if (result == "succes")
                return RedirectToAction("Login", "User");
            else
                return Register(result);

        }
        [HttpGet]
        public IActionResult Fit()
        {
            var user = UserFromSession();
            var fit = new List<FitModel>();
            //TempData["user"] = user;

            var service = new Services.FitService(user);
            fit = service.Fit(user);
            var opitimizer = new Optimizer() { UserKcal=user.Kcal};
            fit = opitimizer.Fit(fit);
            fitTemps[user.Id] = fit;

            TempData["SumProducts"] = fit.Count;
            
            TempData["SumWeight"] = opitimizer.SumWeight(fit);
            TempData["SumPrice"]= opitimizer.SumPrice(fit);
            TempData["SumKcal"] = opitimizer.SumKcal(fit);

            return View(fit);
        }
        [HttpPost]
        public IActionResult Fit(List<FitModel> fit)
        {
            return RedirectToAction("FitAdd");
        }
        public IActionResult FitAdd()
        {
            //List<FitModel> fit
            //TempData["user"] = user;

            var user = UserFromSession();

            var fit = fitTemps[user.Id];
            fitTemps[user.Id] = null;
            var service = new Services.HistoryService(user);
            if (service.Add(fit))
                return RedirectToAction("Index");
            else
                return Fit();
        }

    }
}