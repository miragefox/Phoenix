using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Phoenix.PhoenixDataModel;

namespace Phoniex.dbaccess
{
    public static class DBHelper
    {
        private static SqlConnection connection = new SqlConnection(@"server=.\SQL2014;database=Phoenix;integrated security=sspi");

        /// <summary>
        /// add,delete,update
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string sql, SqlParameter[] param = null)
        {
            try
            {
                connection.Open();
                SqlCommand com = new SqlCommand(sql, connection);
                if (param != null)
                {
                    com.Parameters.AddRange(param);
                }
                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
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
        public static Request ExecuteScalar(string sql)
        {
            var request = new Request();

            var da = new SqlDataAdapter(sql, connection);
            var requestTable = new DataSet();
            da.Fill(requestTable);

            if (requestTable.Tables[0].Rows.Count != 0)
            {
                request.RequestTitle = requestTable.Tables[0].Rows[0].Field<string>("RequestTitle");
                request.RequestDetail = requestTable.Tables[0].Rows[0].Field<string>("RequestDetail");
                request.Comments = requestTable.Tables[0].Rows[0].Field<string>("Comments");
                request.RequestStatus = requestTable.Tables[0].Rows[0].Field<Int32>("RequestStatus");
            }

            return request;

        }
        /// <summary>
        /// return all
        /// </summary>
        /// <param name="selectCommand"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetRecords(string selectCommand, SqlParameter[] param = null)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(selectCommand, connection);
                if (param != null)
                {
                    da.SelectCommand.Parameters.AddRange(param);
                }

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