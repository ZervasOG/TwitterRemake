using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwitterRemake.Models;

namespace TwitterRemake.Controllers
{
    public class CommentVotesController : Controller
    {
        private TwitterRemakeEntities db = new TwitterRemakeEntities();

        // GET: CommentVotes
        public ActionResult Index()
        {
            var t_CommentVotes = db.t_CommentVotes.Include(t => t.t_Comments).Include(t => t.t_Users);
            return View(t_CommentVotes.ToList());
        }

        // GET: CommentVotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_CommentVotes t_CommentVotes = db.t_CommentVotes.Find(id);
            if (t_CommentVotes == null)
            {
                return HttpNotFound();
            }
            return View(t_CommentVotes);
        }

        // GET: CommentVotes/Create
        public ActionResult Create()
        {
            ViewBag.CommentID = new SelectList(db.t_Comments, "CommentID", "Text");
            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username");
            return View();
        }

        // POST: CommentVotes/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoteID,CommentID,UserID,IsUpvote")] t_CommentVotes t_CommentVotes)
        {
            if (ModelState.IsValid)
            {
                db.t_CommentVotes.Add(t_CommentVotes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommentID = new SelectList(db.t_Comments, "CommentID", "Text", t_CommentVotes.CommentID);
            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username", t_CommentVotes.UserID);
            return View(t_CommentVotes);
        }

        // GET: CommentVotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_CommentVotes t_CommentVotes = db.t_CommentVotes.Find(id);
            if (t_CommentVotes == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommentID = new SelectList(db.t_Comments, "CommentID", "Text", t_CommentVotes.CommentID);
            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username", t_CommentVotes.UserID);
            return View(t_CommentVotes);
        }

        // POST: CommentVotes/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoteID,CommentID,UserID,IsUpvote")] t_CommentVotes t_CommentVotes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_CommentVotes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommentID = new SelectList(db.t_Comments, "CommentID", "Text", t_CommentVotes.CommentID);
            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username", t_CommentVotes.UserID);
            return View(t_CommentVotes);
        }

        // GET: CommentVotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_CommentVotes t_CommentVotes = db.t_CommentVotes.Find(id);
            if (t_CommentVotes == null)
            {
                return HttpNotFound();
            }
            return View(t_CommentVotes);
        }

        // POST: CommentVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            t_CommentVotes t_CommentVotes = db.t_CommentVotes.Find(id);
            db.t_CommentVotes.Remove(t_CommentVotes);
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
