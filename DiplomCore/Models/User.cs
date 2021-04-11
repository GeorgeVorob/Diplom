using System;
using System.ComponentModel.DataAnnotations;

namespace DiplomCore.Models
{
    public enum Role { user, admin }
    public class User
    {
        public int ID { get; set; }

        [Required]
        [StringLength(25)]
        public string Login { get; set; }

        [Required]
        [StringLength(25)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MidName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegDate { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
