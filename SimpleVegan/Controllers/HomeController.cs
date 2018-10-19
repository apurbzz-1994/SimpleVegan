using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleVegan.DAL;
using SimpleVegan.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

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

        public ActionResult Profile()
        {
            var userCred = User.Identity.GetUserId();
            var viewModel = new ProfileViewModel {
                MyBlogs = db.BlogPosts.ToList().Where(m => string.Equals(m.Member.userId, User.Identity.GetUserId())),
                MyBookings = db.EventBookings.ToList().Where(m => string.Equals(m.Member.userId, User.Identity.GetUserId())),
                MyComments = db.Comments.ToList().Where(m => string.Equals(m.CommenterId, User.Identity.GetUserId())),
                MyName = db.Members.SingleOrDefault(m => string.Equals(m.userId, userCred)).FirstName
            };
            return View(viewModel);
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}