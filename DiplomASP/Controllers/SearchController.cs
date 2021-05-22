using DiplomASP.Models;
using DiplomASP.Models.ViewModels;
using DiplomCore.Models;
using DiplomCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiplomASP.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataProviderService _data;

        public SearchController(ILogger<HomeController> logger, DataProviderService data)
        {
            _logger = logger;
            _data = data;
        }

        [HttpPost]
        public IActionResult Index(string? searchString, string? selectedCategoryName,string orderParam = "PopularDecr" , int priceMax = Int32.MaxValue, int priceMin = 0)
        {
            SearchViewModel model = new SearchViewModel();
            model.searchString = searchString;

            (Expression<Func<Product, object>>, bool) orderArgs;
            switch(orderParam) //TODO: сделать через нормальный конструктор выражений
            {
                case "PopularInc":
                    orderArgs.Item1 = p => p.Orders.Sum(p => p.Quantity);
                    orderArgs.Item2 = false;
                    break;
                case "PopularDecr":
                default: //PopularDecr
                    orderArgs.Item1 = p => p.Orders.Sum(p => p.Quantity);
                    orderArgs.Item2 = true;
                    break;
            }
            model.resultProducts = _data.GetProducts(p => p.Price >= priceMin && p.Price <= priceMax && p.Category.CategoryName == selectedCategoryName, orderArgs, searchString, 100); //TODO: постраничный вывод
            

            model.searchingCategoryName = selectedCategoryName;
            model.searchingProductExample = _data.GetProducts(p => p.Category.CategoryName == selectedCategoryName, null, null, 1).FirstOrDefault(); //TODO: полноценный поиск по категории
            model.categories = _data.GetCategories();


            return View(model);
        }
    }
}
