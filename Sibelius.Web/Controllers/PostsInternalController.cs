using Sibelius.Web.Behavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sibelius.Web.Controllers
{
    public class PostsInternalController : Controller
    {
        PostBehavior postBehavior = new PostBehavior();
        PostSectionBehavior postSectionBehavior = new PostSectionBehavior();

        [HttpPost]
        public ActionResult Index(int page = 1)
        {
            var posts = postBehavior.GetAll(page);
            ViewBag.Pages = postBehavior.GetPages();
            ViewBag.CurPage = page;
            ViewBag.MetaDescription = "Posts cortos sobre computacion, videojuegos, gamedev, appdev, software y hardware.";
            ViewBag.MetaKeywords = "computacion, software, programacion, desarrollo, software, hardware, crear videojuegos, gamedev, videojuegos indie, apps";

            return PartialView("_PostsList", posts);
        }

        [HttpPost]
        public ActionResult Section(string name, int page = 1)
        {
            var post = postBehavior.GetBySection(name, page);
            ViewBag.Pages = postBehavior.GetPages(name);
            ViewBag.CurPage = page;
            ViewBag.Section = name;
            ViewBag.MetaDescription = "Posts sobre " + name;
            ViewBag.MetaKeywords = "posts, computación, artículos, tutoriales, " + name;
            return PartialView("_PostsList", post);
        }

        [HttpPost]
        public ActionResult Show(string id)
        {
            var post = postBehavior.GetById(id);
            ViewBag.MetaDescription = post.Title;
            ViewBag.MetaKeywords = post.Tags;

            return View("_Show", post);
        }

        [HttpPost]
        public ActionResult SectionsMenu()
        {
            return PartialView("_Sections", postSectionBehavior.GetAll());
        }
    }
}