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
    public class PostsController : Controller
    {
        private TwitterRemakeEntities db = new TwitterRemakeEntities();

        // GET: Posts
        public ActionResult Index()
        {
            var t_Posts = db.t_Posts.Include(t => t.t_Users);
            return View(t_Posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Posts t_Posts = db.t_Posts.Find(id);
            if (t_Posts == null)
            {
                return HttpNotFound();
            }
            return View(t_Posts);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username");
            return View();
        }

        // POST: Posts/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,UserID,Date,Text")] t_Posts t_Posts)
        {
            if (ModelState.IsValid)
            {
                db.t_Posts.Add(t_Posts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username", t_Posts.UserID);
            return View(t_Posts);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Posts t_Posts = db.t_Posts.Find(id);
            if (t_Posts == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username", t_Posts.UserID);
            return View(t_Posts);
        }

        // POST: Posts/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,UserID,Date,Text")] t_Posts t_Posts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Posts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.t_Users, "UserID", "Username", t_Posts.UserID);
            return View(t_Posts);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Posts t_Posts = db.t_Posts.Find(id);
            if (t_Posts == null)
            {
                return HttpNotFound();
            }
            return View(t_Posts);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            t_Posts t_Posts = db.t_Posts.Find(id);
            db.t_Posts.Remove(t_Posts);
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
