using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Class.Entities;
namespace Library_Class.Repository
{
    public interface IGioHangRepository
    {
        public void CreateGioHang(GioHang gioHang);
        public void UpdateGioHang(GioHang gioHang);
        public void DeleteGioHang(int gioHangId);
        public List<GioHang> GetAllGioHang();
        public GioHang findGioHangById(int gioHangId);
    }
}
