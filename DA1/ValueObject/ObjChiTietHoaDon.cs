using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObject
{
    public class ObjChiTietHoaDon
    {

        //Ma chi tiet hoa don
        private string CTHD_maChiTietHoaDon;
        public string CTHD_MaChiTietHoaDon
        {
            get { return CTHD_maChiTietHoaDon; }
            set { CTHD_maChiTietHoaDon = value; }
        }
        //Phat sinh
        private string CTHD_phatSinh;
        public string CTHD_PhatSinh
        {
            get { return CTHD_phatSinh; }
            set { CTHD_phatSinh = value; }
        }
        //ngày sử dụng dịch vụ
        
        public DateTime CTHD_NgaySuDungDichVu { get; set; }
        private string  soLuong;

        public string  CTHD_SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private string CTHD_maDichVu;

        public string CTHD_MaDichVu
        {
            get { return CTHD_maDichVu; }
            set { CTHD_maDichVu = value; }
        }
        private string HD_maHoaDon;

        public string HD_MaHoaDon
        {
            get { return HD_maHoaDon; }
            set { HD_maHoaDon = value; }
        }
        
    }
}
