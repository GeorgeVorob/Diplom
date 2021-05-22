using DiplomASP.Models;
using DiplomASP.Models.ViewModels;
using DiplomCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataProviderService _data;

        public HomeController(ILogger<HomeController> logger, DataProviderService data)
        {
            _logger = logger;
            _data = data;
        }

        public IActionResult Index()
        {
            IndexModel model = new IndexModel();
            model.categories = _data.GetCategories();
            model.popularProducts = _data.GetProducts(null, (p => p.Orders.Sum(x => x.Quantity), false), null, 6);
            model.newProducts = _data.GetProducts(null, (p => p.PostDate, false), null, 4);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
