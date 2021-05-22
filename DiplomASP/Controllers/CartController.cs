using DiplomASP.Models.ViewModels;
using DiplomCore.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomASP.Controllers
{
    public class CartController : Controller
    {
        DataProviderService _data;
        public CartController(DataProviderService data)
        {
            _data = data;
        }
        public IActionResult Index()
        {
            var model = new CartModel();
            model.TmpProducts = _data.GetProducts(null, null, null, 4);
            return View(model);
        }
    }
}
