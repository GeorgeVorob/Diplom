using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace DiplomCore.Models
{
    public abstract class Product
    {
        public abstract Dictionary<string, string> GetPublicTTX();
        public int ID { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public int Price { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? Discount { get; set; }

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