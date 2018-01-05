using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;


/// <summary>  
/// 动态调用WebService  
/// </summary>  
/// <param name="url">WebService地址</param>  
/// <param name="classname">类名</param>  
/// <param name="methodname">方法名(模块名)</param>  
/// <param name="args">参数列表</param>  
/// <returns>object</returns>  
namespace Phoenix
{
    public class WebserviceHelper
    {
        public void SendForApprovalHttpPost(SendForApproval sendForApproval)
        {
            try
            {
                // Prepare web request...  
                var sendForApprovalUrl = ConfigurationManager.ConnectionStrings["SendForApprovalUrl"].ConnectionString;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sendForApprovalUrl); request.Method = "POST";
                request.ContentType = "application/json";

                var ToPeople = new List<long>();
                sendForApproval.ToPeople = ToPeople;
                sendForApproval.AirId = "6666";
                sendForApproval.ToPeople.Add(Convert.ToInt64("1213800"));

                string requestjsontrans = JsonConvert.SerializeObject(sendForApproval);
                StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
                writer.Write(requestjsontrans);
                writer.Flush();

                // Get response 
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModifyRequestIdHttpPost(ModifyRequest modifyRequest)
        {
            try
            {
                // Prepare web request... 
                var modifyRequestUrl = ConfigurationManager.ConnectionStrings["ModifyRequestUrl"].ConnectionString;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(modifyRequestUrl); request.Method = "POST";
                request.ContentType = "application/json";
                modifyRequest.UpdateUser = "yuhan";
                string modifyRequestjsontrans = JsonConvert.SerializeObject(modifyRequest);
                StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
                writer.Write(modifyRequestjsontrans);
                writer.Flush();

                // Get response  
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class SendForApproval
    {
        [JsonProperty]
        public string RequestId { get; set; }
        [JsonProperty]
        public string AirId { get; set; }//固定6666
        [JsonProperty]
        public string BusinessCode { get; set; } //原因，固定A01send for approval A02notification
        [JsonProperty]
        public List<long> ToPeople { get; set; }//发给谁personalnum随便给
        [JsonProperty]
        public string Title { get; set; }
        [JsonProperty]
        public RequestDetail Details { get; set; }
    }

    public class RequestDetail
    {
        [JsonProperty]
        public string DueDate { get; set; }//页面传值
        [JsonProperty]
        public int Priority { get; set; }//default 0: normal priority 1
        [JsonProperty]
        public string FromEnterpriseId { get; set; }//给死
        [JsonProperty]
        public string OtherJsonDetails { get; set; }//为空，不然手机没法解析

    }

    public class ModifyRequest
    {
        [JsonProperty]
        public string RequestId { get; set; }
        [JsonProperty]
        public string Comments { get; set; }
        [JsonProperty]
        public int ApprovalStatus { get; set; }
        [JsonProperty]
        public string UpdateUser { get; set; }//写死
    }

    //public class OtherJsonDetails
    //{

    //}

    //public enum ApprovalStatus//yongming的
    //{
    //    Pending,
    //    Approve,
    //    Reject,
    //    Ignore
    //}
}