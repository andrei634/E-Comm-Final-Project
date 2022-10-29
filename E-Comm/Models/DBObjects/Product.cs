using System;
using System.Collections.Generic;

namespace E_Comm.Models.DBObjects
{
    public partial class Product
    {
        public Guid IdProduct { get; set; }
        public string Title { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }
        public int? Rating { get; set; }
        public string Image { get; set; } = null!;
        public string Category { get; set; } = null!;
    }
}
