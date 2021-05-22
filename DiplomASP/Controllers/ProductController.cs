using DiplomASP.Models.ViewModels;
using DiplomCore.Models;
using DiplomCore.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomASP.Controllers
{
    public class ProductController : Controller
    {
        DataProviderService _data;
        public ProductController(DataProviderService data)
        {
            _data = data;
        }

        public IActionResult Index(int? productId)
        {
            ProductViewModel model = new ProductViewModel();

            model.Product = _data.GetProducts(p => p.ID == productId, null, null, 1).First();
            if (model.Product == null) return RedirectToAction("Index", "Home"); //TODO: add 404

            model.SameRecommendedProducts = _data.GetProducts(p => p.Price > (model.Product.Price * 1.3) || p.Price < (model.Product.Price / 1.3), null ,null, 3);
            return View(model);
        }
    }
}
