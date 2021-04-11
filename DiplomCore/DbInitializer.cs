using System;
using System.IO;
using System.Linq;
using DiplomCore.Models;
using DiplomCore.Models.CategoriesModels;

namespace DiplomCore
{
    public class DbInitializer
    {
        public static void Initialize(Context context)
        {
            try
            {
                context.Database.EnsureCreated();

                if (context.Products.Any())
                {
                    return;   // DB has been seeded
                }

                var Categories = new Category[]
                {
                new Category { CategoryName="Graphics Cards"},
                new Category { CategoryName="Processors"}
                };

                foreach (var s in Categories)
                {
                    context.Categories.Add(s);
                }
                context.SaveChanges();

                var GPUS = new GraphicsCard[]
                {
                new GraphicsCard {
                    memory = 1000,
                    clock= 1600,
                    Name="MSI nVidia GeForce GT 710 , GT 710 1GD3H LP, 1ГБ, DDR3, Low Profile, Ret",
                    quantity = 10,
                    Price=3190,
                    PostDate = DateTime.Now,
                    Category = Categories.First(),
                    Image = File.ReadAllBytes(@"wwwroot\TestImages\1.jpg")
                }
                };

                foreach (GraphicsCard i in GPUS)
                {
                    context.GraphicsCards.Add(i);
                }
                context.SaveChanges();

                var prots = new CPU[]
                {
                new CPU {
                    Name = "Процессор AMD Ryzen 5 2600, SocketAM4, OEM [yd2600bbm6iaf]",
                    quantity = 10,
                    Price = 11590,
                    PostDate = DateTime.Now,
                    Category = Categories[1],
                    cores = 6,
                    clock = 3400,
                    Image = File.ReadAllBytes(@"wwwroot\TestImages\2.PNG")
                }
                };

                foreach (var i in prots)
                {
                    context.CPUs.Add(i);
                }

                context.SaveChanges();

                var people = new User[]
    {
                new User {
                    Login = "loginFromUser",
                    Password = "PasswodFromUser",
                    FirstName = "Ivan",
                    RegDate = DateTime.Now,
                    Role = Role.user
                },
                new User {
                    Login = "loginFromAdmin",
                    Password = "PasswodFromAdmin",
                    FirstName = "DIO",
                    RegDate = DateTime.Now,
                    Role = Role.admin
                }
    };

                foreach (var u in people)
                {
                    context.Users.Add(u);
                }

                var sells = new Order[]
                {
                new Order
                {
                    shippingAdress = "tuda",
                    Phone = "88005553535",
                    Status = OrderStatus.done
                }
                };

                foreach (var s in sells)
                {
                    context.Orders.Add(s);
                }

                context.SaveChanges();

                var ordered = new OrderedProduct[]
                {
                new OrderedProduct
                {
                    OrderID = context.Orders.FirstOrDefault().ID,
                    ProductID = context.Products.FirstOrDefault().ID,
                    Quantity = 4
                }
                };

                foreach (var op in ordered)
                {
                    context.OrderedProducts.Add(op);
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("a");
            }
        }

    }
}
