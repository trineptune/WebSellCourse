using Library_Class.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Class.Repository
{
    public class KhoaHocOnlineRepository : IKhoaHocOnlineRepository
    {
        pdkladykillah_eLearningContext context = new pdkladykillah_eLearningContext();
        
        public void CreateKhoaHocOnline(KhoaHocOnline khoaHocOnline)
        {
            context.KhoaHocOnlines.Add(khoaHocOnline);
            context.SaveChanges();
        }

        public void DeleteKhoaHocOnline(int khoaHocOnlineId)
        {
            KhoaHocOnline dbKhoaHocOnline = context.KhoaHocOnlines.SingleOrDefault(b => b.Id == khoaHocOnlineId);
            if (dbKhoaHocOnline != null)
            {
                    context.KhoaHocOnlines.Remove(dbKhoaHocOnline);
                    context.SaveChanges();
            }
        }

        public List<KhoaHocOnline> GetAllKhoaHocOnline()
        {
            List<KhoaHocOnline> khoaHocOnlines = context.KhoaHocOnlines.Include(x => x.BaiHocs).ToList();
            return khoaHocOnlines;
        }

        public KhoaHocOnline FindKhoaHocOnlineById(int khoaHocOnlineId)
        {
            KhoaHocOnline dbKhoaHocOnline = context.KhoaHocOnlines.SingleOrDefault(b => b.Id == khoaHocOnlineId);
            return dbKhoaHocOnline;
        }

        public void UpdateKhoaHocOnline(KhoaHocOnline khoaHocOnline)
        {
            KhoaHocOnline dbKhoaHocOnline = context.KhoaHocOnlines.SingleOrDefault(b => b.Id == khoaHocOnline.Id);
            if (dbKhoaHocOnline != null)
            {
                dbKhoaHocOnline.TenKhoaHoc = khoaHocOnline.TenKhoaHoc;
                dbKhoaHocOnline.GiaGoc = khoaHocOnline.GiaGoc;
                dbKhoaHocOnline.GiaGiam = khoaHocOnline.GiaGiam;
                dbKhoaHocOnline.IdGiangVien = khoaHocOnline.IdGiangVien;
                dbKhoaHocOnline.IdNganhHoc = khoaHocOnline.IdNganhHoc;
                dbKhoaHocOnline.DanhGia = khoaHocOnline.DanhGia;
                dbKhoaHocOnline.LinkHinhAnh = khoaHocOnline.LinkHinhAnh;
                dbKhoaHocOnline.LinkVideo = khoaHocOnline.LinkVideo; 
                dbKhoaHocOnline.RatingTrungBinh = khoaHocOnline.RatingTrungBinh;
                context.SaveChanges();
            }
        }
    }
}
