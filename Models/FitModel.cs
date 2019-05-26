using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class FitModel
    {
        public string Ingredient { get; set; }
        public int Weight { get; set; }
        public int Kcal { get; set; }
        public float Price { get; set; }
        public int? IngredientID { get; set; }
        public int? ProductID { get; set; }
    }
}
