using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObject
{
    public class ObjDichVu
    {
        private string DV_maDichVu;

        public string DV_MaDichVu
        {
            get { return DV_maDichVu; }
            set { DV_maDichVu = value; }
        }
        private string DV_tenDichVu;

        public string DV_TenDichVu
        {
            get { return DV_tenDichVu; }
            set { DV_tenDichVu = value; }
        }
        private string DV_giaDichVu;

        public string DV_GiaDichVu
        {
            get { return DV_giaDichVu; }
            set { DV_giaDichVu = value; }
        }
        private string DV_moTa;

        public string DV_MoTa
        {
            get { return DV_moTa; }
            set { DV_moTa = value; }
        }
        public string DV_TrangThai { get; set; }
    }
}
