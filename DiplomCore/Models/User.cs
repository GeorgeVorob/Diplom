using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace DiplomCore.Models
{
    public enum Role { user, admin }
    public class User : IdentityUser
    {
        public int? UsID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegDate { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
