using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiplomCore.Models
{
    public enum OrderStatus { pending, done, declined };
    public class Order
    {
        public Order()
        {

        }
        public Order(string email, string shippingAdress, string phone, OrderStatus status)
        {
            this.email = email;
            this.shippingAdress = shippingAdress;
            this.phone = phone;
            this.status = status;
        }
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
