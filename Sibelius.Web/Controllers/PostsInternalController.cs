using Sibelius.Web.Behavior;
using Sibelius.Web.Common;
using Sibelius.Web.Data;
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

            var url = "/Posts/Index?page={0}";
            ViewBag.PaginationVM = new PaginationVM()
            {
                Pages = postBehavior.GetPages(),
                CurPage = page,
                Url = url
            };

            PostsMetadata.ForIndex(ViewBag);
            
            return PartialView("_PostsList", posts.ToList());
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

            PostsMetadata.ForSection(ViewBag, name);

            return PartialView("_PostsList", post.ToList());
        }
        
        public ActionResult Show(string id)
        {
            var post = postBehavior.GetById(id);

            PostsMetadata.ForPost(ViewBag, post);

            return View("_Show", post);
        }
        
        public ActionResult SectionsMenu()
        {
            return PartialView("_Sections", postSectionBehavior.GetAll());
        }
    }
}