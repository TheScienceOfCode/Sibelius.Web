using Sibelius.Web.Data;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Behavior
{
    public class PostBehavior
    {
        UnitOfWork unit = new UnitOfWork();

        #region Basic Behavior
        public void Insert(Post post)
        {
            unit.Posts.Add(post);
        }

        public Post GetById(string id)
        {
            return unit.Posts.GetById(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return unit.Posts;
        }

        public void Update(Post post)
        {
            unit.Posts.Update(post);
        }

        public void Delete(Post post)
        {
            unit.Posts.Delete(post);
        }
        #endregion


        public List<Post> GetBySection(string section)
        {
            return unit.Posts.Where(p => p.Section == section).ToList();
        }
    }
}