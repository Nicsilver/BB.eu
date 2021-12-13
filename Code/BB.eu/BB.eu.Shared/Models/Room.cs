using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BB.eu.Shared.Models
{
    public class Room : EntityBase
    {
        [Required] public string RoomName { get; set; }
        [Required] public string RoomDescription { get; set; }
        [Required] public Address Address { get; set; }
        [Required] public int GuestCount { get; set; }
        [Required] public int Price { get; set; }
        public List<Booking> Bookings { get; set; } = new();
        public List<Picture> Pictures { get; set; } = new();
    }
}