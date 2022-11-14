using System;
using System.Collections.Generic;

namespace E_commerce.Models.DBObjects
{
    public partial class Cart
    {
        public Cart()
        {
            ProductCarts = new HashSet<ProductCart>();
        }

        public Guid IdCart { get; set; }
        public Guid IdUser { get; set; }

        public virtual UserTable IdUserNavigation { get; set; } = null!;
        public virtual ICollection<ProductCart> ProductCarts { get; set; }
    }
}
