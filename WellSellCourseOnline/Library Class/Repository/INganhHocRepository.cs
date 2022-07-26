using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Class.Entities;
namespace Library_Class.Repository
{
    public interface INganhHocRepository
    {
        public void createNganhHoc(NganhHoc nganhHoc);
        public void UpdateNganhHoc(NganhHoc nganhHoc);
        public void DeleteNganhHoc(int nganhHocId);
        public List<NganhHoc> GetAllNganhHoc();
        public NganhHoc FindNganhHocById(int NganhHocId);
    }
}
