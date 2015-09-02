using Sibelius.Web.Behavior;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sibelius.Web.Controllers
{
    public class QuestionsController : Controller
    {
        QuestionBehavior questionBehavior = new QuestionBehavior();
        CollaboratorBehavior collaboratorBehavior = new CollaboratorBehavior();

        public ActionResult Index(string msg=null, string error=null)
        {
            ViewBag.msg = msg;
            ViewBag.error = error;

            ViewBag.Collaborators = collaboratorBehavior.GetAll();
            var questions = questionBehavior.GetAll();
            return View(questions);
        }

        public ActionResult Show(string id)
        {
            ViewBag.Collaborators = collaboratorBehavior.GetAll();
            var question = questionBehavior.GetById(id);
            return View(question);
        }

        public ActionResult SendQuestion()
        {
            return PartialView("_SendQuestion");
        }

        [HttpPost]
        public ActionResult Index(Question question)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(
                    "Index", 
                    new { error = "No pudimos recibir la pregunta :(" });
            }
            else
            {
                questionBehavior.Insert(question);
                return RedirectToAction(
                   "Index",
                   new { msg = "¡Hemos recibido tu pregunta!" });
            }
            
            
        }
    }
}