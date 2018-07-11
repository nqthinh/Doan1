using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DALKhachHangKemTheo
    {
        dbConnect db = new dbConnect();
        public DataTable getData()
        {
            return db.getData("SP_KHACHHANGKEMTHEO_SELECT_ALL", null);
        }
        public DataTable getDataById(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("KH_MAKH", id)
            };
            return db.getData("SP_KHACHHANGKEMTHEO_SELECT_BYID", para);
        }
        public int Insert(ObjKhachHangKemTheo obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("KH_MAKH", obj.KH_MaKH),
                new SqlParameter("HD_MAHD", obj.HD_MaHoaDon),
                new SqlParameter("LOAIKHACH", obj.LoaiKhach),
            };
            return db.ExcuteSQL("SP_KHACHANGKEMTHEO_INSERT", para);
        }
        public int Update(ObjKhachHangKemTheo obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("KH_MAKH", obj.KH_MaKH),
                new SqlParameter("HD_MAHD", obj.HD_MaHoaDon),
                new SqlParameter("LOAIKHACH", obj.LoaiKhach),
            };
            return db.ExcuteSQL("SP_KHACHANGKEMTHEO_UPDATE", para);
        }
        public int Delete(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("KH_MAKH", id)
                
            };
            return db.ExcuteSQL("SP_KHACHANGKEMTHEO_DELETE", para);
        }
    }
}
