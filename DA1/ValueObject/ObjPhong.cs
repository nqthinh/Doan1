using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObject
{
    public class ObjPhong
    {
        //Mã phòng
        private string PHG_maPhong;

        public string PHG_MaPhong
        {
            get { return PHG_maPhong; }
            set { PHG_maPhong = value; }
        }
        
        //Hiện trạng phòng
        private string PHG_hienTrang;

        public string PHG_HienTrang
        {
            get { return PHG_hienTrang; }
            set { PHG_hienTrang = value; }
        }
        
        //SDT phòng
        private string PHG_sdtPhong;

        public string PHG_SDTPhong
        {
            get { return PHG_sdtPhong; }
            set { PHG_sdtPhong = value; }
        }
        
        //Phòng max
        private string PHG_slMax;

        public string PHG_SLMax
        {
            get { return PHG_slMax; }
            set { PHG_slMax = value; }
        }
        
        //Phòng giá
        private string PHG_gia;

        public string PHG_Gia
        {
            get { return PHG_gia; }
            set { PHG_gia = value; }
        }

        //Loại phòng
        private string LPHG_maLoai;

        public string LPHG_MaLoai
        {
            get { return LPHG_maLoai; }
            set { LPHG_maLoai = value; }
        }
        
    }
}
