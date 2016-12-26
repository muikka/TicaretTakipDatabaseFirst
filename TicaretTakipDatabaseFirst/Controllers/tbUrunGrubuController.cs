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
    public class tbUrunGrubuController : Controller
    {
        private TicaretTakipEntities1 db = new TicaretTakipEntities1();

        // GET: tbUrunGrubu
        public ActionResult Index()
        {
            return View(db.tbUrunGrubu.ToList());
        }

        // GET: tbUrunGrubu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUrunGrubu tbUrunGrubu = db.tbUrunGrubu.Find(id);
            if (tbUrunGrubu == null)
            {
                return HttpNotFound();
            }
            return View(tbUrunGrubu);
        }

        // GET: tbUrunGrubu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbUrunGrubu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UrunGrubuAciklamasi")] tbUrunGrubu tbUrunGrubu)
        {
            if (ModelState.IsValid)
            {
                db.tbUrunGrubu.Add(tbUrunGrubu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbUrunGrubu);
        }

        // GET: tbUrunGrubu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUrunGrubu tbUrunGrubu = db.tbUrunGrubu.Find(id);
            if (tbUrunGrubu == null)
            {
                return HttpNotFound();
            }
            return View(tbUrunGrubu);
        }

        // POST: tbUrunGrubu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UrunGrubuAciklamasi")] tbUrunGrubu tbUrunGrubu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbUrunGrubu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbUrunGrubu);
        }

        // GET: tbUrunGrubu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUrunGrubu tbUrunGrubu = db.tbUrunGrubu.Find(id);
            if (tbUrunGrubu == null)
            {
                return HttpNotFound();
            }
            return View(tbUrunGrubu);
        }

        // POST: tbUrunGrubu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbUrunGrubu tbUrunGrubu = db.tbUrunGrubu.Find(id);
            db.tbUrunGrubu.Remove(tbUrunGrubu);
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
