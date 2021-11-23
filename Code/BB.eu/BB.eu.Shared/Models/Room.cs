using System;
using System.Collections.Generic;

namespace BB.eu.Shared.Models
{
    public class Room : EntityBase
    {
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public Address Address { get; set; }
        public int GuestCount { get; set; }
        public List<Booking> Bookings { get; set; } = new();
        public List<Picture> Pictures { get; set; } = new();
    }
}