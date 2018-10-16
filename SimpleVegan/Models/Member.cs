using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleVegan.Models
{
    public class Member
    {
        [Required]
        public int MemberID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string userId { get; set; }

        public virtual ICollection<EventBooking> Bookings { get; set; }

        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }
}