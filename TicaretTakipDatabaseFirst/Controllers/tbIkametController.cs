using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicaretTakipDatabaseFirst.Models;

namespace TicaretTakipDatabaseFirst.Controllers
{
    public class tbIkametController : Controller
    {
        private TicaretTakipEntities1 db = new TicaretTakipEntities1();

        // GET: tbIkamet
        public ActionResult Index()
        {
            return View(db.tbIkamet.ToList());
        }

        // GET: tbIkamet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbIkamet tbIkamet = db.tbIkamet.Find(id);
            if (tbIkamet == null)
            {
                return HttpNotFound();
            }
            return View(tbIkamet);
        }

        // GET: tbIkamet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbIkamet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,YerIsmi")] tbIkamet tbIkamet)
        {
            if (ModelState.IsValid)
            {
                db.tbIkamet.Add(tbIkamet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbIkamet);
        }

        // GET: tbIkamet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbIkamet tbIkamet = db.tbIkamet.Find(id);
            if (tbIkamet == null)
            {
                return HttpNotFound();
            }
            return View(tbIkamet);
        }

        // POST: tbIkamet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,YerIsmi")] tbIkamet tbIkamet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbIkamet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbIkamet);
        }

        // GET: tbIkamet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbIkamet tbIkamet = db.tbIkamet.Find(id);
            if (tbIkamet == null)
            {
                return HttpNotFound();
            }
            return View(tbIkamet);
        }

        // POST: tbIkamet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbIkamet tbIkamet = db.tbIkamet.Find(id);
            db.tbIkamet.Remove(tbIkamet);
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
