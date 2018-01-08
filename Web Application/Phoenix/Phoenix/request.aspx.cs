
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
            var requestId = Session["id"].ToString();
            var busiessCode = Session["BusinessCode"].ToString();
            if (!IsPostBack)
            {
                ErrorMessage.Text = "";
                DisplayPage(requestId, busiessCode);
            }
        }

        public void DisplayPage(string requestId, string busiessCode)
        {
            if (requestId != "")
            {
                SendForApprovalButton.Text = "Send for Approval";
                Request request = requestmodel.FindRequestById(requestId);
                BindRequest(request);
            }
            else
            {
                var requestid = Guid.NewGuid().ToString();
                RequestId.Text = requestid;
                if (busiessCode == "A01")
                {
                    SendForApprovalButton.Text = "Send for Approval";
                }
                if (busiessCode == "A02")
                {
                    SendForApprovalButton.Text = "Send Notify";
                }
            }
        }

        public void BindRequest(Request request)
        {
            RequestId.Text = request.RequestId;
            RequestTitle.Text = request.RequestTitle;
            RequestDetails.Text = request.RequestDetail;
            //DueDatePicker.Value = request.DueDate.ToString();
            Priority.Checked = request.Priority == 0 ? true : false;
        }
        protected void SendForApprovalButtonClick(object sender, EventArgs e)
        {

            if (RequestTitle.Text == "" || RequestDetails.Text == "" || Request.Form["DueDate"] == "")
            {
                ErrorMessage.Text = "Please fill out all required fields!";
            }
            else
            {
                bool addRequestFeedback = SaveNewRequest(GetRequestStatus(), "A01");
                ReturnFeedback(addRequestFeedback);
                CallWebservice("A01");
                Response.Redirect("index.aspx");
            }
        }
        protected void NotifyButtonClick(object sender, EventArgs e)
        {
            if (RequestTitle.Text == "" || RequestDetails.Text == "" || Request.Form["DueDate"] == "")
            {
                ErrorMessage.Text = "Please fill out all required fields!";
            }
            else
            {
                bool addRequestFeedback = SaveNewRequest(GetRequestStatus(), "A02");
                ReturnFeedback(addRequestFeedback);
                CallWebservice("A02");
                Response.Redirect("index.aspx");
            }
        }
        public RequestStatusDetail GetRequestStatus()
        {
            RequestStatusDetail requestStatus = new RequestStatusDetail();
            if (SendForApprovalButton.Text == "Send for Approval")
            {
                requestStatus = RequestStatusDetail.PENDINGREVIEW;
            }
            if (SendForApprovalButton.Text == "Send Notify")
            {
                requestStatus = RequestStatusDetail.COMPLETED;
            }
            return requestStatus;
        }
        protected void CancelButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        public bool SaveNewRequest(RequestStatusDetail requeststatus, string businesscode)
        {
            bool addRequestFeedback = requestmodel.AddRequest(new Request
            {
                RequestId = RequestId.Text,
                RequestTitle = RequestTitle.Text,
                RequestDetail = RequestDetails.Text,
                Comments = "",
                RequestStatus = requeststatus,
                EditDttm = DateTime.Now,
                Priority = GetPriority(),
                CreateDate = DateTime.Now,
                DueDate = Convert.ToDateTime(Request.Form["DueDate"]),
                ActionSource = "Web",
                BusinessCode = businesscode
            });
            return addRequestFeedback;
        }
        public int GetPriority()
        {
            int priority;
            switch (Priority.Checked)
            {
                case false:
                    priority = 0;
                    break;
                case true:
                    priority = 1;
                    break;
                default:
                    priority = 0;
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
                AirId = "",
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
                DueDate = Request.Form["DueDate"],
                Priority = GetPriority(),
                FromEnterpriseId = "",
                OtherJsonDetails = ""
            };
        }
    }
}