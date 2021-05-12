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
                var itemsTemp = db.Products.Include(i => i.Orders).Include(i => i.Images);

                if (whereArgs != null)
                    itemsTemp.Where(whereArgs);
                if (orderArgs != null)
                    itemsTemp.OrderBy(orderArgs);

                return itemsTemp.Take(amount).ToList();
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
