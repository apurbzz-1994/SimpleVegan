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
    public class MembersController : Controller
    {
        private SimpleVeganContext db = new SimpleVeganContext();


        [Authorize(Roles = "Admin")]
        // GET: Members
        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        [Authorize(Roles = "Admin")]
        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        [Authorize]
        public ActionResult Create()
        {
            Boolean isMemberLoggedIn = false;

            //so that already registered members won't be able to access this
            IEnumerable <Models.Member> memberList = db.Members.ToList();

            foreach (var m in memberList)
            {
                if (string.Equals(m.userId, User.Identity.GetUserId()))
                {
                    isMemberLoggedIn = true;
                }

            }

            if (isMemberLoggedIn)
            {
                return Content("You are already Registered!");
            }
            else
            {
                return View();
            }
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "MemberID,FirstName,LastName,userId")] Member member)
        {
            member.userId = User.Identity.GetUserId();

            ModelState.Clear();
            TryValidateModel(member);

            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberID,FirstName,LastName,userId")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
