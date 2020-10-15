using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokTakip.Models.Entity;
namespace MvcStokTakip.Controllers
{


    public class SatislarController : Controller
    {
        // GET: Satislar
        StokTakipMVCEntities db = new StokTakipMVCEntities(); // entity klasörü içinde bulunan modelin tanımlanması
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();

        }

        [HttpPost]
        public ActionResult YeniSatis(TblSatıslar p1)
        {
            db.TblSatıslar.Add(p1);
            db.SaveChanges();
            return View("Index");
        }
    }
}
