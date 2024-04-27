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
    public class İdariController : Controller
    {
        private MvcDbVizeEntities1 db = new MvcDbVizeEntities1();

        // GET: İdari
        public ActionResult Index()
        {
            return View(db.TBLIDARIs.ToList());
        }

        // GET: İdari/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLIDARI tBLIDARI = db.TBLIDARIs.Find(id);
            if (tBLIDARI == null)
            {
                return HttpNotFound();
            }
            return View(tBLIDARI);
        }

        // GET: İdari/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: İdari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idid,idAd,idSoyad,idBirimi")] TBLIDARI tBLIDARI)
        {
            if (ModelState.IsValid)
            {
                db.TBLIDARIs.Add(tBLIDARI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBLIDARI);
        }

        // GET: İdari/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLIDARI tBLIDARI = db.TBLIDARIs.Find(id);
            if (tBLIDARI == null)
            {
                return HttpNotFound();
            }
            return View(tBLIDARI);
        }

        // POST: İdari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idid,idAd,idSoyad,idBirimi")] TBLIDARI tBLIDARI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBLIDARI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBLIDARI);
        }

        // GET: İdari/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLIDARI tBLIDARI = db.TBLIDARIs.Find(id);
            if (tBLIDARI == null)
            {
                return HttpNotFound();
            }
            return View(tBLIDARI);
        }

        // POST: İdari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            TBLIDARI tBLIDARI = db.TBLIDARIs.Find(id);
            db.TBLIDARIs.Remove(tBLIDARI);
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
