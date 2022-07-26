using System;
using System.Collections.Generic;

namespace Library_Class.Entities
{
    public partial class DanhGiaKhoaHoc
    {
        public int Id { get; set; }
        public int? IdHocVien { get; set; }
        public int? IdKhoaHocOnline { get; set; }
        public DateTime? NgayDanhGia { get; set; }
        public string? NoiDungDanhGia { get; set; }
        public double? Rating { get; set; }

        public virtual HocVien? IdHocVienNavigation { get; set; }
        public virtual KhoaHocOnline? IdKhoaHocOnlineNavigation { get; set; }
    }
}
