using System;
using System.Collections.Generic;

namespace E_commerce.Models.DBObjects
{
    public partial class OrderTable
    {
        public OrderTable()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public Guid IdOrder { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public string City { get; set; } = null!;
        public int ZipCode { get; set; }
        public string Street { get; set; } = null!;
        public int StreetNumber { get; set; }
        public Guid IdUser { get; set; }

        public virtual UserTable IdUserNavigation { get; set; } = null!;
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
