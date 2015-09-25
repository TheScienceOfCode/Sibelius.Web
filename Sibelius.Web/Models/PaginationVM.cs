using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Models
{
    public class PaginationVM
    {
        public int Pages { get; set; }
        public int CurPage { get; set; }
        public string Url { get; set; }
    }
}