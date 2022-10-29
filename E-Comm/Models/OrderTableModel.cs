namespace E_Comm.Models
{
    public class OrderTableModel
    {
        public Guid IdCart { get; set; }
        public DateTime Date { get; set; }
        public int TotalPrice { get; set; }
        public string City { get; set; } = null!;
        public int ZipCode { get; set; }
        public string Street { get; set; } = null!;
        public int StreetNumber { get; set; }
        public string IdUser { get; set; } = null!;
    }
}
