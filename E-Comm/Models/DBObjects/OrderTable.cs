using System;
using System.Collections.Generic;

namespace E_Comm.Models.DBObjects
{
    public partial class OrderTable
    {
        public Guid IdCart { get; set; }
        public DateTime Date { get; set; }
        public int TotalPrice { get; set; }
        public string City { get; set; } = null!;
        public int ZipCode { get; set; }
        public string Street { get; set; } = null!;
        public int StreetNumber { get; set; }
        public string IdUser { get; set; } = null!;

        public virtual Cart IdCartNavigation { get; set; } = null!;
        public virtual UserTable IdUserNavigation { get; set; } = null!;
    }
}
