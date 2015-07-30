using Sibelius.Web.Data;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Behavior
{
    public class PostSectionBehavior
    {
        UnitOfWork unit = new UnitOfWork();

        #region Basic Behavior
        public void Insert(PostSection postSection)
        {
            unit.PostSections.Add(postSection);
        }

        public PostSection GetById(string id)
        {
            return unit.PostSections.GetById(id);
        }

        public IEnumerable<PostSection> GetAll()
        {
            return unit.PostSections;
        }

        public void Update(PostSection postSection)
        {
            unit.PostSections.Update(postSection);
        }

        public void Delete(PostSection postSection)
        {
            unit.PostSections.Delete(postSection);
        }
        #endregion

    }
}