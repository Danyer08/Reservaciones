using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProyectoReservaciones.Areas.Identity.Data;
using ProyectoReservaciones.Models;

[assembly: HostingStartup(typeof(ProyectoReservaciones.Areas.Identity.IdentityHostingStartup))]
namespace ProyectoReservaciones.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ProyectoReservacionesIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ProyectoReservacionesIdentityContextConnection")));

                services.AddDefaultIdentity<ProyectoReservacionesUser>()
                    .AddEntityFrameworkStores<ProyectoReservacionesIdentityContext>();
            });
        }
    }
}