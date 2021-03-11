using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models.CategoriesModels
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
