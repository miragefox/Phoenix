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
        /// 增删改数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, SqlParameter[] param = null)
        {       
            try
            {
                connection.Open();   //打开数据库连接
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
        /// 返回单个值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql)   
        {
            try
            {
                connection.Open();   //打开数据库连接
                SqlCommand com = new SqlCommand(sql, connection);
                return com.ExecuteScalar();

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
        /// 返回数据集
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
                DataSet ds = new DataSet();
                da.Fill(ds); //填充数据集
                return ds.Tables[0];
            }
            catch (Exception)
            {
                throw;
                //将异常引发出现
                //  throw new Exception(e.Message);
            }
        }
    }
}