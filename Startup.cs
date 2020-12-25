using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DBModels;
using App.Helpers;
using App.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace App
{
    public class Startup
    {
        public const string CookieScheme = "YourSchemeName";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme) // Sets the default scheme to cookies
               .AddCookie(options =>
               {
                   options.AccessDeniedPath = "/Login/AccessDenied";
                   options.LoginPath = "/Login/Index";
                   options.Cookie.Name = "AppCookie";
               });

            // Example of how to customize a particular instance of cookie options and
            // is able to also use other services.
            services.AddSingleton<IConfigureOptions<CookieAuthenticationOptions>, ConfigureAppCookie>();
            services.AddDbContext<dbAppContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<db2AppContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("Db2Connection")));
            services.AddControllersWithViews();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ILDAPAuth, LDAPAuth>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
