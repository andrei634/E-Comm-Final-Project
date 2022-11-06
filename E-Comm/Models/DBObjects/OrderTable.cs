using System;
using System.Collections.Generic;

namespace E_comm.Models.DBObjects
{
    public partial class OrderTable
    {
        public Guid IdOrder { get; set; }
        public DateTime Date { get; set; }
        public int TotalPrice { get; set; }
        public string City { get; set; } = null!;
        public int ZipCode { get; set; }
        public string Street { get; set; } = null!;
        public int StreetNumber { get; set; }
        public string IdUser { get; set; } = null!;

        public virtual UserTable IdUserNavigation { get; set; } = null!;
    }
}
