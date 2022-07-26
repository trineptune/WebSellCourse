using System;
using System.Collections.Generic;

namespace Library_Class.Entities
{
    public partial class ChiTietDatHang
    {
        public int IdDatHang { get; set; }
        public int? IdKhoaHocOnline { get; set; }
        public int? SoLuong { get; set; }
        public decimal? GiaKhoaHoc { get; set; }

        public virtual KhoaHocOnline? IdKhoaHocOnlineNavigation { get; set; }
    }
}
