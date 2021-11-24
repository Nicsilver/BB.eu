using System.Collections.Generic;

namespace BB.eu.Shared.Models
{
    public class Tenant : AccountBase
    {
        public List<Booking> Bookings { get; set; } = new();
    }
}