using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Models
{
    public class Collaborator : Entity
    {
        public string Fullname { get; set; }
        public string Nickname { get; set; }
        public string University { get; set; }
        public string About { get; set; }
        public string Site { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Google { get; set; }
        public string LinkedIn { get; set; }
        public string Github { get; set; }
        public int Answers { get; set; }
        public string ImgUrl { get; set; }
        public string Topics { get; set; }
        public DateTime MemberSince { get; set; }
        public string Username { get; set; }
    }
}