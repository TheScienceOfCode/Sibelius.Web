using Sibelius.Web.Behavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sibelius.Web.Controllers
{
    public class PostsController : Controller
    {
        PostBehavior postBehavior = new PostBehavior();
        PostSectionBehavior postSectionBehavior = new PostSectionBehavior();

        public ActionResult Index(int page=1)
        {
            ViewBag.CallbackUrl = Url.Content("~/Posts/Index?page=" + page);
            ViewBag.Title = "Posts";
            ViewBag.Controller = "PostsInternal";
            ViewBag.Action = "Index";
            ViewBag.RouteValues = null;
            return View();
        }

        public ActionResult Section(string name, int page = 1)
        {
            ViewBag.CallbackUrl = Url.Content("~/Posts/Section?name=" + name + "&page=" + page);
            ViewBag.Title = "Posts";
            ViewBag.Controller = "PostsInternal";
            ViewBag.Action = "Section";
            ViewBag.RouteValues = new object[] { name, page };
            return View("Index");
        }

        public ActionResult Show(string id)
        {
            ViewBag.CallbackUrl = Url.Content("~/Posts/Show/" + id);
            ViewBag.Title = "Posts";
            ViewBag.Controller = "PostsInternal";
            ViewBag.Action = "Show";
            ViewBag.RouteValues = new object[] { id };
            return View("Index");
        }
    }
}