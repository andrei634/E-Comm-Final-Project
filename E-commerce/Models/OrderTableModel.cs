namespace E_commerce.Models
{
    public class OrderTableModel
    {
        public Guid IdOrder { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public string City { get; set; } = null!;
        public int ZipCode { get; set; }
        public string Street { get; set; } = null!;
        public int StreetNumber { get; set; }
        public Guid IdUser { get; set; }
    }
}
