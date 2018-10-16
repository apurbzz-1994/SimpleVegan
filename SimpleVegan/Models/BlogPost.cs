using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleVegan.Models
{
    public class BlogPost
    {

        [Required]
        public int BlogPostID { get; set; }
        public int MemberID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Dop { get; set; }
        public string Body { get; set; }

        public virtual Member Member { get; set; }
    }
}