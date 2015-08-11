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
            var posts = postBehavior.GetAll(page);
            ViewBag.Sections = postSectionBehavior.GetAll();
            ViewBag.Pages = postBehavior.GetPages();
            ViewBag.CurPage = page;
            return View(posts);
        }

        public ActionResult Show(string id)
        {
            var post = postBehavior.GetById(id);
            ViewBag.Sections = postSectionBehavior.GetAll();
            return View(post);
        }
        

        public ActionResult Section(string name, int page=1)
        {
            var post = postBehavior.GetBySection(name, page);
            ViewBag.Sections = postSectionBehavior.GetAll();
            ViewBag.Pages = postBehavior.GetPages(name);
            ViewBag.CurPage = page;
            ViewBag.Section = name;
            return View("Index", post);
        }
    }
}