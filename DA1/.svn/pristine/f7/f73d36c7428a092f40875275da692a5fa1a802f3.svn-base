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
    public class DALLoaiPhong
    {
        dbConnect db = new dbConnect();
        public DataTable getData() //Lấy tất cả dữ liệu từ loại phong
        {
            return db.getData("SP_LOAIPHONG_SELECT_ALL", null);
        }
    }
}
