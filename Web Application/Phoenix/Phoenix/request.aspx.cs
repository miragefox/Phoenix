
using System.Data.SqlClient;
using System;
using System.Text;
using Phoenix.PhoenixDataModel;
using static Phoenix.RequestStatus;

namespace Phoenix
{
    public partial class request : System.Web.UI.Page
    {
        RequestModel requestmodel = new RequestModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            var requestid = Guid.NewGuid().ToString();
            RequestId.Text = requestid;
        }

        protected void SendForApprovalButtonClick(object sender, EventArgs e)
        {

            if (RequestId.Text == "" || RequestTitle.Text == "" || RequestDetails.Text == "")
            {
                Response.Write("<script>alert('Please fill out all fields!');</script>");
            }
            else
            {
                bool addRequestFeedback = SaveNewRequest(RequestStatusDetail.PENDINGREVIEW);
                ReturnFeedback(addRequestFeedback);
                Response.Redirect("index.aspx");
            }
        }
        protected void NotifyButtonClick(object sender, EventArgs e)
        {
            if (RequestId.Text == "" || RequestTitle.Text == "" || RequestDetails.Text == "")
            {
                Response.Write("<script>alert('Please fill out all fields!');</script>");
            }
            else
            {
                bool addRequestFeedback = SaveNewRequest(RequestStatusDetail.COMPLETED);
                ReturnFeedback(addRequestFeedback);
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
                EditTime = DateTime.Now
            });
            return addRequestFeedback;
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
    }
}