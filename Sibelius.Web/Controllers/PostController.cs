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

        public ActionResult Index()
        {
            var posts = postBehavior.GetAll().OrderByDescending(p => p.Date);
            ViewBag.Sections = postSectionBehavior.GetAll();
            return View(posts);
        }

        public ActionResult Show(string id)
        {
            var post = postBehavior.GetById(id);
            ViewBag.Sections = postSectionBehavior.GetAll();
            return View(post);
        }

        public ActionResult Section(string name)
        {
            var post = postBehavior.GetBySection(name);
            ViewBag.Sections = postSectionBehavior.GetAll();
            return View("Index", post);
        }
    }
}