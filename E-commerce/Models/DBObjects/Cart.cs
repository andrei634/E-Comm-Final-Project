using System;
using System.Collections.Generic;

namespace E_commerce.Models.DBObjects
{
    public partial class Cart
    {
        public Guid IdCart { get; set; }
        public Guid IdUser { get; set; }

        public virtual UserTable IdUserNavigation { get; set; } = null!;
    }
}
