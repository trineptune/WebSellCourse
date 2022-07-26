using System;
using System.Collections.Generic;

namespace Library_Class.Entities
{
    public partial class GiangVien
    {
        public GiangVien()
        {
            KhoaHocOnlines = new HashSet<KhoaHocOnline>();
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public int Id { get; set; }
        public string? HoTen { get; set; }
        public int? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? BangCap { get; set; }
        public string? LinkHinhAnhGiangVien { get; set; }

        public virtual ICollection<KhoaHocOnline> KhoaHocOnlines { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
