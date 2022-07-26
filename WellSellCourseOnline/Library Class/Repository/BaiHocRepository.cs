using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Class.Entities;
namespace Library_Class.Repository
{
    public class BaiHocRepository : IBaiHocRespository
    {
        pdkladykillah_eLearningContext context = new pdkladykillah_eLearningContext();
        public void CreateBaiHoc(BaiHoc baiHoc)
        {
            context.BaiHocs.Add(baiHoc);
            context.SaveChanges();
        }

        public void DeleteBaiHoc(int id)
        {
            BaiHoc dbBaiHoc = context.BaiHocs.SingleOrDefault(b => b.Id == id);
            if (dbBaiHoc != null)
            {
                    context.BaiHocs.Remove(dbBaiHoc);
                    context.SaveChanges();
            }
        }

        public BaiHoc findBaiHocById(int id)
        {
            BaiHoc dbBaiHoc = context.BaiHocs.SingleOrDefault(b => b.Id == id);
            return dbBaiHoc;
        }

        public List<BaiHoc> GetAllBaiHoc()
        {
            List<BaiHoc> BaiHocs = context.BaiHocs.ToList();
            return BaiHocs;
        }

        public void UpdateBaiHoc(BaiHoc BaiHoc)
        {
            BaiHoc dbBaiHoc = context.BaiHocs.SingleOrDefault(b => b.Id == BaiHoc.Id);
            if (dbBaiHoc != null)
            {
                dbBaiHoc.Id = BaiHoc.Id;
                dbBaiHoc.Ten = BaiHoc.Ten;
                dbBaiHoc.ThoiGian = BaiHoc.ThoiGian;
                dbBaiHoc.NoiDung = BaiHoc.NoiDung;
                dbBaiHoc.LinkVideo = BaiHoc.LinkVideo;
                dbBaiHoc.IdKhoaHocOnline = BaiHoc.IdKhoaHocOnline;
                context.SaveChanges();
            }
        }
    }
}
