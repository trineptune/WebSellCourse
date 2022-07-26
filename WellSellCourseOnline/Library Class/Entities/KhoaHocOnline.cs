using System;
using System.Collections.Generic;

namespace Library_Class.Entities
{
    public partial class KhoaHocOnline
    {
        public KhoaHocOnline()
        {
            BaiHocs = new HashSet<BaiHoc>();
            ChiTietDatHangs = new HashSet<ChiTietDatHang>();
            DangKies = new HashSet<DangKy>();
            DanhGiaKhoaHocs = new HashSet<DanhGiaKhoaHoc>();
            GioHangs = new HashSet<GioHang>();
        }

        public int Id { get; set; }
        public string? TenKhoaHoc { get; set; }
        public string? DanhGia { get; set; }
        public int? IdGiangVien { get; set; }
        public decimal? GiaGoc { get; set; }
        public decimal? GiaGiam { get; set; }
        public int? IdNganhHoc { get; set; }
        public string? LinkHinhAnh { get; set; }
        public string? LinkVideo { get; set; }
        public double? RatingTrungBinh { get; set; }

        public virtual GiangVien? IdGiangVienNavigation { get; set; }
        public virtual NganhHoc? IdNganhHocNavigation { get; set; }
        public virtual ICollection<BaiHoc> BaiHocs { get; set; }
        public virtual ICollection<ChiTietDatHang> ChiTietDatHangs { get; set; }
        public virtual ICollection<DangKy> DangKies { get; set; }
        public virtual ICollection<DanhGiaKhoaHoc> DanhGiaKhoaHocs { get; set; }
        public virtual ICollection<GioHang> GioHangs { get; set; }
    }
}
