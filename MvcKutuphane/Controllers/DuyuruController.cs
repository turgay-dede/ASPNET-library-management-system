using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;


namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var duyurular = db.TBLDUYURULAR.ToList();
            return View(duyurular);
        }
        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DuyuruEkle(TBLDUYURULAR d)
        {
            db.TBLDUYURULAR.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TBLDUYURULAR.Find(id);
            db.TBLDUYURULAR.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruDetay(TBLDUYURULAR d)
        {
            var duyuru = db.TBLDUYURULAR.Find(d.ID);
            return View("DuyuruDetay", duyuru);
        }

        [HttpPost]
        public ActionResult DuyuruGuncelle(TBLDUYURULAR d)
        {
            var duyuru = db.TBLDUYURULAR.Find(d.ID);
            duyuru.KATEGORI = d.KATEGORI;
            duyuru.ICERIK = d.ICERIK;
            duyuru.TARIH = d.TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}