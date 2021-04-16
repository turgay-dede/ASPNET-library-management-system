using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
   
    public class KayitController : Controller
    {
        // GET: Kayit
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(TBLUYELER uye)
        {
            if (!ModelState.IsValid)
            {
                return View("KayitOl");
            }
            db.TBLUYELER.Add(uye);
            db.SaveChanges();

            return View();
        }
    }
}