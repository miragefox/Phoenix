using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phoenix
{
    public class RequestStatus
    {
        public enum RequestStatusDetail
        {
            PENDINGREVIEW = 0,
            APPROVED = 1,
            REJECTED = 2,
            COMPLETED = 3

        }
    }
}