using System;
using System.Collections.Generic;

namespace E_commerce.Models.DBObjects
{
    public partial class Product
    {
        public Product()
        {
            ProductCarts = new HashSet<ProductCart>();
            ProductOrders = new HashSet<ProductOrder>();
        }

        public Guid IdProduct { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; } = null!;
        public string Category { get; set; } = null!;

        public virtual ICollection<ProductCart> ProductCarts { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
