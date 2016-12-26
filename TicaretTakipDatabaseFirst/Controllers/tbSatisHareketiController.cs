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
    public class tbSatisHareketiController : Controller
    {
        private TicaretTakipEntities1 db = new TicaretTakipEntities1();

        // GET: tbSatisHareketi
        public ActionResult Index()
        {
            var tbSatisHareketi = db.tbSatisHareketi.Include(t => t.tbMusteri).Include(t => t.tbUrun);
            return View(tbSatisHareketi.ToList());
        }

        // GET: tbSatisHareketi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSatisHareketi tbSatisHareketi = db.tbSatisHareketi.Find(id);
            if (tbSatisHareketi == null)
            {
                return HttpNotFound();
            }
            return View(tbSatisHareketi);
        }

        // GET: tbSatisHareketi/Create
        public ActionResult Create()
        {
            ViewBag.MusteriId = new SelectList(db.tbMusteri, "Id", "TcKimlikNumara");
            ViewBag.UrunId = new SelectList(db.tbUrun, "Id", "UrunAciklamasi");
            return View();
        }

        // POST: tbSatisHareketi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MusteriId,UrunId,UrunIsmi,UrunAdet,ToplamEtiketFiyati,SatisBedeli,YuzdeIskonto,PesinMi,VadeliMi,PesinTarihi,VadeTarihi,SatisTarihi")] tbSatisHareketi tbSatisHareketi)
        {
            if (ModelState.IsValid)
            {
                db.tbSatisHareketi.Add(tbSatisHareketi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MusteriId = new SelectList(db.tbMusteri, "Id", "TcKimlikNumara", tbSatisHareketi.MusteriId);
            ViewBag.UrunId = new SelectList(db.tbUrun, "Id", "UrunAciklamasi", tbSatisHareketi.UrunId);
            return View(tbSatisHareketi);
        }

        // GET: tbSatisHareketi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSatisHareketi tbSatisHareketi = db.tbSatisHareketi.Find(id);
            if (tbSatisHareketi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusteriId = new SelectList(db.tbMusteri, "Id", "TcKimlikNumara", tbSatisHareketi.MusteriId);
            ViewBag.UrunId = new SelectList(db.tbUrun, "Id", "UrunAciklamasi", tbSatisHareketi.UrunId);
            return View(tbSatisHareketi);
        }

        // POST: tbSatisHareketi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MusteriId,UrunId,UrunIsmi,UrunAdet,ToplamEtiketFiyati,SatisBedeli,YuzdeIskonto,PesinMi,VadeliMi,PesinTarihi,VadeTarihi,SatisTarihi")] tbSatisHareketi tbSatisHareketi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbSatisHareketi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MusteriId = new SelectList(db.tbMusteri, "Id", "TcKimlikNumara", tbSatisHareketi.MusteriId);
            ViewBag.UrunId = new SelectList(db.tbUrun, "Id", "UrunAciklamasi", tbSatisHareketi.UrunId);
            return View(tbSatisHareketi);
        }

        // GET: tbSatisHareketi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSatisHareketi tbSatisHareketi = db.tbSatisHareketi.Find(id);
            if (tbSatisHareketi == null)
            {
                return HttpNotFound();
            }
            return View(tbSatisHareketi);
        }

        // POST: tbSatisHareketi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbSatisHareketi tbSatisHareketi = db.tbSatisHareketi.Find(id);
            db.tbSatisHareketi.Remove(tbSatisHareketi);
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
