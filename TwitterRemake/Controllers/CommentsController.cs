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
    public class CommentsController : Controller
    {
        private TwitterRemakeEntities db = new TwitterRemakeEntities();

        // GET: Comments
        public ActionResult Index()
        {
            var t_Comments = db.t_Comments.Include(t => t.t_Posts).Include(t => t.t_Users);
            return View(t_Comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Comments t_Comments = db.t_Comments.Find(id);
            if (t_Comments == null)
            {
                return HttpNotFound();
            }
            return View(t_Comments);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.PostID = new SelectList(db.t_Posts, "PostID", "Text");
            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username");
            return View();
        }

        // POST: Comments/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,UserID,Text,PostID")] t_Comments t_Comments)
        {
            if (ModelState.IsValid)
            {
                db.t_Comments.Add(t_Comments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostID = new SelectList(db.t_Posts, "PostID", "Text", t_Comments.PostID);
            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username", t_Comments.UserID);
            return View(t_Comments);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Comments t_Comments = db.t_Comments.Find(id);
            if (t_Comments == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostID = new SelectList(db.t_Posts, "PostID", "Text", t_Comments.PostID);
            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username", t_Comments.UserID);
            return View(t_Comments);
        }

        // POST: Comments/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,UserID,Text,PostID")] t_Comments t_Comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostID = new SelectList(db.t_Posts, "PostID", "Text", t_Comments.PostID);
            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username", t_Comments.UserID);
            return View(t_Comments);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Comments t_Comments = db.t_Comments.Find(id);
            if (t_Comments == null)
            {
                return HttpNotFound();
            }
            return View(t_Comments);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            t_Comments t_Comments = db.t_Comments.Find(id);
            db.t_Comments.Remove(t_Comments);
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
