using Library_Class.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Class.Repository
{
    public class NganhHocRepository : INganhHocRepository
    {
        pdkladykillah_eLearningContext context = new pdkladykillah_eLearningContext();
        public void createNganhHoc(NganhHoc nganhHoc)
        {
            context.NganhHocs.Add(nganhHoc);
            context.SaveChanges();
        }

        public void DeleteNganhHoc(int nganhHocId)
        {
            NganhHoc dbNganhHoc = context.NganhHocs.SingleOrDefault(b => b.IdNganhHoc == nganhHocId);
            if (dbNganhHoc != null)
            {
                    context.NganhHocs.Remove(dbNganhHoc);
                    context.SaveChanges();
            }
        }

        public NganhHoc FindNganhHocById(int NganhHocId)
        {
            NganhHoc dbNganhHoc = context.NganhHocs.SingleOrDefault(b => b.IdNganhHoc == NganhHocId);
            return dbNganhHoc;
        }

        public List<NganhHoc> GetAllNganhHoc()
        {
            List<NganhHoc> nganhHocs = context.NganhHocs.Include(x => x.KhoaHocOnlines).ThenInclude(x => x.BaiHocs).ToList();
            return nganhHocs;
        }

        public void UpdateNganhHoc(NganhHoc nganhHoc)
        {
            NganhHoc dbNganhHoc = context.NganhHocs.SingleOrDefault(b => b.IdNganhHoc == nganhHoc.IdNganhHoc);
            if (dbNganhHoc != null)
            {
                dbNganhHoc.TenNganhHoc = nganhHoc.TenNganhHoc;
                dbNganhHoc.GioiThieu = nganhHoc.GioiThieu;
                dbNganhHoc.TinChi = nganhHoc.TinChi;
                context.SaveChanges();
            }
        }
    }
}
