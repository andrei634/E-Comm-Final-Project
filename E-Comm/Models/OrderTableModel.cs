namespace E_comm.Models
{
    public class OrderTableModel
    {
        public Guid IdOrder { get; set; }
        public DateTime Date { get; set; }
        public int TotalPrice { get; set; }
        public string City { get; set; } = null!;
        public int ZipCode { get; set; }
        public string Street { get; set; } = null!;
        public int StreetNumber { get; set; }
        public string IdUser { get; set; } = null!;
    }
}
