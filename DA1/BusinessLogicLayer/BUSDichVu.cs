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
    public class BUSDichVu
    {
        DALDichVu dal = new DALDichVu();
        public DataTable GetData()
        {
            return dal.getData();
        }
        public DataTable GetDataByID(string ID)
        {
            return dal.getDataById(ID);
        }
        public int Insert(ObjDichVu obj)
        {
            return dal.Insert(obj);
        }
        public int Update(ObjDichVu obj)
        {
            return dal.Update(obj);
        }
        public int UpdateTrangThai(ObjDichVu obj)
        {
            return dal.UpdateTrangThai(obj);
        }

        public int Delete(string ID)
        {
            return dal.Delete(ID);
        }
    }
}
