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

        public override Dictionary<string, string> GetPublicTTX()
        {
            var stats = new Dictionary<string, string>();

            stats.Add("Кол-во ядер", this.cores.ToString());
            stats.Add("Частота", this.clock.ToString());

            return stats;
        }
        //TODO
    }
}
