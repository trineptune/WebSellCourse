using System;
using System.Collections.Generic;

namespace Library_Class.Entities
{
    public partial class NganhHoc
    {
        public NganhHoc()
        {
            KhoaHocOnlines = new HashSet<KhoaHocOnline>();
        }

        public int IdNganhHoc { get; set; }
        public string? TenNganhHoc { get; set; }
        public int? TinChi { get; set; }
        public string? GioiThieu { get; set; }

        public virtual ICollection<KhoaHocOnline> KhoaHocOnlines { get; set; }
    }
}
