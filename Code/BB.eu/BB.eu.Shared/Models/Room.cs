using System;
using System.Collections.Generic;

namespace BB.eu.Shared.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public Address Address { get; set; }
        public int GuestCount { get; set; }
        public DateTime RentedTill { get; set; }
        public bool IsAvailable { get; set; }
        public List<Picture> Pictures { get; set; } = new();
    }
}