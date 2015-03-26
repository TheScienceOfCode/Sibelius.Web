using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.App_Start
{
    using AspNet.Identity.MongoDB;

    public class EnsureAuthIndexes
    {
        public static void Exist()
        {
            var context = ApplicationIdentityContext.Create();
            IndexChecks.EnsureUniqueIndexOnUserName(context.Users);
            IndexChecks.EnsureUniqueIndexOnRoleName(context.Roles);
        }
    }

}