using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Settings;
using Microsoft.AspNetCore.Http;

namespace _01.FirstWebApi
{
    public class Startup
    {


        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsDevelopment())
            {
                Console.WriteLine(_env.EnvironmentName);
            }
            else if (_env.IsStaging())
            {
                Console.WriteLine(_env.EnvironmentName);
            }
            else if (_env.IsEnvironment("Other Environment"))
            {
                Console.WriteLine(_env.EnvironmentName);
            }
            else
            {
                Console.WriteLine("Not dev or staging");
            }


            var emailSettings = this.Configuration.GetSection("EmailSettings").Get<EmailSettings>();
            services.Add(new ServiceDescriptor(typeof(EmailSettings), emailSettings));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FirstWebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FirstWebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello From ASP.NET Core Web API");
                });
                endpoints.MapGet("/Resource1", async context =>
                {
                    await context.Response.WriteAsync("Hello From ASP.NET Core Web API Resource1");
                });
            });
        }
    }
}
