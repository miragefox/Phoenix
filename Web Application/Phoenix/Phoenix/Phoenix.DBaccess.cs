using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Phoniex.dbaccess
{
    public static class DBHelper
     { 
         static SqlConnection connection; 
         private static SqlConnection Connection
         { 
             get { 
                 if (connection == null) 
                 { 
                     connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString);
                 } 
                 return connection; 
             } 
         } 

        /// <summary>
        /// add,delete,update
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, SqlParameter[] param = null)
        {
            try
            {
                connection.Open();//打开数据库连接
                SqlCommand com = new SqlCommand(sql, connection);
                if (param != null)
                {
                    com.Parameters.AddRange(param);
                }
                return com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// return select result
        /// </summary>
        /// <param name="selectCommand"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetRecords(string selectCommand, SqlParameter[] param = null)
        {
            try
            {
                //创建数据适配器对象
                SqlDataAdapter da = new SqlDataAdapter(selectCommand, Connection);
                if (param != null)
                {
                    da.SelectCommand.Parameters.AddRange(param);
                }
                //创建数据集
                DataSet ds = new DataSet();
                da.Fill(ds); //填充数据集 
                return ds.Tables[0];
            }
            catch (Exception e)
            {
                //throw e;
                throw new Exception(e.Message);
            }
        }
    }
}