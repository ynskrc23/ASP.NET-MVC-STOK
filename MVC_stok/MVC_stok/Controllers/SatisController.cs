using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_stok.Models.Entity;

namespace MVC_stok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        denemeEntities db = new denemeEntities();
        public ActionResult Index()
        {     
            return View(deger);          
        }

        [HttpGet]
        public ActionResult Newsatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Newsatis(tbl_satislar p1)
        {
            db.tbl_satislar.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}