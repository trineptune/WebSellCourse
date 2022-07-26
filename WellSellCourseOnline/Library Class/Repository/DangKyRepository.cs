using Library_Class.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Class.Repository
{
    public class DangKyRepository : IDangKyRepository
    {
        pdkladykillah_eLearningContext context = new pdkladykillah_eLearningContext();
        public void CreateDangKy(DangKy dangKy)
        {
            context.DangKies.Add(dangKy);
            context.SaveChanges();
        }

        public void DeleteDangKy(int id)
        {
            DangKy dbDangKy = context.DangKies.SingleOrDefault(b => b.Id == id);
            if (dbDangKy != null)
            {
                    context.DangKies.Remove(dbDangKy);
                    context.SaveChanges();
            }
        }

        public DangKy findDangKyById(int id)
        {
            DangKy dbDangKy = context.DangKies.SingleOrDefault(b => b.Id == id);
            return dbDangKy;
        }

        public List<DangKy> GetAllDangKy()
        {
            List<DangKy> dangKys = context.DangKies.ToList();
            return dangKys;
        }

        public void UpdateDangKy(DangKy dangKy)
        {
            DangKy dbDangKy = context.DangKies.SingleOrDefault(b => b.Id == dangKy.Id);
            if (dbDangKy != null)
            {
                dbDangKy.Id = dangKy.Id;
                dbDangKy.IdHocVien = dangKy.IdHocVien;
                dbDangKy.NgayDangKy = dangKy.NgayDangKy;
                dbDangKy.IdKhoaHocOnline = dangKy.IdKhoaHocOnline;
                dbDangKy.ThanhTien = dangKy.ThanhTien;
                context.SaveChanges();
            }
        }
    }
}
