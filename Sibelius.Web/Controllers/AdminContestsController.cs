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
    public class AdminContestsController : Controller
    {
        ContestBehavior contestBehavior = new ContestBehavior();

        public ActionResult Index()
        {
            return View(contestBehavior.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Contest contest)
        {
            if(!ModelState.IsValid)
                return View();

            contestBehavior.Insert(contest);
            return RedirectToAction("Index");          
        }

        public ActionResult Edit(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var contest = contestBehavior.GetById(id);
            if (contest == null)
                return HttpNotFound();

            return View(contest);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Contest contest)
        {
            if(!ModelState.IsValid)
                return View(contest);

            contestBehavior.Update(contest);
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var contest = contestBehavior.GetById(id);
            if(contest == null)
                 return HttpNotFound();

            return View(contest);
        }

        [HttpPost]
        public ActionResult Delete(Contest contest)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            contestBehavior.Delete(contest);

            return RedirectToAction("Index");
        }
    }
}