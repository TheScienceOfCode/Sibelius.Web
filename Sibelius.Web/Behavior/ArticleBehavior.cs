using Sibelius.Web.Data;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Behavior
{
    public class ArticleBehavior
    {
        UnitOfWork unit = new UnitOfWork();

        #region Basic Behavior
        public void Insert(Article article)
        {
            unit.Articles.Add(article);
        }

        public Article GetById(string id)
        {
            return unit.Articles.GetById(id);
        }

        public IEnumerable<Article> GetVisible()
        {
            return unit.Articles.Where(c => c.Visible == true).OrderByDescending(c => c.Portrait).ThenByDescending(c => c.Date);
        }

        public IEnumerable<Article> GetAll()
        {
            return unit.Articles;
        }

        public void Update(Article article)
        {
            unit.Articles.Update(article);
        }

        public void Delete(Article article)
        {
            unit.Articles.Delete(article);
        }
        #endregion

    }
}