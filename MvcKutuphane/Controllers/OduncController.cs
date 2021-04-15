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
            var haraket = db.TBLHAREKET.Where(x => x.ISLEMDURUM == false).ToList();
            return View(haraket);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> uyeler = (from x in db.TBLUYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD + " " + x.SOYAD,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.uyeler = uyeler;
            List<SelectListItem> kitaplar = (from x in db.TBLKİTAP.Where(x => x.DURUM == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.AD,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.kitaplar = kitaplar;
            List<SelectListItem> personeller = (from x in db.TBLPERSONEL.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PERSONEL,
                                                    Value = x.ID.ToString()
                                                }).ToList();
            ViewBag.personeller = personeller;
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET h)
        {
            var uye = db.TBLUYELER.Where(x => x.ID == h.TBLUYELER.ID).FirstOrDefault();
            var kitap = db.TBLKİTAP.Where(y => y.ID == h.TBLKİTAP.ID).FirstOrDefault();
            var personel = db.TBLPERSONEL.Where(z => z.ID == h.TBLPERSONEL.ID).FirstOrDefault();
            h.TBLUYELER = uye;
            h.TBLKİTAP = kitap;
            h.TBLPERSONEL = personel;
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