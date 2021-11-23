using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BB.eu.Shared.Models
{
    public class Renter : AccountBase
    {
        public List<Room> Rooms { get; set; } = new();
    }
}