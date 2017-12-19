using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Phoenixw
{
    [DataContract]
    public class PhoenixRequest
    {
        [DataMember]
        public string RequestId { get; set; }
        [DataMember]
        public string RequestTitle { get; set; }
        [DataMember]
        public string RequestDetail { get; set; }
        [DataMember]
        public string Comments { get; set; }
        public Status Status { get; set; }
        //public DateTime UpdateTime { get; set; }
        //public string UpdateUser { get; set; }

    }
    public enum Status
    {
        PenddingApprove,
        Approved,
        Rejected,
        Cpmpleted
    }
}