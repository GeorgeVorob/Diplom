using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using DiplomCore.Models;
using DiplomCore.Models.CategoriesModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DiplomCore
{
    public class DbInitializer
    {
        public async static Task<int> Initialize(Context context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            try
            {
                IdentityResult result;
                context.Database.EnsureCreated();

                if (context.Products.Any())
                {
                    return 0;   // DB has been seeded
                }

                var Categories = new Category[]
                {
                new Category { CategoryName="Видеокарты"},
                new Category { CategoryName="Процессоры"},
                new Category { CategoryName="Ноутбуки"},
                };

                foreach (var s in Categories)
                {
                    context.Categories.Add(s);
                }
                context.SaveChanges();

                var GPUS = new GraphicsCard[]
                {
                    new GraphicsCard
                    {
                        memory = 1000,
                        clock= 1600,
                        Name="MSI nVidia GeForce GT 710 , GT 710 1GD3H LP",
                        quantity = 10,
                        Price=3190,
                        PostDate = DateTime.Now,
                        Category = Categories.First(),
                        ImageThumbnail = Convert.ToBase64String (File.ReadAllBytes(@"wwwroot\TestImages\1.jpg")),
                        Images = context.Images.ToList()
                    },
                    new GraphicsCard
                    {
                        memory = 4000,
                        clock= 7000,
                        Name="PALIT nVidia GeForce GTX 1050TI , PA-GTX1050Ti StormX 4G",
                        quantity = 10,
                        Price=21590,
                        PostDate = DateTime.Now,
                        Category = Categories.First(),
                        ImageThumbnail = Convert.ToBase64String (File.ReadAllBytes(@"wwwroot\TestImages\3.jpg")),
                        Images = context.Images.ToList()
                    },
                    new GraphicsCard
                    {
                        memory = 1000,
                        clock= 5012,
                        Name="ASUS NVIDIA GeForce GT 710 , GT710-SL-1GD5",
                        quantity = 10,
                        Price=3490,
                        PostDate = DateTime.Now,
                        Category = Categories.First(),
                        ImageThumbnail = Convert.ToBase64String (File.ReadAllBytes(@"wwwroot\TestImages\4.jpg")),
                        Images = context.Images.ToList(),
                        Discount = 10 
                    },
                    new GraphicsCard
                    {
                        memory = 2000,
                        clock= 2100,
                        Name="MSI nVidia GeForce GT 1030 , GT 1030 AERO ITX 2GD4 OC",
                        quantity = 10,
                        Price=7390,
                        PostDate = DateTime.Now,
                        Category = Categories.First(),
                        ImageThumbnail = Convert.ToBase64String (File.ReadAllBytes(@"wwwroot\TestImages\5.jpg")),
                        Images = context.Images.ToList()
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
                    Name = "AMD Ryzen 5 2600, SocketAM4, OEM",
                    quantity = 10,
                    Price = 11590,
                    PostDate = DateTime.Now,
                    Category = Categories[1],
                    cores = 6,
                    clock = 3400,
                    ImageThumbnail = Convert.ToBase64String (File.ReadAllBytes(@"wwwroot\TestImages\2.jpg")),
                }
                };
                Notebook a = new Notebook
                {
                    Images = context.Images.ToList(),
                    Category = Categories[2],
                    Name = "DIGMA EVE 14 C411, 14.1 IPS",
                    ImageThumbnail = Convert.ToBase64String(File.ReadAllBytes(@"wwwroot\TestImages\222.jpg"))
                };
                context.Notebooks.Add(a);

                foreach (var i in prots)
                {
                    context.CPUs.Add(i);
                }

                context.SaveChanges();

                var ImageContens = new ImageContent[]
                {
                    new ImageContent{ content = File.ReadAllBytes(@"wwwroot\TestImages\carousel\1s.jpg")},
                    new ImageContent{ content = File.ReadAllBytes(@"wwwroot\TestImages\carousel\2b.jpg")}
                };
                foreach (var ic in ImageContens)
                {
                    context.ImageContents.Add(ic);
                }
                context.SaveChanges();

                var Images = new Image[]
                {
                    new Image {ImageContentID = context.ImageContents.ToList()[0].ImageContentID , ProductID = context.GraphicsCards.FirstOrDefault().ID},
                    new Image {ImageContentID = context.ImageContents.ToList()[1].ImageContentID , ProductID = context.GraphicsCards.FirstOrDefault().ID},
                };

                foreach (var I in Images)
                {
                    context.Images.Add(I);
                }

                context.SaveChanges();

                var Roles = new IdentityRole[]
                {
                    new IdentityRole("admin"),
                    new IdentityRole("user"),
                };

                foreach (var r in Roles)
                {
                    result = await roleManager.CreateAsync(r);
                }
                context.SaveChanges();

                var Users = new User[]
                {
                    new User{ UserName =  "loginFromUser@gmail.com", Email = "emailFromUser@gmail.com"},
                    new User{ UserName =  "loginFromAdmin@gmail.com", Email = "emailFromAdmin@gmail.com"}
                };
                result = await userManager.CreateAsync(Users[0], "PasswodFromUser!1");
                result = await userManager.AddToRoleAsync(userManager.FindByEmailAsync("emailFromUser@gmail.com").Result, "user");
                result = await userManager.CreateAsync(Users[1], "PasswodFromAdmin!1");
                result = await userManager.AddToRoleAsync(userManager.FindByEmailAsync("emailFromAdmin@gmail.com").Result, "admin");

                context.SaveChanges();

                //            var people = new User[]
                //{
                //            new User {
                //                UsLogin = "loginFromUser",
                //                UsPassword = "PasswodFromUser",
                //                FirstName = "Ivan",
                //                RegDate = DateTime.Now,
                //                Role = Role.user
                //            },
                //            new User {
                //                UsLogin = "loginFromAdmin",
                //                UsPassword = "PasswodFromAdmin",
                //                FirstName = "DIO",
                //                RegDate = DateTime.Now,
                //                Role = Role.admin
                //            }
                //};

                //            foreach (var u in people)
                //            {
                //                context.Users.Add(u);
                //            }

                var sells = new Order[]
                {
                new Order
                {
                    shippingAdress = "tuda",
                    phone = "88005553535",
                    email = "testmail@gmail.com",
                    status = OrderStatus.pending
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
                return 1;
            }
            catch (Exception e)
            {

                Console.WriteLine("a");
                return 0;
            }
        }

    }
}
