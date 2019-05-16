using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class RegisterService : Service
    {
        public RegisterService(Models.UserModel _user) : base (_user)
        {
        }
        public string Register()
        {
            try
            {
                var args = new List<string>();
                args.Add(User.Username);


                var answer = db.Query("User_Find", args);
                if (answer.Count > 0)
                {
                    return "busy";
                }


                args.Add(User.Password);
                args.Add(User.Kcal.ToString());
                answer = db.Query("User_Register", args);


                return "succes";
            }
            catch (Exception)
            {
                return "fail";
            }
        }
    }
}
