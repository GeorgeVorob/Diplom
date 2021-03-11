using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }

        [Required]
        public ICollection<OrderedProduct> Orderedproducts { get; set; }

        [Required]
        public string shippingAdress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
