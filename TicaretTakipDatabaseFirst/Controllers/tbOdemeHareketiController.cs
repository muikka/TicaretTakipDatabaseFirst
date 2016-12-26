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
    public class tbOdemeHareketiController : Controller
    {
        private TicaretTakipEntities1 db = new TicaretTakipEntities1();

        // GET: tbOdemeHareketi
        public ActionResult Index()
        {
            var tbOdemeHareketi = db.tbOdemeHareketi.Include(t => t.tbMusteri);
            return View(tbOdemeHareketi.ToList());
        }

        // GET: tbOdemeHareketi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbOdemeHareketi tbOdemeHareketi = db.tbOdemeHareketi.Find(id);
            if (tbOdemeHareketi == null)
            {
                return HttpNotFound();
            }
            return View(tbOdemeHareketi);
        }

        // GET: tbOdemeHareketi/Create
        public ActionResult Create()
        {
            ViewBag.MusteriId = new SelectList(db.tbMusteri, "Id", "TcKimlikNumara");
            return View();
        }

        // POST: tbOdemeHareketi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MusteriId,MusteriIsmiSoyIsmi,OdenenTutar,Tarih")] tbOdemeHareketi tbOdemeHareketi)
        {
            if (ModelState.IsValid)
            {
                db.tbOdemeHareketi.Add(tbOdemeHareketi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MusteriId = new SelectList(db.tbMusteri, "Id", "TcKimlikNumara", tbOdemeHareketi.MusteriId);
            return View(tbOdemeHareketi);
        }

        // GET: tbOdemeHareketi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbOdemeHareketi tbOdemeHareketi = db.tbOdemeHareketi.Find(id);
            if (tbOdemeHareketi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusteriId = new SelectList(db.tbMusteri, "Id", "TcKimlikNumara", tbOdemeHareketi.MusteriId);
            return View(tbOdemeHareketi);
        }

        // POST: tbOdemeHareketi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MusteriId,MusteriIsmiSoyIsmi,OdenenTutar,Tarih")] tbOdemeHareketi tbOdemeHareketi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbOdemeHareketi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MusteriId = new SelectList(db.tbMusteri, "Id", "TcKimlikNumara", tbOdemeHareketi.MusteriId);
            return View(tbOdemeHareketi);
        }

        // GET: tbOdemeHareketi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbOdemeHareketi tbOdemeHareketi = db.tbOdemeHareketi.Find(id);
            if (tbOdemeHareketi == null)
            {
                return HttpNotFound();
            }
            return View(tbOdemeHareketi);
        }

        // POST: tbOdemeHareketi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbOdemeHareketi tbOdemeHareketi = db.tbOdemeHareketi.Find(id);
            db.tbOdemeHareketi.Remove(tbOdemeHareketi);
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
