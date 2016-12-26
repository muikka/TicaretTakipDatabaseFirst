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
    public class tbUrunController : Controller
    {
        private TicaretTakipEntities1 db = new TicaretTakipEntities1();

        // GET: tbUrun
        public ActionResult Index()
        {
            var tbUrun = db.tbUrun.Include(t => t.tbUrunGrubu);
            return View(tbUrun.ToList());
        }

        // GET: tbUrun/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUrun tbUrun = db.tbUrun.Find(id);
            if (tbUrun == null)
            {
                return HttpNotFound();
            }
            return View(tbUrun);
        }

        // GET: tbUrun/Create
        public ActionResult Create()
        {
            ViewBag.UrunGrubuId = new SelectList(db.tbUrunGrubu, "Id", "UrunGrubuAciklamasi");
            return View();
        }

        // POST: tbUrun/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UrunAciklamasi,UrunGrubuId,UrunGrubuIsmi,AlisFiyat,SatisFiyat")] tbUrun tbUrun)
        {
            if (ModelState.IsValid)
            {
                db.tbUrun.Add(tbUrun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UrunGrubuId = new SelectList(db.tbUrunGrubu, "Id", "UrunGrubuAciklamasi", tbUrun.UrunGrubuId);
            return View(tbUrun);
        }

        // GET: tbUrun/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUrun tbUrun = db.tbUrun.Find(id);
            if (tbUrun == null)
            {
                return HttpNotFound();
            }
            ViewBag.UrunGrubuId = new SelectList(db.tbUrunGrubu, "Id", "UrunGrubuAciklamasi", tbUrun.UrunGrubuId);
            return View(tbUrun);
        }

        // POST: tbUrun/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UrunAciklamasi,UrunGrubuId,UrunGrubuIsmi,AlisFiyat,SatisFiyat")] tbUrun tbUrun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbUrun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UrunGrubuId = new SelectList(db.tbUrunGrubu, "Id", "UrunGrubuAciklamasi", tbUrun.UrunGrubuId);
            return View(tbUrun);
        }

        // GET: tbUrun/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUrun tbUrun = db.tbUrun.Find(id);
            if (tbUrun == null)
            {
                return HttpNotFound();
            }
            return View(tbUrun);
        }

        // POST: tbUrun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbUrun tbUrun = db.tbUrun.Find(id);
            db.tbUrun.Remove(tbUrun);
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
