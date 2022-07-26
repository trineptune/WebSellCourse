using Library_Class.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Class.Repository
{
    public class GiangVienRepository : IGiangVienRepository
    {
        pdkladykillah_eLearningContext context = new pdkladykillah_eLearningContext();
        public void CreateGiangVien(GiangVien giangVien)
        {
            context.GiangViens.Add(giangVien);
            context.SaveChanges();
        }

        public void DeleteGiangVien(int giangVienId)
        {
            GiangVien dbGiangVien = context.GiangViens.SingleOrDefault(b => b.Id == giangVienId);
            if (dbGiangVien != null)
            {
                    context.GiangViens.Remove(dbGiangVien);
                    context.SaveChanges();
            }
        }

        public GiangVien findGiangVienById(int giangVienId)
        {
            GiangVien dbGiangVien = context.GiangViens.SingleOrDefault(b => b.Id == giangVienId);
            return dbGiangVien;
        }

        public List<GiangVien> GetAllGiangVien()
        {
            List<GiangVien> giangViens = context.GiangViens.ToList();
            return giangViens;
        }

        public void UpdateGiangVien(GiangVien giangVien)
        {
            GiangVien dbGiangVien = context.GiangViens.SingleOrDefault(b => b.Id == giangVien.Id);
            if (dbGiangVien != null)
            {
                dbGiangVien.HoTen = giangVien.HoTen;
                dbGiangVien.BangCap = giangVien.BangCap;
                dbGiangVien.Email = giangVien.Email;
                dbGiangVien.SoDienThoai = giangVien.SoDienThoai;
                dbGiangVien.LinkHinhAnhGiangVien = giangVien.LinkHinhAnhGiangVien;
                context.SaveChanges();
            }
        }

    }
}
