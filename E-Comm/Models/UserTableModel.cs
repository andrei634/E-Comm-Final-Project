namespace E_Comm.Models
{
    public class UserTableModel
    {
        public string IdUser { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string City { get; set; } = null!;
        public int ZipCode { get; set; }
        public string Street { get; set; } = null!;
        public int StreetNumber { get; set; }
    }
}
