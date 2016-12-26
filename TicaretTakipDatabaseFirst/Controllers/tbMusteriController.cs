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
    public class tbMusteriController : Controller
    {
        private TicaretTakipEntities1 db = new TicaretTakipEntities1();

        // GET: tbMusteri
        public ActionResult Index()
        {
            var tbMusteri = db.tbMusteri.Include(t => t.tbIkamet);
            return View(tbMusteri.ToList());
        }

        // GET: tbMusteri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMusteri tbMusteri = db.tbMusteri.Find(id);
            if (tbMusteri == null)
            {
                return HttpNotFound();
            }
            return View(tbMusteri);
        }

        // GET: tbMusteri/Create
        public ActionResult Create()
        {
            ViewBag.IkametId = new SelectList(db.tbIkamet, "Id", "YerIsmi");
            return View();
        }

        // POST: tbMusteri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TcKimlikNumara,Isim,SoyAd,IkametId,TamAdres,TelefonNumarasi,IkinciTelefonNumarasi,MusteriAciklamasi")] tbMusteri tbMusteri)
        {
            if (ModelState.IsValid)
            {
                db.tbMusteri.Add(tbMusteri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IkametId = new SelectList(db.tbIkamet, "Id", "YerIsmi", tbMusteri.IkametId);
            return View(tbMusteri);
        }

        // GET: tbMusteri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMusteri tbMusteri = db.tbMusteri.Find(id);
            if (tbMusteri == null)
            {
                return HttpNotFound();
            }
            ViewBag.IkametId = new SelectList(db.tbIkamet, "Id", "YerIsmi", tbMusteri.IkametId);
            return View(tbMusteri);
        }

        // POST: tbMusteri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TcKimlikNumara,Isim,SoyAd,IkametId,TamAdres,TelefonNumarasi,IkinciTelefonNumarasi,MusteriAciklamasi")] tbMusteri tbMusteri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbMusteri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IkametId = new SelectList(db.tbIkamet, "Id", "YerIsmi", tbMusteri.IkametId);
            return View(tbMusteri);
        }

        // GET: tbMusteri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMusteri tbMusteri = db.tbMusteri.Find(id);
            if (tbMusteri == null)
            {
                return HttpNotFound();
            }
            return View(tbMusteri);
        }

        // POST: tbMusteri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbMusteri tbMusteri = db.tbMusteri.Find(id);
            db.tbMusteri.Remove(tbMusteri);
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
