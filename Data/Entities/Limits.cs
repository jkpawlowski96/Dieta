using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Limits
    {
        public int Id { get; set; }
        public int? IngredientId { get; set; }
        public int? Daily { get; set; }

        public virtual Ingredients Ingredient { get; set; }
    }
}
