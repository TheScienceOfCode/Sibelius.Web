using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Models
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Section { get; set; }
        public string IntroHtml { get; set; }
        public string Html { get; set; }
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Tags { get; set; }
        public string Language { get; set; }
    }
}