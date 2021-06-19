using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace DiplomCore.Models
{
    public abstract class Product
    {
        //public abstract List<(string name, string techname ,string value, Type type )> GetPublicTTX();
        public int ID { get; set; }
        [Required]
        [PublicProp("number", "Категория")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [Required]
        [PublicProp("text", "Название")]
        [StringLength(200)]
        public string Name { get; set; } = "NA";

        [Required]
        [PublicProp("number", "Кол-во")]
        public int quantity { get; set; } = 10;

        [Required]
        [PublicProp("number", "Цена")]
        public int Price { get; set; } = 15600;

        [PublicProp("number", "Скидка")]
        public int Discount { get; set; } = 0;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PostDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AlterDate { get; set; }

        public List<OrderedProduct> Orders { get; set; }

        public string ImageThumbnail { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
    }
}