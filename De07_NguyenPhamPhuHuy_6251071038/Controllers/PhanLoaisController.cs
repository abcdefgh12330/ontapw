using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using De07_NguyenPhamPhuHuy_6251071038;

namespace De07_NguyenPhamPhuHuy_6251071038.Controllers
{
    public class PhanLoaisController : Controller
    {
        private QLBanChauCanhEntities1 db = new QLBanChauCanhEntities1();

        // GET: PhanLoais
        public async Task<ActionResult> Index()
        {
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
            var products = db.SanPhams
                            .Where(sp => sp.PhanLoai.PhanLoaiChinh == phanLoai)
                            .ToList();
            List<SanPham> _product = products.Select(sp => new SanPham
                                            {
                                                MaSanPham = sp.MaSanPham,
                                                TenSanPham = sp.TenSanPham,
                                                AnhDaiDien = sp.AnhDaiDien,
                                                DonGiaBanNhoNhat = sp.DonGiaBanNhoNhat
                                            }).ToList();
            return Json( new { product = _product }, JsonRequestBehavior.AllowGet);
        }
    }
}
