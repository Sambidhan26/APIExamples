using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIExamples.Services
{
    public class IsAuthorized : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(context.HttpContext.Request.Headers["scope"]))
            {
                context.Result = new UnauthorizedResult();
            }
            if (!ValidateScope(context.HttpContext.Request.Headers["scope"],context.RouteData.Values["Controller"].ToString()))
            {
                context.Result = new UnauthorizedResult();
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //logging action
        }

        private bool ValidateScope(string scope, string controller)
        {
            if (scope == "A1" && controller == "Item")
            {
                return true;
            }
            else if (scope == "A2" && (controller == "Item" || controller == "Order"))
            {
                return true;
            }
            else if(scope == "A3" && (controller == "Item" || controller == "Order" || controller == "User"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
