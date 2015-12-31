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
        public MongoRepository<Post> Posts;
        public MongoRepository<PostSection> PostSections;
        public MongoRepository<Collaborator> Collaborators;
        public MongoRepository<Question> Questions;
        public MongoRepository<License> Licenses;

        public UnitOfWork()
        {
            Courses = new MongoRepository<Course>(Global.Connection);
            Articles = new MongoRepository<Article>(Global.Connection);
            Posts = new MongoRepository<Post>(Global.Connection);
            PostSections = new MongoRepository<PostSection>(Global.Connection);
            Collaborators = new MongoRepository<Collaborator>(Global.Connection);
            Questions = new MongoRepository<Question>(Global.Connection);
            Licenses = new MongoRepository<License>(Global.Connection);
        }
    }
}