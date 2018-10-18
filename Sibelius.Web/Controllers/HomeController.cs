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
        QuestionBehavior questionBehavior = new QuestionBehavior();
        CollaboratorBehavior collaboratorBehavior = new CollaboratorBehavior();

        public ActionResult Index()
        {
            var result = new MainpageVM()
            {
                Articles = articleBehavior.GetVisible().ToList(),
                Posts = postBehavior.GetAll(1).Take(3).ToList(),
                Questions = questionBehavior.GetAll(1).ToList()
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

        public JsonResult LegalAccept()
        {
            Session["legal"] = true;
            return Json("ok");
        }
               
        public ActionResult About()
        {
            return View(collaboratorBehavior.GetAll().ToList());
        } 
    }
}