using Library_Class.Entities;
using Library_Class.Repository;
using System;
using System.Collections.Generic;
using System.Web;

namespace Web_Học_Trực_Tuyến.Models
{
    public class Hocvien_Giangvien_Taikhoan
    {
        public HocVien hocviens { get; set; }
        public TaiKhoan taikhoans { get; set; }
        public GiangVien giangviens { get; set; }
    }
}
