using Library_Class.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Class.Repository
{
    public class HocVIenRepository : IHocVienRepository
    {
        pdkladykillah_eLearningContext context = new pdkladykillah_eLearningContext();
        public void CreateHocVien(HocVien hocVien)
        {
            context.HocViens.Add(hocVien);
            context.SaveChanges();
        }

        public void DeleteHocVien(int hocVienId)
        {
            HocVien dbHocVien = context.HocViens.SingleOrDefault(b => b.Id == hocVienId);
            if (dbHocVien != null)
            {
                    context.HocViens.Remove(dbHocVien);
                    context.SaveChanges();
            }
        }

        public HocVien findHocVienById(int hocVienId)
        {
            HocVien dbHocVien = context.HocViens.SingleOrDefault(b => b.Id == hocVienId);
            return dbHocVien;
        }

        public List<HocVien> GetAllHocVien()
        {
            List<HocVien> hocViens = context.HocViens.ToList();
            return hocViens;
        }

        public void UpdateHocVien(HocVien hocVien)
        {
            HocVien dbHocVien = context.HocViens.SingleOrDefault(b => b.Id == hocVien.Id);
            if (dbHocVien != null)
            {
                dbHocVien.HoTen = hocVien.HoTen;
                dbHocVien.SoDienThoai = hocVien.SoDienThoai;
                dbHocVien.Email = hocVien.Email;
                dbHocVien.TaiKhoan = hocVien.TaiKhoan;
                dbHocVien.LinkHinhAnhHocVien = hocVien.LinkHinhAnhHocVien;
                context.SaveChanges();
            }
        }
    }
}
