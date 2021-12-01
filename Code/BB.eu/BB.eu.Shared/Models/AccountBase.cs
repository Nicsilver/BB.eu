using System;
using System.ComponentModel.DataAnnotations;

namespace BB.eu.Shared.Models
{
    public abstract class AccountBase : EntityBase
    {
        [Required] [MinLength(2)] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Password { get; set; }
        [EmailAddress] [Required] public string Email { get; set; }
        public Guid Guid { get; set; }
    }
}