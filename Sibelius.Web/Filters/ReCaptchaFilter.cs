using Sibelius.Web.Data;
using Sibelius.Web.Integration;
using System.Web.Mvc;

namespace Sibelius.Web.Filters
{
    public class ReCaptchaFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string captchaResponse = filterContext.RequestContext.HttpContext.Request[ReCaptcha.RequestParam];
            if (captchaResponse == null)
            {
                filterContext.ActionParameters[ReCaptcha.CaptchaParam] = false;
                return;
            }
            
            filterContext.ActionParameters[ReCaptcha.CaptchaParam] = ReCaptcha.Validate(captchaResponse);            
        }               
    }
}