using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Class.Entities;
namespace Library_Class.Repository
{
    public class ChiTietDatHangRepository : IChiTietDatHangRespository
    {
        pdkladykillah_eLearningContext context = new pdkladykillah_eLearningContext();
        public void CreateChiTietDatHang(ChiTietDatHang chiTietDatHang)
        {
            context.ChiTietDatHangs.Add(chiTietDatHang);
            context.SaveChanges();
        }

        public void DeleteChiTietDatHang(int id)
        {
            ChiTietDatHang dbChiTietDatHang = context.ChiTietDatHangs.SingleOrDefault(b => b.IdDatHang == id);
            if (dbChiTietDatHang != null)
            {
                context.ChiTietDatHangs.Remove(dbChiTietDatHang);
                context.SaveChanges();
            }
        }

        public ChiTietDatHang findChiTietDatHangById(int id)
        {
            ChiTietDatHang dbChiTietDatHang = context.ChiTietDatHangs.SingleOrDefault(b => b.IdDatHang == id);
            return dbChiTietDatHang;
        }

        public List<ChiTietDatHang> GetAllChiTietDatHang()
        {
            List<ChiTietDatHang> ChiTietDatHangs = context.ChiTietDatHangs.ToList();
            return ChiTietDatHangs;
        }

        public void UpdateChiTietDatHang(ChiTietDatHang chiTietDatHang)
        {
            ChiTietDatHang dbChiTietDatHang = context.ChiTietDatHangs.SingleOrDefault(b => b.IdDatHang == chiTietDatHang.IdDatHang);
            if (dbChiTietDatHang != null)
            {
                dbChiTietDatHang.IdDatHang = chiTietDatHang.IdDatHang;
                dbChiTietDatHang.IdKhoaHocOnline = chiTietDatHang.IdKhoaHocOnline;
                dbChiTietDatHang.SoLuong = chiTietDatHang.SoLuong;
                dbChiTietDatHang.GiaKhoaHoc = chiTietDatHang.GiaKhoaHoc;
                context.SaveChanges();
            }
        }
    }
}
