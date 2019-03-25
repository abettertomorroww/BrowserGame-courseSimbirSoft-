using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using BrowserGame_courseSimbirSoft_.Models;
using BrowserGame_courseSimbirSoft_.Views.Error;
using Microsoft.AspNetCore.Authentication.Cookies;
using BrowserGame_courseSimbirSoft_.Services;
using BrowserGame_courseSimbirSoft_.Services.Implementation;
using DataLogicLayer.Data;
using DataLogicLayer.Models;
using BusinessLogicLayer.Data;


namespace BrowserGame_courseSimbirSoft_
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication()
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                    facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                });


            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc();
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(connection, b => b.MigrationsAssembly("DataLogicLayer")));

            services.AddScoped<ICharacterServices, CharacterServices>();
            services.AddScoped<IUserService, UserService>();
            services.AddDataLibraryCollection(Configuration);
            services.AddBusinessLibraryCollection();

            services.AddDefaultIdentity<UserData>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "log//logger_" + DateTime.Today.ToShortDateString() + ".txt"));
            //var logger = loggerFactory.CreateLogger("FileLogger");
            app.UseExceptionHandler("/Error");
            app.UseStatusCodePagesWithRedirects("Home/Error/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}