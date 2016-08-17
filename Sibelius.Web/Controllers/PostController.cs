using Sibelius.Web.Behavior;
using Sibelius.Web.Common;
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
            ViewBag.Title = "Posts";
            ViewBag.Controller = "PostsInternal";
            ViewBag.Action = "Index";
            ViewBag.RouteValues = null;
            return View();
        }

        public ActionResult Section(string name, int page = 1)
        {
            ViewBag.Title = "Posts";
            ViewBag.Controller = "PostsInternal";
            ViewBag.Action = "Section";
            ViewBag.RouteValues = new object[] { name, page };
            return View("Index");
        }

        public ActionResult Show(string id)
        {
            var post = postBehavior.GetById(id);
            PostsMetadata.ForPost(ViewBag, post);

            ViewBag.Post = post;
            return View("Index");
        }
    }
}