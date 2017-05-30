﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Models
{
    public class MainpageVM
    {
        public List<Article> Articles { get; set; }

        public List<Post> Posts { get; set; }

        public List<Question> Questions { get; set; }
    }
}