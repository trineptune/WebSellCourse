using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Class.Entities;
namespace Library_Class.Repository
{
    public interface IBaiHocRespository
    {
        public void CreateBaiHoc(BaiHoc baiHoc);
        public void UpdateBaiHoc(BaiHoc baiHoc);
        public void DeleteBaiHoc(int id);
        public List<BaiHoc> GetAllBaiHoc();
        public BaiHoc findBaiHocById(int id);
    }
}
