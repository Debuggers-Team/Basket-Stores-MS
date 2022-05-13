

using Basket_Store_MS.Data;

using Basket_Store_MS.Models.Interface;
using Basket_Store_MS.Models.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket_Store_MS
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BasketStoreDBContext>(options => {
                // Our DATABASE_URL from js days
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });
            services.AddTransient<ICart, CartService>();
            services.AddTransient<IPaymentType,PaymentTypeServices>();
            services.AddTransient<IFeedBack, FeedBackServices>();
            services.AddTransient<IProuduct, ProuductServices>();
            services.AddTransient<ICategory, CategoryServiece>();
            services.AddControllers()
                   .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllers();
            //configure a new service dependency
            services.AddSwaggerGen(options =>
            {
                // Make sure get the "using Statement"
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Basket Store MS",
                    Version = "v1",
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseSwagger(options => {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Basket Store MS");
                options.RoutePrefix = "";
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
           
        }
    }
}

