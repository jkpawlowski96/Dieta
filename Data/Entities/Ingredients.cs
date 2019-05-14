using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Ingredients
    {
        public Ingredients()
        {
            History = new HashSet<History>();
            Limits = new HashSet<Limits>();
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }
        public float Fat { get; set; }
        public byte? Gluten { get; set; }
        public byte? Lactose { get; set; }
        public byte? Vege { get; set; }
        public float KcalPerG { get; set; }

        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<Limits> Limits { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
