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
    public class BUSCa
    {
        DALCa dal = new DALCa();
        public DataTable GetData()
        {
            return dal.getData();
        }

        public DataTable GetDataByID(string ID)
        {
            return dal.getDataById(ID);
        }
    }
}
