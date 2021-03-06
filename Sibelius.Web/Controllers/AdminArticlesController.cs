﻿using Sibelius.Web.Behavior;
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
    public class AdminArticlesController : Controller
    {
        ArticleBehavior articleBehavior = new ArticleBehavior();
        LicenseBehavior licenseBehavior = new LicenseBehavior();

        private void DropdownLicenses()
        {
            ViewBag.Licenses = licenseBehavior.GetSelectList();
        }

        public ActionResult Index()
        {            
            return View(articleBehavior.GetAll());
        }

        public ActionResult Create()
        {
            DropdownLicenses();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article)
        {
            if (!ModelState.IsValid)
            {
                DropdownLicenses();
                return View();
            }

            articleBehavior.Insert(article);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var article = articleBehavior.GetById(id);
            if (article == null)
                return HttpNotFound();

            DropdownLicenses();
            return View(article);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Article article)
        {
            if (!ModelState.IsValid)
            {
                DropdownLicenses();
                return View(article);
            }

            articleBehavior.Update(article);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var course = articleBehavior.GetById(id);
            if (course == null)
                return HttpNotFound();

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Article article)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            articleBehavior.Delete(article);

            return RedirectToAction("Index");
        }
    }
}