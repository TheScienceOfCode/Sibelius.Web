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
    public class AdminLicensesController : Controller
    {
        LicenseBehavior licenseBehavior = new LicenseBehavior();

        public ActionResult Index()
        {
            return View(licenseBehavior.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(License license)
        {
            if (!ModelState.IsValid)
                return View();

            licenseBehavior.Insert(license);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var license = licenseBehavior.GetById(id);
            if (license == null)
                return HttpNotFound();

            return View(license);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(License license)
        {
            if (!ModelState.IsValid)
                return View(license);

            licenseBehavior.Update(license);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var license = licenseBehavior.GetById(id);
            if (license == null)
                return HttpNotFound();

            return View(license);
        }

        [HttpPost]
        public ActionResult Delete(License license)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            licenseBehavior.Delete(license);

            return RedirectToAction("Index");
        }
    }
}