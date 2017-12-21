using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Phoniex.dbaccess
{
    public class DBHelper
    {

        //数据库连接
        //public static string SqlConnection = @"server=.\SQL2014;database=Phoenix;integrated security=sspi";
        //公共连接对象
        ////public static SqlConnection con;

        private const string con = @"server=.\SQL2014;database=Phoenix;integrated security=sspi";
        private static SqlConnection connection = new SqlConnection(con);


        /// <summary>
        /// 读取数据
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader Reader(string sql)
        {
            try
            {
                connection.Open();
                SqlCommand com = new SqlCommand(sql, connection);
                return com.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 增删改数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            try
            {
                connection.Open();   //打开数据库连接
                SqlCommand com = new SqlCommand(sql, connection);
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
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataSet Fill(string sql, string tableName)
        {
            try
            {
                connection.Open();  //打开连接
                //创建数据适配器对象
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                //创建数据集
                DataSet ds = new DataSet();
                da.Fill(ds, tableName); //填充数据集
                return ds;
            }
            catch (Exception)
            {
                throw;
                //将异常引发出现
                //  throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}