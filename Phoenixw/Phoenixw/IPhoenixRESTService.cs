using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.Data;
using Newtonsoft.Json;

namespace Phoenixw
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDemoRESTService" in both code and config file together.
    [ServiceContract]
    public interface IPhoenixRESTService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
           BodyStyle = WebMessageBodyStyle.Bare,
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "PhoenixRequestUpdate"
         )]
        void InsertRequest(PhoenixRequest phoenixRequest);

        //新增数据
        //[OperationContract]
        //void InsertRequestToDB(string requestId, string requestTitle, string requestDetail, string comments, Status requestStatus);
        //删除数据
        [OperationContract]
        void DeleteRequestToDB(string requestId);
        //修改数据
        [OperationContract]
        void UpdataRequestToDB(string requestId);
        //查询数据
        [OperationContract]
        void SelectRequestToDB(string requestId);


    }
}
