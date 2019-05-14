using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Products
    {
        public Products()
        {
            History = new HashSet<History>();
        }

        public int Id { get; set; }
        public int? IngridientId { get; set; }
        public int? ShopId { get; set; }
        public float? Price { get; set; }
        public int? Weight { get; set; }
        public float? Price100 { get; set; }

        public virtual Ingredients Ingridient { get; set; }
        public virtual Shops Shop { get; set; }
        public virtual ICollection<History> History { get; set; }
    }
}
