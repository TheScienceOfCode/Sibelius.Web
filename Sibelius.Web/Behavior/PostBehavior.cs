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

        private const int PER_PAGE = 7;

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
            return unit.Posts.OrderByDescending(p => p.Date);
        }
        

        public IEnumerable<Post> GetAll(int page)
        {
            return unit.Posts
                .OrderByDescending(p => p.Date)
                .Skip(PER_PAGE * (page-1))
                .Take(PER_PAGE);
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


        public IEnumerable<Post> GetBySection(string section, int page)
        {
            return unit.Posts
                .Where(p => p.Section == section)
                .OrderByDescending(p => p.Date)
                .Skip(PER_PAGE * (page - 1))
                .Take(PER_PAGE); ;
        }

        public long GetPages()
        {
            return (long)Math.Ceiling(unit.Posts.Count() / (double)PER_PAGE);
        }

        public long GetPages(string section)
        {
            return (long)Math.Ceiling(unit.Posts.Where(p => p.Section == section).Count() / (double)PER_PAGE);
        }
    }
}