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
    public class DALChucVu
    {
        dbConnect db = new dbConnect();

        public DataTable getData() //Lấy tất cả dữ liệu từ nhân viên, ca, chức vụ
        {
            return db.getData("SP_CHUCVU_SELECT_ALL", null);
        }
    }
}
