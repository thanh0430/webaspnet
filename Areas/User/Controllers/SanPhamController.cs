using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baitapcuoimonweb.Models;
using PagedList;
using PagedList.Mvc;


namespace baitapcuoimonweb.Areas.User.Controllers
{
    public class SanPhamController : Controller
    {
        private ShopDienThoaiEntities db = new ShopDienThoaiEntities();
        private static string lochang = "";
        // GET: User/SanPham
        public ActionResult Home(int? page)
        {
            int pageNumber = page ?? 1;
            int pagesize = 8;
            List<Tb_SanPham> lst = db.Tb_SanPham.ToList();
            var sanpham = lst.ToPagedList(pageNumber, pagesize);
            return View(sanpham);
           
        }
        public ActionResult Khuyenmai(int? pages)
        {
            int pageNumber = pages ?? 1;
            int pagesize = 6;
            List<Tb_SanPham> lst = db.Tb_SanPham.Where(x=>x.KhuyenMai>0).ToList();
            var sanpham = lst.ToPagedList(pageNumber, pagesize);
            return PartialView(sanpham);

        }
        public ActionResult SanPham(long? id)
        {
            
            Tb_SanPham ls = db.Tb_SanPham.Where(a => a.Id == id).Single();
            List<Tb_Kho> sl = db.Tb_Kho.Where(b => b.IdSanPham == id).ToList();
            
            if (sl.Count!=0)
            {
                Tb_Kho kho = db.Tb_Kho.Where(b => b.IdSanPham == id).Single();
                ViewBag.soluong = kho.SoLuong;
                
            }
            else
            {
                ViewBag.soluong = 0;
            }
            
            return View(ls);

        }
        public ActionResult theohang(string hang, int? page)
        {

            List<Tb_SanPham> lst;
            int pageNumber = page ?? 1;
            int pagesize = 6;
            if (hang == null)
            {
                return RedirectToAction("Tatcasanpham");
            }
            else
            {

                lst = db.Tb_SanPham.Where(x => x.Tb_DanhMucSanPham.HangSanXuat == hang).ToList();


                ViewBag.hang = hang;
                lochang = hang;
            }
            var sanpham = lst.ToPagedList(pageNumber, pagesize);
            return View(sanpham);


        }
        [HttpGet]
        public ActionResult theohangloc(int? page,string gia)
        {
           
            List<Tb_SanPham> lst;
            int pageNumber = page ?? 1;
            int pagesize = 6;
            if (lochang == null)
            {
                return RedirectToAction("Tatcasanpham");
            }
            else
            {
                if (gia == null || gia == "")
                {
                    lst = db.Tb_SanPham.Where(x => x.Tb_DanhMucSanPham.HangSanXuat == lochang).ToList();
                }
                else
                {
                    if (gia == "1")
                    {
                        lst = db.Tb_SanPham.Where(t => t.GiaBan <= 5000000 && t.Tb_DanhMucSanPham.HangSanXuat == lochang).ToList();
                    }
                    else if (gia == "2")
                    {
                        lst = db.Tb_SanPham.Where(t => t.GiaBan > 5000000 && t.GiaBan <= 10000000 && t.Tb_DanhMucSanPham.HangSanXuat == lochang).ToList();
                    }
                    else if (gia == "3")
                    {
                        lst = db.Tb_SanPham.Where(t => t.GiaBan > 10000000 && t.GiaBan <= 15000000 && t.Tb_DanhMucSanPham.HangSanXuat == lochang).ToList();

                    }
                    else
                    {
                        lst = db.Tb_SanPham.Where(t => t.GiaBan > 15000000 && t.Tb_DanhMucSanPham.HangSanXuat == lochang).ToList();
                    }
                }
                ViewBag.hang = lochang;
                ViewBag.gia = gia;
            }
            var sanpham = lst.ToPagedList(pageNumber, pagesize);
            return View(sanpham);


        }
        public ActionResult phukientheohang(string hang, int? page)
        {

            List<Tb_SanPham> lst;
            int pageNumber = page ?? 1;
            int pagesize = 6;
            if (hang == null)
            {
                return RedirectToAction("Tatcasanpham");
            }
            else
            {

                lst = db.Tb_SanPham.Where(x => x.Tb_DanhMucSanPham.HangSanXuat == hang).ToList();


                ViewBag.hang = hang;
                lochang = hang;
            }
            var sanpham = lst.ToPagedList(pageNumber, pagesize);
            return View(sanpham);


        }
        [HttpGet]
        public ActionResult locphukientheohang(int? page, string gia)
        {

            List<Tb_SanPham> lst;
            int pageNumber = page ?? 1;
            int pagesize = 6;
            if (lochang == null)
            {
                return RedirectToAction("Tatcasanpham");
            }
            else
            {
                if (gia == null || gia == "")
                {
                    lst = db.Tb_SanPham.Where(x => x.Tb_DanhMucSanPham.HangSanXuat == lochang).ToList();
                }
                else
                {
                    if (gia == "1")
                    {
                        lst = db.Tb_SanPham.Where(t => t.GiaBan <= 500000 && t.Tb_DanhMucSanPham.HangSanXuat == lochang).ToList();
                    }
                    else if (gia == "2")
                    {
                        lst = db.Tb_SanPham.Where(t => t.GiaBan > 500000 && t.GiaBan <= 1000000 && t.Tb_DanhMucSanPham.HangSanXuat == lochang).ToList();
                    }
                    else if (gia == "3")
                    {
                        lst = db.Tb_SanPham.Where(t => t.GiaBan > 1000000 && t.GiaBan <= 1500000 && t.Tb_DanhMucSanPham.HangSanXuat == lochang).ToList();

                    }
                    else
                    {
                        lst = db.Tb_SanPham.Where(t => t.GiaBan > 1500000 && t.Tb_DanhMucSanPham.HangSanXuat == lochang).ToList();
                    }
                }
                ViewBag.hang = lochang;
                ViewBag.gia = gia;
            }
            var sanpham = lst.ToPagedList(pageNumber, pagesize);
            return View(sanpham);


        }
        [HttpGet]
        public ActionResult Tatcasanpham(string gia, int? page)
        {
            List<Tb_SanPham> tb_SanPham = new List<Tb_SanPham>();
            if (gia == null || gia == "")
            {
                tb_SanPham = db.Tb_SanPham.ToList();
            }
            else
            {
                if (gia == "1")
                {
                    tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan < 5000000).ToList();
                }
                else if (gia == "2")
                {
                    tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 5000000 && t.GiaBan < 10000000).ToList();
                }
                else if (gia == "3")
                {
                    tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 10000000 && t.GiaBan < 15000000).ToList();

                }
                else
                {
                    tb_SanPham = db.Tb_SanPham.Where(t => t.GiaBan > 15000000).ToList();
                }
            }
            
            int pageNumber = page ?? 1;
            int pagesize = 6;
         

            ViewBag.SanPham = new SelectList(db.Tb_SanPham, "ID", "GiaBan");

            var sanpham = tb_SanPham.ToPagedList(pageNumber, pagesize);
            return View(sanpham);

        }
    }
}