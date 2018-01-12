using Phoenix.PhoenixDataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static Phoenix.RequestStatus;

namespace Phoenix
{
    public partial class handle : System.Web.UI.Page
    {
        WebserviceHelper wshelper = new WebserviceHelper();

        protected void Page_Load(object sender, EventArgs e)
        {

            var requestId = Session["id"].ToString();

            if (!IsPostBack)
            {
                DisplayRequest(requestId);
            }

        }

        RequestModel requestmodel = new RequestModel();
        protected void EnableControls(RequestStatusDetail requestStatus)
        {

        
            if (requestStatus != RequestStatusDetail.PENDINGREVIEW)
            {
                txt_Comments.Enabled = false;
                btn_Approval.Enabled = false;
                btn_Reject.Enabled = false;
            }


        }
        protected void DisplayRequest(string  requestId)
        {
            Request request = requestmodel.FindRequestById(requestId);
            BindRequest(request);
            EnableControls(request.RequestStatus);
            ShowImage(request);
        }

        protected void btn_Approval_Click(object sender, EventArgs e)
        {
            PassRequestStatus(RequestStatusDetail.APPROVED);

            var modifyRequest = CreateModifyRequest(RequestStatusDetail.APPROVED);
            wshelper.ModifyRequestIdHttpPost(modifyRequest);

            Response.Redirect("index.aspx");
        }
        protected void PassRequestStatus(RequestStatusDetail RequestStatus)
        {
            var request = new Request();
            request.RequestStatus = RequestStatus;
            request.RequestId = txt_requestId.Text;
            request.Comments = txt_Comments.Text;
            requestmodel.UpdateRequest(request);

        }
        protected void btn_Reject_Click(object sender, EventArgs e)
        {
            PassRequestStatus(RequestStatusDetail.REJECTED);

            var modifyRequest = CreateModifyRequest(RequestStatusDetail.REJECTED);
            wshelper.ModifyRequestIdHttpPost(modifyRequest);

            Response.Redirect("index.aspx");
        }

        private ModifyRequest CreateModifyRequest(RequestStatusDetail status)
        {
            var modifyRequest = new ModifyRequest();
            modifyRequest.RequestId = txt_requestId.Text;
            modifyRequest.Comments = txt_Comments.Text;
            modifyRequest.ApprovalStatus = (int)status;

            return modifyRequest;
        }

        public void BindRequest(Request request)
        {
           
            txt_requestId.Text = request.RequestId;
            txt_Title.Text = request.RequestTitle;
            txt_Details.Text = request.RequestDetail;
            txt_Comments.Text = request.Comments;
            txt_status.Text = request.RequestStatus.ToString();
            txt_SendDate.Text = request.CreateDate.ToString();
            txt_DueDate.Text = request.DueDate.ToString();
         
          }
        public void ShowImage(Request request) {
            if (1 == request.Priority)
            {
                Image1.Visible = true;
            }
            else
            {
                Image1.Visible = false;
            }
        }

        protected void btn_Close_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
