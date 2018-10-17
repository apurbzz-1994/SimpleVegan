using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleVegan.Models
{
    public class HomePageViewModel
    {
        public Event latestEvent { get; set; }

        //will add a second property when blogpost is there
        public BlogPost latestPost { get; set; }
    }
}