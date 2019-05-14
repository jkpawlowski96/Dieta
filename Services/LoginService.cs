using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;
namespace Services
{
    public class LoginService
    {
        private Data.jkpawlowski_dietaContext context;
        public UserModel User { get; set; }
        public LoginService(Models.UserModel _user)
        {
            context = new Data.jkpawlowski_dietaContext();
            User = _user;
            
        }
        public bool SignIn()
        {
            context = new Data.jkpawlowski_dietaContext();

            var user = context.Users.Where(x => x.UserName == User.Username && x.Password == User.Password).FirstOrDefault();
            if (user != null)
                return true;     
            else return false;
        }
    }
}
