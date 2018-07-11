using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using ValueObject;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class BUSKhachHang
    {
        DALKhachHang dal = new DALKhachHang();

        public DataTable getData()
        {
            return dal.getData();
        }
        public DataTable getDataById(string id)
        {
            return dal.getDataById(id);
        }
        public int Insert(ObjKhachHang obj)
        {
            return dal.Insert(obj);
        }
        public int Update(ObjKhachHang obj)
        {
            return dal.Update(obj);
        }
        public int Delete(string id)
        {
            return dal.Delete(id);
        }

        public int InsertDK(ObjKhachHang obj)
        {
            return dal.InsertDK(obj);
        }
    }
}
