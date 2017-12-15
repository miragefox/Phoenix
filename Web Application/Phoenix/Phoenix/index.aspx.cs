using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phoenix
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public enum RequestStatus
        {
            PENDINGAPPROVAL = 0,
            APPROVED = 1  ,
            REJECTED = 2,
            COMPLETED = 3
        }
    }
}