using ComputerWebShopSPA.Database;
using ComputerWebShopSPA.Models.Data;
using ComputerWebShopSPA.Models.Repo;
using ComputerWebShopSPA.Models.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //------------------------- connection to database -----------------------------------------
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //------------------------- identity ---------------------------------------------------
            services.AddIdentity<IdentityAppUser, IdentityRole>()
                        .AddEntityFrameworkStores<AppDbContext>()
                        .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            //------------------------- services IoC ---------------------------------------------------
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IComputerService, ComputerService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();

            //------------------------- repo IoC -------------------------------------------------------
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IComputerRepo, ComputerRepo>();
            services.AddScoped<IShoppingCartRepo, ShoppingCartRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();

            //------------------------- CORS -----------------------------------------------------------
            services.AddCors(options =>
            {
                options.AddPolicy("ReactPolicy",
                    builder =>
                    {
                        builder.WithOrigins("*")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            //------------------------- Swagger -----------------------------------------------------------
            //services.AddSwaggerGen();

            //------------------------- Context and Session ---------------------------------------------
            services.AddHttpContextAccessor();
            services.AddSession();

            //services.AddControllersWithViews();
            services.AddMvc();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            //app.UseSwagger();

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Persons API V1");
            //});

            app.UseRouting();

            //Cors
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
