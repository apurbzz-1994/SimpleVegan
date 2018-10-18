using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleVegan.DAL;
using SimpleVegan.Models;

namespace SimpleVegan.Controllers
{
    public class CommentsController : Controller
    {


        private SimpleVeganContext db = new SimpleVeganContext();


        [HttpPost]
        public ActionResult Create(string bid, string message, string mid)
        {

            var commenterId = db.Members.ToList().SingleOrDefault(a => string.Equals(a.userId, mid));

            Comment NewComment = new Comment {
                BlogPostID = Convert.ToInt32(bid),
                Body = message,
                dop = DateTime.Now,
                CommenterName = commenterId.FirstName
                
            };

            if (ModelState.IsValid)
            {
                db.Comments.Add(NewComment);
                db.SaveChanges();
                return Json("Success");
            }

            return Json("An error has occured");
        }

        public ActionResult DeleteConfirmed(int id)
        {
            Comment c = db.Comments.Find(id);
            db.Comments.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Details", "BlogPosts", new { id = c.BlogPostID});
        }
    }
}