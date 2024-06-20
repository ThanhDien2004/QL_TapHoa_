using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanHang_TapHoa.Models;

namespace QuanLyBanHang_TapHoa.Controllers
{
    public class LoaiSPController : Controller
    {
        QL_TapHoaEntities db = new QL_TapHoaEntities(); 
        // GET: LoaiSP
        public ActionResult Index()
        {
            var loaisp = db.LOAISANPHAMs.ToList();
            return View(loaisp);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LOAISANPHAM lsp)
        {
            try
            {
                db.LOAISANPHAMs.Add(lsp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("LOI TAO MOI CATEGORY");
            }
        }
    }
}