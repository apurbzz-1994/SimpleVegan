using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleVegan.Models
{
    public class EventBooking
    {
        public int EventBookingID { get; set; }
        public int MemberID { get; set; }
        public int EventID { get; set; }

        public virtual Member Member { get; set; }
        public virtual Event Event { get; set; }
    }
}