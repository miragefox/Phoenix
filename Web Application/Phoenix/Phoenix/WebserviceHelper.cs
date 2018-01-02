using System;
using System.Collections.Generic;
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
        public SendForApproval PostData { get; set; }

        public void SendForApprovalHttpPost(SendForApproval sendForApproval)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://mhe-ming-cluster.chinanorth.cloudapp.chinacloudapi.cn:20000/api/Requests");//webconfig里
                request.Method = "POST";
                request.ContentType = "application/json";

                var ToPeople = new List<long>();
                sendForApproval.ToPeople = ToPeople;
                sendForApproval.AirId = "6666";
                sendForApproval.ToPeople.Add(Convert.ToInt64("1213800"));

                string requestjsontrans = JsonConvert.SerializeObject(sendForApproval);
                StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);

                writer.Write(requestjsontrans);
                writer.Flush();

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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://mhe-ming-cluster.chinanorth.cloudapp.chinacloudapi.cn:20000/api/Requests/Update");//webconfig里
                request.Method = "POST";
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
        public string BusinessCode { get; set; } //原因，固定A01不需要update A02需要
        [JsonProperty]
        public List<long> ToPeople { get; set; }//发给谁personalnum随便给？
        [JsonProperty]
        public string Title { get; set; }
        [JsonProperty]
        public RequestDetail Details { get; set; }
    }

    public class RequestDetail
    {
        [JsonProperty]
        public string DueDate { get; set; }//截止时间，固定的当前+5或随机
        [JsonProperty]
        public int Priority { get; set; }//default 0: normal priority 1:High Priority2
        [JsonProperty]
        public string FromEnterpriseId { get; set; }//谁发的，随便？
        [JsonProperty]
        public string OtherJsonDetails { get; set; }//我们的details放这里？

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
}