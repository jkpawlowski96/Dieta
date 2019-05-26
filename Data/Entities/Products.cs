using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Products
    {
    

        public int Id { get; set; }
        public int? IngridientId { get; set; }
        public int? ShopId { get; set; }
        public float? Price { get; set; }
        public int? Weight { get; set; }
        public float? Price100 { get; set; }

       
    }
}
