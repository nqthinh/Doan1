using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using ValueObject;

namespace BusinessLogicLayer
{
    public class BUSPhong
    {
        DALPhong dal = new DALPhong();
        
        public DataTable GetData()
        {
            return dal.getData();
        }
        
        public DataTable GetDataByID(string ID)
        {
            return dal.getDataById(ID);
        }

        public int Insert(ObjPhong obj)
        {
            return dal.Insert(obj);
        }

        public int Update(ObjPhong obj)
        {
            return dal.Update(obj);
        }
        public int UpdateTrangThai(ObjPhong obj)
        {
            return dal.UpdateTrangThai(obj);
        }

        public int Delete (string id)
        {
            return dal.Delete(id);
        }
    }
}
