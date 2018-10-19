using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleVegan.Models
{
    public class ProfileViewModel
    {
        public IEnumerable<BlogPost> MyBlogs { get; set; }
        public IEnumerable<EventBooking> MyBookings { get; set; }
        public IEnumerable<Comment> MyComments { get; set; }
        public string MyName { get; set; }
    }
}