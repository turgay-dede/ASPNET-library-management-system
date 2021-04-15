using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PanelController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Panel
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];
            var kullanici = db.TBLUYELER.FirstOrDefault(x => x.MAIL == mail);
            return View(kullanici);
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
    }
}