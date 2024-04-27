using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvc_ogrenci_kayit.Models.Entity;

namespace mvc_ogrenci_kayit.Controllers
{
    public class AkademiController : Controller
    {
        private MvcDbVizeEntities1 db = new MvcDbVizeEntities1();

        // GET: Akademi
        public ActionResult Index()
        {
            return View(db.TBLAKAs.ToList());
        }

        // GET: Akademi/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLAKA tBLAKA = db.TBLAKAs.Find(id);
            if (tBLAKA == null)
            {
                return HttpNotFound();
            }
            return View(tBLAKA);
        }

        // GET: Akademi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Akademi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Akaid,AkaAd,AkaSoyad,AkaBolum")] TBLAKA tBLAKA)
        {
            if (ModelState.IsValid)
            {
                db.TBLAKAs.Add(tBLAKA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBLAKA);
        }

        // GET: Akademi/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLAKA tBLAKA = db.TBLAKAs.Find(id);
            if (tBLAKA == null)
            {
                return HttpNotFound();
            }
            return View(tBLAKA);
        }

        // POST: Akademi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Akaid,AkaAd,AkaSoyad,AkaBolum")] TBLAKA tBLAKA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBLAKA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBLAKA);
        }

        // GET: Akademi/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLAKA tBLAKA = db.TBLAKAs.Find(id);
            if (tBLAKA == null)
            {
                return HttpNotFound();
            }
            return View(tBLAKA);
        }

        // POST: Akademi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            TBLAKA tBLAKA = db.TBLAKAs.Find(id);
            db.TBLAKAs.Remove(tBLAKA);
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
