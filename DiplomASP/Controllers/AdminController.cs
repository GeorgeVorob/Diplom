using DiplomASP.Models;
using DiplomASP.Models.ViewModels;
using DiplomASP.Models.ViewModels.PartialViewModels;
using DiplomCore.Models;
using DiplomCore.Models.CategoriesModels;
using DiplomCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiplomASP.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataProviderService _data;

        public AdminController(ILogger<HomeController> logger, DataProviderService data)
        {
            _logger = logger;
            _data = data;
        }

        public IActionResult Index(BootstrapAlertClass? result)
        {
            AdminModel model = new AdminModel();

            if (result != null)
            {
                if (result == BootstrapAlertClass.success)
                    model.resultModel = new ActionResultPartialViewModel("Статус заказа изменен", (BootstrapAlertClass)result);
                if (result == BootstrapAlertClass.danger)
                    model.resultModel = new ActionResultPartialViewModel("Что-то пошло не так", (BootstrapAlertClass)result);
            }
            model.categories = _data.GetCategories();
            model.orders = _data.GetOrders();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddProduct(int categoryId)
        {
            Product a = _data.GetProducts(p => p.CategoryID == categoryId, null, null, 1).FirstOrDefault();
            ViewData["RequestCategory"] = categoryId.ToString();
            return View(a);
        }
        [HttpPost]
        public IActionResult AddProduct(Dictionary<string, string> properties, string RequestCategory) //1000-7
        {
            Dictionary<string, object> cringe = new Dictionary<string, object>();//TODO: переосмыслить этот ужас попытки сделать из C# не строготипизированный язык
            foreach (var p in properties)
            {
                cringe.Add(p.Key, p.Value);
            } //Перебивка словаря под обобщенный тип

            int categoryInt = Int32.Parse(RequestCategory);

            Type addingType = _data.GetProducts(p => p.CategoryID == categoryInt, null, null, 1).First().GetType(); //Достаем тип, с которым работаем

            //var ProductToadd = cringe.ToObject<object>();

            MethodInfo method = typeof(ObjectExtensions).GetMethod(nameof(ObjectExtensions.ToObjectStatic));
            MethodInfo generic = method.MakeGenericMethod(addingType); //Конструируем обобщенный метод перебивки словая в объект с addingType в роли типа
            var ProductToadd = generic.Invoke(null, new object[] { cringe });

            method = typeof(DataProviderService).GetMethod(nameof(DataProviderService.AddProduct));
            generic = method.MakeGenericMethod(addingType); //Конструируем метод для датапровайдера о добавлении товара в dbset нужного типа
            generic.Invoke(_data, new object[] { ProductToadd });

            var c = Request;
            Product a = new CPU();
            return View(a);
        }

        public IActionResult ChangeStatus(OrderStatus status, int orderId)
        {
            if (_data.EditOrder(orderId, null, null, null, status))
                return RedirectToAction("Index", "Admin", new { result = BootstrapAlertClass.success }); //Переименовать класс, бутстрапа нет
            else
                return RedirectToAction("Index", "Admin", new { result = BootstrapAlertClass.danger });
        }
    }
}