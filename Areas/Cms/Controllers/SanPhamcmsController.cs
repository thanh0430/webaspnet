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
    public class SanPhamcmsController : Controller
    {
       
        private ShopDienThoaiEntities db = new ShopDienThoaiEntities();

        // GET: Cms/SanPham
        public ActionResult Index(string search,string gia,string IdDanhMuc,string KhuyenMai)
        {
          
            ViewBag.IdDanhMuc = new SelectList(new List<string>() { "điện thoại", "phụ kiện" });

            ViewBag.HangSanXuat = new SelectList(db.Tb_DanhMucSanPham, "HangSanXuat", "HangSanXuat");
            
            ViewBag.KhuyenMai = new SelectList(db.Tb_SanPham, "Id", "KhuyenMai");
            List<Tb_SanPham> tb_SanPham=new List<Tb_SanPham>();
            
            if(search==null||search==""){
                if(IdDanhMuc==null||IdDanhMuc=="" ){
                    if(KhuyenMai==null||KhuyenMai==""){
                        if (gia == null || gia == "")
                        {
                            tb_SanPham = db.Tb_SanPham.Include(t => t.Tb_DanhMucSanPham).ToList();
                        }
                        else
                        {
                            if (gia == "1")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan <= 5000000).Include(t => t.Tb_DanhMucSanPham).ToList();
                            } else if (gia == "2")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 5000000 && t.GiaBan <= 10000000).Include(t => t.Tb_DanhMucSanPham).ToList();
                            } else if (gia == "3") {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 10000000 && t.GiaBan <= 15000000).Include(t => t.Tb_DanhMucSanPham).ToList();

                            } else
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 15000000 ).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                        }
                    }
                    else
                    {
                        if (gia == null || gia == "")
                        {
                            tb_SanPham = db.Tb_SanPham.Where(t => t.KhuyenMai==int.Parse(KhuyenMai)).Include(t => t.Tb_DanhMucSanPham).ToList();
                        }
                        else
                        {
                            if (gia == "1")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan <= 5000000&& t.KhuyenMai == int.Parse(KhuyenMai)).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                            else if (gia == "2")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 5000000 && t.GiaBan <= 10000000&& t.KhuyenMai == int.Parse(KhuyenMai)).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                            else if (gia == "3")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 10000000 && t.GiaBan <= 15000000&& t.KhuyenMai == int.Parse(KhuyenMai)).Include(t => t.Tb_DanhMucSanPham).ToList();

                            }
                            else
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 15000000&& t.KhuyenMai == int.Parse(KhuyenMai)).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                        }
                    }
                }
                else
                {
                    if (KhuyenMai == null || KhuyenMai == "")
                    {
                        if (gia == null || gia == "")
                        {
                            tb_SanPham = db.Tb_SanPham.Where(t => t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc).Include(t => t.Tb_DanhMucSanPham).ToList();
                        }
                        else
                        {
                            if (gia == "1")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan <= 5000000&& t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                            else if (gia == "2")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 5000000 && t.GiaBan <=10000000 && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                            else if (gia == "3")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 10000000 && t.GiaBan <= 15000000 && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc).Include(t => t.Tb_DanhMucSanPham).ToList();

                            }
                            else
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 15000000 && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                        }
                    }
                    else
                    {
                        if (gia == null || gia == "")
                        {
                            tb_SanPham = db.Tb_SanPham.Where(t => t.KhuyenMai == int.Parse(KhuyenMai) && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc).Include(t => t.Tb_DanhMucSanPham).ToList();
                        }
                        else
                        {
                            if (gia == "1")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan <= 5000000 && t.KhuyenMai == int.Parse(KhuyenMai) && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                            else if (gia == "2")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 5000000 && t.GiaBan <= 10000000 && t.KhuyenMai == int.Parse(KhuyenMai) && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                            else if (gia == "3")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 10000000 && t.GiaBan <= 15000000 && t.KhuyenMai == int.Parse(KhuyenMai) && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc).Include(t => t.Tb_DanhMucSanPham).ToList();

                            }
                            else
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 15000000 && t.KhuyenMai == int.Parse(KhuyenMai) && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                        }
                    }
                }
            }
            else
            {
                if (IdDanhMuc == null || IdDanhMuc == "")
                {
                    if (KhuyenMai == null || KhuyenMai == "")
                    {
                        if (gia == null || gia == "")
                        {
                            tb_SanPham = db.Tb_SanPham.Where(t => t.TenSanPham==search).Include(t => t.Tb_DanhMucSanPham).ToList();
                        }
                        else
                        {
                            if (gia == "1")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan <= 5000000&& t.TenSanPham == search).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                            else if (gia == "2")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 5000000 && t.GiaBan <= 10000000 && t.TenSanPham == search).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                            else if (gia == "3")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 10000000 && t.GiaBan <= 15000000 && t.TenSanPham == search).Include(t => t.Tb_DanhMucSanPham).ToList();

                            }
                            else
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 15000000 && t.TenSanPham == search).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                        }
                    }
                    else
                    {
                        if (gia == null || gia == "")
                        {
                            tb_SanPham = db.Tb_SanPham.Where(t => t.KhuyenMai == int.Parse(KhuyenMai) && t.TenSanPham == search).Include(t => t.Tb_DanhMucSanPham).ToList();
                        }
                        else
                        {
                            if (gia == "1")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan <= 5000000 && t.KhuyenMai == int.Parse(KhuyenMai) && t.TenSanPham == search).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                            else if (gia == "2")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 5000000 && t.GiaBan <= 10000000 && t.KhuyenMai == int.Parse(KhuyenMai) && t.TenSanPham == search).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                            else if (gia == "3")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 10000000 && t.GiaBan <= 15000000 && t.KhuyenMai == int.Parse(KhuyenMai) && t.TenSanPham == search).Include(t => t.Tb_DanhMucSanPham).ToList();

                            }
                            else
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 15000000 && t.KhuyenMai == int.Parse(KhuyenMai) && t.TenSanPham == search).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                        }
                    }
                }
                else
                {
                    if (KhuyenMai == null || KhuyenMai == "")
                    {
                        if (gia == null || gia == "")
                        {
                            tb_SanPham = db.Tb_SanPham.Where(t => t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc && t.TenSanPham == search).Include(t => t.Tb_DanhMucSanPham).ToList();
                        }
                        else
                        {
                            if (gia == "1")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan <= 5000000 && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc && t.TenSanPham == search).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                            else if (gia == "2")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 5000000 && t.GiaBan <= 10000000 && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc && t.TenSanPham == search).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                            else if (gia == "3")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 10000000 && t.GiaBan <= 15000000 && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc && t.TenSanPham == search).Include(t => t.Tb_DanhMucSanPham).ToList();

                            }
                            else
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 15000000 && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc && t.TenSanPham == search).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                        }
                    }
                    else
                    {
                        if (gia == null || gia == "")
                        {
                            tb_SanPham = db.Tb_SanPham.Where(t => t.KhuyenMai == int.Parse(KhuyenMai) && t.TenSanPham == search && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc).Include(t => t.Tb_DanhMucSanPham).ToList();
                        }
                        else
                        {
                            if (gia == "1")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan <= 5000000 && t.TenSanPham == search && t.KhuyenMai == int.Parse(KhuyenMai) && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                            else if (gia == "2")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 5000000 && t.TenSanPham == search && t.GiaBan <= 10000000 && t.KhuyenMai == int.Parse(KhuyenMai) && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                            else if (gia == "3")
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 10000000 && t.TenSanPham == search && t.GiaBan <= 15000000 && t.KhuyenMai == int.Parse(KhuyenMai) && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc).Include(t => t.Tb_DanhMucSanPham).ToList();

                            }
                            else
                            {
                                tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 15000000 && t.TenSanPham == search && t.KhuyenMai == int.Parse(KhuyenMai) && t.Tb_DanhMucSanPham.LoaiSanPham==IdDanhMuc).Include(t => t.Tb_DanhMucSanPham).ToList();
                            }
                        }
                    }
                }
            }
            
            return View(tb_SanPham);
        }

    

        // GET: Cms/SanPham/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_SanPham tb_SanPham = db.Tb_SanPham.Find(id);
            if (tb_SanPham == null)
            {
                return HttpNotFound();
            }
            return View(tb_SanPham);
        }

        // GET: Cms/SanPham/Create
        public ActionResult Create()
        {

    
            ViewBag.Loaisanpham = new SelectList(new List<string>(){"điện thoại","phụ kiện"});

            ViewBag.HangSanXuat = new SelectList(db.Tb_DanhMucSanPham, "HangSanXuat", "HangSanXuat");
         
            return View();
        }

        // POST: Cms/SanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tb_SanPham tb_SanPham, string Loaisanpham, string HangSanXuat)
        {
            try
            {
                var f = Request.Files["Image"];
                Tb_DanhMucSanPham id= db.Tb_DanhMucSanPham.Where(a => a.LoaiSanPham == Loaisanpham.Trim() && a.HangSanXuat == HangSanXuat).Single();
                tb_SanPham.IdDanhMuc = id.Id;
                if (f != null && f.ContentLength > 0)
                {
                    string fname = DateTime.Now.ToString("yyyyMMddssffff") + "." + f.FileName.Split('.')[f.FileName.Split('.').Length - 1];

                    var path = Server.MapPath("~/image/" + fname);
                    f.SaveAs(path);
                    tb_SanPham.AnhSanPham = "/image/" + fname;
                }
                else
                {
                    tb_SanPham.AnhSanPham = "";
                }
                if (ModelState.IsValid)
                {
                    db.Tb_SanPham.Add(tb_SanPham);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {

            }



            ViewBag.Loaisanpham = new SelectList(new List<string>() { "điện thoại", "phụ kiện" });

            ViewBag.HangSanXuat = new SelectList(db.Tb_DanhMucSanPham, "Id", "HangSanXuat");

            return View(tb_SanPham);
        }

        // GET: Cms/SanPham/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_SanPham tb_SanPham = db.Tb_SanPham.Find(id);
            if (tb_SanPham == null)
            {
                return HttpNotFound();
            }

            ViewBag.Loaisanpham = new SelectList(new List<string>() { "điện thoại", "phụ kiện" });

            ViewBag.HangSanXuat = new SelectList(db.Tb_DanhMucSanPham, "HangSanXuat", "HangSanXuat");
            return View(tb_SanPham);
        }

        // POST: Cms/SanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tb_SanPham tb_SanPham,string Loaisanpham, string HangSanXuat)
        {
            try
            {
                var f = Request.Files["Image"];
                Tb_DanhMucSanPham id = db.Tb_DanhMucSanPham.Where(a => a.LoaiSanPham == Loaisanpham.Trim() && a.HangSanXuat == HangSanXuat).Single();
                tb_SanPham.IdDanhMuc = id.Id;
                if (f != null && f.ContentLength > 0)
                {
                    string fname = DateTime.Now.ToString("yyyyMMddssffff") + "." + f.FileName.Split('.')[f.FileName.Split('.').Length - 1];

                    var path = Server.MapPath("~/image/" + fname);
                    f.SaveAs(path);
                    tb_SanPham.AnhSanPham = "/image/" + fname;
                }
                else
                {
                    tb_SanPham.AnhSanPham = "";
                }
                if (ModelState.IsValid)
                {
                    db.Entry(tb_SanPham).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {

            }
            ViewBag.Loaisanpham = new SelectList(new List<string>() { "điện thoại", "phụ kiện" });
            ViewBag.IdDanhMuc = new SelectList(db.Tb_DanhMucSanPham, "Id", "LoaiSanPham", tb_SanPham.IdDanhMuc);
            return View(tb_SanPham);
        }

        // GET: Cms/SanPham/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_SanPham tb_SanPham = db.Tb_SanPham.Find(id);
            if (tb_SanPham == null)
            {
                return HttpNotFound();
            }

            if (db.Tb_Kho.Where(x => x.IdSanPham == id).Single() != null|| db.Tb_ChiTietHD.Where(x => x.IdSanPham == id).Single() != null|| db.Tb_ChiTietPhieuNHap.Where(x => x.IdSanPham == id).Single() != null)
            {
                ViewBag.loixoa = 1;

            }
         
            return View(tb_SanPham);
        }

        // POST: Cms/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tb_SanPham tb_SanPham = db.Tb_SanPham.Find(id);
           
                    db.Tb_SanPham.Remove(tb_SanPham);
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
