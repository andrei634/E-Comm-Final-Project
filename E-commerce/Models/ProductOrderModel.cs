namespace E_commerce.Models
{
    public class ProductOrderModel
    {
        public Guid IdProduct { get; set; }
        public Guid IdOrder { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Guid IdProductOrder { get; set; }
        public string ProductTitle { get; set; } = null!;
    }
}
