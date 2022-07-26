using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Class.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
namespace Library_Class.Repository
{
    public class DanhGiaKhoaHocRepository : IDanhGiaKhoaHocRepository
    {
        pdkladykillah_eLearningContext context = new pdkladykillah_eLearningContext();
        public void CreateDanhGia(DanhGiaKhoaHoc danhGia)
        {
            context.DanhGiaKhoaHocs.Add(danhGia);
            context.SaveChanges();
            KhoaHocOnline khoaHocOnline = context.KhoaHocOnlines.SingleOrDefault(x => x.Id == danhGia.IdKhoaHocOnline);
            if (khoaHocOnline != null)
            {
                double? avg = context.DanhGiaKhoaHocs.Where(x => x.IdKhoaHocOnline == khoaHocOnline.Id).Average(x => x.Rating);
                IKhoaHocOnlineRepository rp = new KhoaHocOnlineRepository();
                khoaHocOnline.RatingTrungBinh = avg;
                rp.UpdateKhoaHocOnline(khoaHocOnline);
            }
        }
        public void DeleteDanhGia(int danhGiaId)
        {
            DanhGiaKhoaHoc dbDanhGia = context.DanhGiaKhoaHocs.SingleOrDefault(b => b.Id == danhGiaId);
            KhoaHocOnline khoaHocOnline = context.KhoaHocOnlines.SingleOrDefault(x => x.Id == dbDanhGia.IdKhoaHocOnline);
            if (dbDanhGia != null)
            {
                context.DanhGiaKhoaHocs.Remove(dbDanhGia);
                context.SaveChanges();
            }

            if (khoaHocOnline != null)
            {
                double? avg = context.DanhGiaKhoaHocs.Where(x => x.IdKhoaHocOnline == khoaHocOnline.Id).Average(x => x.Rating);
                IKhoaHocOnlineRepository rp = new KhoaHocOnlineRepository();
                khoaHocOnline.RatingTrungBinh = avg;
                rp.UpdateKhoaHocOnline(khoaHocOnline);
            }
        }

        public DanhGiaKhoaHoc findDanhGiaById(int danhGiaId)
        {
            DanhGiaKhoaHoc dbDanhGia = context.DanhGiaKhoaHocs.SingleOrDefault(b => b.Id == danhGiaId);
            return dbDanhGia;
        }


        public void UpdateDanhGia(DanhGiaKhoaHoc danhGia)
        {
            DanhGiaKhoaHoc dbDanhGia = context.DanhGiaKhoaHocs.SingleOrDefault(b => b.Id == danhGia.Id);
            if (dbDanhGia != null)
            {
                dbDanhGia.Rating = danhGia.Rating;
                dbDanhGia.NoiDungDanhGia = danhGia.NoiDungDanhGia;
                dbDanhGia.NgayDanhGia = danhGia.NgayDanhGia;
                dbDanhGia.IdKhoaHocOnline = danhGia.IdKhoaHocOnline;
                dbDanhGia.IdHocVien = danhGia.IdHocVien;
                context.SaveChanges();
            }
            KhoaHocOnline khoaHocOnline = context.KhoaHocOnlines.SingleOrDefault(x => x.Id == danhGia.IdKhoaHocOnline);
            if (khoaHocOnline != null)
            {
                double? avg = context.DanhGiaKhoaHocs.Where(x => x.IdKhoaHocOnline == khoaHocOnline.Id).Average(x => x.Rating);
                IKhoaHocOnlineRepository rp = new KhoaHocOnlineRepository();
                khoaHocOnline.RatingTrungBinh = avg;
                rp.UpdateKhoaHocOnline(khoaHocOnline);
            }
        }

        public List<DanhGiaKhoaHoc> getAllDanhGia()
        {
            List<DanhGiaKhoaHoc> danhGias = context.DanhGiaKhoaHocs.ToList();
            return danhGias;
        }
    }
}
