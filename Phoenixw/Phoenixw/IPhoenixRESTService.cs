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
    }
}
