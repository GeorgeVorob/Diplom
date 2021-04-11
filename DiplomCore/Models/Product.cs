using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace DiplomCore.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

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

        public byte[] Image { get; set; }

        public Category Category { get; set; }
    }
}
