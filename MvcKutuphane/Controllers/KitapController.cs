using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TBLKİTAP select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(x => x.AD.Contains(p));
            }
            //var kitaplar = db.TBLKİTAP.ToList();
            return View(kitaplar.ToList());
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> kategori = (from i in db.TBLKATEGORİ.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.ktg = kategori;
            List<SelectListItem> yazar = (from i in db.TBLYAZAR.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.AD+' '+i.SOYAD,
                                              Value = i.ID.ToString()
                                          }).ToList();
            ViewBag.yzr = yazar;
             return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(TBLKİTAP ktp)
        {
            var kategori = db.TBLKATEGORİ.Where(k => k.ID == ktp.TBLKATEGORİ.ID).FirstOrDefault();
            var yazar = db.TBLYAZAR.Where(y => y.ID == ktp.TBLYAZAR.ID).FirstOrDefault();
            ktp.TBLKATEGORİ = kategori;
            ktp.TBLYAZAR = yazar;
            db.TBLKİTAP.Add(ktp);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var kitap = db.TBLKİTAP.Find(id);
            db.TBLKİTAP.Remove(kitap);
            db.SaveChanges();         

            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var kitap = db.TBLKİTAP.Find(id);
            List<SelectListItem> kategori = (from i in db.TBLKATEGORİ.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.AD,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.ktg = kategori;
            List<SelectListItem> yazar = (from i in db.TBLYAZAR.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.AD + ' ' + i.SOYAD,
                                              Value = i.ID.ToString()
                                          }).ToList();
            ViewBag.yzr = yazar;

            return View("KitapGetir", kitap);

        }
        [HttpPost]
        public ActionResult KitapGuncelle(TBLKİTAP ktp)
        {
            var kitap = db.TBLKİTAP.Find(ktp.ID);
            var kategori = db.TBLKATEGORİ.Where(k => k.ID == ktp.TBLKATEGORİ.ID).FirstOrDefault();
            var yazar = db.TBLYAZAR.Where(y => y.ID == ktp.TBLYAZAR.ID).FirstOrDefault();
            kitap.AD = ktp.AD;
            kitap.KATEGORI = kategori.ID;
            kitap.YAZAR = yazar.ID;
            kitap.BASIMYIL = ktp.BASIMYIL;
            kitap.YAYINEVI = ktp.YAYINEVI;
            kitap.SAYFA = ktp.SAYFA;

            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}