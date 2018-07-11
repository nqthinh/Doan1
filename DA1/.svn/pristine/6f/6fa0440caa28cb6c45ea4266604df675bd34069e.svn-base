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

    public class DALHoaDon
    {
        dbConnect db = new dbConnect();
        public DataTable getData()
        {
            return db.getData("SP_HOADON_SELECT_ALL", null);
        }
        public DataTable GetDataTruCuu()
        {
            return db.getData("SP_HOADON_TRACUU", null);
        }
        
        public DataTable getDataDANGKY()
        {
            return db.getData("SP_HOADON_SELECT_DANGKY", null);
        }
        public DataTable getDataById(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("HD_MAHD", id)
            };
            return db.getData("SP_HOADON_SELECT_BYID", para);
        }
        public DataTable getDataSuDungDichVu(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("HD_MAHD", id)
            };
            return db.getData("SP_HOADON_DANHSACHDICHVU", para);
        }
        
        public int Insert(ObjHoaDon obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("HD_MAHD", obj.HD_MaHoaDon),
                new SqlParameter("PHG_MAPHONG", obj.PHG_MaPhong),
                new SqlParameter("NV_MANV", obj.NV_MANV),
                new SqlParameter("KH_MAKH", obj.KH_MaKH),
                new SqlParameter("HD_NGAYHD", obj.HD_NgayHoaDon),
                new SqlParameter("HD_SOLUONGKHACH", obj.HD_SoLuongKhach),
                new SqlParameter("HD_NGAYTHUE", obj.HD_NgayThue),
                new SqlParameter("HD_TRANGTHAI", obj.HD_TrangThaiHoaDon)
               
            };
            return db.ExcuteSQL("SP_HOADON_INSERT", para);
        }
        public int InsertDK(ObjHoaDon obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("HD_MAHD", obj.HD_MaHoaDon),
                new SqlParameter("PHG_MAPHONG", obj.PHG_MaPhong),
                new SqlParameter("NV_MANV", obj.NV_MANV),
                new SqlParameter("KH_MAKH", obj.KH_MaKH),
                new SqlParameter("HD_SOLUONGKHACH", obj.HD_SoLuongKhach),
                new SqlParameter("HD_NGAYTHUE", obj.HD_NgayThue),
                new SqlParameter("HD_TRANGTHAI", obj.HD_TrangThaiHoaDon)
            };
            return db.ExcuteSQL("SP_HOADON_INSERT_FROMDANGKY", para);
        }
        public int UpdateTrangThaiHoaDon(ObjHoaDon obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("HD_MAHD", obj.HD_MaHoaDon),
                new SqlParameter("HD_TRANGTHAI", obj.HD_TrangThaiHoaDon),
                new SqlParameter("HD_NGAYTRA", obj.HD_NgayTra)
            };
            return db.ExcuteSQL("SP_HOADON_UPDATE_TRANGTHAI", para);
        }
        public int Update(ObjHoaDon obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("HD_MAHD", obj.HD_MaHoaDon),
                new SqlParameter("PHG_MAPHONG", obj.PHG_MaPhong),
                new SqlParameter("NV_MANV", obj.NV_MANV),
                new SqlParameter("KH_MAKH", obj.KH_MaKH),
                new SqlParameter("HD_NGAYHD", obj.HD_NgayHoaDon),
                new SqlParameter("HD_SOLUONGKHACH", obj.HD_SoLuongKhach),
                new SqlParameter("HD_NGAYTHUE", obj.HD_NgayThue)
            };
            return db.ExcuteSQL("SP_HOADON_UPDATE", para);
        }
        public int Delete(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("HD_MAHD", id)
                
            };
            return db.ExcuteSQL("SP_HOADON_DELETE", para);
        }
    }
}
