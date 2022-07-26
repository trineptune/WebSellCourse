using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Class.Entities;
namespace Library_Class.Repository
{
    public interface IChiTietDatHangRespository
    {
        public void CreateChiTietDatHang(ChiTietDatHang chiTietDatHang);
        public void UpdateChiTietDatHang(ChiTietDatHang chiTietDatHang);
        public void DeleteChiTietDatHang(int id);
        public List<ChiTietDatHang> GetAllChiTietDatHang();
        public ChiTietDatHang findChiTietDatHangById(int id);
    }
}
