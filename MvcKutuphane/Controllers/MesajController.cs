using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var mail = Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.ALICI == mail.ToString()).ToList();
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR msj)
        {
            db.TBLMESAJLAR.Add(msj);
            db.SaveChanges();
            return RedirectToAction("Giden", "Mesaj");
        }

        public ActionResult Giden()
        {
            var mail = Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.GONDEREN == mail.ToString()).ToList();
            return View(mesajlar);
        }

    }
}