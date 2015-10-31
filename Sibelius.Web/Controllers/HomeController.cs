using Sibelius.Web.Behavior;
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

        public ActionResult Index()
        {
            var result = new PortraitVM()
            {
                Articles = articleBehavior.GetVisible().ToList(),
                Posts = postBehavior.GetAll(1).ToList()
            }; 
            return View(result);
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public JsonResult LegalAccept()
        {
            Session["legal"] = true;
            return Json("ok");
        }

        [HttpPost]
        public JsonResult PubAdvAccept(bool value)
        {
            Session["pubadv"] = value;
            return Json("ok");
        }      
        
        public ActionResult About()
        {
            return View();
        } 
    }
}