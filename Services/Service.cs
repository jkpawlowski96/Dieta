using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class Service
    {
        protected Data.Database db;
        protected Models.UserModel User { get; set; }

        public Service(Models.UserModel _user)
        {
            db = new Data.Database();
            User = _user;
        }
    }
}
