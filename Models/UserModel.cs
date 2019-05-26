using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class UserModel
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public int  Id { get; set; }
        public int  Kcal { get; set; }
        /// <summary>
        /// May eat Lactose
        /// </summary>
        public bool Lactose { get; set; }
        /// <summary>
        /// May eat Gluten
        /// </summary>
        public bool Gluten { get; set; }
        /// <summary>
        /// Can eat a Meat
        /// </summary>
        public bool Vege { get; set; }
    }
}
