namespace E_commerce.Models
{
    public class UserTableModel
    {
        public Guid IdUser { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string City { get; set; } = null!;
        public int ZipCode { get; set; }
        public string Street { get; set; } = null!;
        public int StreetNumber { get; set; }
        public string EmailAddress { get; set; } = null!;
    }
}
