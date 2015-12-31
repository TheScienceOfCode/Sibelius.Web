using Sibelius.Web.Data;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sibelius.Web.Common;

namespace Sibelius.Web.Behavior
{
    public class ArticleBehavior
    {        
        UnitOfWork unit = new UnitOfWork();
        LicenseableBehavior<Article> licenseableBehavior = new LicenseableBehavior<Article>();

        #region Basic Behavior
        public void Insert(Article article)
        {
            unit.Articles.Add(article);
        }

        public Article GetById(string id)
        {
            var article = unit.Articles.GetById(id);

            licenseableBehavior.AddLicense(article);
            return article;
        }

        public List<Article> GetVisible()
        {
            var articles = unit.Articles
                .Where(c => c.Visible == true)
                .OrderByDescending(c => c.Portrait)
                .ThenByDescending(c => c.Date).ToList();

            licenseableBehavior.AddLicense(articles);
            return articles;
        }

        public List<Article> GetAll()
        {
            var articles = unit.Articles.ToList();

            licenseableBehavior.AddLicense(articles);          
            return articles;
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