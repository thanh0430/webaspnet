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
    
    public class NhanVienController : Controller
    {
        private ShopDienThoaiEntities db = new ShopDienThoaiEntities();

        // GET: Cms/NhanVien

        [HttpGet]
        public ActionResult Index(string search, string Gender,string quequan, string Chucvu)
        {
            List<Tb_NhanVien> list;
            if (search == null || search == "")
            {
                if (Gender == null || Gender == "")
                {
                   
                     if (quequan == null || quequan == "")
                     {
                        if (Chucvu == null || Chucvu == "")
                        {
                            list = db.Tb_NhanVien.ToList();
                        }
                        else
                        {
                            list = db.Tb_NhanVien.Where(x => x.ChucVu == Chucvu).ToList();
                        }
                    }
                     else {
                        if (Chucvu == null || Chucvu == "")
                        {
                            list = db.Tb_NhanVien.Where(x => x.QueQuan == quequan).ToList();
                        }
                        else
                        {
                            list = db.Tb_NhanVien.Where(x => x.ChucVu == Chucvu && x.QueQuan == quequan).ToList();
                        }
                        
                     }
                }
                else
                {

                    if (quequan == null || quequan == "")
                    {
                        if (Chucvu == null || Chucvu == "")
                        {
                            list = db.Tb_NhanVien.Where(x => x.GioiTinh == Gender).ToList();
                        }
                        else
                        {
                            list = db.Tb_NhanVien.Where(x => x.ChucVu == Chucvu && x.GioiTinh == Gender).ToList();
                        }
                    }
                    else
                    {
                        if (Chucvu == null || Chucvu == "")
                        {
                            list = db.Tb_NhanVien.Where(x => x.GioiTinh == Gender && x.QueQuan==quequan).ToList();
                        }
                        else
                        {
                            list = db.Tb_NhanVien.Where(x => x.ChucVu == Chucvu && x.GioiTinh == Gender &&x.QueQuan==quequan).ToList();
                        }
                      
                    }
                   
                }
            }
            else
            {
                if (Gender == null || Gender == "")
                {

                    if (quequan == null || quequan == "")
                    {
                        if (Chucvu == null || Chucvu == "")
                        {
                            list = db.Tb_NhanVien.Where(x => x.TenNV == search).ToList();
                        }
                        else
                        {
                            list = db.Tb_NhanVien.Where(x => x.ChucVu == Chucvu&& x.TenNV == search).ToList();
                        }
                    }
                    else
                    {
                        if (Chucvu == null || Chucvu == "")
                        {
                            list = db.Tb_NhanVien.Where(x => x.QueQuan == quequan&&x.TenNV == search).ToList();
                        }
                        else
                        {
                            list = db.Tb_NhanVien.Where(x => x.ChucVu == Chucvu && x.QueQuan == quequan&& x.TenNV == search).ToList();
                        }

                    }
                }
                else
                {

                    if (quequan == null || quequan == "")
                    {
                        if (Chucvu == null || Chucvu == "")
                        {
                            list = db.Tb_NhanVien.Where(x => x.GioiTinh == Gender&& x.TenNV == search).ToList();
                        }
                        else
                        {
                            list = db.Tb_NhanVien.Where(x => x.TenNV == search&& x.ChucVu == Chucvu && x.GioiTinh == Gender).ToList();
                        }
                    }
                    else
                    {
                        if (Chucvu == null || Chucvu == "")
                        {
                            list = db.Tb_NhanVien.Where(x => x.TenNV == search&& x.GioiTinh == Gender && x.QueQuan == quequan).ToList();
                        }
                        else
                        {
                            list = db.Tb_NhanVien.Where(x => x.TenNV == search&& x.ChucVu == Chucvu && x.GioiTinh == Gender && x.QueQuan == quequan).ToList();
                        }

                    }

                }
            }
            ViewBag.Chucvu = new SelectList(db.Tb_NhanVien, "ChucVu", "ChucVu");

            return View(list);
        }

        // GET: Cms/NhanVien/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_NhanVien tb_NhanVien = db.Tb_NhanVien.Find(id);
            if (tb_NhanVien == null)
            {
                return HttpNotFound();
            }
            return View(tb_NhanVien);
        }

        // GET: Cms/NhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cms/NhanVien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenNV,SDT,CMND,QueQuan,ChucVu,TenDanhNhap,MatKhau,NgaySinh,GioiTinh")] Tb_NhanVien tb_NhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Tb_NhanVien.Add(tb_NhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_NhanVien);
        }

        // GET: Cms/NhanVien/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_NhanVien tb_NhanVien = db.Tb_NhanVien.Find(id);
            if (tb_NhanVien == null)
            {
                return HttpNotFound();
            }
            return View(tb_NhanVien);
        }

        // POST: Cms/NhanVien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenNV,SDT,CMND,QueQuan,ChucVu,TenDanhNhap,MatKhau,NgaySinh,GioiTinh")] Tb_NhanVien tb_NhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_NhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_NhanVien);
        }

        // GET: Cms/NhanVien/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_NhanVien tb_NhanVien = db.Tb_NhanVien.Find(id);
            if (tb_NhanVien == null)
            {
                return HttpNotFound();
            }
            List<Tb_PhieuNhap> phieunhap = db.Tb_PhieuNhap.Where(x => x.IdNhanVien == id).ToList();
            if ( phieunhap.Count != 0)
            {
                ViewBag.loixoa = 1;
            }
            return View(tb_NhanVien);
        }

        // POST: Cms/NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tb_NhanVien tb_NhanVien = db.Tb_NhanVien.Find(id);
            db.Tb_NhanVien.Remove(tb_NhanVien);
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
