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
    public class DALDichVu
    {
        dbConnect db = new dbConnect();

        public DataTable getData() //Lấy tất cả dữ liệu từ dịch vụ
        {
            return db.getData("SP_DICHVU_SELECT", null);
        }

        public DataTable getDataById(string id)   //Lấy dữ liệu bằng mã dịch vụ
        {
            SqlParameter[] para = {
                                      new SqlParameter("DV_MADV", id)
                                  };

            return db.getData("SP_DICHVU_SELECT_BYID", para);
        }

        public int Insert(ObjDichVu obj)
        {
            SqlParameter[] para = {
                                      new SqlParameter("DV_MADV", obj.DV_MaDichVu),
                                      new SqlParameter("DV_TENDV", obj.DV_TenDichVu),
                                      new SqlParameter("DV_GIADICHVU", obj.DV_GiaDichVu),
                                      new SqlParameter("DV_GHICHU", obj.DV_MoTa),
                                      new SqlParameter("DV_TRANGTHAI", obj.DV_TrangThai)
                                  };

            return db.ExcuteSQL("SP_DICHVU_INSERT", para);
        }

        public int Update(ObjDichVu obj)
        {
            SqlParameter[] para = {
                                      new SqlParameter("DV_MADV", obj.DV_MaDichVu),
                                      new SqlParameter("DV_TENDV", obj.DV_TenDichVu),
                                      new SqlParameter("DV_GIADICHVU", obj.DV_GiaDichVu),
                                      new SqlParameter("DV_GHICHU", obj.DV_MoTa)
                                      
                                  };

            return db.ExcuteSQL("SP_DICHVU_UPDATE", para);
        }
        public int UpdateTrangThai(ObjDichVu obj)
        {
            SqlParameter[] para = {
                                      new SqlParameter("DV_MADV", obj.DV_MaDichVu),
                                      new SqlParameter("DV_TRANGTHAI", obj.DV_TrangThai)      
                                      
                                  };

            return db.ExcuteSQL("SP_DICHVU_UPDATE_TRANGTHAI", para);
        }
        public int Delete(string id)
        {
            SqlParameter[] para = {
                                      new SqlParameter("DV_MADV", id)
                                  };

            return db.ExcuteSQL("SP_DICHVU_DELETE", para);
        }
    }
}
