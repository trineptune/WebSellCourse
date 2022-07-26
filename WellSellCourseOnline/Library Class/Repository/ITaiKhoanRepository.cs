using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Class.Entities;
namespace Library_Class.Repository
{
    public interface ITaiKhoanRepository
    {
        public void CreateTaiKhoan(TaiKhoan taiKhoan);
        public void UpdateTaiKhoan(TaiKhoan taiKhoan);
        public void DeleteTaiKhoan(string Id);
        public List<TaiKhoan> GetAllTaiKhoan();
        public TaiKhoan findTaiKhoanById(string Id);
    }
}
