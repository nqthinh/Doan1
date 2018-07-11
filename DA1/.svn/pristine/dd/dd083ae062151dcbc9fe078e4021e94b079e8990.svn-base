using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ValueObject;

namespace DataAccessLayer
{
    public class DALChiTietHoaDon
    {
        dbConnect db = new dbConnect();

        public DataTable getData() //Lấy tất cả dữ liệu từ chi tiết hóa đơn
        {
            return db.getData("SP_CTHD_SELECT", null);
        }
       public DataTable getDataByID(string id)
        {
           SqlParameter[] para = {

             new SqlParameter("CTHD_MACTHD", id)
                                  };
           return db.getData("SP_CTHD_SELECTBYID", para);
        }
        public DataTable getDataDoanhThu()
       { return db.getData("SP_CTHD_DOANHTHU", null); }
      
        public DataTable getDataMaHoaDon(string id)
       {
           SqlParameter[] para = {

             new SqlParameter("HD_MAHD", id)
                                  };
           return db.getData("SP_CTHD_SELECT_SUDUNGDICHVU", para);
       }
       public int Insert(ObjChiTietHoaDon obj)
       {
           SqlParameter[] para = {
                                      new SqlParameter("CTHD_MACTHD", obj.CTHD_MaChiTietHoaDon),
                                      new SqlParameter("DV_MADV", obj.CTHD_MaDichVu),
                                      new SqlParameter("CTHD_SOLUONG", obj.CTHD_SoLuong),
                                      new SqlParameter("CTHD_NGAYSUDUNGDV", obj.CTHD_NgaySuDungDichVu),
                                      new SqlParameter("HD_MAHD", obj.HD_MaHoaDon),
                                  };

           return db.ExcuteSQL("SP_CTHD_INSERT", para);
       }
       public int Update(ObjChiTietHoaDon obj)
       {
           SqlParameter[] para = {
                                      new SqlParameter("CTHD_MACTHD", obj.CTHD_MaChiTietHoaDon),
                                      new SqlParameter("DV_MADV", obj.CTHD_MaDichVu),
                                      new SqlParameter("CTHD_SOLUONG", obj.CTHD_SoLuong),
                                      new SqlParameter("CTHD_NGAYSUDUNGDV", obj.CTHD_NgaySuDungDichVu),
                                      new SqlParameter("HD_MAHD", obj.HD_MaHoaDon),
                                  };

           return db.ExcuteSQL("SP_CTHD_UPDATE", para);
       }
       public int Delete(string id)
       {
           SqlParameter[] para = {
                                      new SqlParameter("CTHD_MACTHD", id)
                                  };

           return db.ExcuteSQL("SP_CTHD_DELETE", para);
       }
    }
}
