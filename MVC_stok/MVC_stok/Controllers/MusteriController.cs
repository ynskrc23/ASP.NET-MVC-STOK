using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MVC_stok.Models.Entity;

namespace MVC_stok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        denemeEntities db = new denemeEntities();
        public ActionResult Index(int sayfa = 1)
        {
            //var deger = db.tbl_musteriler.ToList();
            var deger = db.tbl_musteriler.ToList().ToPagedList(sayfa, 8);
            return View(deger);
        }

        [HttpGet]
        public ActionResult Musteriadd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Musteriadd(tbl_musteriler p1)
        {
            db.tbl_musteriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var musteriler = db.tbl_musteriler.Find(id);
            db.tbl_musteriler.Remove(musteriler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Musteriupdate(int id)
        {
            var mus = db.tbl_musteriler.Find(id);
            return View("Musteriupdate", mus);
        }

        public ActionResult Update(tbl_musteriler p1)
        {
            var musteri = db.tbl_musteriler.Find(p1.musteri_id);
            musteri.musteri_ad = p1.musteri_ad;
            musteri.musteri_soyad = p1.musteri_soyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}