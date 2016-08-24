using Sibelius.Web.Behavior;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Sibelius.Web.Controllers
{
    [Authorize]
    public class AdminPostsController : Controller
    {
        PostBehavior postBehavior = new PostBehavior();

        public ActionResult Index()
        {
            return View(postBehavior.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
                return View();

            postBehavior.Insert(post);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var post = postBehavior.GetById(id);
            if (post == null)
                return HttpNotFound();

            return View(post);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (!ModelState.IsValid)
                return View(post);

            postBehavior.Update(post);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var post = postBehavior.GetById(id);
            if (post == null)
                return HttpNotFound();

            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Post post)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            postBehavior.Delete(post);

            return RedirectToAction("Index");
        }
    }
}