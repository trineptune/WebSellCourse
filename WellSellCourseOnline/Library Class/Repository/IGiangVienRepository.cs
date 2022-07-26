using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Class.Entities;
namespace Library_Class.Repository
{
    public interface IGiangVienRepository
    {
        void CreateGiangVien(GiangVien giangVien);
        void UpdateGiangVien(GiangVien giangVien);
        void DeleteGiangVien(int giangVienId);
        List<GiangVien> GetAllGiangVien();
        GiangVien findGiangVienById(int giangVienId);

    }
}
