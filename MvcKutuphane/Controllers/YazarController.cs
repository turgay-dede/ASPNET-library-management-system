﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    
    public class YazarController : Controller
    {

        // GET: Yazar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLYAZAR.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(TBLYAZAR yzr)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TBLYAZAR.Add(yzr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarSil(int id)
        {
            var yazar = db.TBLYAZAR.Find(id);
            db.TBLYAZAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            var yazar = db.TBLYAZAR.Find(id);
            return View("YazarGetir", yazar);

        }

        public ActionResult YazarGuncelle(TBLYAZAR yzr)
        {
            var yazar = db.TBLYAZAR.Find(yzr.ID);
            yazar.AD = yzr.AD;
            yazar.SOYAD = yzr.SOYAD;
            yazar.DETAY = yzr.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}