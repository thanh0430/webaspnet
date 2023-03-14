using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using baitapcuoimonweb.Models;

namespace baitapcuoimonweb.Areas.Cms.Controllers
{
    public class PhieuNhapController : Controller
    {
        private ShopDienThoaiEntities db = new ShopDienThoaiEntities();

        // GET: Cms/PhieuNhap
        public ActionResult Index()
        {
            var tb_PhieuNhap = db.Tb_PhieuNhap.Include(t => t.Tb_Kho).Include(t => t.Tb_Kho1).Include(t => t.Tb_NhaCungCap).Include(t => t.Tb_NhanVien);
            return View(tb_PhieuNhap.ToList());
        }

        // GET: Cms/PhieuNhap/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_PhieuNhap tb_PhieuNhap = db.Tb_PhieuNhap.Find(id);
            if (tb_PhieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(tb_PhieuNhap);
        }

        // GET: Cms/PhieuNhap/Create
        public ActionResult Create()
        {
            ViewBag.IdKho = new SelectList(db.Tb_Kho, "Id", "Id");
            ViewBag.IdKho = new SelectList(db.Tb_Kho, "Id", "Id");
            ViewBag.NhaCungCap = new SelectList(db.Tb_NhaCungCap, "Id", "TenNhaCungCap");
            ViewBag.IdNhanVien = new SelectList(db.Tb_NhanVien, "Id", "TenNV");
            return View();
        }

        // POST: Cms/PhieuNhap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdNhanVien,IdSanPham,IdKho,TongTien,NhaCungCap")] Tb_PhieuNhap tb_PhieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.Tb_PhieuNhap.Add(tb_PhieuNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdKho = new SelectList(db.Tb_Kho, "Id", "Id", tb_PhieuNhap.IdKho);
            ViewBag.IdKho = new SelectList(db.Tb_Kho, "Id", "Id", tb_PhieuNhap.IdKho);
            ViewBag.NhaCungCap = new SelectList(db.Tb_NhaCungCap, "Id", "TenNhaCungCap", tb_PhieuNhap.NhaCungCap);
            ViewBag.IdNhanVien = new SelectList(db.Tb_NhanVien, "Id", "TenNV", tb_PhieuNhap.IdNhanVien);
            return View(tb_PhieuNhap);
        }

        // GET: Cms/PhieuNhap/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_PhieuNhap tb_PhieuNhap = db.Tb_PhieuNhap.Find(id);
            if (tb_PhieuNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdKho = new SelectList(db.Tb_Kho, "Id", "Id", tb_PhieuNhap.IdKho);
            ViewBag.IdKho = new SelectList(db.Tb_Kho, "Id", "Id", tb_PhieuNhap.IdKho);
            ViewBag.NhaCungCap = new SelectList(db.Tb_NhaCungCap, "Id", "TenNhaCungCap", tb_PhieuNhap.NhaCungCap);
            ViewBag.IdNhanVien = new SelectList(db.Tb_NhanVien, "Id", "TenNV", tb_PhieuNhap.IdNhanVien);
            return View(tb_PhieuNhap);
        }

        // POST: Cms/PhieuNhap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdNhanVien,IdSanPham,IdKho,TongTien,NhaCungCap")] Tb_PhieuNhap tb_PhieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_PhieuNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdKho = new SelectList(db.Tb_Kho, "Id", "Id", tb_PhieuNhap.IdKho);
            ViewBag.IdKho = new SelectList(db.Tb_Kho, "Id", "Id", tb_PhieuNhap.IdKho);
            ViewBag.NhaCungCap = new SelectList(db.Tb_NhaCungCap, "Id", "TenNhaCungCap", tb_PhieuNhap.NhaCungCap);
            ViewBag.IdNhanVien = new SelectList(db.Tb_NhanVien, "Id", "TenNV", tb_PhieuNhap.IdNhanVien);
            return View(tb_PhieuNhap);
        }

        // GET: Cms/PhieuNhap/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_PhieuNhap tb_PhieuNhap = db.Tb_PhieuNhap.Find(id);
            if (tb_PhieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(tb_PhieuNhap);
        }

        // POST: Cms/PhieuNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tb_PhieuNhap tb_PhieuNhap = db.Tb_PhieuNhap.Find(id);
            db.Tb_PhieuNhap.Remove(tb_PhieuNhap);
            db.SaveChanges();
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
    }
}
