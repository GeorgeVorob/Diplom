using System.ComponentModel.DataAnnotations;

namespace DiplomCore.Models
{
    public class ImageContent
    {
        [Key]
        public int ImageContentID { get; set; }
        public byte[] content { get; set; }
    }
}
