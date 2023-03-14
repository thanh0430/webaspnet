using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using baitapcuoimonweb.Models;

namespace baitapcuoimonweb.Areas.Cms.Controllers
{
    public class LoginController : Controller
    {
        // GET: Cms/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Tb_NhanVien tb)
        {
            ShopDienThoaiEntities db = new ShopDienThoaiEntities();
            try
            {
                Tb_NhanVien a = db.Tb_NhanVien.Where(x => x.TenDanhNhap== tb.TenDanhNhap && x.MatKhau==tb.MatKhau).Single();
                if (a != null)
                {

                    FormsAuthentication.SetAuthCookie(tb.TenDanhNhap, false);
                        return RedirectToAction("Index", "HomeCms");
                }
                else
                {
                    ModelState.AddModelError("","Đăng nhập thất bại");
                }

            }
            catch
            {
                ViewBag.thongbao = "tai khoan mat khau khong chính xác";
            }


            return  RedirectToAction( "Index"); ;
        }
    }
}