using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_stok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVC_stok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        denemeEntities db = new denemeEntities();
        public ActionResult Index(int sayfa = 1)
        {
            //var deger = db.tbl_kategoriler.ToList();
            var deger = db.tbl_kategoriler.ToList().ToPagedList(sayfa, 8);
            return View(deger);
        }

        [HttpGet]
        public ActionResult Kategoriadd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kategoriadd(tbl_kategoriler p1)
        {
            db.tbl_kategoriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var kategori = db.tbl_kategoriler.Find(id);
            db.tbl_kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Kategoriupdate(int id)
        {
            var ktgr = db.tbl_kategoriler.Find(id);
            return View("Kategoriupdate", ktgr);
        }

        public ActionResult Update(tbl_kategoriler p1)
        {
            var ktg = db.tbl_kategoriler.Find(p1.kategori_id);
            ktg.kategori_ad = p1.kategori_ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}