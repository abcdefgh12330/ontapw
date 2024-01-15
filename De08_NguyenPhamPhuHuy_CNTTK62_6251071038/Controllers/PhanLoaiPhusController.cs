using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using De08_NguyenPhamPhuHuy_CNTTK62_6251071038;

namespace De08_NguyenPhamPhuHuy_CNTTK62_6251071038.Controllers
{
    public class PhanLoaiPhusController : Controller
    {
        private QLBanChauCanhEntities db = new QLBanChauCanhEntities();

        // GET: PhanLoaiPhus
        public async Task<ActionResult> Index()
        {
            return View(await db.PhanLoaiPhus.ToListAsync());
        }

        // GET: PhanLoaiPhus/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanLoaiPhu phanLoaiPhu = await db.PhanLoaiPhus.FindAsync(id);
            if (phanLoaiPhu == null)
            {
                return HttpNotFound();
            }
            return View(phanLoaiPhu);
        }

        // GET: PhanLoaiPhus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhanLoaiPhus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaPhanLoaiPhu,TenPhanLoaiPhu,MaPhanLoai")] PhanLoaiPhu phanLoaiPhu)
        {
            if (ModelState.IsValid)
            {
                db.PhanLoaiPhus.Add(phanLoaiPhu);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(phanLoaiPhu);
        }

        // GET: PhanLoaiPhus/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanLoaiPhu phanLoaiPhu = await db.PhanLoaiPhus.FindAsync(id);
            if (phanLoaiPhu == null)
            {
                return HttpNotFound();
            }
            return View(phanLoaiPhu);
        }

        // POST: PhanLoaiPhus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaPhanLoaiPhu,TenPhanLoaiPhu,MaPhanLoai")] PhanLoaiPhu phanLoaiPhu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phanLoaiPhu).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(phanLoaiPhu);
        }

        // GET: PhanLoaiPhus/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanLoaiPhu phanLoaiPhu = await db.PhanLoaiPhus.FindAsync(id);
            if (phanLoaiPhu == null)
            {
                return HttpNotFound();
            }
            return View(phanLoaiPhu);
        }

        // POST: PhanLoaiPhus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            PhanLoaiPhu phanLoaiPhu = await db.PhanLoaiPhus.FindAsync(id);
            db.PhanLoaiPhus.Remove(phanLoaiPhu);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public async Task<ActionResult> GetProductsByCategory(string phanLoaiPhu)
        {
            List<SanPham> sps = null;
            if(phanLoaiPhu == "Tất cả sản phẩm")
            {
                sps = db.SanPhams.ToList();
            }
            else
            {
                sps= db.SanPhams
                            .Where(sp => sp.PhanLoaiPhu.TenPhanLoaiPhu == phanLoaiPhu)
                            .ToList();
            }
            
            List<SanPham> _sanPhams = sps.Select(sp => new SanPham
            {
                MaSanPham = sp.MaSanPham,
                TenSanPham = sp.TenSanPham,
                AnhDaiDien = sp.AnhDaiDien,
                DonGiaBanNhoNhat = sp.DonGiaBanNhoNhat
            }).ToList();
            return Json(new {sanPhams = _sanPhams }, JsonRequestBehavior.AllowGet);
        }
    }
}
