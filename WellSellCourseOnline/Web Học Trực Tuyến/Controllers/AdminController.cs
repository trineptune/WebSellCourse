using Microsoft.AspNetCore.Mvc;
using Library_Class.Entities;
using Library_Class.Repository;

using Web_Học_Trực_Tuyến.Models;

namespace Web_Học_Trực_Tuyến.Controllers
{
    public class AdminController : Controller
    {
        TaiKhoanRepository rep = new TaiKhoanRepository();
        KhoaHocOnlineRepository repAdd = new KhoaHocOnlineRepository();
        BaiHocRepository repAdd2 = new BaiHocRepository();
        IKhoaHocOnlineRepository repGet = new KhoaHocOnlineRepository();
        pdkladykillah_eLearningContext pdkcontext = new pdkladykillah_eLearningContext();

        INganhHocRepository repGet5 = new NganhHocRepository();

        IBaiHocRespository repGet2 = new BaiHocRepository();
        IHocVienRepository repget3 = new HocVIenRepository();
        IGiangVienRepository repget4 = new GiangVienRepository();
        public IActionResult Index()
        {
            List<KhoaHocOnline> khoaHocOnlineList = repGet.GetAllKhoaHocOnline();
            ViewBag.Sokhoahoc = khoaHocOnlineList.Count();
            List<HocVien> hocviens = repget3.GetAllHocVien();
            ViewBag.SoHocVien = hocviens.Count();
            List<GiangVien> SoGiangVien = repget4.GetAllGiangVien();
            ViewBag.SoGiangVien = SoGiangVien.Count();
            List<NganhHoc> SoNghanhHoc = repGet5.GetAllNganhHoc();
            ViewBag.SoNghanhHoc = SoNghanhHoc.Count();
            return View();
        }
        public IActionResult Thanhcong()
        {
            return View();
        }
        //Xem danh sach khoa hoc
        public IActionResult ListKhoahoc()
        {
            List<KhoaHocOnline> ds = repGet.GetAllKhoaHocOnline();

            return View(ds);
        }
        //Thêm Khoa hoc

        public IActionResult AddKhoahoconline()
        {
            List<NganhHoc> nganhHocs = pdkcontext.NganhHocs.ToList();
            ViewBag.tennghanh = nganhHocs;


            KhoaHocOnline khol = new KhoaHocOnline();
            return View(khol);
        }
        public IActionResult GetallKhoahoconline()
        {
            List<KhoaHocOnline> khoahocs = pdkcontext.KhoaHocOnlines.ToList();

            return View(khoahocs);
        }
        public IActionResult GetallDanhGia()
        {
            List<DanhGiaKhoaHoc> danhgias = pdkcontext.DanhGiaKhoaHocs.ToList();

            return View(danhgias);
        }
        public IActionResult GetallGiangVien(Hocvien_Giangvien_Taikhoan taikhoanGV)
        {
            List<GiangVien> giangviens = pdkcontext.GiangViens.ToList();
            List<TaiKhoan> taikhoans = pdkcontext.TaiKhoans.ToList();
            ViewData["ListTaikhoanGV"] = from gv in giangviens
                                         join tk in taikhoans on gv.Id equals tk.IdGiangVien into table
                                         from tk in table.DefaultIfEmpty()
                                         select new Hocvien_Giangvien_Taikhoan { giangviens = gv, taikhoans = tk };
            return View(ViewData["ListTaikhoanGV"]);
        }
        public IActionResult GetallHocvien(Hocvien_Giangvien_Taikhoan taikhoanHv)
        {
            List<HocVien> hocviens = pdkcontext.HocViens.ToList();
            List<TaiKhoan> taikhoans = pdkcontext.TaiKhoans.ToList();
            ViewData["ListTaikhoanHV"] = from hv in hocviens
                                         join tk in taikhoans on hv.Id equals tk.IdHocVien into table
                                         from tk in table.DefaultIfEmpty()
                                         select new Hocvien_Giangvien_Taikhoan { hocviens=hv, taikhoans = tk };
            
            return View(ViewData["ListTaikhoanHV"]);
        }
        public IActionResult Getallbaihoc(int id)
        {
            List<BaiHoc> baihocs = repGet2.GetAllBaiHoc().Where(x => x.IdKhoaHocOnline == id).ToList();

            return View(baihocs);
        }
        public IActionResult SaveKhoahoconline(KhoaHocOnline khoahocs)
        {
            repAdd.CreateKhoaHocOnline(khoahocs);


            return RedirectToAction("GetallKhoahoconline");
        }
        //Them tai khoan
        public IActionResult AddTaikhoan()
        {

            return View();
        }
        [HttpPost]
        public IActionResult SaveTaikhoan(Hocvien_Giangvien_Taikhoan addTk)
        {
            addTk.taikhoans.NgayTao = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

            repget4.CreateGiangVien(addTk.giangviens);
            addTk.taikhoans.IdGiangVien = addTk.giangviens.Id;
            rep.CreateTaiKhoan(addTk.taikhoans);
            return RedirectToAction("GetallGiangVien");
        }
        //Them Bai hoc
        public IActionResult Addbaihoc()
        {
            BaiHoc bh = new BaiHoc();
            return View(bh);
        }
        public IActionResult Savebaihoc(BaiHoc bh)
        {
            repAdd2.CreateBaiHoc(bh);

            return View(bh);
            return RedirectToAction("GetallKhoahoconline");
        }
        public IActionResult Deletekhoahoc(int id)
        {
            // tim doi tuong có id
            //select * from categories where CCategoryId = id 
            KhoaHocOnline khoahocs = pdkcontext.KhoaHocOnlines.Where(x => x.Id == id).SingleOrDefault();

            //xoa du lieu

            pdkcontext.KhoaHocOnlines.Remove(khoahocs);
            pdkcontext.SaveChanges();

            return RedirectToAction("GetallKhoahoconline");
        }
        public IActionResult Deletebaihoc(int id)
        {
            // tim doi tuong có id
            //select * from categories where CCategoryId = id 
            BaiHoc baihocs = pdkcontext.BaiHocs.Where(x => x.Id == id).SingleOrDefault();

            //xoa du lieu

            pdkcontext.BaiHocs.Remove(baihocs);
            pdkcontext.SaveChanges();

            return RedirectToAction("Getallbaihoc");
        }
        public IActionResult DeleteDanhgia(int id)
        {
            // tim doi tuong có id
            //select * from categories where CCategoryId = id 
            DanhGiaKhoaHoc danhgia = pdkcontext.DanhGiaKhoaHocs.Where(x => x.Id == id).SingleOrDefault();

            //xoa du lieu

            pdkcontext.DanhGiaKhoaHocs.Remove(danhgia);
            pdkcontext.SaveChanges();

            return RedirectToAction("GetallDanhGia");
        }
        public IActionResult DeleteGV(int id)
        {
            // tim doi tuong có id
            //select * from categories where CCategoryId = id 
            GiangVien giangviens = pdkcontext.GiangViens.Where(x => x.Id == id).SingleOrDefault();
            TaiKhoan taikhoans = pdkcontext.TaiKhoans.Where(x=>x.IdGiangVien == id).SingleOrDefault();
            //xoa du lieu
            pdkcontext.GiangViens.Remove(giangviens);
            pdkcontext.TaiKhoans.Remove(taikhoans);
            pdkcontext.SaveChanges();
            return RedirectToAction("GetallGiangVien");
        }
        public IActionResult DeleteHV(int id)
        {
            // tim doi tuong có id
            //select * from categories where CCategoryId = id 
            HocVien hocviens = pdkcontext.HocViens.Where(x => x.Id == id).SingleOrDefault();
            TaiKhoan taikhoans = pdkcontext.TaiKhoans.Where(x => x.IdHocVien == id).SingleOrDefault();
            //xoa du lieu
            pdkcontext.HocViens.Remove(hocviens);
            pdkcontext.TaiKhoans.Remove(taikhoans);
            pdkcontext.SaveChanges();
            return RedirectToAction("GetallHocvien");
        }
        public IActionResult EditKhoahoc(string Name)
        {
            KhoaHocOnline khoahoc = pdkcontext.KhoaHocOnlines.Where(x => x.TenKhoaHoc == Name).SingleOrDefault();
            return View(khoahoc);
        }

        public IActionResult UpdateKhoahoc(KhoaHocOnline khoahocs)
        {
            KhoaHocOnline khoahoc = pdkcontext.KhoaHocOnlines.Where(x => x.TenKhoaHoc == khoahocs.TenKhoaHoc).SingleOrDefault();
            if (khoahoc != null)
            {
                khoahoc.TenKhoaHoc = khoahocs.TenKhoaHoc;

            }
            pdkcontext.SaveChanges();
            return RedirectToAction("GetallKhoahoconline");
        }
    }

}
