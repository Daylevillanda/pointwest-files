using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ApiWebDemo.Middlewares;

namespace _03.Middleware
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

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseUrlLogger();

            // 2. The Use Extension Method in ASP.NET Core Application allows us to add a new middleware component which may call
            // the next middleware component in the request processing pipeline. The Use extension method adds a middleware
            // delegate defined in-line to the application’s request pipeline.
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Getting Response from First Use Middleware \n");
                await next();
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Use Middleware1 Incoming Request \n");
                await next();
                await context.Response.WriteAsync("Use Middleware1 Outgoing Response \n");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Use Middleware2 Incoming Request \n");
                await next();
                await context.Response.WriteAsync("Use Middleware2 Outgoing Response \n");
            });

            // 3
            app.Map("/m1", HandleMapOne);
            app.Map("/m2", appMap =>
            {
                appMap.Run(async context =>
                {
                    await context.Response.WriteAsync("Hello from 2nd app.Map()");
                });
            });


            // 1. The Run method in ASP.NET Core Application is used to complete the Middleware Execution.
            // That means the Run extension method allows us to add the terminating middleware component.
            // Terminating middleware means the middleware which will not call the next middleware components in the request processing pipeline.
            //
            //  app: The Microsoft.AspNetCore.Builder.IApplicationBuilder instance.
            //  handler: A delegate that handles the request.
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Response from First Run Middleware");
            });
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Response from Second Run Middleware");
            });

            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            //This middleware is used to redirects HTTP requests to HTTPS.  
            app.UseHttpsRedirection();

            //This middleware is used to returns static files and short-circuits further request processing.   
            app.UseStaticFiles();

            //This middleware is used to route requests. 
            app.UseRouting();

            // Allow cross domain request
            app.UseCors();

            //This middleware is used to authorizes a user to access secure resources.  
            app.UseAuthorization();

            //This middleware is used to add  Api controller endpoints to the request pipeline.   
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void HandleMapOne(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from 1st app.Map()");
            });
        }
    }
}
