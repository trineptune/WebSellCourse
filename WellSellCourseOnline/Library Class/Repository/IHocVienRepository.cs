using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Class.Entities;
namespace Library_Class.Repository
{
    public interface IHocVienRepository
    {
        public void CreateHocVien(HocVien hocVien);
        public void UpdateHocVien(HocVien hocVien);
        public void DeleteHocVien(int hocVienId);
        public List<HocVien> GetAllHocVien();
        public HocVien findHocVienById(int hocVienId);
    }
}
