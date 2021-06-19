using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DiplomCore.Models;
using DiplomCore.Models.CategoriesModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DiplomCore.Services
{
    public class DataProviderService
    {
        private string connectionString;
        public DataProviderService(string dbConnStr)
        {
            connectionString = dbConnStr;
            //using (var db = new Context(connectionString)) //Вынесено в Program.cs после билда, теперь DI сервиса не генерит базу автоматически
            //    DbInitializer.Initialize(db);
        }

        public bool CreateOrderWithProducts(Order order, List<(int productID, int quantity)> products) //TODO перегрузку для полноценных типов товаров?
        {
            try
            {
                using (var db = new Context(connectionString))
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    foreach (var prod in products)
                    {
                        db.OrderedProducts.Add(new OrderedProduct
                        {
                            OrderID = order.ID,
                            ProductID = prod.productID,
                            Quantity = prod.quantity
                        });
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("a");
                return false;
                throw;
            }
        }
        public List<Category> GetCategories()
        {
            using (var db = new Context(connectionString))
            {
                return db.Categories.ToList();
            }
        }
        public List<Order> GetOrders()
        {
            using (var db = new Context(connectionString))
            {
                return db.Orders.OrderByDescending(o => o.CreateDate).ToList();
                db.Orders.AsNoTracking();
            }
        }
        public bool EditOrder(int orderId, string? email, string shippingAdress, string? phone, OrderStatus? status)
        {
            try
            {
                using (var db = new Context(connectionString))
                {
                    var orderToChange = db.Orders.Where(o => o.ID == orderId).First();
                    if (email != null)
                        orderToChange.email = email;
                    if (shippingAdress != null)
                        orderToChange.shippingAdress = shippingAdress;
                    if (phone != null)
                        orderToChange.phone = phone;
                    if (status != null)
                        orderToChange.status = (OrderStatus)status;
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
                throw;
            }
        }
        public List<Product> GetProducts(
            Expression<Func<Product, bool>> whereArgs,
            (Expression<Func<Product, object>> orderArg, bool isDescending)? orderArgs,
            string productNameLikeArg,
            int amount,
            int startFrom = 0
            )
        {
            using (var db = new Context(connectionString))
            {

                IQueryable<Product> query;
                query = db.Products.AsQueryable();

                if (whereArgs != null)
                    query = query.Where(whereArgs);
                if (productNameLikeArg != null)
                    query = query.Where(p => EF.Functions.Like(p.Name, $"%{productNameLikeArg}%"));
                if (orderArgs != null)
                    if (orderArgs.Value.isDescending == false)
                        query = query.OrderBy(orderArgs.Value.orderArg);
                    else
                        query = query.OrderByDescending(orderArgs.Value.orderArg);

                query = query.Include(i => i.Orders).Include(i => i.Images);
                var s = query.ToQueryString();
                return query.Skip(startFrom).Take(amount).ToList();
            }
        }
        public bool AddProduct<T>(object Product) where T : class
        {
            try
            {
                using (var db = new Context(connectionString))
                {
                    db.Set<T>().Add((T)Product);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
                throw;
            }
        }
        public Image GetImageById(int id)
        {
            using (var db = new Context(connectionString))
            {
                Image returnImg = db.Images.Include(i => i.ImageContent).Where(i => i.ImageID == id).SingleOrDefault();
                return returnImg;
            }
        }
    }
}
