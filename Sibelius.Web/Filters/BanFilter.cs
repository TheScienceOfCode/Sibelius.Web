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
            // Start
            if (context.HttpContext.Session["pubadv"] == null)
            {
                context.HttpContext.Session["pubadv"] = 0;

            }

            // Do not Filter?
            if (context.ActionDescriptor.GetCustomAttributes(typeof(SkipBanFilter), false).Any())
            {
                return;
            }
            // No pub?
            else if ((int)context.HttpContext.Session["pubadv"] > 0)
            {
                context.HttpContext.Session["ban"] = true;
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Home" },
                        { "action", "Index" }
                    });
            }
            else
            {
                if (context.HttpContext.Request.Url.ToString().ToUpper().Contains("UNBAN"))
                {
                    if (context.HttpContext.Session["burl"] != null)
                    {
                        context.HttpContext.Response.Redirect(((Uri)context.HttpContext.Session["burl"]).AbsolutePath);
                    }
                }
                else
                {
                    context.HttpContext.Session["burl"] = context.HttpContext.Request.Url;
                }
            }
        }
    }
}