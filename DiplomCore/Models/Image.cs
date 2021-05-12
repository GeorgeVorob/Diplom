using System.ComponentModel.DataAnnotations;

namespace DiplomCore.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        [Required]
        public int ImageContentID { get; set; }
        public ImageContent ImageContent { get; set; }

        [Required]
        public int ProductID { get; set; }
        //public Product Product { get; set; }
    }
}
