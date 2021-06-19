using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiplomCore.Models.CategoriesModels
{
    public class GraphicsCard : Product
    {
        [Required]
        [PublicProp("number", "Объем видеопамяти")]
        public int memory { get; set; } = 2000;//МБ
        [Required]
        [PublicProp("number","Частота")]
        public int clock { get; set; } = 4000;//МГц 

        [Required]
        [PublicProp("number", "Потребление Вт")]
        public int power { get; set; } = 300;

        [Required]
        [PublicProp("int", "Длина видеокарты Мм")]
        public int lenght { get; set; } = 147;
        //TODO: больше свойств

        //public override List<(string, string, string, Type)> GetPublicTTX()
        //{
        //    var stats = new List<(string, string, string, Type)>();

        //    stats.Add(("Объем видеопамяти", "memory", this.memory.ToString(), this.memory.GetType()));
        //    stats.Add(("Частота", "clock",this.clock.ToString(), this.clock.GetType()));

        //    return stats;
        //}
    }
}
