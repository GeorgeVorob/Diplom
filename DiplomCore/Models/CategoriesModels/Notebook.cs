using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiplomCore.Models.CategoriesModels
{
    public class Notebook : Product
    {
        [Required]
        [PublicProp("number", "Кол-во ядер")]
        public int cores { get; set; } = 4;

        [Required]
        [PublicProp("number", "Базовая МГц")]
        public int clock { get; set; } = 4000;//МГц 

        [Required]
        [PublicProp("text", "Сокет")]
        public string socket { get; set; } = "AM4";
        [Required]
        [PublicProp("number", "Техпроцесс")]
        public int techProcess { get; set; } = 7;
    }
}
