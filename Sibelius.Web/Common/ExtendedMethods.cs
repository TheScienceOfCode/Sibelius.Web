using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Common
{
    public static class ExtendedMethods
    {
        /// <summary>
        /// This method receives a Url and replaces the {0} with an int param
        /// </summary>
        /// <param name="url">Url with only {0} param</param>
        /// <param name="value">Integer value to replace</param>
        /// <returns></returns>
        public static string Param(this string url, int value)
        {
            return string.Format(url, value);
        }
    }
}