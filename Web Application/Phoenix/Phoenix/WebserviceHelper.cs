using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Net.Http;

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

        public string SendForApprovalHttpPost(SendForApproval sendForApproval)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://mhe-ming-cluster.chinanorth.cloudapp.chinacloudapi.cn:20000/api/Requests");
                request.Method = "POST";
                request.ContentType = "application/json";
                string requestjsontrans = JsonConvert.SerializeObject(sendForApproval);

                //request.ContentLength = requestjsontrans.Length;
                StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);

                writer.Write(requestjsontrans);
                writer.Flush();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string encoding = response.ContentEncoding;
                if (encoding == null || encoding.Length < 1)
                {
                    encoding = "UTF-8"; //默认编码  
                }
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
                string retString = reader.ReadToEnd();

                return retString;

                //if (response.StatusCode == HttpStatusCode.OK)
                //{
                //    return "success!";
                //}

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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://mhe-ming-cluster.chinanorth.cloudapp.chinacloudapi.cn:20000/api/Requests/Update");
                request.Method = "POST";
                request.ContentType = "application/json";
                string modifyRequestjsontrans = JsonConvert.SerializeObject(modifyRequest);
                StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
                writer.Write(modifyRequestjsontrans);
                writer.Flush();

                // Get response  
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
                Console.ReadLine();

                //想返回什么？
            }
            catch (Exception)
            {
                throw;
            }


        }

        //public string SaveRequetJson(SendForApproval sendForApproval)
        //{
        //    StringWriter sw = new StringWriter();
        //    JsonWriter writer = new JsonTextWriter(sw);
        //    writer.WriteStartObject();
        //    writer.WritePropertyName("RequestId");
        //    writer.WriteValue(sendForApproval.RequestId);

        //    writer.WritePropertyName("AirId");
        //    writer.WriteValue(sendForApproval.AirId);

        //    writer.WritePropertyName("BusinessCode");
        //    writer.WriteValue(sendForApproval.BusinessCode);

        //    writer.WritePropertyName("ToPeople");
        //    writer.WriteStartArray();
        //    writer.WriteValue(sendForApproval.ToPeople);
        //    writer.WriteValue(sendForApproval.ToPeople);
        //    writer.WriteEndArray();

        //    writer.WritePropertyName("Title");
        //    writer.WriteValue(sendForApproval.Title);

        //    writer.WritePropertyName("Details");
        //    writer.WriteStartArray();
        //    writer.WriteValue(sendForApproval.Details);
        //    //??
        //    writer.WriteEndArray();

        //    writer.WriteEndObject();
        //    writer.Flush();
        //    string jsonText = sw.GetStringBuilder().ToString();

        //    return jsonText;
        //}

        //public string reLoadRequetJson(string jsonText)
        //{  
        //    JArray ja = (JArray)JsonConvert.DeserializeObject(jsonText);  
        //    return ja[0]["result"].ToString();  
        //}

    }

    public class SendForApproval
    {
        [JsonProperty]
        public string RequestId { get; set; }
        [JsonProperty]
        public string AirId { get; set; }
        [JsonProperty]
        public string BusinessCode { get; set; }
        [JsonProperty]
        public List<long> ToPeople { get; set; }
        [JsonProperty]
        public string Title { get; set; }
        [JsonProperty]
        public RequestDetail Details { get; set; }
    }

    public class RequestDetail
    {
        [JsonProperty]
        public string DueDate { get; set; }
        [JsonProperty]
        public int Priority { get; set; }//default 0: normal priority 1:High Priority
        [JsonProperty]
        public string FromEnterpriseId { get; set; }
        [JsonProperty]
        public string OtherJsonDetails { get; set; }

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
        public string UpdateUser { get; set; }
    }

    //public class OtherJsonDetails
    //{

    //}
}