using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using De01_NguyenPhamPhuHuy_CNTT_6251071038;


namespace De01_NguyenPhamPhuHuy_CNTT_6251071038.Controllers
{
    public class PhanLoaisController : Controller
    {
        private QLBanHangQuanAoEntities db = new QLBanHangQuanAoEntities();

        // GET: PhanLoais
        public async Task<ActionResult> Index()
        {
            var sanPhams = await db.SanPhams.ToListAsync();
            ViewBag.sanPhams = sanPhams;
            return View(await db.PhanLoais.ToListAsync());
        }

        // GET: PhanLoais/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanLoai phanLoai = await db.PhanLoais.FindAsync(id);
            if (phanLoai == null)
            {
                return HttpNotFound();
            }
            return View(phanLoai);
        }

        // GET: PhanLoais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhanLoais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaPhanLoai,PhanLoaiChinh")] PhanLoai phanLoai)
        {
            if (ModelState.IsValid)
            {
                db.PhanLoais.Add(phanLoai);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(phanLoai);
        }

        // GET: PhanLoais/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanLoai phanLoai = await db.PhanLoais.FindAsync(id);
            if (phanLoai == null)
            {
                return HttpNotFound();
            }
            return View(phanLoai);
        }

        // POST: PhanLoais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaPhanLoai,PhanLoaiChinh")] PhanLoai phanLoai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phanLoai).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(phanLoai);
        }

        // GET: PhanLoais/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanLoai phanLoai = await db.PhanLoais.FindAsync(id);
            if (phanLoai == null)
            {
                return HttpNotFound();
            }
            return View(phanLoai);
        }

        // POST: PhanLoais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            PhanLoai phanLoai = await db.PhanLoais.FindAsync(id);
            db.PhanLoais.Remove(phanLoai);
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

        public async Task<ActionResult> GetProductsByCategory(string phanLoai)
        {
            List<SanPham> products = null;
            if (phanLoai == null || phanLoai == "Tất cả sản phẩm")
            {
                products = await db.SanPhams.ToListAsync();
            }
            else 
            {
                products = await db.SanPhams
                            .Where(sp => sp.PhanLoai.PhanLoaiChinh == phanLoai)
                            .ToListAsync();
            } 
            var _sanPham = products
                .Select(sp => new SanPham
                {
                    MaSanPham = sp.MaSanPham,
                    TenSanPham = sp.TenSanPham,
                    DonGiaBanNhoNhat = sp.DonGiaBanNhoNhat,
                    TrangThai = sp.TrangThai,
                    MoTaNgan = sp.MoTaNgan,
                    AnhDaiDien = sp.AnhDaiDien,
                    NoiBat = sp.NoiBat,
                    MaPhanLoaiPhu = sp.MaPhanLoaiPhu,
                    MaPhanLoai = sp.MaPhanLoai,
                    GiaNhap = sp.GiaNhap
                }).ToList();
            return Json(new { sanPham = _sanPham }, JsonRequestBehavior.AllowGet);
        }
    }
}
