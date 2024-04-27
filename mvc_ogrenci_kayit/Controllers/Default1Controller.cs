using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvc_ogrenci_kayit.Models.Entity ;

namespace mvc_ogrenci_kayit.Controllers
{
    public class Default1Controller : Controller
    {
        private MvcDbVizeEntities1 db = new MvcDbVizeEntities1();

        // GET: Default1
        public ActionResult Index()
        {
            return View(db.TBLOGRENCILERs.ToList());
        }

        // GET: Default1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLOGRENCILER table = db.TBLOGRENCILERs.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        // GET: Default1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ogrid,OgrAd,OgrSoyad,OgrNo,OgrBolum")] TBLOGRENCILER table)
        {
            if (ModelState.IsValid)
            {
                db.TBLOGRENCILERs.Add(table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table);
        }

        // GET: Default1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLOGRENCILER table = db.TBLOGRENCILERs.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        // POST: Default1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrId,OgrAd,OgrSoyad,OgrNo")] TBLOGRENCILER table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table);
        }

        // GET: Default1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLOGRENCILER table = db.TBLOGRENCILERs.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        // POST: Default1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBLOGRENCILER table = db.TBLOGRENCILERs.Find(id);
            db.TBLOGRENCILERs.Remove(table);
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
