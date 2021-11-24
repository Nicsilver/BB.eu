using System;
using BB.eu.Shared.Models;

namespace BB.eu.API.Responses
{
    public class RenterLoginResponse : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid Guid { get; set; }
    }
}