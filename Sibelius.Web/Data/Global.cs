﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Data
{
    public static class Global
    {
        public static readonly string Connection =
             Environment.GetEnvironmentVariable("CUSTOMCONNSTR_MONGOLAB_URI");
             //"mongodb://localhost/tsoc";                

        public static readonly string DefaultMainImg =
            Environment.GetEnvironmentVariable("APPSETTING_DEFAULT_MAINIMG_URL");
        
        public const string IdProperty = "Id";
    }
}