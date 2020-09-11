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
        public static MongoRepository<Course> _courses = new MongoRepository<Course>(Global.Connection);
        public static MongoRepository<Article> _articles = new MongoRepository<Article>(Global.Connection);
        public static MongoRepository<Post> _posts = new MongoRepository<Post>(Global.Connection);
        public static MongoRepository<PostSection> _postSections = new MongoRepository<PostSection>(Global.Connection);
        public static MongoRepository<Collaborator> _collaborators = new MongoRepository<Collaborator>(Global.Connection);
        public static MongoRepository<Question> _questions = new MongoRepository<Question>(Global.Connection);
        public static MongoRepository<License> _licenses = new MongoRepository<License>(Global.Connection);
        public static MongoRepository<Asset> _assets = new MongoRepository<Asset>(Global.Connection);

        public MongoRepository<Course> Courses { get { return _courses; } }
        public MongoRepository<Article> Articles { get { return _articles; } }
        public MongoRepository<Post> Posts { get { return _posts; } }
        public MongoRepository<PostSection> PostSections { get { return _postSections; } }
        public MongoRepository<Collaborator> Collaborators { get { return _collaborators; } }
        public MongoRepository<Question> Questions { get { return _questions; } }
        public MongoRepository<License> Licenses { get { return _licenses; } }
        public MongoRepository<Asset> Assets { get { return _assets; } }

        public UnitOfWork() { }
    }
}