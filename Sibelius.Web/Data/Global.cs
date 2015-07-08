using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Data
{
    public static class Global
    {
        public static readonly string Connection = 
            // System.Environment.GetEnvironmentVariable("CUSTOMCONNSTR_MONGOLAB_URI"); 
            "mongodb://webapp:Tsocdb123*@ds062097.mongolab.com:62097/TsocDB";
            // USE A STRING LIKE THIS WHEN DEV: "mongodb://localhost/tsoc";
    }
}