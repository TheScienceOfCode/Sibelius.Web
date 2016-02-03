using Sibelius.Web.Behavior;
using Sibelius.Web.Filters;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sibelius.Web.Controllers
{
    public class HomeController : Controller
    {
        ArticleBehavior articleBehavior = new ArticleBehavior();
        CourseBehavior courseBehavior = new CourseBehavior();
        PostBehavior postBehavior = new PostBehavior();

        [SkipBanFilter]
        public ActionResult Index()
        {
            var result = new PortraitVM()
            {
                Articles = articleBehavior.GetVisible().ToList(),
                Posts = postBehavior.GetAll(1).ToList()
            };
            return View(result);
        }
        
        public ActionResult Unban()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Privacy()
        {
            return View();
        }        

        [SkipBanFilter]
        public JsonResult LegalAccept()
        {
            Session["legal"] = true;
            return Json("ok");
        }

        [HttpPost]
        [SkipBanFilter]
        public JsonResult PubAdvAccept(bool value)
        {
            if (value)
            {
                Session["pubadv"] = (int)Session["pubadv"] + 1;
            }
            else
            {
                Session["pubadv"] = 0;
            }
            return Json("ok");
        }      
        
        public ActionResult About()
        {
            return View();
        } 
    }
}