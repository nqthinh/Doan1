using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using System.Data;
namespace BusinessLogicLayer
{
   public class BUSLoaiPhong
    {
       DALLoaiPhong dal = new DALLoaiPhong();
       public DataTable getData() //Lấy tất cả dữ liệu từ loại phong
       {
           return dal.getData();
       }
    }
}
