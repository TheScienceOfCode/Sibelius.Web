using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Models
{
    [CollectionName("Asset")]
    public class Asset : LicenseableEntity
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Collection { get; set; }
        public string Site { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Tags { get; set; }        
        public int Quality { get; set; }
        public string Collaborator { get; set; }
        public bool Visible { get; set; }
    }
}