using System;
using System.Collections.Generic;

namespace Library_Class.Entities
{
    public partial class GioHang
    {
        public int IdGioHang { get; set; }
        public int? IdKhoaHocOnline { get; set; }
        public int? Soluong { get; set; }

        public virtual KhoaHocOnline? IdKhoaHocOnlineNavigation { get; set; }
    }
}
