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
    public class UrunController : Controller
    {
        // GET: Urun
        denemeEntities db = new denemeEntities();
        public ActionResult Index(int sayfa = 1)
        {
            //var deger = db.tbl_urunler.ToList();
            var deger = db.tbl_urunler.ToList().ToPagedList(sayfa, 8);
            return View(deger);
        }

        [HttpGet]
        public ActionResult Urunadd()
        {
           List<SelectListItem> degerler = (from i in db.tbl_kategoriler.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.kategori_ad,
                                                      Value = i.kategori_id.ToString()
                                                  }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult Urunadd(tbl_urunler p1)
        {
            var ktg = db.tbl_kategoriler.Where(m => m.kategori_id == p1.tbl_kategoriler.kategori_id).FirstOrDefault();
            p1.tbl_kategoriler = ktg;
            db.tbl_urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var urunler = db.tbl_urunler.Find(id);
            db.tbl_urunler.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Urunupdate(int id)
        {
            var urun = db.tbl_urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.tbl_kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategori_ad,
                                                 Value = i.kategori_id.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("Urunupdate", urun);
        }

        public ActionResult Update(tbl_urunler p1)
        {
            var urun = db.tbl_urunler.Find(p1.urun_id);
            urun.urun_ad = p1.urun_ad;
            urun.urun_marka = p1.urun_marka;
            urun.urun_stok = p1.urun_stok;
            urun.urun_fiyat = p1.urun_fiyat;
            var ktg = db.tbl_kategoriler.Where(m => m.kategori_id == p1.tbl_kategoriler.kategori_id).FirstOrDefault();
            urun.urun_kategori = ktg.kategori_id;
            //urun.urun_kategori = p1.urun_kategori;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}