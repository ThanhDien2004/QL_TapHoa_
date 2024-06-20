using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanHang_TapHoa.Models;

namespace QuanLyBanHang_TapHoa.Controllers
{
    public class LoginController : Controller
    {
        private QL_TapHoaEntities db = new QL_TapHoaEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TAIKHOAN ad)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(ad.TenDangNhap)) ModelState.AddModelError(string.Empty, "Name không được để trống");

                if (string.IsNullOrEmpty(ad.MatKhau)) ModelState.AddModelError(string.Empty, "Password không được để trống");
                if (ModelState.IsValid)
                {
                    // tim khach hang co ten dang nhap va password hop le trong csdl
                    var admin = db.TAIKHOANs.FirstOrDefault(k => k.TenDangNhap == ad.TenDangNhap && k.MatKhau == ad.MatKhau);
                    if (admin != null)
                    {
                        ViewBag.ThongBao = " chuc mung ban dang nhap thanh cong";
                        //luu vao session
                        Session["TaiKhoan"] = admin;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ThongBao = " ten dang nhap hoac mat khau khong dung";
                    }
                }
            }
            return View("Login");
        }

    }
}