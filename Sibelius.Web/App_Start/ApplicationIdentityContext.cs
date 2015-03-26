using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.App_Start
{

    using System;
    using AspNet.Identity.MongoDB;
    using MongoDB.Driver;
    using Sibelius.Web.Data;

    public class ApplicationIdentityContext : IdentityContext, IDisposable
    {
        public ApplicationIdentityContext(MongoCollection users, MongoCollection roles)
            : base(users, roles)
        {
        }

        public static ApplicationIdentityContext Create()
        {
            // todo add settings where appropriate to switch server & database in your own application
            string uri = Global.Connection;
            MongoUrl url = new MongoUrl(uri); 
            MongoClient client = new MongoClient(url); 
            MongoServer server = client.GetServer(); 
            MongoDatabase db = server.GetDatabase(url.DatabaseName);
            var users = db.GetCollection<IdentityUser>("users");
            var roles = db.GetCollection<IdentityRole>("roles");
            return new ApplicationIdentityContext(users, roles);
        }

        public void Dispose()
        {
        }
    }

}