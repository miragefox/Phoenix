using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Phoenixw
{
    [DataContract]
    public class Demo
    {
        [DataMember]
        public int Id { get; set; }
    }
}