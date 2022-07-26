using System;
using System.Collections.Generic;

namespace Library_Class.Entities
{
    public partial class TaiKhoan
    {
        public string Id { get; set; } = null!;
        public string? MatKhau { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? IdGiangVien { get; set; }
        public int? IdHocVien { get; set; }

        public virtual GiangVien? IdGiangVienNavigation { get; set; }
        public virtual HocVien? IdHocVienNavigation { get; set; }
    }
}
