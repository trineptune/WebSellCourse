using System;
using System.Collections.Generic;

namespace Library_Class.Entities
{
    public partial class DangKy
    {
        public int Id { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public int? IdHocVien { get; set; }
        public int? IdKhoaHocOnline { get; set; }
        public decimal? ThanhTien { get; set; }

        public virtual HocVien? IdHocVienNavigation { get; set; }
        public virtual KhoaHocOnline? IdKhoaHocOnlineNavigation { get; set; }
    }
}
