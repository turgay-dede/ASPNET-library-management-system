using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflarim;

namespace MvcKutuphane.Controllers
{
    public class IstatistikController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Istatistik
        public ActionResult Index()
        {
            var uyeSayisi = db.TBLUYELER.Count();
            ViewBag.uye= uyeSayisi;
            var kitapSayisi = db.TBLKİTAP.Count();
            ViewBag.kitap = kitapSayisi;
            var emanetKitapSayisi = db.TBLKİTAP.Where(x => x.DURUM == false).Count();
            ViewBag.emanet = emanetKitapSayisi;
            var kasa =db.TBLCEZALAR.Sum(x => x.PARA);
            ViewBag.kasa = kasa;

            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength>0)
            {
                string dosyaYolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyaYolu);

            }
            return RedirectToAction("Galeri");
        }

        public ActionResult LinqKart()
        {
            var kitapSayisi = db.TBLKİTAP.Count();
            ViewBag.kitapSayisi = kitapSayisi;

            var uyeSayisi = db.TBLUYELER.Count();
            ViewBag.uyeSayisi = uyeSayisi;

            var kasaTutar = db.TBLCEZALAR.Sum(x => x.PARA);
            ViewBag.kasaTutar = kasaTutar;

            var oduncKitap = db.TBLKİTAP.Where(x => x.DURUM == false).Count();
            ViewBag.oduncKitap = oduncKitap;

            var kategoriSayisi = db.TBLKATEGORİ.Count();
            ViewBag.kategoriSayisi = kategoriSayisi;

            var yazarKitapSayisi = db.EnFazlaKitapYazar().FirstOrDefault();
            ViewBag.yazarKitapSayisi = yazarKitapSayisi;

            var yayinevi = db.TBLKİTAP.GroupBy(x => x.YAYINEVI).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
            ViewBag.yayinevi = yayinevi;
            return View();
        }
    }
}