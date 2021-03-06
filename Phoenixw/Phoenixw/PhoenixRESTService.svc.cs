﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;

namespace Phoenixw
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DemoRESTService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DemoRESTService.svc or DemoRESTService.svc.cs at the Solution Explorer and start debugging.
    public class PhoenixRESTService : IPhoenixRESTService
    {
        //连接本地数据库
        //SqlConnection sqlConnection = new SqlConnection(@"server=.\SQL2014;database=Phoenix;integrated security=sspi");
        //Azure数据库
        SqlConnection sqlConnection = new SqlConnection(@"Server=tcp:xueyangserver.database.chinacloudapi.cn,1433;Initial Catalog = xueyangDB; Persist Security Info=False;uid=MHEAdmin;password=Dalian@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;");

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
                    var actionSource ="Mobile";
                    UpdateRequestToDB(requestId, comments, requestStatus, editDttm, actionSource);
                }
             }

            catch (Exception ex)
            {
                woc.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;
                woc.OutgoingResponse.StatusDescription = ex.Message;
            }

        }

        //更新数据库
        private void UpdateRequestToDB(string requestId, string comments, Status requestStatus, DateTime editDttm, String actionSource)
        {
            WebOperationContext woc = WebOperationContext.Current;
            try
            {
                sqlConnection.Open();
                SqlCommand mycmd = new SqlCommand("SELECT RequestId FROM Request WHERE RequestId=@requestId", sqlConnection);
                SqlParameter parq = new SqlParameter("@requestId", requestId);
                mycmd.Parameters.Add(parq);
                SqlDataReader mysdr = mycmd.ExecuteReader();
                if (mysdr.HasRows)
                {
                    sqlConnection.Close();
                    //已经有记录使用此编号
                    try
                    {
                        sqlConnection.Open();

                        string strSql = "UPDATE  Request  SET Comments=@comments,RequestStatus=@requestStatus,EditDttm=@editDttm,ActionSource=@actionSource WHERE RequestId=@requestId";
                        SqlCommand cmd = new SqlCommand(strSql, sqlConnection);
                        SqlParameter parn = new SqlParameter("@requestId", requestId);
                        cmd.Parameters.Add(parn);
                        SqlParameter parc = new SqlParameter("@comments", comments);
                        cmd.Parameters.Add(parc);
                        SqlParameter parre = new SqlParameter("@requestStatus", requestStatus);
                        cmd.Parameters.Add(parre);
                        SqlParameter parra = new SqlParameter("@editDttm", editDttm);
                        cmd.Parameters.Add(parra);
                        SqlParameter parrd = new SqlParameter("@actionSource", actionSource);
                        cmd.Parameters.Add(parrd);
                        //result接受受影响的行数，也就是说大于0的话表示添加成功
                        int result = cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        woc.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
                        woc.OutgoingResponse.StatusDescription = "Update successfully!";

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    woc.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    woc.OutgoingResponse.StatusDescription = "Can not find the requestId";

                }
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
