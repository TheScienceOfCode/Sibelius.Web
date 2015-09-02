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
            ViewBag.CallbackUrl = Url.Content("~/Posts");
            return View();
        }

        [HttpPost]
        public ActionResult Index(int page = 1)
        {
            var posts = postBehavior.GetAll(page);
            ViewBag.Pages = postBehavior.GetPages();
            ViewBag.CurPage = page;
            return PartialView("_PostsList", posts);
        }

        public ActionResult Show(string id)
        {
            var post = postBehavior.GetById(id);
            return View(post);
        }

        [HttpPost]
        public ActionResult Section(string name, int page = 1)
        {
            var post = postBehavior.GetBySection(name, page);
            ViewBag.Pages = postBehavior.GetPages(name);
            ViewBag.CurPage = page;
            ViewBag.Section = name;
            return PartialView("_PostsList", post);
        }
        

        [HttpPost]
        public ActionResult SectionsMenu()
        {
            return PartialView("_Sections", postSectionBehavior.GetAll());
        }
    }
}