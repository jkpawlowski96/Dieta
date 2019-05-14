using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    
    public class LoginService
    {

        Database db;
        public UserModel User { get; set; }
        public LoginService( Models.UserModel _user)
        {
            db = new Database();
            User = _user;
            
        }
        public bool SignIn()
        {
            var args = new List<string>();
            args.Add(User.Username);
            args.Add(User.Password);

            var answer = db.Query("User_Login", args);
            if (answer.Count == 0)
            {
                return false;
            }
            else
            {
                User.Id = int.Parse( answer[0]);
                User.Kcal = int.Parse(answer[1]);
                return true;
            }
        }
    }
}
