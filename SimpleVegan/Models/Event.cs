using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimpleVegan.Models
{
    public class Event
    {
        public int EventID { get; set; }

        [Required(ErrorMessage = "Your Event requires a title.")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage ="Please provide the destination venue for your guests to know.")]
        public string Venue { get; set; }
        [Required(ErrorMessage ="Please add the date of vegan event.")]
        public string EDate { get; set; }
        [Required(ErrorMessage ="Please enter a valid time for event")]
        public string ETime { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        [Range(0, 23, ErrorMessage = "Please enter valid integer Number")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter a positive integer number for duration.")]
        public int Duration { get; set; }

        public virtual ICollection<EventBooking> Bookings { get; set; }
    }
}