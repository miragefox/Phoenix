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
                foreach (var item in requetslist) {
                    var requestId = item.RequestId;
                    var requestTitle = item.RequestTitle;
                    var requestDetail = item.RequestDetail;
                    var comments = item.Comments;
                    var requestStatus = item.Status;

                    InsertRequestToDB(requestId, requestTitle, requestDetail, comments, requestStatus);
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
        private void InsertRequestToDB(string requestId, string requestTitle, string requestDetail, string comments , Status requestStatus)
        {
            try
            {
                sqlConnection.Open();
                string strSql = "INSERT INTO Request(RequestId,RequestTitle,RequestDetail,Comments,RequestStatus) VALUES(@requestId,@requestTitle,@requestDetail,@comments,@requestStatus)";
                SqlCommand cmd = new SqlCommand(strSql, sqlConnection);
                SqlParameter parn = new SqlParameter("@requestId", requestId);
                cmd.Parameters.Add(parn);
                SqlParameter parp = new SqlParameter("@requestTitle", requestTitle);
                cmd.Parameters.Add(parp);
                SqlParameter parr = new SqlParameter("@requestDetail", requestDetail);
                cmd.Parameters.Add(parr);
                SqlParameter parc = new SqlParameter("@comments", comments);
                cmd.Parameters.Add(parc);
                SqlParameter parre = new SqlParameter("@requestStatus", requestStatus);
                cmd.Parameters.Add(parre);
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

        //删除数据
        public void DeleteRequestToDB(string requestId)
        {
            try
            {
                sqlConnection.Open();
                string strSql = "DELETE FROM Login WHERE RequestId = @requestId";
                SqlCommand cmd = new SqlCommand(strSql, sqlConnection);
                SqlParameter parn = new SqlParameter("@requestId", requestId);
                cmd.Parameters.Add(parn);
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


        //修改数据
        public void UpdataRequestToDB(string requestId)
        {
            try
            {
                sqlConnection.Open();
                string strSql = "UPDATE  Login  SET RequestId=@requestId WHERE RequestId=@requestId";
                SqlCommand cmd = new SqlCommand(strSql, sqlConnection);
                SqlParameter parn = new SqlParameter("@requestId", requestId);
                cmd.Parameters.Add(parn);
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
        //查询数据
        public void SelectRequestToDB(string requestId)
        {
            try
            {
                sqlConnection.Open();
                string strSql = "SELECT UName,UPassword FROM Login ";
                DataSet ds = new DataSet();
                SqlDataAdapter s = new SqlDataAdapter(strSql, sqlConnection);
                s.Fill(ds);
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
