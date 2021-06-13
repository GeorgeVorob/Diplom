using DiplomASP.Models.ViewModels.PartialViewModels;
using DiplomCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomASP.Models.ViewModels
{
    public class CartModel
    {
        public ActionResultPartialViewModel resultModel { get; set; }

        public List<(Product, int)> Products { get; set; }
        public bool IsLoggedIn { get; set; }

        public string shippingAddress { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public CartModel()
        {
            Products = new List<(Product product, int quantity)>();
        }
    }
}
