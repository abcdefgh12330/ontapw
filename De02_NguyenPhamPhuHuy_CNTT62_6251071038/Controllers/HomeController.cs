using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace De02_NguyenPhamPhuHuy_CNTT62_6251071038.Controllers
{
    public class HomeController : Controller
    {
        QLBanHangQuanAoEntities db = new QLBanHangQuanAoEntities();
        public ActionResult Index()
        {
            var phanLoaiPhu = db.PhanLoaiPhus.ToList();
            var sps = db.SanPhams.ToList();
            ViewBag.sanPhams = sps;
            ViewBag.phanLoaiPhu = phanLoaiPhu;
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