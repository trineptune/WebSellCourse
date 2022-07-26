using Library_Class.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Class.Repository
{
    public class GioHangRepository : IGioHangRepository
    {
        pdkladykillah_eLearningContext context = new pdkladykillah_eLearningContext();
        public void CreateGioHang(GioHang gioHang)
        {
            context.GioHangs.Add(gioHang);
            context.SaveChanges();
        }

        public void DeleteGioHang(int id)
        {
            GioHang dbGioHang = context.GioHangs.SingleOrDefault(b => b.IdGioHang == id);
            if (dbGioHang != null)
            {
                context.GioHangs.Remove(dbGioHang);
                context.SaveChanges();
            }
        }

        public GioHang findGioHangById(int id)
        {
            GioHang dbGioHang = context.GioHangs.SingleOrDefault(b => b.IdGioHang == id);
            return dbGioHang;
        }

        public List<GioHang> GetAllGioHang()
        {
            List<GioHang> GioHangs = context.GioHangs.ToList();
            return GioHangs;
        }

        public void UpdateGioHang(GioHang GioHang)
        {
            GioHang dbGioHang = context.GioHangs.SingleOrDefault(b => b.IdGioHang == GioHang.IdGioHang);
            if (dbGioHang != null)
            {
                dbGioHang.IdGioHang = GioHang.IdGioHang;
                dbGioHang.IdKhoaHocOnline = GioHang.IdKhoaHocOnline;
                dbGioHang.Soluong = GioHang.Soluong;
                context.SaveChanges();
            }
        }
    }
}
