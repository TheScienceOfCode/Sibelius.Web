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
    public class AdminQuestionsController : Controller
    {
        QuestionBehavior questionBehavior = new QuestionBehavior();

        public ActionResult Index()
        {
            return View(questionBehavior.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Question question)
        {
            if (!ModelState.IsValid)
                return View();

            question.Date = DateTime.Now;
            questionBehavior.Insert(question);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var question = questionBehavior.GetById(id);
            if (question == null)
                return HttpNotFound();

            return View(question);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Question question)
        {
            if (!ModelState.IsValid)
                return View(question);

            questionBehavior.Update(question);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            if (id == null || id == string.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var question = questionBehavior.GetById(id);
            if (question == null)
                return HttpNotFound();

            return View(question);
        }

        [HttpPost]
        public ActionResult Delete(Question question)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            questionBehavior.Delete(question);

            return RedirectToAction("Index");
        }
    }
}