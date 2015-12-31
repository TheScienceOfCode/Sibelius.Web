using MongoDB.Bson.Serialization.Attributes;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Models
{
    [CollectionName("Article")]
    public class Article : LicenseableEntity
    {        
        public string Title { get; set; }
        public string Section { get; set; }
        public string Intro { get; set; }
        public string Html { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Tags { get; set; }
        public string Language { get; set; }
        public string Portrait { get; set; }
        public string ImageUrl { get; set; }
        public string Thumbnail { get; set; }
        public string BackgroundPosition { get; set; }
        public string HtmlImageFooter { get; set; }
        public bool Visible { get; set; }
        public int Visitas { get; set; }
        public string TaringaUrl { get; set; }
        public int TaringaVisitas { get; set; }       
    }
}