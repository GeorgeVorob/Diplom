using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomCore.Models;

namespace DiplomASP.Models.ViewModels
{
    public class IndexModel
    {
        public List<Category> categories { get; set; }
        public List<Product> popularProducts { get; set; }
        public List<Product> newProducts { get; set; }
    }
}
