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
    public class AdminPostSectionsController : Controller
    {
        PostSectionBehavior postSectionBehavior = new PostSectionBehavior();

        public ActionResult Index()
        {
            return View(postSectionBehavior.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(PostSection postSection)
        {
            if (!ModelState.IsValid)
                return View();

            postSectionBehavior.Insert(postSection);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var postSection = postSectionBehavior.GetById(id);
            if (postSection == null)
                return HttpNotFound();

            return View(postSection);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(PostSection postSection)
        {
            if (!ModelState.IsValid)
                return View(postSection);

            postSectionBehavior.Update(postSection);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var postSection = postSectionBehavior.GetById(id);
            if (postSection == null)
                return HttpNotFound();

            return View(postSection);
        }

        [HttpPost]
        public ActionResult Delete(PostSection postSection)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            postSectionBehavior.Delete(postSection);

            return RedirectToAction("Index");
        }
    }
}