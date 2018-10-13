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
using Microsoft.AspNet.Identity;


namespace SimpleVegan.Controllers
{
    public class EventBookingsController : Controller
    {
        private SimpleVeganContext db = new SimpleVeganContext();

        // GET: EventBookings
        public ActionResult Index()
        {
            var eventBookings = db.EventBookings.Include(e => e.Event).Include(e => e.Member);
            return View(eventBookings.ToList());
        }

        // GET: EventBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventBooking eventBooking = db.EventBookings.Find(id);
            if (eventBooking == null)
            {
                return HttpNotFound();
            }
            return View(eventBooking);
        }

        // GET: EventBookings/Create
        //public ActionResult Create()
        //{
        //    ViewBag.EventID = new SelectList(db.Events, "EventID", "Title");
        //    ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName");
        //    return View();
        //}

        // POST: EventBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
     
        public ActionResult Create(int id)
        {

            var loggedInUser = User.Identity.GetUserId();
            //fetches the member object associated with the current logged in user.
            var currentMember = db.Members.ToList().SingleOrDefault(m => string.Equals(m.userId, loggedInUser));

            EventBooking eventBooking = new EventBooking()
            {
                MemberID = currentMember.MemberID,
                EventID = id
            };

            db.EventBookings.Add(eventBooking);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        // GET: EventBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventBooking eventBooking = db.EventBookings.Find(id);
            if (eventBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title", eventBooking.EventID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName", eventBooking.MemberID);
            return View(eventBooking);
        }

        // POST: EventBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventBookingID,MemberID,EventID")] EventBooking eventBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title", eventBooking.EventID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName", eventBooking.MemberID);
            return View(eventBooking);
        }

        // GET: EventBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventBooking eventBooking = db.EventBookings.Find(id);
            if (eventBooking == null)
            {
                return HttpNotFound();
            }
            return View(eventBooking);
        }

        // POST: EventBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventBooking eventBooking = db.EventBookings.Find(id);
            db.EventBookings.Remove(eventBooking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
