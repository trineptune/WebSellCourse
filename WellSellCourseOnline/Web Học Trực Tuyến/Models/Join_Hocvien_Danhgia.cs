using Library_Class.Entities;
using Library_Class.Repository;
using System;
using System.Collections.Generic;
using System.Web;
namespace Web_Học_Trực_Tuyến.Models
{
    public class Join_Hocvien_Danhgia
    {
        public HocVien hocviens { get; set; }
        public DanhGiaKhoaHoc danhgias { get; set; }
        public KhoaHocOnline khoahocs { get; set; }
    }
 
}
