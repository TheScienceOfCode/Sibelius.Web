using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sibelius.Web.Filters
{
    public class SkipBanFilter : Attribute
    {
    }
    

    public class BanFilter : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session["pubadv"] == null)
                context.HttpContext.Session["pubadv"] = 0;

            if (context.ActionDescriptor.GetCustomAttributes(typeof(SkipBanFilter), false).Any())
            {
                return;
            }

            if ((int)context.HttpContext.Session["pubadv"] > 0)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Home" },
                        { "action", "Index" }
                    });
            }
        }
    }
}