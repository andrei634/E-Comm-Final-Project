using System;
using System.Collections.Generic;

namespace E_comm.Models.DBObjects
{
    public partial class UserTable
    {
        public UserTable()
        {
            Carts = new HashSet<Cart>();
            OrderTables = new HashSet<OrderTable>();
        }

        public string IdUser { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string City { get; set; } = null!;
        public int ZipCode { get; set; }
        public string Street { get; set; } = null!;
        public int StreetNumber { get; set; }

        public virtual AspNetUser IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderTable> OrderTables { get; set; }
    }
}
