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
    class DALLoaiDichVu
    {
        dbConnect db = new dbConnect();

        public DataTable getData() //Lấy tất cả dữ liệu từ loại dịch vụ
        {
            return db.getData("SP_LOAIDICHVU_SELECT", null);
        }

        public DataTable getDataById(string id)   //Lấy dữ liệu bằng mã nhân viên
        {
            SqlParameter[] para = {
                                      new SqlParameter("NV_MANV", id)
                                  };

            return db.getData("SP_LOAIDICHVU_SELECT_BYID", para);
        }

        public int Insert(ObjNhanVien obj)
        {
            SqlParameter[] para = {
                                      new SqlParameter("LDV_MALOAI", obj.NV_MaNV),
                                      new SqlParameter("LDV_TENLOAI", obj.CV_MaCV)
                                  };

            return db.ExcuteSQL("SP_LOAIDICHVU_INSERT", para);
        }

        public int Update(ObjNhanVien obj)
        {
            SqlParameter[] para = {
                                      new SqlParameter("LDV_MALOAI", obj.NV_MaNV),
                                      new SqlParameter("LDV_TENLOAI", obj.CV_MaCV)
                                  };

            return db.ExcuteSQL("SP_LOAIDICHVU_INSERT", para);
        }

        public int Delete(string id)
        {
            SqlParameter[] para = {
                                      new SqlParameter("LDV_MALOAI", id)
                                  };

            return db.ExcuteSQL("SP_LOAIDICHVU_DELETE", para);
        }
    }
}
