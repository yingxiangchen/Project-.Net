using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public  class DBReaderWriter
    {
        public static SqlConnection GetConn()
        {
            string connstr = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            //string connstr = ConfigurationManager.AppSettings["connstr"];
            SqlConnection conn = new SqlConnection(connstr);
            return conn;
        }
        public static DataSet SelectData(string sql)
        {
            return SelectData(sql, null);
        }
        public static DataSet SelectData(string sql, SqlParameter[] Parameters)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection();
            conn = GetConn();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            if (Parameters != null)
            {
                foreach (SqlParameter parm in Parameters)
                {
                    if (parm.Value == null)
                    {
                        //如果参数值为Null 将替换为数据库值NULL ，这样就不会报没有参数错误	
                        parm.Value = DBNull.Value;
                    }
                    da.SelectCommand.Parameters.Add(parm);
                }
            }
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public static bool ExecuteSql(string sql)
        {
            return ExecuteSql(sql, null);
        }
        public static bool ExecuteSql(string sql, SqlParameter[] Parameters)
        {
            bool flag = false;
            SqlConnection conn = new SqlConnection();
            conn = GetConn();
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (Parameters != null)
            {
                foreach (SqlParameter parm in Parameters)
                {
                    if (parm.Value == null)
                    {
                        //如果参数值为Null 将替换为数据库值NULL ，这样就不会报没有参数错误	
                        parm.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parm);
                }
            }
            conn.Open();
            flag = cmd.ExecuteNonQuery() > 0;
            conn.Close();
            return flag;
        }
    }
}
