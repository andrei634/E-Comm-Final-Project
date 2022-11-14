using System;
using System.Collections.Generic;

namespace E_commerce.Models.DBObjects
{
    public partial class ProductCart
    {
        public Guid IdProduct { get; set; }
        public Guid IdCart { get; set; }
        public int Quantity { get; set; }
        public Guid IdProductCart { get; set; }

        public virtual Cart IdCartNavigation { get; set; } = null!;
        public virtual Product IdProductNavigation { get; set; } = null!;
    }
}
