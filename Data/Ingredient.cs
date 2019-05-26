using System;
using System.Collections.Generic;

namespace Data
{
    public partial class Ingredient
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }
        public float Fats { get; set; }
        public bool? Gluten { get; set; }
        public bool? Lactose { get; set; }
        public bool? Vege { get; set; }
        public float KcalPerG { get; set; }
        public float Kcal { get; set; }

   
    }
}
