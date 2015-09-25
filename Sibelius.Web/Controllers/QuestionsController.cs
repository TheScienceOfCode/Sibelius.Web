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

        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult List()
        {
            ViewBag.Collaborators = collaboratorBehavior.GetAll();
            var questions = questionBehavior.GetAll();
            return PartialView("_List", questions);
        }

        public ActionResult Show(string id)
        {
            var question = questionBehavior.GetById(id);
            ViewBag.Collaborator = collaboratorBehavior.GetByUsername(question.Collaborator);
            return View(question);
        }

        public ActionResult SendQuestion()
        {
            return PartialView("_SendQuestion");
        }

        [HttpPost]
        public ActionResult SendQuestion([Bind(Include ="Text,Name,SourceCodeUrl,Email")]Question question)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(
                    "_SendResult", 
                    new QuestionResultVM
                    {
                        Error = true,
                        Message = "No pudimos recibir la pregunta :(",
                        Question = question
                    });
            }
            else
            {
                question.Title = question.Text;
                questionBehavior.Insert(question);
                return PartialView(
                   "_SendResult",
                   new QuestionResultVM
                   {
                       Error = false,
                       Message = "¡Hemos recibido tu pregunta!"
                   });
            }
            
            
        }
    }
}