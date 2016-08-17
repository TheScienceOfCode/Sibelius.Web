using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Data
{
    public static class Global
    {
        public static readonly string Connection =
             System.Environment.GetEnvironmentVariable("CUSTOMCONNSTR_MONGOLAB_URI");
             //"mongodb://localhost/tsoc";

        public static readonly string IdProperty = "Id";

        public const string DefaultMainImg = "https://www.facebook.com/TheScienceOfCode/photos/a.352841624827797.1073741827.213321925446435/729301400515149/?type=1&theater";
    }
}