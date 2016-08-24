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
    public class AdminCollaboratorsController : Controller
    {
        CollaboratorBehavior collaboratorBehavior = new CollaboratorBehavior();

        public ActionResult Index()
        {
            return View(collaboratorBehavior.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Collaborator collaborator)
        {
            if (!ModelState.IsValid)
                return View();

            collaborator.MemberSince = DateTime.Now;
            collaborator.Answers = 0;
            collaboratorBehavior.Insert(collaborator);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var collaborator = collaboratorBehavior.GetById(id);
            if (collaborator == null)
                return HttpNotFound();

            return View(collaborator);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Collaborator collaborator)
        {
            if (!ModelState.IsValid)
                return View(collaborator);

            collaboratorBehavior.Update(collaborator);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var collaborator = collaboratorBehavior.GetById(id);
            if (collaborator == null)
                return HttpNotFound();

            return View(collaborator);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Collaborator collaborator)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            collaboratorBehavior.Delete(collaborator);

            return RedirectToAction("Index");
        }
    }
}