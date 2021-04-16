using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class AyarlarController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Ayarlar
        [HttpGet]
        public ActionResult Index()
        {
            var admin = db.TBLADMIN.ToList();
            return View(admin);
        }
        [HttpPost]
        public ActionResult YeniAdmin(TBLADMIN a)
        {
            db.TBLADMIN.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            var admin = db.TBLADMIN.Find(id);
            db.TBLADMIN.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult AdminGuncelle(int id)
        {
            var admin = db.TBLADMIN.Find(id);

            return View("AdminGuncelle", admin);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(TBLADMIN a)
        {
            var admin = db.TBLADMIN.Find(a.ID);
            admin.KULLANICI = a.KULLANICI;
            admin.SIFRE = a.SIFRE;
            admin.YETKI = a.YETKI;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}