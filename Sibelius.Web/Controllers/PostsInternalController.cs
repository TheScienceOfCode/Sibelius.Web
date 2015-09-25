using Sibelius.Web.Behavior;
using Sibelius.Web.Models;
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
                
        public ActionResult Index(int page = 1)
        {
            var posts = postBehavior.GetAll(page);

            var url = string.Format("/Posts/Index?page={0}", page);
            ViewBag.PaginationVM = new PaginationVM()
            {
                Pages = postBehavior.GetPages(),
                CurPage = page,
                Url = url
            };

            ViewBag.MetaDescription = "Posts cortos sobre computacion, videojuegos, gamedev, appdev, software y hardware.";
            ViewBag.MetaKeywords = "computacion, software, programacion, desarrollo, software, hardware, crear videojuegos, gamedev, videojuegos indie, apps";

            return PartialView("_PostsList", posts);
        }
        
        public ActionResult Section(string name, int page = 1)
        {
            var post = postBehavior.GetBySection(name, page);

            var url = string.Format("/Posts/Section?name={0}", name);
            ViewBag.PaginationVM = new PaginationVM()
            {
                Pages = postBehavior.GetPages(name),
                CurPage = page,
                Url = url + "&page={0}"
            };

            ViewBag.Section = name;
            ViewBag.MetaDescription = "Posts sobre " + name;
            ViewBag.MetaKeywords = "posts, computación, artículos, tutoriales, " + name;
            return PartialView("_PostsList", post);
        }
        
        public ActionResult Show(string id)
        {
            var post = postBehavior.GetById(id);
            ViewBag.MetaDescription = post.Title;
            ViewBag.MetaKeywords = post.Tags;

            return View("_Show", post);
        }
        
        public ActionResult SectionsMenu()
        {
            return PartialView("_Sections", postSectionBehavior.GetAll());
        }
    }
}