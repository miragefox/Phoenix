using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Threading.Tasks;

namespace Phoenixw
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DemoRESTService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DemoRESTService.svc or DemoRESTService.svc.cs at the Solution Explorer and start debugging.
    public class PhoenixRESTService : IPhoenixRESTService
    {
        //连接本地数据库
        SqlConnection sqlConnection = new SqlConnection(@"server=.\SQL2014;database=Phoenix;integrated security=sspi");
        
        public void InsertRequest(PhoenixRequest phoenixRequest)
        {
            WebOperationContext woc = WebOperationContext.Current;
            woc.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;

            try
            {
                IList<PhoenixRequest> requetslist = new List<PhoenixRequest>();
                requetslist.Add(phoenixRequest);
                foreach (var item in requetslist)
                {
                    var requestId = item.RequestId;
                    var comments = item.Comments;
                    var requestStatus = item.Status;
                    var editDttm = DateTime.Now;
                    UpdateRequestToDB(requestId, comments, requestStatus, editDttm);
                }

                woc.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
             }
            catch (Exception ex)
            {
                woc.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;
                woc.OutgoingResponse.StatusDescription = ex.Message;
            }

        }

        //添加数据
        private void UpdateRequestToDB(string requestId, string comments, Status requestStatus, DateTime editDttm)
        {
            //try
            //{
            //    sqlConnection.Open();
            //    //string strSql = "SELECT RequestId FROM Request";
            //    //DataSet ds = new DataSet();
            //    //SqlDataAdapter s = new SqlDataAdapter(strSql, sqlConnection);
            //    //s.Fill(ds);
            //    SqlCommand mycmd = new SqlCommand("SELECT RequestId FROM Request", sqlConnection);
            //    SqlDataReader mysdr = mycmd.ExecuteReader();
            //    if (mysdr.HasRows)
            //    {
            //        //已经有记录使用此编号
            //    }
            //}

            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    sqlConnection.Close();
            //}
            try
            {
                sqlConnection.Open();

                string strSql = "UPDATE  Request  SET Comments=@comments,RequestStatus=@requestStatus,EditDttm=@editDttm WHERE RequestId=@requestId";
                SqlCommand cmd = new SqlCommand(strSql, sqlConnection);
                SqlParameter parn = new SqlParameter("@requestId", requestId);
                cmd.Parameters.Add(parn);
                SqlParameter parc = new SqlParameter("@comments", comments);
                cmd.Parameters.Add(parc);
                SqlParameter parre = new SqlParameter("@requestStatus", requestStatus);
                cmd.Parameters.Add(parre);
                SqlParameter parra = new SqlParameter("@editDttm", editDttm);
                cmd.Parameters.Add(parra);
                //result接受受影响的行数，也就是说大于0的话表示添加成功
                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

    }


}
