using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomCore.Models.CategoriesModels
{
    public class GraphicsCard : Product
    {
        public int memory { get; set; } //МБ
        public int clock { get; set; } //МГц 

        //TODO: больше свойств

        public override List<(string, string, string, Type)> GetPublicTTX()
        {
            var stats = new List<(string, string, string, Type)>();

            stats.Add(("Объем видеопамяти", "memory", this.memory.ToString(), this.memory.GetType()));
            stats.Add(("Частота", "clock",this.clock.ToString(), this.clock.GetType()));

            return stats;
        }
    }
}
