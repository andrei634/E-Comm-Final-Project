using System;
using System.Collections.Generic;

namespace E_commerce.Models.DBObjects
{
    public partial class Product
    {
        public Guid IdProduct { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; } = null!;
        public string Category { get; set; } = null!;
    }
}
