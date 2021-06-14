using DiplomASP.Models.ViewModels.PartialViewModels;
using DiplomCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomASP.Models.ViewModels
{
    public class AdminModel
    {
        public List<Order> orders { get; set; }

        public List<Category> categories { get; set; }

        public ActionResultPartialViewModel resultModel { get; set; }
    }
}
