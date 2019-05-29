using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    
    public class LoginService : Service
    {
        public LoginService(UserModel _user) :base (_user)
        {

        }
        public bool SignIn()
        {
            try
            {
                var args = new List<string>();
                args.Add(User.Username);
                args.Add(User.Password);

                var answer = db.Procedure("User_Login", args);
                if (answer.Count == 0)
                {
                    return false;
                }
                else
                {
                    User.Id = int.Parse(answer[0]);
                    User.Kcal = int.Parse(answer[1]);
                    User.Lactose = bool.Parse(answer[2]);
                    User.Gluten = bool.Parse(answer[3]);
                    User.Meat = bool.Parse(answer[4]);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }            
        }
    }
}
