using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StarWars.DataAccess.Infrastructure;
using StarWars.Services.Interfaces;

namespace StarWars.API
{
    public class Startup
    {
        private readonly IConfiguration _configurationService;

        public Startup(IConfiguration configurationService)
        {
            _configurationService = configurationService;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("AllowAll");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "StarWars API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StarWarsContext>(options =>
            {
                string connectionString = _configurationService.GetConnectionString("StarWarsContext");

                options.UseSqlServer(connectionString);
            });

            services.AddControllers()
                    .AddNewtonsoftJson();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "StarWars API", Version = "v1" });
            });

            services.AddCors(options => options.AddPolicy("AllowAll", p => p
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));

            services.Scan(scan =>
                scan.FromAssemblyOf<ICharactersService>()
                    .AddClasses()
                    .AsMatchingInterface()
            );
        }
    }
}