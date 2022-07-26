using System;
using System.Collections.Generic;

namespace Library_Class.Entities
{
    public partial class HocVien
    {
        public HocVien()
        {
            DangKies = new HashSet<DangKy>();
            DanhGiaKhoaHocs = new HashSet<DanhGiaKhoaHoc>();
            DatHangs = new HashSet<DatHang>();
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public int Id { get; set; }
        public string? HoTen { get; set; }
        public int? SoDienThoai { get; set; }
        public string Email { get; set; } = null!;
        public string? TaiKhoan { get; set; }
        public string? LinkHinhAnhHocVien { get; set; }

        public virtual ICollection<DangKy> DangKies { get; set; }
        public virtual ICollection<DanhGiaKhoaHoc> DanhGiaKhoaHocs { get; set; }
        public virtual ICollection<DatHang> DatHangs { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
