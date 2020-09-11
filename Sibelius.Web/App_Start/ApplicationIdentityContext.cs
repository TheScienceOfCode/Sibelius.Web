using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.App_Start
{

    using System;
    using System.Threading.Tasks;
    using AspNet.Identity.MongoDB;
    using MongoDB.Driver;
    using Sibelius.Web.Data;
    using Sibelius.Web.Models;

    public class ApplicationIdentityContext : IDisposable
    {
        public static ApplicationIdentityContext Create()
        {
            string uri = Global.Connection;
            var url = new MongoUrl(uri); 
            var client = new MongoClient(url); 
            var db = client.GetDatabase(url.DatabaseName);
            var users = db.GetCollection<ApplicationUser>("users");
            var roles = db.GetCollection<IdentityRole>("roles");
            return new ApplicationIdentityContext(users, roles);
        }

        private ApplicationIdentityContext(IMongoCollection<ApplicationUser> users, IMongoCollection<IdentityRole> roles)
        {
            Users = users;
            Roles = roles;
        }

        public IMongoCollection<IdentityRole> Roles { get; set; }

        public IMongoCollection<ApplicationUser> Users { get; set; }

        public void Dispose()
        {
        }
    }

}