using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebDemo.Middlewares
{
    public class LogURLMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<LogURLMiddleware> logger;
        public LogURLMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            this.logger = loggerFactory?.CreateLogger<LogURLMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }
        public async Task InvokeAsync(HttpContext context)
        {
            this.logger.LogInformation($"Request URL: {Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");
            
            //context.Response.WriteAsync("Response!");
            await this.next(context);
        }
    }

    public static class LogURLMiddlewareExtensions
    {
        public static IApplicationBuilder UseUrlLogger(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogURLMiddleware>();
        }
    }
}
