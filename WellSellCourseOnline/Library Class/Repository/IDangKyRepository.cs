using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Class.Entities;
namespace Library_Class.Repository
{
    public interface IDangKyRepository
    {
        public void CreateDangKy(DangKy dangKy);
        public void UpdateDangKy(DangKy dangKy);
        public void DeleteDangKy(int id);
        public List<DangKy> GetAllDangKy();
        public DangKy findDangKyById(int id);

    }
}
