using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class History
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? IngredientId { get; set; }
        public int? ProductId { get; set; }
        public int? Amount { get; set; }
        public DateTime? Date { get; set; }

    }
}
