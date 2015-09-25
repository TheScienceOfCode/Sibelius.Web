using Sibelius.Web.Data;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Behavior
{
    public class QuestionBehavior
    {
        UnitOfWork unit = new UnitOfWork();

        private const int PER_PAGE = 5;

        #region Basic Behavior
        public void Insert(Question question)
        {
            question.Date = DateTime.Now;
            unit.Questions.Add(question);
        }

        public Question GetById(string id)
        {
            return unit.Questions.GetById(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return unit.Questions.OrderByDescending(q => q.Date);
        }

        public IEnumerable<Question> GetAll(int page)
        {
            return unit.Questions
                .OrderByDescending(q => q.Date)
                .Skip(PER_PAGE * (page - 1))
                .Take(PER_PAGE);
        }

        public void Update(Question question)
        {
            unit.Questions.Update(question);
        }

        public void Delete(Question question)
        {
            unit.Questions.Delete(question);
        }
        #endregion        
    }
}