using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {

                var errors = new List<KeyValuePair<string, ModelErrorCollection>>();
                context.ModelState.Keys.ToList<string>().ForEach(key =>
                {
                    var error = context.ModelState[key];
                    errors.Add(new KeyValuePair<string, ModelErrorCollection>(key, error.Errors));
                });

                var errorResponse = new
                {
                    Message = "Bad Request",
                    Errors = errors
                };

                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
