using Sibelius.Web.Data;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Behavior
{
    public class ContestBehavior
    {
        UnitOfWork unit = new UnitOfWork();

        #region Basic Behavior
        public void Insert(Contest contest)
        {            
            unit.Contests.Add(contest);
        }

        public Contest GetById(string id)
        {
            return unit.Contests.GetById(id);
        }

        public IEnumerable<Contest> GetAll()
        {
            return unit.Contests;
        }

        public IEnumerable<Contest> GetVisible()
        {
            return unit.Contests.Where(c => c.Visible == true).OrderByDescending(c => c.Date);
        }

        public void Update(Contest contest)
        {
            unit.Contests.Update(contest);
        }

        public void Delete(Contest contest)
        {
            unit.Contests.Delete(contest);
        }
        #endregion

    }
}