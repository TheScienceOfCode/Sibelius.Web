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

        public ActionResult Index()
        {
            var result = new Dictionary<string, Article>();
            foreach (var article in articleBehavior.GetAll())
            {
                if (article.Portrait == string.Empty)
                    continue;
                result.Add(article.Portrait, article);

            }

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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}