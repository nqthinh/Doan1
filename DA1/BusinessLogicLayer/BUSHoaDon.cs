using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ValueObject;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    
    public class BUSHoaDon
    {
        DALHoaDon dal = new DALHoaDon();
        public DataTable getDataByDANHSACHKH(string hd)
        {
            return dal.getDataById(hd);
        }
        public DataTable getData()
        {
            return dal.getData();
        }
        public DataTable GetDataTruCuu()
        {
            return dal.GetDataTruCuu();
        }
        public DataTable getDataDANGKY()
        {
            return dal.getDataDANGKY();
        }
        public DataTable GetDataSuDungDichVu(string id)
        {
            return dal.getDataSuDungDichVu(id);
        }
        public int Insert(ObjHoaDon obj)
        {
            return dal.Insert(obj);
        }
        public int InsertDK(ObjHoaDon obj)
        {
            return dal.InsertDK(obj);
        }
        public int Update(ObjHoaDon obj)
        {
            return dal.Update(obj);
        }
        public int UpdateTrangThai(ObjHoaDon obj)
        {
            return dal.UpdateTrangThaiHoaDon(obj);
        }
        
    }
}
