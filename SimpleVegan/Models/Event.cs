﻿using System;
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
        [Required(ErrorMessage = "Provide a venue for your guests.")]
        public string Venue { get; set; }
        [Required]
        public string EDate { get; set; }
        [Required]
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