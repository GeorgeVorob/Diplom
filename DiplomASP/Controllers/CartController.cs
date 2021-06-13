using DiplomASP.Models.ViewModels;
using DiplomASP.Models.ViewModels.PartialViewModels;
using DiplomCore.Models;
using DiplomCore.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        public IActionResult Index(BootstrapAlertClass? result)
        {
            if (!(Request.Cookies.ContainsKey("orderedProductsCookie")) && (result == null))
                return View(new CartModel { IsLoggedIn = false });

            var model = new CartModel();
            if (result != null)
            {
                if (result == BootstrapAlertClass.success)
                    model.resultModel = new ActionResultPartialViewModel("Заказ успешно оформлен", (BootstrapAlertClass)result);
                if (result == BootstrapAlertClass.danger)
                    model.resultModel = new ActionResultPartialViewModel("Что-то пошло не так", (BootstrapAlertClass)result);
            }
            if (Request.Cookies["orderedProductsCookie"] != null){
                Dictionary<int, int> orderedProducts;
                orderedProducts = JsonSerializer.Deserialize<Dictionary<int, int>>(Request.Cookies["orderedProductsCookie"]);

                foreach (var prod in orderedProducts)
                {
                    var product = _data.GetProducts(p => p.ID == prod.Key, null, null, 1).FirstOrDefault(); //TODO: попытаться переделать, тут по запросу в базу на товар
                    model.Products.Add((product, prod.Value));
                }
            }

            model.IsLoggedIn = User.Identity.IsAuthenticated;
            return View(model);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            Dictionary<int, int> orderedProductsCookie;
            if (Request.Cookies.ContainsKey("orderedProductsCookie"))
            {
                orderedProductsCookie = JsonSerializer.Deserialize<Dictionary<int, int>>(Request.Cookies["orderedProductsCookie"]); //TODO: вынести список и его тип в отдельный класс, то же самое в других методах

                ActionResultPartialViewModel result;
                if (orderedProductsCookie.ContainsKey(productId))
                    result = new ActionResultPartialViewModel("Продукт уже был добавлен в корзину, количество обновлено.", BootstrapAlertClass.warning);
                else
                    result = new ActionResultPartialViewModel("Добавлено в корзину", BootstrapAlertClass.success);

                orderedProductsCookie[productId] = quantity;

                Response.Cookies.Append("orderedProductsCookie", JsonSerializer.Serialize(orderedProductsCookie));
                return PartialView("_ActionResultPartial", result);
            }
            else
            {
                orderedProductsCookie = new Dictionary<int, int>();
                orderedProductsCookie.Add(productId, quantity);
                Response.Cookies.Append("orderedProductsCookie", JsonSerializer.Serialize(orderedProductsCookie));

                return PartialView("_ActionResultPartial", new ActionResultPartialViewModel("Добавлено в корзину", BootstrapAlertClass.success)); //TODO: разобраться с AJAX
            }
        }

        [HttpGet]
        public IActionResult RemoveFromCart(int productId)//TODO: упростить методы для изменения корзины, много одинакового кода
        {
            Dictionary<int, int> orderedProductsCookie;
            if (Request.Cookies.ContainsKey("orderedProductsCookie"))
            {
                orderedProductsCookie = JsonSerializer.Deserialize<Dictionary<int, int>>(Request.Cookies["orderedProductsCookie"]);
                orderedProductsCookie.Remove(productId);

                Response.Cookies.Delete("orderedProductsCookie");
                Response.Cookies.Append("orderedProductsCookie", JsonSerializer.Serialize(orderedProductsCookie));

                return RedirectToAction("Index", "Cart"); ; //TODO: по хорошему эти методы вообще не должны возвращать вьюху, а просто код ответа. Подумать о том как ещё тянуть вьюху.
            }
            return PartialView("_ActionResultPartial", new ActionResultPartialViewModel("Данного товара уже нет в корзине!", BootstrapAlertClass.warning));
        }

        [HttpPost]
        public IActionResult CreateOrder(List<int> id, List<int> quantity, string email, string phone, string shippingAddress)//TODO: переработать первые два параметра в один
        {
            Order order = new Order(email, shippingAddress, phone, OrderStatus.pending);
            List<(int, int)> products = new List<(int, int)>();

            for (int i = 0; i < id.Count; i++)
            {
                products.Add((id[i], quantity[i]));
            }

            if (_data.CreateOrderWithProducts(order, products))
            {
                Response.Cookies.Delete("orderedProductsCookie");
                return RedirectToAction("Index", "Cart", new { result = BootstrapAlertClass.success });
            }
            else
                return RedirectToAction("Index", "Cart", new { result = BootstrapAlertClass.danger });

        }

        //[HttpPost]
        //public IActionResult ChangeQuantity(int productId, int quantity) 
        //{
        //    Dictionary<int, int> orderedProductsCookie;
        //    if (Request.Cookies.ContainsKey("orderedProductsCookie"))
        //    {
        //        orderedProductsCookie = JsonSerializer.Deserialize<Dictionary<int, int>>(Request.Cookies["orderedProductsCookie"]);
        //        if (orderedProductsCookie.ContainsKey(productId))
        //        {
        //            orderedProductsCookie[productId] = quantity;
        //            Response.Cookies.Append("orderedProductsCookie", JsonSerializer.Serialize(orderedProductsCookie));
        //            return PartialView("_ActionResultPartial", new ActionResultPartialViewModel("Значение изменено", BootstrapAlertClass.success));
        //        }
        //    }
        //    return PartialView("_ActionResultPartial", new ActionResultPartialViewModel("Что-то пошло не так", BootstrapAlertClass.danger));
        //}
    }
}
