﻿namespace E_Comm.Models
{
    public class ProductCartModel
    {
        public Guid IdProduct { get; set; }
        public Guid IdCart { get; set; }
        public int Quantity { get; set; }
    }
}
