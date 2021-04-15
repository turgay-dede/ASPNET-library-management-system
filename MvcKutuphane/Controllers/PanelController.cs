using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Panel
        [HttpGet]
        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];
            // var kullanici = db.TBLUYELER.FirstOrDefault(x => x.MAIL == mail);
            var duyurular = db.TBLDUYURULAR.ToList();

            var ad = db.TBLUYELER.Where(x => x.MAIL == mail).Select(y => y.AD).FirstOrDefault();
            ViewBag.ad = ad;

            var soyad = db.TBLUYELER.Where(x => x.MAIL == mail).Select(y => y.SOYAD).FirstOrDefault();
            ViewBag.soyad = soyad;

            var okul = db.TBLUYELER.Where(x => x.MAIL == mail).Select(y => y.OKUL).FirstOrDefault();
            ViewBag.okul = okul;

            var tel = db.TBLUYELER.Where(x => x.MAIL == mail).Select(y => y.TELEFON).FirstOrDefault();
            ViewBag.tel = tel;

            var uyeID = db.TBLUYELER.Where(x => x.MAIL == mail).Select(y => y.ID).FirstOrDefault();
            var kitapSayisi = db.TBLHAREKET.Where(x => x.UYE == uyeID).Count();
            ViewBag.kitapSayisi = kitapSayisi;

            var gelenMesaj = db.TBLMESAJLAR.Where(x => x.ALICI == mail).Count();
            ViewBag.gelenMesaj = gelenMesaj;


            var duyuru = db.TBLDUYURULAR.Count();
            ViewBag.duyuru = duyuru;

            return View(duyurular);
        }
        [HttpPost]
        public ActionResult ProfilGuncelle(TBLUYELER uye)
        {
            var mail = (string)Session["Mail"];
            var kullanici = db.TBLUYELER.FirstOrDefault(x => x.MAIL == mail);
            kullanici.AD = uye.AD;
            kullanici.SOYAD= uye.SOYAD;
            kullanici.KULLANICIADI = uye.KULLANICIADI;
            kullanici.SIFRE = uye.SIFRE;
            kullanici.OKUL = uye.OKUL;
            kullanici.FOTOGRAF = uye.FOTOGRAF;
            db.SaveChanges();
            return View("Index");
        }

        public ActionResult Kitaplarim()
        {
            var mail = (string)Session["Mail"];
            var id = db.TBLUYELER.Where(x => x.MAIL == mail.ToString()).Select(z => z.ID).FirstOrDefault();
            var islem = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            return View(islem);
        }
        public ActionResult Duyurular()
        {
            var duyurular = db.TBLDUYURULAR.ToList();
            return View(duyurular);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Vitrin");
        }

        public PartialViewResult PartialDuyuru()
        {

            return PartialView();
        }
        public PartialViewResult PartialAyarlar()
        {
            var mail = (string)Session["Mail"];
            var id = db.TBLUYELER.Where(x => x.MAIL == mail).Select(y => y.ID).FirstOrDefault();
            var uye = db.TBLUYELER.Find(id);
            return PartialView(uye);
        }
    }
}