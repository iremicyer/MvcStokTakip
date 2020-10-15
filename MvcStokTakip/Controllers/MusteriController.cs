using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokTakip.Models.Entity;

namespace MvcStokTakip.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        StokTakipMVCEntities db = new StokTakipMVCEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TblMusterıler select d; // linq sorgusu.
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }

            return View(degerler.ToList());
            // var degerler = db.TblMusterıler.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TblMusterıler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");

            }
            db.TblMusterıler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteriler = db.TblMusterıler.Find(id);
            db.TblMusterıler.Remove(musteriler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TblMusterıler.Find(id);
            return View("MusteriGetir", musteri);
        }
        public ActionResult Guncelle(TblMusterıler p1)
        {
            var musteri = db.TblMusterıler.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}