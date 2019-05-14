using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Users
    {
        public Users()
        {
            History = new HashSet<History>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? Kcals { get; set; }

        public virtual ICollection<History> History { get; set; }
    }
}
