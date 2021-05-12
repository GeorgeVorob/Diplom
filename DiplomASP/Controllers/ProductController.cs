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
            int id = (int)productId;
            Product product = _data.GetProducts(p => p.ID == id, null, 1).First();
            if (product == null) return RedirectToAction("Index", "Home"); //TODO: add 404
            return View(product);
        }
    }
}
