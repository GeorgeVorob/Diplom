using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiplomCore.Models
{
    public enum OrderStatus { pending, done, declined };
    public class Order
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
#nullable enable
        public User? User { get; set; }
#nullable disable

        public ICollection<OrderedProduct> Orderedproducts { get; set; }

        [Required]
        public string shippingAdress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        public OrderStatus Status { get; set; }
    }
}
