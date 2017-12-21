using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phoenix.PhoenixDataModel
{
    public class PhoenixDataModel
    {
        public class Request
        {
            public string RequestId { get; set; }
            public string RequestTitle { get; set; }
            public string RequestDetail { get; set; }
            public string Comments { get; set; }
            public int RequestStatus { get; set; }
        }
    }
}