using DiplomCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomASP.Models.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public List<Product> SameRecommendedProducts { get; set; }
    }
}
