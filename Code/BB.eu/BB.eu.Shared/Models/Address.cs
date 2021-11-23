namespace BB.eu.Shared.Models
{
    public class Address : EntityBase
    {
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
    }
}