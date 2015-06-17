using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Models
{
    public class Contest : Entity
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Intro { get; set; }
        public string Html { get; set; }
        public string From { get; set; }
        public DateTime Date { get; set; }
        public string Languages { get; set; }
        public string ImageUrl { get; set; }
        public bool Visible { get; set; }
    }
}