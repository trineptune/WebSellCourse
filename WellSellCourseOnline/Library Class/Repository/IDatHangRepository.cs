using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Class.Entities;
namespace Library_Class.Repository
{
    public interface IDatHangRepository
    {
        void CreateDatHang(DatHang datHang);
        void UpdateDatHang(DatHang datHang);
        void DeleteDatHang(int datHangId);
        List<DatHang> GetAllDatHang();
        DatHang findDatHangById(int datHangId);

    }
}
