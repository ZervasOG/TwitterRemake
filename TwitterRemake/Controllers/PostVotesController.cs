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
    public class PostVotesController : Controller
    {
        private TwitterRemakeEntities db = new TwitterRemakeEntities();

        // GET: PostVotes
        public ActionResult Index()
        {
            var t_PostVotes = db.t_PostVotes.Include(t => t.t_Posts).Include(t => t.t_Users);
            return View(t_PostVotes.ToList());
        }

        // GET: PostVotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PostVotes t_PostVotes = db.t_PostVotes.Find(id);
            if (t_PostVotes == null)
            {
                return HttpNotFound();
            }
            return View(t_PostVotes);
        }

        // GET: PostVotes/Create
        public ActionResult Create()
        {
            ViewBag.PostID = new SelectList(db.t_Posts, "PostID", "Text");
            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username");
            return View();
        }

        // POST: PostVotes/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoteID,UserID,PostID,IsUpvote")] t_PostVotes t_PostVotes)
        {
            if (ModelState.IsValid)
            {
                db.t_PostVotes.Add(t_PostVotes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostID = new SelectList(db.t_Posts, "PostID", "Text", t_PostVotes.PostID);
            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username", t_PostVotes.UserID);
            return View(t_PostVotes);
        }

        // GET: PostVotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PostVotes t_PostVotes = db.t_PostVotes.Find(id);
            if (t_PostVotes == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostID = new SelectList(db.t_Posts, "PostID", "Text", t_PostVotes.PostID);
            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username", t_PostVotes.UserID);
            return View(t_PostVotes);
        }

        // POST: PostVotes/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoteID,UserID,PostID,IsUpvote")] t_PostVotes t_PostVotes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_PostVotes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostID = new SelectList(db.t_Posts, "PostID", "Text", t_PostVotes.PostID);
            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username", t_PostVotes.UserID);
            return View(t_PostVotes);
        }

        // GET: PostVotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_PostVotes t_PostVotes = db.t_PostVotes.Find(id);
            if (t_PostVotes == null)
            {
                return HttpNotFound();
            }
            return View(t_PostVotes);
        }

        // POST: PostVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            t_PostVotes t_PostVotes = db.t_PostVotes.Find(id);
            db.t_PostVotes.Remove(t_PostVotes);
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
