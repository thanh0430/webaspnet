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
    public class HoaDonController : Controller
    {
        
        private ShopDienThoaiEntities db = new ShopDienThoaiEntities();

        // GET: Cms/HoaDon
        public ActionResult Index()
        {
            var tb_HoaDon = db.Tb_HoaDon.Include(t => t.KhachHang);
            return View(tb_HoaDon.ToList());
        }

        // GET: Cms/HoaDon/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_HoaDon tb_HoaDon = db.Tb_HoaDon.Find(id);
            if (tb_HoaDon == null)
            {
                return HttpNotFound();
            }
            return View(tb_HoaDon);
        }

        // GET: Cms/HoaDon/Create
        public ActionResult Create()
        {
            ViewBag.SDTKH = new SelectList(db.KhachHangs, "SDT", "TenKH");
            return View();
        }

        // POST: Cms/HoaDon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenKH,DiaChi,SDTKH,Tongtien,NgayBan,TrangThai")] Tb_HoaDon tb_HoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Tb_HoaDon.Add(tb_HoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SDTKH = new SelectList(db.KhachHangs, "SDT", "TenKH", tb_HoaDon.SDTKH);
            return View(tb_HoaDon);
        }

        // GET: Cms/HoaDon/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_HoaDon tb_HoaDon = db.Tb_HoaDon.Find(id);
            if (tb_HoaDon == null)
            {
                return HttpNotFound();
            }
            List<string> a = new List<string>{ "chưa thanh toán", "hoàn thành", "bị hủy" };
            ViewBag.trangthai = new SelectList(a);
            return View(tb_HoaDon);
        }

        // POST: Cms/HoaDon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenKH,DiaChi,SDTKH,Tongtien,NgayBan,trangthai")] Tb_HoaDon tb_HoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_HoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<string> a = new List<string> { "chưa thanh toán", "hoàn thành", "bị hủy" };
            ViewBag.trangthai = new SelectList(a);
            return View(tb_HoaDon);
        }

        // GET: Cms/HoaDon/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_HoaDon tb_HoaDon = db.Tb_HoaDon.Find(id);
            if (tb_HoaDon == null)
            {
                return HttpNotFound();
            }
            return View(tb_HoaDon);
        }

        // POST: Cms/HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tb_HoaDon tb_HoaDon = db.Tb_HoaDon.Find(id);
            db.Tb_HoaDon.Remove(tb_HoaDon);
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
