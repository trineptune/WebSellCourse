using Library_Class.Entities;
using Library_Class.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_Học_Trực_Tuyến.Models;
using Microsoft.AspNetCore.Http;
using System.Web;
namespace Web_Học_Trực_Tuyến.Controllers
{

    public class HomeController : Controller
    {

        IKhoaHocOnlineRepository rep = new KhoaHocOnlineRepository();
        INganhHocRepository rep2 = new NganhHocRepository();
        IBaiHocRespository rep3 = new BaiHocRepository();
        IGiangVienRepository rep4 = new GiangVienRepository();
        IDanhGiaKhoaHocRepository repdanhgia = new DanhGiaKhoaHocRepository();
        IHocVienRepository repHocVien = new HocVIenRepository();

        ChiTietDatHangRepository chitietdathangs=new ChiTietDatHangRepository();

        pdkladykillah_eLearningContext pdkcontext = new pdkladykillah_eLearningContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            TempData.Keep("IdHocVien");
            TempData.Keep("TenHV");
            //1. getall
            String hoten = Convert.ToString(TempData["TenHV"]);
            int idHV = Convert.ToInt32(TempData["IdHocVien"]);
            
            List<HocVien> hocviens=repHocVien.GetAllHocVien().Where(x=>x.Id==idHV).ToList();
            ViewBag.hotenHV = hocviens;
            List<KhoaHocOnline> ds = rep.GetAllKhoaHocOnline();
            List<NganhHoc> nghanhocs = rep2.GetAllNganhHoc();
            ViewBag.danhsachnghanhoc = nghanhocs;
            //2.passing model to view
            return View(ds);
        }
        public IActionResult Khoahoc(int Id)
        {
            List<NganhHoc> nghanhocs = rep2.GetAllNganhHoc();
            NganhHoc nganhHOc = rep2.FindNganhHocById(Id);


            List<GiangVien> gv = rep4.GetAllGiangVien();
            // ViewBag.danhsachgiangvien = gv;

            List<KhoaHocOnline> ds = nganhHOc.KhoaHocOnlines.ToList();

            TempData.Keep("IdHocVien");
            TempData.Keep("TenHV");
            //1. getall
            String hoten = Convert.ToString(TempData["TenHV"]);
            int idHV = Convert.ToInt32(TempData["IdHocVien"]);

            List<HocVien> hocviens = repHocVien.GetAllHocVien().Where(x => x.Id == idHV).ToList();
            ViewBag.hotenHV = hocviens;
            return View(ds);
        }
        public IActionResult ChiTiet(int id) //them int Id
        {
            
            //1. getall\
            List<BaiHoc> ds = rep3.GetAllBaiHoc().Where(X => X.IdKhoaHocOnline == id).ToList();
            //KhoaHocOnline khoahoc=rep.khoaHocOnlineById(Id);
            //  List<BaiHoc> ds = khoahoc.BaiHocs.ToList();
            List<KhoaHocOnline> danhsachbaihoc = rep.GetAllKhoaHocOnline().Where(B => B.Id == id).ToList();


            // Thong tin giang vien
            KhoaHocOnline khoahoc = rep.FindKhoaHocOnlineById(id);
            List<GiangVien> gv = rep4.GetAllGiangVien().Where(X => X.Id == khoahoc.IdGiangVien).ToList();

            KhoaHocOnline khoahocss = pdkcontext.KhoaHocOnlines.Where(x => x.Id == id).SingleOrDefault();

            //danh sach cac danh gia theo khoahoconline


            
            List<KhoaHocOnline> khoahocs = pdkcontext.KhoaHocOnlines.ToList();  
            List<DanhGiaKhoaHoc> danhgias = pdkcontext.DanhGiaKhoaHocs.Where(x=>x.IdKhoaHocOnline==id).ToList();
            List<HocVien> hocviens = pdkcontext.HocViens.ToList();
            ViewData["ListDanhGia"] = from d in danhgias join h in hocviens on d.IdHocVien equals h.Id into table
                                      from h in table.DefaultIfEmpty()
                                      
                                      select new Join_Hocvien_Danhgia { danhgias = d,hocviens = h};
            //List<HocVien> hocviens = repHocVien.GetAllHocVien().Where(x=>x.Id==Listdanhgia.Id).ToList();

            //List<DanhGiaKhoaHoc> test = repdanhgia.getAllDanhGia().ToList();
            //Thong tin hoc vien
            TempData.Keep("IdHocVien");
            TempData.Keep("TenHV");
            //1. getall
            String hoten = Convert.ToString(TempData["TenHV"]);
            int idHV = Convert.ToInt32(TempData["IdHocVien"]);

            List<HocVien> hocvienss = repHocVien.GetAllHocVien().Where(x => x.Id == idHV).ToList();
            ViewBag.hotenHV = hocvienss;
            // ViewBag.Hocvien = hocviens;
            //ViewBag.danhgia = danhgias;
            ViewBag.danhsachgiangvien = gv;
            ViewBag.danhsachkhoahoc = danhsachbaihoc;

            ViewBag.Baihoc = ds;


            return View(khoahocss);

        }
        public ActionResult LoginThanhCong()
        {
            TempData.Keep("IdHocVien");
            TempData.Keep("TenHV");
            TempData.Peek("TenHV");
            String hoten = Convert.ToString(TempData["TenHV"]);
            ViewBag.hotenHV = hoten;
            return View();
        }
        public IActionResult Login()
        {
            int id = Convert.ToInt32(TempData["IdHocVien"]);
          //  ViewBag.IdHocVien = id;
            var Tenhocvien = (from userlist in pdkcontext.HocViens where userlist.Id == id select new { userlist.HoTen }).ToList();
            if (Tenhocvien.FirstOrDefault() != null)
            {
               TempData["TenHV"] = Tenhocvien.FirstOrDefault().HoTen;
               
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(Hocvien_Giangvien_Taikhoan login)
        {
            
            bool isvalid = pdkcontext.TaiKhoans.Any(m => m.Id == login.taikhoans.Id && m.MatKhau == login.taikhoans.MatKhau);
            if (isvalid)
            {
                var user = (from userlist in pdkcontext.TaiKhoans where userlist.Id == login.taikhoans.Id && userlist.MatKhau == login.taikhoans.MatKhau select new { userlist.IdHocVien}).ToList();
                if (user.FirstOrDefault() != null)
                {
                    TempData["IdHocVien"] = user.FirstOrDefault().IdHocVien;
                }

                return RedirectToAction("LoginThanhCong");
            }
            //if (ModelState.IsValid)
            //{
            //    bool isvalid = pdkcontext.TaiKhoans.Any(m => m.Id == login.taikhoans.Id && m.MatKhau == login.taikhoans.MatKhau);
            //var user = (from userlist in pdkcontext.TaiKhoans where userlist.Id == login.taikhoans.Id && userlist.MatKhau == login.taikhoans.MatKhau select new { userlist.IdHocVien, userlist.Id,login.hocviens.HoTen }).ToList();
            //    //if (user.FirstOrDefault() != null)
            //    //{
            //    //    ViewBag.idhocvien=user.FirstOrDefault().IdHocVien;
            //    //    ViewBag.tenhocvien = user.FirstOrDefault().HoTen;
            //    //    return RedirectToAction("Index");

            //    //}
            //    //else
            //    //{
            //    //    ModelState.AddModelError("", "Invalid login");
            //    //}
            //}
            ModelState.AddModelError("", "Invalid Username/Password!");

            return View(login);
        }

        public IActionResult Lophoc()
        {
            //1. getall
            List<KhoaHocOnline> ds = rep.GetAllKhoaHocOnline();
            List<NganhHoc> nghanhocs = rep2.GetAllNganhHoc();
            ViewBag.danhsachnghanhoc = nghanhocs;
            //2.passing model to view
            //3 thong tin user
            TempData.Keep("IdHocVien");
            TempData.Keep("TenHV");
            //1. getall
            String hoten = Convert.ToString(TempData["TenHV"]);
            int idHV = Convert.ToInt32(TempData["IdHocVien"]);

            List<HocVien> hocvienss = repHocVien.GetAllHocVien().Where(x => x.Id == idHV).ToList();
            ViewBag.hotenHV = hocvienss;

            //4
            List<KhoaHocOnline> dstop5 = rep.GetAllKhoaHocOnline().OrderByDescending(x=>x.GiaGiam).Take(5).ToList();
            ViewBag.dskhtop5 = dstop5;
            return View(ds);
        }

        public IActionResult AddDanhGia(int id)
        {
            //int idHV = Convert.ToInt32(TempData["IdHocVien"]);
            //ViewBag.id = idHV;
            TempData.Keep("IdHocVien");
            TempData.Keep("TenHV");
            TempData.Peek("TenHV");
            String hoten = Convert.ToString(TempData["TenHV"]);
            int idHV = Convert.ToInt32(TempData["IdHocVien"]);

            List<HocVien> hocvienss = repHocVien.GetAllHocVien().Where(x => x.Id == idHV).ToList();
            ViewBag.hotenHV = hocvienss;
            DanhGiaKhoaHoc dg = new DanhGiaKhoaHoc();
            dg.IdKhoaHocOnline=id;
            //DanhGiaKhoaHoc danhgias = pdkcontext.DanhGiaKhoaHocs.Where(x => x.IdKhoaHocOnline == id).SingleOrDefault();
            return View(dg);
        }
       
        public IActionResult SaveDanhGia(DanhGiaKhoaHoc danhgia)
        {
            int idHV = Convert.ToInt32(TempData["IdHocVien"]);
            if(idHV == null)
            {
                RedirectToAction("Index");
            }
            danhgia.NgayDanhGia = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,DateTime.Today.Hour,DateTime.Today.Minute,DateTime.Today.Second);

            danhgia.IdHocVien = idHV;
            repdanhgia.CreateDanhGia(danhgia);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult GiamDan()
        {
            TempData.Keep("IdHocVien");
            TempData.Keep("TenHV");
            //1. getall
            String hoten = Convert.ToString(TempData["TenHV"]);
            int idHV = Convert.ToInt32(TempData["IdHocVien"]);

            List<HocVien> hocviens = repHocVien.GetAllHocVien().Where(x => x.Id == idHV).ToList();
            ViewBag.hotenHV = hocviens;
            List<KhoaHocOnline> dstop5 = rep.GetAllKhoaHocOnline().OrderByDescending(x => x.GiaGoc).Take(Range.All).ToList();
            ViewBag.dskhtop5 = dstop5;
            return View(dstop5);
        }
        public IActionResult Lienhe()
        {
            return View();
        }
        public IActionResult DangXuat()
        {
            TempData.Clear();
            return View();
        }
        public IActionResult Thongtin()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}