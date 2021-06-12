using System;
using DiplomCore;
using DiplomCore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DiplomASP.Areas.Identity.IdentityHostingStartup))]
namespace DiplomASP.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Context>(options => { }); //TODO: ВАЖНО! передавать строку подключения нормально

                services.AddDefaultIdentity<User>(options => { })
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<Context>();
            });
        }
    }
}