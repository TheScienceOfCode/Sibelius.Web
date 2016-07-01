using MongoDB.Bson.Serialization.Attributes;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Models
{
    [BsonKnownTypes(typeof(Article), typeof(Course), typeof(Asset))]
    public class LicenseableEntity : Entity
    {
        public string LicenseId { get; set; }

        [BsonIgnore]
        public License License { get; set; }
    }
}