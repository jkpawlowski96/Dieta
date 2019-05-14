using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Shops
    {
        public Shops()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
