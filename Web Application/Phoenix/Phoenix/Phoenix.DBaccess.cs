using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Phoniex.dbaccess
{
    public static class DBHelper
    {

        //Server=tcp:mhedb.database.chinacloudapi.cn,1433;Initial Catalog = zengguosqlservertest; Persist Security Info=False;uid=mheadmin;password=Dalian@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;

        private const string con = @"server=.\SQL2014;database=Phoenix;integrated security=sspi";
        private static SqlConnection connection = new SqlConnection(con);


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