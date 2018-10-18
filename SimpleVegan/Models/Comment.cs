using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleVegan.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int BlogPostID { get; set; }
        public string CommenterName { get; set; }
        public DateTime dop { get; set; }
        public string Body { get; set; }

        public virtual BlogPost BlogPost { get; set; }

    }
}