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
    public class KhoController : Controller
    {
        private ShopDienThoaiEntities db = new ShopDienThoaiEntities();

        // GET: Cms/Kho
        public ActionResult Index()
        {
            var tb_Kho = db.Tb_Kho.Include(t => t.Tb_SanPham);
            return View(tb_Kho.ToList());
        }

        // GET: Cms/Kho/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_Kho tb_Kho = db.Tb_Kho.Find(id);
            if (tb_Kho == null)
            {
                return HttpNotFound();
            }
            return View(tb_Kho);
        }

        // GET: Cms/Kho/Create
        public ActionResult Create()
        {
            ViewBag.IdSanPham = new SelectList(db.Tb_SanPham, "Id", "TenSanPham");
            return View();
        }

        // POST: Cms/Kho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdSanPham,SoLuong")] Tb_Kho tb_Kho)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Kho.Add(tb_Kho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSanPham = new SelectList(db.Tb_SanPham, "Id", "TenSanPham", tb_Kho.IdSanPham);
            return View(tb_Kho);
        }

        // GET: Cms/Kho/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_Kho tb_Kho = db.Tb_Kho.Find(id);
            if (tb_Kho == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSanPham = new SelectList(db.Tb_SanPham, "Id", "TenSanPham", tb_Kho.IdSanPham);
            return View(tb_Kho);
        }

        // POST: Cms/Kho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdSanPham,SoLuong")] Tb_Kho tb_Kho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Kho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSanPham = new SelectList(db.Tb_SanPham, "Id", "TenSanPham", tb_Kho.IdSanPham);
            return View(tb_Kho);
        }

        // GET: Cms/Kho/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_Kho tb_Kho = db.Tb_Kho.Find(id);
            if (tb_Kho == null)
            {
                return HttpNotFound();
            }
            return View(tb_Kho);
        }

        // POST: Cms/Kho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tb_Kho tb_Kho = db.Tb_Kho.Find(id);
            db.Tb_Kho.Remove(tb_Kho);
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
