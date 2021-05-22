using DiplomCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomASP.Models.ViewModels
{
    public class SearchViewModel
    {
        public string searchString { get; set; }
        public string searchingCategoryName { get; set; }
        public Product searchingProductExample { get; set; }
        public List<Category> categories { get; set; }

        public List<Product> resultProducts { get; set; }
    }
}
