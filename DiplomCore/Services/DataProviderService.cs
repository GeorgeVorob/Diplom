using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DiplomCore.Models;
using DiplomCore.Models.CategoriesModels;
using Microsoft.EntityFrameworkCore;

namespace DiplomCore.Services
{
    public class DataProviderService
    {
        private string connectionString;
        public DataProviderService(string dbConnStr)
        {
            connectionString = dbConnStr;
            using (var db = new Context(connectionString))
                DbInitializer.Initialize(db);
        }

        public List<Category> GetCategories()
        {
            using (var db = new Context(connectionString))
            {
                return db.Categories.ToList();
            }
        }
        public List<Product> GetProducts(Expression<Func<Product,bool>> whereArgs, Expression<Func<Product, object>> orderArgs, int amount)
        {
            using (var db = new Context(connectionString))
            {
                var itemsTemp = db.Products.Include(i => i.Orders);

                if (whereArgs != null)
                    itemsTemp.Where(whereArgs);
                if (orderArgs != null)
                    itemsTemp.OrderBy(orderArgs);

                var items = itemsTemp.Take(amount).ToList();
                return items;
            }
        }
        //public List<Product> GetProductsJoinOrders(Expression<Func<OrderedProduct, bool>> orderArgs, Expression<Func<Product, bool>> productArgs, int amount)
        //{
        //    using (var db = new Context(connectionString))
        //    {
        //        var orders = db.OrderedProducts.Where(orderArgs.Compile()).ToList();

        //        return db.Products.Join(
        //            orders,
        //            p => p.ID,
        //            o => o.ProductID,
        //            (p, o) => new Product
        //            {
        //                CategoryId = p.CategoryId,
        //                Name = p.Name,
        //                quantity = p.quantity,
        //                Price = p.Price,
        //                Discount = p.Discount
        //            }
        //            ).Where(productArgs.Compile()).Take(amount).ToList();
        //    }
        //}
    }
}
