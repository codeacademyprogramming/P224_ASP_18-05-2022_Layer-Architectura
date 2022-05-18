using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shop.Core.Repositories;
using Shop.Data;
using Shop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shop.Service.Profiles;
using FluentValidation.AspNetCore;
using Shop.Service.DTOs.CategoryDtos;
using Shop.Service.Interfaces;
using Shop.Service.Implementations;

namespace Shop.Api
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
            services.AddControllers()
                .AddNewtonsoftJson(cfg => cfg.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddFluentValidation(cfg=> 
                {
                    cfg.RegisterValidatorsFromAssemblyContaining<CategoryPostDtoValidator>();
                });
            services.AddDbContext<ShopDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddAutoMapper(options =>
            {
                options.AddProfile(new MapProfile());
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();


            services.AddScoped<ICategoryService, CategoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
