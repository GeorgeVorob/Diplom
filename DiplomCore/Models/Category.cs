using System.ComponentModel.DataAnnotations;

namespace DiplomCore.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
    }
}
