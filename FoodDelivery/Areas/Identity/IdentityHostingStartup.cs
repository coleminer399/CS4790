using System;
using FoodDelivery.Areas.Identity.Data;
using FoodDelivery.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FoodDelivery.Areas.Identity.IdentityHostingStartup))]
namespace FoodDelivery.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FoodDeliveryContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FoodDeliveryContextConnection")));

                services.AddDefaultIdentity<FoodDeliveryUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<FoodDeliveryContext>();
            });
        }
    }
}