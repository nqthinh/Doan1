using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ValueObject;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    class BUSKhachHangKemTheo
    {
        DALKhachHangKemTheo dal = new DALKhachHangKemTheo();

        public DataTable getData()
        {
            return dal.getData();
        }
        public DataTable getDataById(string id)
        {
            return dal.getDataById(id);
        }
        public int Insert(ObjKhachHangKemTheo obj)
        {
            return dal.Insert(obj);
        }
        public int Update(ObjKhachHangKemTheo obj)
        {
            return dal.Update(obj);
        }
        public int Delete(string id)
        {
            return dal.Delete(id);
        }
    }
}
