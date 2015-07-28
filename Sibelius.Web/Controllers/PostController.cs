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

        public ActionResult Index()
        {
            var posts = postBehavior.GetAll().OrderByDescending(p => p.Date);
            return View(posts);
        }

        public ActionResult Show(string id)
        {
            var post = postBehavior.GetById(id);
            return View(post);
        }
    }
}