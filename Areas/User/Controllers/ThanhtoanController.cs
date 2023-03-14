using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baitapcuoimonweb.Models;

namespace baitapcuoimonweb.Areas.User.Controllers
{
    public class ThanhtoanController : Controller
    {
        private ShopDienThoaiEntities db = new ShopDienThoaiEntities();
        private static string id="";
        // GET: User/Thanhtoan
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tb_HoaDon Tb_HoaDon)
        {
            List<Cart> lstCart = (List<Cart>)Session["lstCart"];
            double tien = 0;
            foreach (var item in lstCart)
            {
                tien = tien + (double)(item.soluong * item.Sanpham.GiaBan);
            }
            List<KhachHang> lst = db.KhachHangs.Where(x => x.SDT == Tb_HoaDon.SDTKH).ToList();
            if (lst.Count == 0)
            {
                KhachHang khachHang = new KhachHang();
                khachHang.SDT = Tb_HoaDon.SDTKH;
                khachHang.DiaChi = Tb_HoaDon.DiaChi;
                khachHang.TenKH = Tb_HoaDon.TenKH;
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
            }
            
            Tb_HoaDon.Tongtien = tien;
            Tb_HoaDon.NgayBan = DateTime.Now;
            string day = DateTime.Now.Day.ToString()+ DateTime.Now.Month.ToString()+ DateTime.Now.Hour.ToString()+ DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
            Tb_HoaDon.TrangThai = "chưa thanh toán";
            Tb_HoaDon.Id = Tb_HoaDon.SDTKH + day;
            db.Tb_HoaDon.Add(Tb_HoaDon);
           
            db.SaveChanges();
            id = Tb_HoaDon.Id;

            return RedirectToAction("Xacnhanthanhtoan");
        }
        public ActionResult tinhtongtien()
        {
            List<Cart> lstCart = (List<Cart>)Session["lstCart"];
            if (lstCart == null)
            {
                lstCart = new List<Cart>();
            }
            return PartialView(lstCart);
        }
        public ActionResult Xacnhanthanhtoan()
        {
            List<Cart> lstCart = (List<Cart>)Session["lstCart"];
            if (lstCart == null)
            {
                lstCart = new List<Cart>();
            }
            return View(lstCart);
        }
        [HttpPost]
        public ActionResult Xacnhanthanhtoandonhang()
        {
            List<Cart> lstCart = (List<Cart>)Session["lstCart"];
            if (lstCart == null)
            {
                return RedirectToAction("Loithanhtoan");
            }
            else
            {
                foreach(var item in lstCart)
                {
                    Tb_ChiTietHD a = new Tb_ChiTietHD();
                    a.IdHoaDon = id;
                    a.IdSanPham = item.SanphamId;
                    a.SoLuong = item.soluong;
                    a.GiaBan = item.Sanpham.GiaBan;
                    a.ThanhTien = (double)item.soluong * item.Sanpham.GiaBan;
                    db.Tb_ChiTietHD.Add(a);

                    db.SaveChanges();
                }
            }

            return RedirectToAction("Thanhtoanthanhcong");
        }

        public ActionResult Thanhtoanthanhcong()
        {
            
            return View();
        }
        public ActionResult Loithanhtoan()
        {
            return View();
        }
    }
}