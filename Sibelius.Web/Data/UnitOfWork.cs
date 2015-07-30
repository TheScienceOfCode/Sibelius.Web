using MongoRepository;
using Sibelius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Data
{
    public class UnitOfWork
    {
        public MongoRepository<Course> Courses;
        public MongoRepository<Article> Articles;
        public MongoRepository<Contest> Contests;
        public MongoRepository<Post> Posts;
        public MongoRepository<PostSection> PostSections;

        public UnitOfWork()
        {
            Courses = new MongoRepository<Course>(Global.Connection);
            Articles = new MongoRepository<Article>(Global.Connection);
            Contests = new MongoRepository<Contest>(Global.Connection);
            Posts = new MongoRepository<Post>(Global.Connection);
            PostSections = new MongoRepository<PostSection>(Global.Connection);
        }
    }
}