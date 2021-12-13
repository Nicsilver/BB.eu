using System.Collections.Generic;

namespace BB.eu.Shared.Models
{
    public class Renter : AccountBase
    {
        public List<Room> Rooms { get; set; } = new();
    }
}