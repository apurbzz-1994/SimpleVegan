using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleVegan.Models
{
    public class EventPageViewModel
    {
        public IEnumerable<Event> AllEvents { get; set; }
        public IEnumerable<EventBooking> AllBookings { get; set; }
    }
}