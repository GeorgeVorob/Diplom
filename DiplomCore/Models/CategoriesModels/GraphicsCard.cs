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

        public override Dictionary<string, string> GetPublicTTX()
        {
            var stats = new Dictionary<string, string>();

            stats.Add("Объем видеопамяти", this.memory.ToString());
            stats.Add("Частота", this.clock.ToString());

            return stats;
        }
    }
}
