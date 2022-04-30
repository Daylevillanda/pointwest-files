using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Diagnostics;

namespace _01.SessionLogin.Filters
{
   
    public class SessionTimeoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("username") == null)
            {
                filterContext.Result = new RedirectResult("~/Account");
                return;
            }
            string path = filterContext.HttpContext.Request.Path;
            base.OnActionExecuting(filterContext);
        }
    }
   
}
