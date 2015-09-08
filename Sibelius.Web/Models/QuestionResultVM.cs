using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Models
{
    public class QuestionResultVM
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public Question Question { get; set; }
    }
}