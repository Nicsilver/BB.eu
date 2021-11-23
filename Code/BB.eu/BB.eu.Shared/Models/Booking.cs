using System;

namespace BB.eu.Shared.Models
{
    public class Booking : EntityBase
    {
        public DateTime RentedFrom { get; set; }
        public DateTime RentedTill { get; set; }
    }
}