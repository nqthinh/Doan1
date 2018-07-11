using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ValueObject;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BUSChiTietHoaDon
    {
        DALChiTietHoaDon dal = new DALChiTietHoaDon();
        public DataTable GetData()
        {
            return dal.getData();
        }
        public DataTable getDataDoanhThu()
        {
            return dal.getDataDoanhThu();
        }
        public DataTable GetDataByID(string id)
        {
            return dal.getDataByID(id);
        }
        public DataTable getDataMaHoaDon(string id)
        {
            return dal.getDataMaHoaDon(id);
        }
        public int Insert(ObjChiTietHoaDon obj)
        {
            return dal.Insert(obj);
        }
        public int Update(ObjChiTietHoaDon obj)
        {
            return dal.Update(obj);
        }
        public int Delete(string id)
        {
            return dal.Delete(id);
        }
    }
}
