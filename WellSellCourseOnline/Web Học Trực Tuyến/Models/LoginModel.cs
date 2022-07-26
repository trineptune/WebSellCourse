using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Học_Trực_Tuyến.Models
{
    public class LoginModel
    {

        [Required]
        public int id { get; set; }
        public String Taikhoan { get; set; }
        public string? HoTen { get; set; }
        public int? SoDienThoai { get; set; }
        public string Email { get; set; } = null!;
        public string? LinkHinhAnhHocVien { get; set; }
        public int? IdHocVien { get; set; }
        [Required]
        public string? MatKhau { get; set; }

    }
}