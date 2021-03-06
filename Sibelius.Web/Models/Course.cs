﻿using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sibelius.Web.Models
{
    [CollectionName("Course")]
    public class Course : LicenseableEntity
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
        public string Professor { get; set; }
        public string University { get; set; }
        public string Intro { get; set; }
        public string ImageUrl { get; set; }
        public string HtmlImageFooter { get; set; }
        public string Html { get; set; }
        public string BibHtml { get; set; }
        public string ToolsHtml { get; set; }
        public bool Active { get; set; }
        public bool CurrentlyUpdated { get; set; }
        public string Language { get; set; }
        public bool Visible { get; set; }
        public bool Virtual { get; set; }
    }
}