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
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                                                      .SelectMany(v => v.Errors)
                                                      .Select(v => v.ErrorMessage)
                                                      .ToList();

                var errorResponse = new
                {
                    Message = "Bad Request",
                    Errors = errors
                };

                context.Result = new BadRequestObjectResult(errorResponse);

                // or
                // context.Result = new JsonResult(responseObj)
                // {
                //    StatusCode = 400
                // };
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
