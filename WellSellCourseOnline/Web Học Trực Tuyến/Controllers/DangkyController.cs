using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_Học_Trực_Tuyến.Models;
using Library_Class.Entities;
using Library_Class.Repository;
using Microsoft.EntityFrameworkCore;
using Xceed.Wpf.Toolkit;

namespace Web_Học_Trực_Tuyến.Controllers
{
    public class DangkyController : Controller
    {
        TaiKhoanRepository repTk= new TaiKhoanRepository();
        HocVIenRepository repHv = new HocVIenRepository();
        pdkladykillah_eLearningContext context= new pdkladykillah_eLearningContext();
        
        public IActionResult FormDK(Hocvien_Giangvien_Taikhoan model)
        {
          
                return View(model);
       
        }
        [HttpPost]
       
        public IActionResult SaveTaikhoan(Hocvien_Giangvien_Taikhoan DkTk)
        {
          
           
            DkTk.taikhoans.NgayTao = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

            DkTk.hocviens.TaiKhoan = DkTk.taikhoans.Id;


           
           repHv.CreateHocVien(DkTk.hocviens);
            DkTk.taikhoans.IdHocVien = DkTk.hocviens.Id;
            repTk.CreateTaiKhoan(DkTk.taikhoans);
            return RedirectToAction("DKThanhCong");
        }
       
        public IActionResult DKThanhCong()
        {
            return View();
        }
    }

}
