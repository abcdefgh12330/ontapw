using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace De07_NguyenPhamPhuHuy_6251071038.Controllers
{
    public class HomeController : Controller
    {
        QLBanChauCanhEntities1 db = new QLBanChauCanhEntities1();
        public ActionResult Index()
        {
            var phanLoai = db.PhanLoais.ToList();
            var allProducts = db.SanPhams.ToList();
            ViewBag.phanLoai = phanLoai;
            ViewBag.allProducts = allProducts; 
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}