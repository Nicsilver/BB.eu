using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BB.eu.Shared.Models;

namespace BB.eu.Shared.Requests
{
    public class CreateRoomRequest
    {
        [Required] public string RoomName { get; set; }
        [Required] public string RoomDescription { get; set; }
        [Required] public Address Address { get; set; }
        [Required] public int GuestCount { get; set; }
        [Required] public int Price { get; set; }
        public List<Picture> Pictures { get; set; } = new();
        public Guid Guid { get; set; }
    }
}