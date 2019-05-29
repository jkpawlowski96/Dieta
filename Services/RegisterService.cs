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


                var answer = db.Procedure("User_Find", args);
                if (answer.Count > 0)
                {
                    return "busy";
                }


                args.Add(User.Password);
                args.Add(User.Kcal.ToString());
                //args.Add(User.Lactose.ToString());
                //args.Add(User.Gluten.ToString());
                //args.Add(User.Vege.ToString());
                answer = db.Procedure("User_Register", args);


                return "succes";
            }
            catch (Exception)
            {
                return "fail";
            }
        }
        public string Update(Models.UserModel _newUser)
        {
            try
            {
                var args = new List<string>();
                args.Add(User.Username);
                args.Add(User.Password);

                var answer = db.Procedure("User_Login", args);
                if (answer.Count == 0)
                {
                    return "sign in again";
                }
                string id = answer[0];


                args = new List<string>();
                args.Add(_newUser.Username);

                if(User.Username != _newUser.Username)
                {
                    answer = db.Procedure("User_Find", args);
                    if (answer.Count > 0)
                    {
                        return "login busy";
                    }
                }
                


                args = new List<string>();
                args.Add(id);
                args.Add(_newUser.Username);
                args.Add(_newUser.Password);
                args.Add(_newUser.Kcal.ToString());
                args.Add(IntFromBool(_newUser.Lactose).ToString());
                args.Add(IntFromBool(_newUser.Gluten).ToString());
                args.Add(IntFromBool(_newUser.Meat).ToString());

                answer = db.Procedure("User_Update", args);

            }
            catch (Exception)
            {
                return "fail";
            }
            return "succes";
        
        }
        int IntFromBool(bool arg)
        {
            if (arg)
                return 1;
            else return 0;
        }
    }
}
