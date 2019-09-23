using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Inventario.Data;
using Inventario.Models;
using Inventario.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

namespace Inventario
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc(option => {
                option.CacheProfiles.Add("Default",
                    new CacheProfile()
                    {
                        Duration = 06,
                        Location = ResponseCacheLocation.Any
                    }
                    );
                option.CacheProfiles.Add("Never", new CacheProfile()
                {
                    Duration = 06,
                    Location = ResponseCacheLocation.None,
                    NoStore = true
            }
                );
            }).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseIdentity();
            var cultures = new List<CultureInfo>();
            cultures.Add(new CultureInfo("en-US"));
            cultures.Add(new CultureInfo("de-DE"));
            cultures.Add(new CultureInfo("es-PE"));
            cultures.Add(new CultureInfo("fr-FR"));
            var requestLocation = new RequestLocalizationOptions
            {
                SupportedCultures = cultures,
                SupportedUICultures = cultures
            };
            app.UseRequestLocalization(requestLocation);

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DPrincipal",
                    template: "DPrincipal",
                    defaults: new { Controller="Producto", action="Index" }
                    );
                routes.MapRoute(
                    name: "DSecundario",
                    template: "DSecundario",
                    defaults: new { Controller = "Categoria", action = "Index" }
                    );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
