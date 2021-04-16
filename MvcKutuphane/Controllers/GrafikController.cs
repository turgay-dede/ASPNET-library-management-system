using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class GrafikController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeKitapResult()
        {
            return Json(liste());
        }

        public List<Class1> liste()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                yayinevi = "Günes",
                sayi = 7
            });
            cs.Add(new Class1()
            {
                yayinevi = "Yildiz",
                sayi = 3
            });
            cs.Add(new Class1()
            {
                yayinevi = "Mars",
                sayi = 4
            });
            cs.Add(new Class1()
            {
                yayinevi = "Jupiter",
                sayi = 5
            });
            return cs;
        }
    }
}