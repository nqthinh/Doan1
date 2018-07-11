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
    public class BUSChucVu
    {
        DALChucVu dal = new DALChucVu();
        public DataTable GetData()
        {
            return dal.getData();
        }
    }
}
