using MongoRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sibelius.Web.Models
{
    public class Question : Entity
    {
        [Required(ErrorMessage="Debes escribir algo aquí")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Debes escribir algo aquí")]
        public string Text { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SourceCodeUrl { get; set; }
        public string HtmlAnswer { get; set; }
        public string Collaborator { get; set; }
        public string Tags { get; set; }
        public DateTime Date { get; set; }
        public bool Answered { get; set; }
    }
}