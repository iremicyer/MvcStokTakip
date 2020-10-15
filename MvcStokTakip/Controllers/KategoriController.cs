using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokTakip.Models.Entity; // modelin kütüphane olarak tanımlanması
using PagedList;
using PagedList.Mvc;

namespace MvcStokTakip.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        StokTakipMVCEntities db = new StokTakipMVCEntities(); // entity klasörü içinde bulunan modelin tanımlanması
        public ActionResult Index(int sayfa = 1)
        {

            var degerler = db.TblKategorıler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet] // sayfa ilk defa yükleniyorsa
        public ActionResult YeniKategori()
        {

            return View();
        }

        [HttpPost] // sayfaya herhangi bir post işlemi yapıldığı zaman aşağıdaki işlemi gerçekleştirir
        public ActionResult YeniKategori(TblKategorıler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TblKategorıler.Add(p1); // veri tabanındaki kategoriler tablosuna p1 parametresinin eklenmesi
            db.SaveChanges();
            return View();

        }
        public ActionResult SIL(int id)
        {
            var kategori = db.TblKategorıler.Find(id);
            db.TblKategorıler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TblKategorıler.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(TblKategorıler p1)
        {
            var ktg = db.TblKategorıler.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}