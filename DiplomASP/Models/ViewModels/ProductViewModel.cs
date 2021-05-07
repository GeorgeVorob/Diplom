using DiplomCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomASP.Models.ViewModels
{
    public class ProductViewModel
    {
        Product Product { get; set; }

        List<Product> SameRecommendedProducts { get; set; }
    }
}
