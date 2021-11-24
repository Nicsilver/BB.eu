using System.Collections.Generic;
using BB.eu.Shared.Models;

namespace BB.eu.API.Responses
{
    public class RenterGetAllResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Room> Rooms { get; set; }
    }
}