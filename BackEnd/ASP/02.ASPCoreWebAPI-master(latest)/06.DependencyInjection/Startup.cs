using ApiWebDemo.Services;
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

namespace _06.DependencyInjection
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
            services.AddSingleton<IPaymentService, CreditCardPaymentService>();

            services.AddSingleton<PaypalPaymentProcessorService>();
            services.AddSingleton<GcashPaymentProcessorService>();
            services.AddSingleton<PaymayaPaymentProcessorService>();
            services.AddSingleton<PaymentProcessorServiceResolver>(serviceProvider => serviceTypeName =>
            {
                switch (serviceTypeName)
                {
                    case PaymentProcessorTypes.PaypalPaymentProcessor:
                        return serviceProvider.GetService<PaypalPaymentProcessorService>();
                    case PaymentProcessorTypes.GcashPaymentProcessor:
                        return serviceProvider.GetService<GcashPaymentProcessorService>();
                    case PaymentProcessorTypes.PaymayaPaymentProcessor:
                        return serviceProvider.GetService<PaymayaPaymentProcessorService>();
                    default:
                        return null;
                }
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
