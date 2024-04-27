using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_ogrenci_kayit.Models.Entity;
namespace mvc_ogrenci_kayit.Controllers
{
    public class GuvenlikController : Controller
    {
        // GET: Guvenlik
        MvcDbVizeEntities1 db = new MvcDbVizeEntities1();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLKULLANICI t)
        {
            return View();
        }
    }
}