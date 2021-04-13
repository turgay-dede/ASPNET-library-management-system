using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var haraket = db.TBLHAREKET.Where(x=>x.ISLEMDURUM==false).ToList();
            return View(haraket);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET h)
        {
            db.TBLHAREKET.Add(h);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OduncIade(TBLHAREKET h)
        {
            var odunc = db.TBLHAREKET.Find(h.ID);
            DateTime d1 = DateTime.Parse(odunc.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("OduncIade", odunc);
        }
        public ActionResult OduncGuncelle(TBLHAREKET h)
        {
            var hareket = db.TBLHAREKET.Find(h.ID);
            hareket.UYEGETIRTARIH = h.UYEGETIRTARIH;
            hareket.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}