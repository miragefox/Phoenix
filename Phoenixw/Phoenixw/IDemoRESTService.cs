using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace Phoenixw
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDemoRESTService" in both code and config file together.
    [ServiceContract]
    public interface IDemoRESTService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetDemoById/Id={Id}"
         )]
        Demo GetDemoById(string Id);

        [OperationContract]
        [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetDemoList"
         )]
        IList<Demo> GetDemoList();
    }
}
