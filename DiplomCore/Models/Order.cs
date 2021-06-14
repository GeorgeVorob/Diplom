using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DiplomCore.Models
{
    public enum OrderStatus {
        [Description("Ожидание")]
        pending,
        [Description("Завершено")]
        done,
        [Description("Отклонено")]
        declined };

    public static class MyEnumExtensions
    {
        public static string ToDescriptionString(this OrderStatus val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }

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

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}
