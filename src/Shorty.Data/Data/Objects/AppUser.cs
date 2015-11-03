using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Shorty.Core.Data.Objects
{
    public class AppUser : IdentityUser
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        [StringLength(50)]
        public string TimeZone { get; set; }

        [StringLength(50)]
        public string SecurityQuestion { get; set; }

        [StringLength(50)]
        public string SecurityAnswer { get; set; }
    }
}