using Sibelius.Web.Behavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sibelius.Web.Controllers
{
    public class ArticlesController : Controller
    {
        ArticleBehavior articleBehavior = new ArticleBehavior();

        public ActionResult Show(string id)
        {
            var article = articleBehavior.GetById(id);
            return View(article);
        }
    }
}