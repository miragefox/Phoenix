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
        public string Comments { get; set; }
        [DataMember]
        public Status Status { get; set; }
        [DataMember]
        public DateTime EditDttm { get; set; }
    }
    public enum Status
    {
        Pending,
        Approve,
        Reject,
        Ignore
    }
}