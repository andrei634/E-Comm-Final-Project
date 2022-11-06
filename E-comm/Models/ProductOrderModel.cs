namespace E_comm.Models
{
    public class ProductOrderModel
    {
        public Guid IdProduct { get; set; }
        public Guid IdOrder { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
