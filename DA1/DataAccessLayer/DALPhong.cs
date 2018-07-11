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
    public class DALPhong
    {
        dbConnect db = new dbConnect();

        public DataTable getData()//Lay du lieu tu phong
        {
            return db.getData("SP_PHONG_GETDATA_FULL", null);
        }
        
        public DataTable getDataById(string id)//Lay du lieu tu phong qua ma nhan vien
        {
            SqlParameter[] para =  {
                                       new SqlParameter("PHG_MAPHONG",id)
                                   };
            return db.getData("SP_PHONG_SELECT_BYID", para);
        }

        public int Insert(ObjPhong obj)
        {
            SqlParameter[] para = {
                                      new SqlParameter("PHG_MAPHONG", obj.PHG_MaPhong),
                                      new SqlParameter("PHG_HIENTRANG", obj.PHG_HienTrang),
                                      new SqlParameter("PHG_SDTPHONG", obj.PHG_SDTPhong),
                                      new SqlParameter("PHG_GIA", obj.PHG_Gia),
                                      new SqlParameter("LPHG_MALOAI", obj.LPHG_MaLoai),
                                      new SqlParameter("@PHG_SLMAX", obj.PHG_SLMax)
                                  };
            return db.ExcuteSQL("SP_PHONG_INSERT", para);
        }

        public int Update(ObjPhong obj)
        {
            SqlParameter[] para = {
                                      new SqlParameter("PHG_MAPHONG", obj.PHG_MaPhong),
                                      new SqlParameter("PHG_HIENTRANG", obj.PHG_HienTrang),
                                      new SqlParameter("PHG_SDTPHONG", obj.PHG_SDTPhong),
                                      new SqlParameter("PHG_GIA", obj.PHG_Gia),
                                      new SqlParameter("LPHG_MALOAI", obj.LPHG_MaLoai),
                                      new SqlParameter("@PHG_SLMAX", obj.PHG_SLMax)                                    
                                  };
            return db.ExcuteSQL("SP_PHONG_UPDATE", para);
        }
        public int UpdateTrangThai(ObjPhong obj)
        {
            SqlParameter [] para  = {
                                        new SqlParameter("PHG_MAPHONG", obj.PHG_MaPhong),
                                        new SqlParameter("PHG_HIENTRANG", obj.PHG_HienTrang)
                                    };
            return db.ExcuteSQL("SP_PHONG_UPDATE_FORMTRANGTHAI", para);
        }

        public int Delete(string id)
        {
            SqlParameter[] para = {
                                      new SqlParameter("PHG_MAPHONG", id)
                                  };
            return db.ExcuteSQL("SP_PHONG_DELETE", para);
        }
    }
}
