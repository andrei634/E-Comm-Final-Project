using System;
using System.Collections.Generic;

namespace E_comm.Models.DBObjects
{
    public partial class Cart
    {
        public Guid IdCart { get; set; }
        public string IdUser { get; set; } = null!;

        public virtual UserTable IdUserNavigation { get; set; } = null!;
    }
}
