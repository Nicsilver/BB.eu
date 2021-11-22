using System.Collections.Generic;

namespace BB.eu.Shared.Models
{
    public class Renter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public string Password { get; set; }
    }
}