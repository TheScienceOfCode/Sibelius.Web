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
    public class AdminCoursesController : Controller
    {
        CourseBehavior courseBehavior = new CourseBehavior();

        LicenseBehavior licenseBehavior = new LicenseBehavior();

        private void DropdownLicenses()
        {
            ViewBag.Licenses = licenseBehavior.GetSelectList();
        }

        public ActionResult Index()
        {            
            return View(courseBehavior.GetAll());
        }

        public ActionResult Create()
        {
            DropdownLicenses();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (!ModelState.IsValid)
            {
                DropdownLicenses();
                return View();
            }
            
            courseBehavior.Insert(course);
            return RedirectToAction("Index");          
        }

        public ActionResult Edit(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var course = courseBehavior.GetById(id);
            if (course == null)
                return HttpNotFound();

            DropdownLicenses();
            return View(course);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            if (!ModelState.IsValid)
            {
                DropdownLicenses();
                return View(course);
            }

            courseBehavior.Update(course);
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var course = courseBehavior.GetById(id);
            if(course == null)
                 return HttpNotFound();
                        
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Course course)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            courseBehavior.Delete(course);

            return RedirectToAction("Index");
        }
    }
}