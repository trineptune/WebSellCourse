using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Class.Entities;
namespace Library_Class.Repository
{
    public class DatHangRepository : IDatHangRepository
    {
        pdkladykillah_eLearningContext context = new pdkladykillah_eLearningContext();

        public List<DatHang> GetAllDatHang()
        {
            List<DatHang> datHangs = context.DatHangs.ToList();
            return datHangs;
        }

        public void CreateDatHang(DatHang datHang)
        {
            context.DatHangs.Add(datHang);
            context.SaveChanges();
        }

        public void UpdateDatHang(DatHang datHang)
        {
            DatHang dbDatHang = context.DatHangs.SingleOrDefault(b => b.IdDatHang == datHang.IdDatHang);
            if (dbDatHang != null)
            {
                dbDatHang.NgayDatHang = datHang.NgayDatHang;
                dbDatHang.IdGioHang = datHang.IdGioHang;
                dbDatHang.IdHocVien = datHang.IdHocVien;
                dbDatHang.TinhTrangDonHang = datHang.TinhTrangDonHang;
                dbDatHang.TongGia = datHang.TongGia;
                context.SaveChanges();
            }
        }

        public void DeleteDatHang(int datHangId)
        {
            DatHang dbDatHang = context.DatHangs.SingleOrDefault(b => b.IdDatHang == datHangId);
            if (dbDatHang != null)
            {
                context.DatHangs.Remove(dbDatHang);
                context.SaveChanges();
            }
        }


        public DatHang findDatHangById(int datHangId)
        {
            DatHang dbDatHang = context.DatHangs.SingleOrDefault(b => b.IdDatHang == datHangId);
            return dbDatHang;
        }

    }
}
