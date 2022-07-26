using System;
using System.Collections.Generic;

namespace Library_Class.Entities
{
    public partial class BaiHoc
    {
        public int Id { get; set; }
        public string? Ten { get; set; }
        public string? NoiDung { get; set; }
        public string? LinkVideo { get; set; }
        public int? IdKhoaHocOnline { get; set; }
        public int? ThoiGian { get; set; }

        public virtual KhoaHocOnline? IdKhoaHocOnlineNavigation { get; set; }
    }
}
