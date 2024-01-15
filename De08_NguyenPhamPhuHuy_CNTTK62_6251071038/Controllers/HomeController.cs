using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace De08_NguyenPhamPhuHuy_CNTTK62_6251071038.Controllers
{
    public class HomeController : Controller
    {
        QLBanChauCanhEntities db = new QLBanChauCanhEntities();
        public ActionResult Index()
        {
            var phanLoaiPhus = db.PhanLoaiPhus.ToList(); 
            var sanPhams = db.SanPhams.ToList();
            ViewBag.sanPhams = sanPhams;
            ViewBag.phanLoaiPhus = phanLoaiPhus;
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