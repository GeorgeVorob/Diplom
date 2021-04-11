using System.ComponentModel.DataAnnotations;

namespace DiplomCore.Models.CategoriesModels
{
    public class CPU : Product
    {
        [Required]
        public int cores { get; set; }

        [Required]
        public int clock { get; set; } //МГц 
        //TODO
    }
}
