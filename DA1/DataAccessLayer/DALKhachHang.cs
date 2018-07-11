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
    public class DALKhachHang
    {
        dbConnect db = new dbConnect();
        public DataTable getData()
        {
            return db.getData("SP_KHACHHANG_SELECT_ALL", null);
        }
        public DataTable getDataById(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("KH_MAKH", id)
            };
            return db.getData("SP_KHACHHANG_SELECT_BYID", para);
        }
        public int Insert(ObjKhachHang obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("KH_MAKH", obj.KH_MaKH),
                new SqlParameter("KH_TENKH", obj.KH_TenKH),
                new SqlParameter("KH_NGAYSINH", obj.KH_NgaySinh),
                new SqlParameter("KH_QUOCTICH", obj.KH_QuocTich),
                new SqlParameter("KH_SDT", obj.KH_SDT),
                new SqlParameter("KH_DIACHI", obj.KH_DiaChi),
                new SqlParameter("KH_CMND", obj.KH_CMND),
            };
            return db.ExcuteSQL("SP_KHACHANG_INSERT", para);
        }
        public int InsertDK(ObjKhachHang obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("KH_MAKH", obj.KH_MaKH),
                new SqlParameter("KH_TENKH", obj.KH_TenKH),
                new SqlParameter("KH_SDT", obj.KH_SDT)
            };
            return db.ExcuteSQL("SP_KHACHHANG_INSERT_CHECKOUT", para);
        }
        public int Update(ObjKhachHang obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("KH_MAKH", obj.KH_MaKH),
                new SqlParameter("KH_TENKH", obj.KH_TenKH),
                new SqlParameter("KH_NGAYSINH", obj.KH_NgaySinh),
                new SqlParameter("KH_QUOCTICH", obj.KH_QuocTich),
                new SqlParameter("KH_SDT", obj.KH_SDT),
                new SqlParameter("KH_DIACHI", obj.KH_DiaChi),
                new SqlParameter("KH_CMND", obj.KH_CMND)
            };
            return db.ExcuteSQL("SP_KHACHANG_UPDATE", para);
        }
        public int Delete(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("KH_MAKH", id)
                
            };
            return db.ExcuteSQL("SP_KHACHANG_DELETE", para);
        }


        public int Insert_HT(ObjKhachHang obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("KH_MAKH", obj.KH_MaKH),
                new SqlParameter("KH_TENKH", obj.KH_TenKH),           
                new SqlParameter("KH_SDT", obj.KH_SDT)
            };
            return db.ExcuteSQL("SP_KHACHHANG_INSERT", para);
        }

    }
}
