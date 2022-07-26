using Library_Class.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Class.Repository
{
    public interface IKhoaHocOnlineRepository
    {
        public void CreateKhoaHocOnline(KhoaHocOnline khoaHocOnline);
        public void UpdateKhoaHocOnline(KhoaHocOnline khoaHocOnline);
        public void DeleteKhoaHocOnline(int khoaHocOnlineId);
        public List<KhoaHocOnline> GetAllKhoaHocOnline();
        public KhoaHocOnline FindKhoaHocOnlineById(int khoaHocOnlineId);
    }
}
