﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}