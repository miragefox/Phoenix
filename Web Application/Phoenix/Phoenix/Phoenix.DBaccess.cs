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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// return one
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        //public static Request ExecuteScalar(string sql)
        //{
        //    var request = new Request();

        //    var da = new SqlDataAdapter(sql, connection);
        //    var requestTable = new DataSet();
        //    da.Fill(requestTable);

        //    if (requestTable.Tables[0].Rows.Count != 0)
        //    {
        //        request.RequestTitle = requestTable.Tables[0].Rows[0].Field<string>("RequestTitle");
        //        request.RequestDetail = requestTable.Tables[0].Rows[0].Field<string>("RequestDetail");
        //        request.Comments = requestTable.Tables[0].Rows[0].Field<string>("Comments");
        //        request.RequestStatus = requestTable.Tables[0].Rows[0].Field<Int32>("RequestStatus");
        //    }

        //    return request;

        //}

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
                SqlDataAdapter da = new SqlDataAdapter(selectCommand, connection);
                if (param != null)
                {
                    da.SelectCommand.Parameters.AddRange(param);
                }
                //创建数据集
                DataSet requestListTable = new DataSet();
                da.Fill(requestListTable);
                return requestListTable.Tables[0];
            }
            catch (Exception)
            {
                throw;
                //  throw new Exception(e.Message);
            }
        }
    }
}