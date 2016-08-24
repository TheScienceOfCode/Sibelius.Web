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
    public class AdminAssetsController : Controller
    {
        AssetBehavior assetBehavior = new AssetBehavior();
        LicenseBehavior licenseBehavior = new LicenseBehavior();

        private void DropdownLicenses()
        {
            ViewBag.Licenses = licenseBehavior.GetSelectList();
        }

        public ActionResult Index()
        {            
            return View(assetBehavior.GetAll());
        }

        public ActionResult Create()
        {
            DropdownLicenses();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Asset asset)
        {
            if (!ModelState.IsValid)
            {
                DropdownLicenses();
                return View();
            }

            assetBehavior.Insert(asset);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var asset = assetBehavior.GetById(id);
            if (asset == null)
                return HttpNotFound();

            DropdownLicenses();
            return View(asset);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Asset asset)
        {
            if (!ModelState.IsValid)
            {
                DropdownLicenses();
                return View(asset);
            }

            assetBehavior.Update(asset);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var asset = assetBehavior.GetById(id);
            if (asset == null)
                return HttpNotFound();

            return View(asset);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Asset asset)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            assetBehavior.Delete(asset);

            return RedirectToAction("Index");
        }
    }
}