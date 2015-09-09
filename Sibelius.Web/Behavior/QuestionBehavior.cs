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