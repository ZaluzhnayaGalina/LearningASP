using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebStore.Infrastructure.Implementations;
using WebStore.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.DomainEntities.Entities;

namespace WebStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IEmployeesData, InMemoryEmployeeData>();
            //  services.AddSingleton<IProductData, InMemoryProductData>();
            services.AddScoped<IProductData, SqlProductData>();
            services.AddScoped<ICartService, CookieCartService>();
            services.AddScoped<IOrderService, SqlOrderService>();
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<WebStoreContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequiredLength = 3;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;

                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                opt.Lockout.MaxFailedAccessAttempts = 10;
                opt.Lockout.AllowedForNewUsers = true;

                //opt.User.RequireUniqueEmail = true; // hack!!!
            });
            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.HttpOnly = true;
                opt.Cookie.Expiration = TimeSpan.FromDays(150);
                opt.LoginPath = "/Account/Login";
                opt.LogoutPath = "/Account/Logout";
                opt.AccessDeniedPath = "/Account/AccessDenied";
                opt.SlidingExpiration = true; 
            });
            services.AddDbContext<WebStoreContext>(
                opt=>opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes => routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}"
                ));
        }
    }
}
