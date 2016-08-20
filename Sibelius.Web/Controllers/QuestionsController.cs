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

        public ActionResult List(int page = 1, bool pagination = true)
        {
            ViewBag.Collaborators = collaboratorBehavior.GetAll();
            var questions = questionBehavior.GetAll(page);

            if (pagination)
            {
                ViewBag.PaginationVM = new PaginationVM()
                {
                    Url = "~/Questions/List?page={0}",
                    CurPage = page,
                    Pages = questionBehavior.GetPages()
                };               
            }
            ViewBag.ShowPagination = pagination;

            return PartialView("_List", questions);
        }

        public ActionResult Show(string id)
        {
            var question = questionBehavior.GetById(id);
            ViewBag.Collaborator = collaboratorBehavior.GetByUsername(question.Collaborator);
            ViewBag.PaginationVM = new PaginationVM()
            {
                Url = "~/Questions/List?page={0}",
                CurPage = 1,
                Pages = questionBehavior.GetPages()
            };
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
                Session["question"] = true;
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