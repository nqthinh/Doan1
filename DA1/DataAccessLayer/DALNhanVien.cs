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
    public class DALNhanVien
    {
        dbConnect db = new dbConnect();

        public DataTable getData() //Lấy tất cả dữ liệu từ nhân viên, ca, chức vụ
        {
            return db.getData("SP_NHANVIEN_GETDATA_FULL", null);
        }

        public DataTable getDataById(string id)   //Lấy dữ liệu bằng mã nhân viên
        {
            SqlParameter[] para = {
                                      new SqlParameter("NV_MANV", id)
                                  };

            return db.getData("SP_NHANVIEN_SELECT_BYID", para);
        }

        public int Insert(ObjNhanVien obj)
        {
            SqlParameter[] para = {
                                      new SqlParameter("NV_MANV", obj.NV_MaNV),
                                      new SqlParameter("CV_MACV", obj.CV_MaCV),
                                      new SqlParameter("CA_MACA", obj.CA_MaCa),
                                      new SqlParameter("NV_HOTEN", obj.NV_HoTen),
                                      new SqlParameter("NV_NGAYSINH", obj.NV_NgaySinh),
                                      new SqlParameter("NV_GIOITINH", obj.NV_GioiTinh),
                                      new SqlParameter("NV_DIACHI", obj.NV_DiaChi),
                                      new SqlParameter("NV_CMND", obj.NV_CMND),
                                      new SqlParameter("NV_SDT", obj.NV_SDT)
                                  };

            return db.ExcuteSQL("SP_NHANVIEN_INSERT", para);
        }

        public int Update(ObjNhanVien obj)
        {
            SqlParameter[] para = {
                                      new SqlParameter("NV_MANV", obj.NV_MaNV),
                                      new SqlParameter("CV_MACV", obj.CV_MaCV),
                                      new SqlParameter("CA_MACA", obj.CA_MaCa),
                                      new SqlParameter("NV_HOTEN", obj.NV_HoTen),
                                      new SqlParameter("NV_NGAYSINH", obj.NV_NgaySinh),
                                      new SqlParameter("NV_GIOITINH", obj.NV_GioiTinh),
                                      new SqlParameter("NV_DIACHI", obj.NV_DiaChi),
                                      new SqlParameter("NV_CMND", obj.NV_CMND),
                                      new SqlParameter("NV_SDT", obj.NV_SDT)
                                  };

            return db.ExcuteSQL("SP_NHANVIEN_UPDATE", para);
        }

        public int Delete(string id)
        {
            SqlParameter[] para = {
                                      new SqlParameter("NV_MANV", id)
                                  };

            return db.ExcuteSQL("dboSP_NHANVIEN_DELETE", para); //
            
        }
    }
}
