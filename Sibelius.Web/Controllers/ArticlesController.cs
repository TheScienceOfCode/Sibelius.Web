﻿using Sibelius.Web.Behavior;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sibelius.Web.Controllers
{
    public class ArticlesController : Controller
    {
        ArticleBehavior articleBehavior = new ArticleBehavior();
        CollaboratorBehavior collaboratorBehavior = new CollaboratorBehavior();

        public ActionResult Index()
        {
            return View(articleBehavior.GetVisible().ToList());
        }

        public ActionResult Show(string id)
        {
            var article = articleBehavior.GetById(id);
            if (!Request.IsAuthenticated && Session[string.Format("articleid={0}", id)] == null)
            {
                Session[string.Format("articleid={0}", id)] = true;

                articleBehavior.UpdateCounter(article);

                // Add +1 just to show to the user
                article.Visitas++;
            }
            var articles = articleBehavior.GetVisible().ToList();

            var result = new List<Article>();
            var random = new Random();
            for (int i = 0; i < 2; ++i)
            {
                int index = random.Next(0, articles.Count() - 1);
                result.Add(articles[index]);
                articles.RemoveAt(index);
            }
            ViewBag.Articles = result;
            return View(article);
        }
    }
}