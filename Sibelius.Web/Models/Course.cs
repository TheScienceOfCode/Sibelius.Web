using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sibelius.Web.Models
{
    public class Course : Entity
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
        public string Professor { get; set; }
        public string University { get; set; }
        public string Intro { get; set; }
        public string ImageUrl { get; set; }
        public string Html { get; set; }
        public bool Active { get; set; }
        public bool CurrentlyUpdated { get; set; }
        public string Language { get; set; }
        public bool Visible { get; set; }
    }
}