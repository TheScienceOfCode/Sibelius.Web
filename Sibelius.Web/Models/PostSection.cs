using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Models
{
    public class PostSection : Entity
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Language { get; set; }
    }
}