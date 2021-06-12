using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiplomCore.Models
{
    public enum OrderStatus { pending, done, declined };
    public class Order
    {
        public int ID { get; set; }
        //public int? UserID { get; set; }
#nullable enable
        public User? user { get; set; }
#nullable disable
        [Required]
        public string email { get; set; }

        [Required]
        public ICollection<OrderedProduct> orderedProducts { get; set; }

        [Required]
        public string shippingAdress { get; set; }

        [Required]
        public string phone { get; set; }

        [Required]
        public OrderStatus status { get; set; }
    }
}
