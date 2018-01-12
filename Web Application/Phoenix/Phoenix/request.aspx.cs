
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
                DisplayPage(requestId);
            }
        }

        private bool editRequest()
        {
            return Session["id"].ToString() != "" ? true : false;
        }
        private bool createNotify()
        {
            return Session["BusinessCode"].ToString() == "A02" ? true : false;
        }
        private bool createRequest()
        {
            return Session["BusinessCode"].ToString() == "A01" ? true : false;
        }
        public void DisplayPage(string requestId)
        {
            if (editRequest())
            {
                SendForApprovalButton.Text = "Send for Approval";
                Request request = requestmodel.FindRequestById(requestId);
                BindRequest(request);
            }
            else
            {
                var requestid = Guid.NewGuid().ToString();
                RequestId.Text = requestid;
                if (createRequest())
                {
                    SendForApprovalButton.Text = "Send for Approval";
                }
                if (createNotify())
                {
                    SendForApprovalButton.Text = "Send";
                }
            }
        }
        public void BindRequest(Request request)
        {
            RequestId.Text = request.RequestId;
            RequestTitle.Text = request.RequestTitle;
            RequestDetails.Text = request.RequestDetail;
            //DueDatePicker.Value = request.DueDate.ToString();
            Priority.Checked = request.Priority == 1 ? true : false;
        }
        protected void SendForApprovalButtonClick(object sender, EventArgs e)
        {

            if (RequestTitle.Text == "" || RequestDetails.Text == "" || Request.Form["DueDate"] == "")
            {
                ErrorMessage.Text = "Please fill out all required fields!";
            }
            else
            {
                if (editRequest())
                {
                    UpdateRequest();
                    CallWebservice("A01");
                }
                if (createRequest())
                {
                    SaveNewRequestOrNotify(RequestStatusDetail.PENDINGREVIEW, "A01");
                    CallWebservice("A01");
                }
                if (createNotify())
                {
                    SaveNewRequestOrNotify(RequestStatusDetail.COMPLETED, "A02");
                    CallWebservice("A02");
                }
                Response.Redirect("index.aspx");
            }
        }               
        protected void CancelButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
        public bool SaveNewRequestOrNotify(RequestStatusDetail requeststatus, string businesscode)
        {
            bool addRequestFeedback = requestmodel.AddRequest(new Request
            {
                RequestId = RequestId.Text,
                RequestTitle = RequestTitle.Text,
                RequestDetail = RequestDetails.Text, 
                RequestStatus = requeststatus,
                Priority = GetPriority(),
                DueDate = Convert.ToDateTime(Request.Form["DueDate"]),
                ActionSource = "Web",
                BusinessCode = businesscode
            });
            return addRequestFeedback;
        }
        public bool UpdateRequest()
        {
            bool addRequestFeedback = requestmodel.UpdateRequestForEdit(new Request
            {
                RequestId = RequestId.Text,
                RequestTitle = RequestTitle.Text,
                RequestDetail = RequestDetails.Text,
                Priority = GetPriority(),
                DueDate = Convert.ToDateTime(Request.Form["DueDate"]),
            });
            return addRequestFeedback;
        }
        public int GetPriority()
        {
            int priority;
            switch (Priority.Checked)
            {
                case true:
                    priority = 1;
                    break;
                case false:
                    priority = 0;
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
                BusinessCode = code,
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
                FromEnterpriseId = "myte6666",
                OtherJsonDetails = ""
            };
        }
    }
}