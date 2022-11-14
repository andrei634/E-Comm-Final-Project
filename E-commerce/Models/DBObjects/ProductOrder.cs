using System;
using System.Collections.Generic;

namespace E_commerce.Models.DBObjects
{
    public partial class ProductOrder
    {
        public Guid IdProduct { get; set; }
        public Guid IdOrder { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Guid IdProductOrder { get; set; }
        public string ProductTitle { get; set; } = null!;

        public virtual OrderTable IdOrderNavigation { get; set; } = null!;
        public virtual Product IdProductNavigation { get; set; } = null!;
    }
}
