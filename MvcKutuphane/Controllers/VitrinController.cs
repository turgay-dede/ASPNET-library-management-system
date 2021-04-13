using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflarim;


namespace MvcKutuphane.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [HttpGet]
        public ActionResult Index()
        {
            VitrinModelView vitrinModelView = new VitrinModelView();
            vitrinModelView.Kitap = db.TBLKİTAP.ToList();
            vitrinModelView.Hakkimizda = db.TBLHAKKIMIZDA.ToList();
            //var kitaplar = db.TBLKİTAP.ToList();
            return View(vitrinModelView);
        }
        [HttpPost]
        public ActionResult Index(TBLILETISIM iletisim)
        {
            db.TBLILETISIM.Add(iletisim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}