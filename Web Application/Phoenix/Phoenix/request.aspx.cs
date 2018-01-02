
using System.Data.SqlClient;
using System;
using System.Text;
using Phoenix.PhoenixDataModel;
using static Phoenix.RequestStatus;
using static Phoenix.WebserviceHelper;
using System.Collections.Generic;

namespace Phoenix
{
    public partial class request : System.Web.UI.Page
    {
        RequestModel requestmodel = new RequestModel();

        WebserviceHelper wshelper = new WebserviceHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var requestid = Guid.NewGuid().ToString();
                RequestId.Text = requestid;
                ErrorMessage.Text = "";
            }

        }

        protected void SendForApprovalButtonClick(object sender, EventArgs e)
        {

            if (RequestId.Text == "" || RequestTitle.Text == "" || RequestDetails.Text == "")
            {
                ErrorMessage.Text = "Please fill out all required fields!";
            }
            else
            {
                bool addRequestFeedback = SaveNewRequest(RequestStatusDetail.PENDINGREVIEW);
                ReturnFeedback(addRequestFeedback);
                CallWebservice("A02");
                Response.Redirect("index.aspx");
            }
        }
        protected void NotifyButtonClick(object sender, EventArgs e)
        {
            if (RequestId.Text == "" || RequestTitle.Text == "" || RequestDetails.Text == "")
            {
                ErrorMessage.Text = "Please fill out all required fields!";
            }
            else
            {
                bool addRequestFeedback = SaveNewRequest(RequestStatusDetail.COMPLETED);
                ReturnFeedback(addRequestFeedback);
                CallWebservice("A01");
                Response.Redirect("index.aspx");
            }
        }
        protected void CancelButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        public bool SaveNewRequest(RequestStatusDetail requestStatus)
        {
            bool addRequestFeedback = requestmodel.AddRequest(new Request
            {
                RequestId = RequestId.Text,
                RequestTitle = RequestTitle.Text,
                RequestDetail = RequestDetails.Text,
                RequestStatus = requestStatus,
                EditTime = DateTime.Now,
                Priority = GetPriority()
            });
            return addRequestFeedback;
        }
         public int GetPriority()
        {
            int priority;
            switch (Priority.SelectedValue) 
            {
                case "Default":  priority = 0;
                    break;
                case "Low Importance": priority= 1;
                    break;
                case "High Importance": priority= 2;
                    break;
                default: priority= 0;
                    break;
            }
            return priority;
        }
        public void ReturnFeedback(bool feedback)
        {
            if (feedback)
            {
                Response.Write("<script>alert('Add a new request successfully!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Add a new request failed!');</script>");
            }
        }
        public void CallWebservice(string code)
        {
            SendForApproval sendforapprovalinfo = SetSendForApprovalInfo(code);
            wshelper.SendForApprovalHttpPost(sendforapprovalinfo);
        }
        public SendForApproval SetSendForApprovalInfo(string code)
        {
          return new SendForApproval
            {
                RequestId = RequestId.Text,
                AirId = "AirId",
                BusinessCode = code,
                ToPeople = new List<long> { 666666 },
                Title = RequestTitle.Text,
                Details = SetRequestDetailInfo()
            };
        }
        public RequestDetail SetRequestDetailInfo()
        {
            return new RequestDetail
            {
                DueDate = DateTime.Now.AddDays(1).ToString(),
                Priority = GetPriority(),
                FromEnterpriseId ="myte6666",
                OtherJsonDetails ="No Other Json"
            };
        }
    }
}