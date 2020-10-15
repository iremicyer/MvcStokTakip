using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MvcStokTakip.Models.Entity; // modelin kütüphane olarak eklenmesi

namespace MvcStokTakip.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        StokTakipMVCEntities db = new StokTakipMVCEntities();
        public ActionResult Index()
        {
            var degerler = db.TblUrunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            //aşağıda DropDownList ile veritabanından veri alıyoruz.
            List<SelectListItem> degerler = (from i in db.TblKategorıler.ToList() select new SelectListItem { Text = i.KATEGORIAD, Value = i.KATEGORIID.ToString() }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(TblUrunler p1)
        {
            var ktg = db.TblKategorıler.Where(m => m.KATEGORIID == p1.TblKategorıler.KATEGORIID).FirstOrDefault();
            p1.TblKategorıler = ktg;

            db.TblUrunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urunler = db.TblUrunler.Find(id);
            db.TblUrunler.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TblUrunler.Find(id);

            //aşağıda DropDownList ile veritabanından veri alıyoruz.
            List<SelectListItem> degerler = (from i in db.TblKategorıler.ToList() select new SelectListItem { Text = i.KATEGORIAD, Value = i.KATEGORIID.ToString() }).ToList();
            ViewBag.dgr = degerler;

            return View("UrunGetir", urun);
        }
        public ActionResult Guncelle(TblUrunler p1)
        {
            var urun = db.TblUrunler.Find(p1.URUNID);
            urun.URUNAD = p1.URUNAD;
            urun.MARKA = p1.MARKA;
            urun.FIYAT = p1.FIYAT;
            urun.STOK = p1.STOK;
            //urun.URUNKATEGORI = p1.URUNKATEGORI;
            var ktg = db.TblKategorıler.Where(m => m.KATEGORIID == p1.TblKategorıler.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}