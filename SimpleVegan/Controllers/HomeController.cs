using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleVegan.DAL;
using SimpleVegan.Models;
using System.Data.Entity;

namespace SimpleVegan.Controllers
{
    public class HomeController : Controller
    {

        private SimpleVeganContext db = new SimpleVeganContext();

        public ActionResult Index()
        {
            List<Event> allEvent = db.Events.OrderByDescending(x => x.EventDate).ToList();
            List<BlogPost> allPost = db.BlogPosts.OrderByDescending(x => x.Dop).ToList();

            var viewModel = new HomePageViewModel {
                latestEvent = allEvent[allEvent.Count - 1],
               latestPost = allPost[0]
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}