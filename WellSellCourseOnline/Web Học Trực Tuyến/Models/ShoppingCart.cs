using Library_Class.Entities;
using Library_Class.Repository;
using System;
using System.Collections.Generic;

namespace Web_Học_Trực_Tuyến.Models
{
    public partial class ShoppingCart
    {
      
            public string CartId { get; set; }
            public int Id { get; set; }
            public int? SiQty { get; set; }

            public KhoaHocOnline IdNavigation { get; set; }
        
    }
}
