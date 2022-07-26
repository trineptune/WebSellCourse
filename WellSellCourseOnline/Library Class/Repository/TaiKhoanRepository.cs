using Library_Class.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Class.Repository
{
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        pdkladykillah_eLearningContext context = new pdkladykillah_eLearningContext();
        public void CreateTaiKhoan(TaiKhoan taiKhoan)
        {
            context.TaiKhoans.Add(taiKhoan);
            context.SaveChanges();
        }

        public void DeleteTaiKhoan(string taiKhoanId)
        {
            TaiKhoan dbTaiKhoan = context.TaiKhoans.SingleOrDefault(b => b.Id == taiKhoanId);
            if (dbTaiKhoan != null)
            {
                    context.TaiKhoans.Remove(dbTaiKhoan);
                    context.SaveChanges();
            }

        }

        public TaiKhoan findTaiKhoanById(string taiKhoanId)
        {
            TaiKhoan dbTaikhoan = context.TaiKhoans.SingleOrDefault(b => b.Id == taiKhoanId);
            return dbTaikhoan;
        }

        public List<TaiKhoan> GetAllTaiKhoan()
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();
            return taiKhoans;
        }

        public void UpdateTaiKhoan(TaiKhoan taiKhoan)
        {
            TaiKhoan dbTaiKhoan = context.TaiKhoans.SingleOrDefault(b => b.Id== taiKhoan.Id);
            if (dbTaiKhoan != null)
            {
                dbTaiKhoan.NgayTao = taiKhoan.NgayTao;
                dbTaiKhoan.MatKhau = taiKhoan.MatKhau;
                dbTaiKhoan.IdGiangVien = taiKhoan.IdGiangVien;
                dbTaiKhoan.IdHocVien = taiKhoan.IdHocVien;
                context.SaveChanges();
            }
        }
    }
}
