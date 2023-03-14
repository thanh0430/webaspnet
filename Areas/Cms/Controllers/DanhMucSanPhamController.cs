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
    [Authorize]
    public class DanhMucSanPhamController : Controller
    {
        private ShopDienThoaiEntities db = new ShopDienThoaiEntities();

        // GET: Cms/DanhMucSanPham
        public ActionResult Index()
        {
            return View(db.Tb_DanhMucSanPham.ToList());
        }

        // GET: Cms/DanhMucSanPham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_DanhMucSanPham tb_DanhMucSanPham = db.Tb_DanhMucSanPham.Find(id);
            if (tb_DanhMucSanPham == null)
            {
                return HttpNotFound();
            }
            return View(tb_DanhMucSanPham);
        }

        // GET: Cms/DanhMucSanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cms/DanhMucSanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LoaiSanPham,anhdanhmuc,HangSanXuat")] Tb_DanhMucSanPham tb_DanhMucSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Tb_DanhMucSanPham.Add(tb_DanhMucSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_DanhMucSanPham);
        }

        // GET: Cms/DanhMucSanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_DanhMucSanPham tb_DanhMucSanPham = db.Tb_DanhMucSanPham.Find(id);
            if (tb_DanhMucSanPham == null)
            {
                return HttpNotFound();
            }
            return View(tb_DanhMucSanPham);
        }

        // POST: Cms/DanhMucSanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LoaiSanPham,anhdanhmuc,HangSanXuat")] Tb_DanhMucSanPham tb_DanhMucSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_DanhMucSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_DanhMucSanPham);
        }

        // GET: Cms/DanhMucSanPham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_DanhMucSanPham tb_DanhMucSanPham = db.Tb_DanhMucSanPham.Find(id);
            if (tb_DanhMucSanPham == null)
            {
                return HttpNotFound();
            }
            return View(tb_DanhMucSanPham);
        }

        // POST: Cms/DanhMucSanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tb_DanhMucSanPham tb_DanhMucSanPham = db.Tb_DanhMucSanPham.Find(id);
            db.Tb_DanhMucSanPham.Remove(tb_DanhMucSanPham);
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
