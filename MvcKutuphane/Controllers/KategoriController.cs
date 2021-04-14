using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORİ.Where(k => k.DURUM == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORİ ktg)
        {
            db.TBLKATEGORİ.Add(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEGORİ.Find(id);
            //db.TBLKATEGORİ.Remove(kategori);
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBLKATEGORİ.Find(id);
            return View("KategoriGetir", kategori);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(TBLKATEGORİ ktg)
        {
            var kategori = db.TBLKATEGORİ.Find(ktg.ID);
            kategori.AD = ktg.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}