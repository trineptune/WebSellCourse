using System;
using System.Collections.Generic;

namespace Library_Class.Entities
{
    public partial class DatHang
    {
        public int IdDatHang { get; set; }
        public DateTime? NgayDatHang { get; set; }
        public int? IdGioHang { get; set; }
        public int? IdHocVien { get; set; }
        public string? TinhTrangDonHang { get; set; }
        public decimal? TongGia { get; set; }

        public virtual HocVien? IdHocVienNavigation { get; set; }
    }
}
