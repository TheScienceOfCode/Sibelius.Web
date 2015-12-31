using MongoDB.Bson.Serialization.Attributes;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Models
{
    public class License : Entity
    {
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Html { get; set; }

        [BsonIgnore]
        public const string DescProperty = "ShortName";
    }
}