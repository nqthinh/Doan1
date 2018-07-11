using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class dbConnect
    {
        private SqlConnection connect { get; set; }

        public dbConnect()
        {
            connect = new SqlConnection("Data Source=210.245.90.220,1433;Network Library=DBMSSOCN;Initial Catalog=vtechsne_QLKS;User ID=vtechsne_QLKS;Password=#842Ewzm");
        }

        public DataTable getData(string query)
        {
            DataTable data = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(query, connect);

            connect.Open();

            adapter.Fill(data);

            connect.Close();

            return data;
        }

        public DataTable getData(string procName, SqlParameter[] para)
        {
            DataTable data = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
            if (para != null)
            {
                cmd.Parameters.AddRange(para);
            }
            cmd.Connection = connect;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            connect.Open();
            adapter.Fill(data);
            connect.Close();

            return data;
        }

        public int ExcuteSQL(string query)
        {
            SqlCommand cmd = new SqlCommand(query, connect);

            connect.Open();
            int row = cmd.ExecuteNonQuery();
            connect.Close();

            return row;
        }

        public int ExcuteSQL(string procName, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = connect;
            if (para != null)
            {
                cmd.Parameters.AddRange(para);
            }

            connect.Open();
            int row = cmd.ExecuteNonQuery();
            connect.Close();

            return row;
        }
    }
}
