using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiplomCore.Models.CategoriesModels
{
    public class CPU : Product
    {
        [Required]
        public int cores { get; set; }

        [Required]
        public int clock { get; set; } //МГц 

        public override List<(string, string, string, Type)> GetPublicTTX()
        {
            var stats = new List<(string, string, string, Type type)>();

            stats.Add(("Кол-во ядер", "cores", this.cores.ToString(), this.cores.GetType()));
            stats.Add(("Частота", "clock", this.clock.ToString(), this.clock.GetType()));

            return stats;
        }
        //TODO
    }
}
