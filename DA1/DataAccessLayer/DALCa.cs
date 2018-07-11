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
    public class DALCa
    {
        dbConnect db = new dbConnect();

        public DataTable getData() //Lấy tất cả dữ liệu ca
        {
            return db.getData("SP_CA_SELECT_ALL", null);
        }

        public DataTable getDataById(string id)   //Lấy dữ liệu bằng mã ca
        {
            SqlParameter[] para = {
                                      new SqlParameter("CA_MACA", id) //cạn lời
                                  };

            return db.getData("SP_CA_SELECT_BYID", para);
        }
    }
}
