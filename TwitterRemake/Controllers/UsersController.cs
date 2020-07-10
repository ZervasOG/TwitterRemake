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
    public class UsersController : Controller
    {
        private TwitterRemakeEntities db = new TwitterRemakeEntities();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.t_Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Users t_Users = db.t_Users.Find(id);
            if (t_Users == null)
            {
                return HttpNotFound();
            }
            return View(t_Users);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Username,Password,Email")] t_Users t_Users)
        {
            if (ModelState.IsValid)
            {
                db.t_Users.Add(t_Users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Users t_Users = db.t_Users.Find(id);
            if (t_Users == null)
            {
                return HttpNotFound();
            }
            return View(t_Users);
        }

        // POST: Users/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Username,Password,Email")] t_Users t_Users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_Users t_Users = db.t_Users.Find(id);
            if (t_Users == null)
            {
                return HttpNotFound();
            }
            return View(t_Users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            t_Users t_Users = db.t_Users.Find(id);
            db.t_Users.Remove(t_Users);
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
