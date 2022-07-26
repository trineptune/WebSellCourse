using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Class.Entities;

namespace Library_Class.Repository
{
    public interface IDanhGiaKhoaHocRepository
    {
        public void CreateDanhGia(DanhGiaKhoaHoc danhGia);
        public void UpdateDanhGia(DanhGiaKhoaHoc danhGia);
        public void DeleteDanhGia(int danhGiaId);
        public List<DanhGiaKhoaHoc> getAllDanhGia();
        public DanhGiaKhoaHoc findDanhGiaById(int danhGiaId);
    }
}
