using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baitapcuoimonweb.Models;

namespace baitapcuoimonweb.Areas.User.Controllers
{
    public class CartController : Controller
    {
        private ShopDienThoaiEntities db = new ShopDienThoaiEntities();
        // GET: User/Card
        public ActionResult Index()
        {
            List<Cart> lstCart = (List<Cart>)Session["lstCart"];
            if (lstCart == null)
            {
                lstCart = new List<Cart>();
            }
            return View(lstCart);
        }
        public ActionResult Add(long Id)
        {
            List<Cart> lstCart = (List<Cart>)Session["lstCart"];
            if (lstCart == null)
            {
                lstCart = new List<Cart>();
            }
            Cart obj = lstCart.FirstOrDefault(x => x.SanphamId == Id);

            if (obj != null)
            {
                obj.soluong = obj.soluong + 1;

            }
            else
            {
                Tb_SanPham product = db.Tb_SanPham.First(x => x.Id == Id);
                obj = new Cart();
                obj.SanphamId = Id;
                obj.Sanpham = product;
                obj.soluong = 1;
                lstCart.Add(obj);
            }
            Session["lstCart"] = lstCart;
            return RedirectToAction("Index");
        }
        public ActionResult Xoa(long? Id)
        {
            List<Cart> lstCart = (List<Cart>)Session["lstCart"];
            Cart sanpham = lstCart.SingleOrDefault(t => t.SanphamId == Id);
            if (sanpham != null)
            {
                lstCart.RemoveAll(t => t.SanphamId == Id);
                return RedirectToAction("Index");
            }
            if (lstCart.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }
       [HttpPost]
        public ActionResult capnhap(long? Id, string soluong)
        {
            List<Cart> lstCart = (List<Cart>)Session["lstCart"];
            Cart sanpham = lstCart.SingleOrDefault(t => t.SanphamId == Id);
            foreach (var item in lstCart)
            {
                if (item.SanphamId == Id)
                {
                    item.soluong = Convert.ToInt32(soluong);
                    break;
                }
            }
            return RedirectToAction("Index");
        }
    }
}