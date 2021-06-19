using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiplomCore.Models.CategoriesModels
{
    public class CPU : Product
    {
        [Required]
        [PublicProp("number", "Кол-во ядер")]
        public int cores { get; set; } = 4;

        [Required]
        [PublicProp("number","Базовая МГц")]
        public int clock { get; set; } //МГц 

        [Required]
        [PublicProp("text", "Сокет")]
        public string socket { get; set; } = "AM4";
        [Required]
        [PublicProp("number", "Техпроцесс")]
        public int techProcess { get; set; } = 7;

        //public override List<(string, string, string, Type)> GetPublicTTX()
        //{
        //    var stats = new List<(string, string, string, Type type)>();

        //    stats.Add(("Кол-во ядер", "cores", this.cores.ToString(), this.cores.GetType()));
        //    stats.Add(("Частота", "clock", this.clock.ToString(), this.clock.GetType()));

        //    return stats;
        //}
        //TODO
    }
}
