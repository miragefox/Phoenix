
using System.Data.SqlClient;
using System;
using System.Text;

namespace Phoenix
{
    public partial class request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var requestid = Guid.NewGuid().ToString();
            RequestId.Text = requestid;
        }

        private readonly SqlConnection _sqlConnection = new SqlConnection(@"server=.\SQL2014;database=Phoenix;integrated security=sspi");
        private const string InsertRequest = "insert into Request(RequestId,RequestTitle,RequestDetail,Comments,RequestStatus,EditDttm) values('{0}','{1}','{2}','',{3},'{4}')";
        protected void SendForApprovalButtonClick(object sender, EventArgs e)
        {
            var requestId = RequestId.Text;
            var requestTitle = RequestTitle.Text;
            var requestDetails = RequestDetails.Text;
            int requestStatus = 0;
            if (requestId == "" || requestTitle == "" || requestDetails == "")
            {
                Response.Write("<script>alert('Please fill out all fields!');</script>");
            }
            else
            {
                _sqlConnection.Open();

                var sqlBaseBuilder = new StringBuilder(InsertRequest);
                var sqlStr = string.Format(sqlBaseBuilder.ToString(), requestId, requestTitle, requestDetails, requestStatus, DateTime.Now);

                SqlCommand myCmd = new SqlCommand(sqlStr, _sqlConnection);
                myCmd.ExecuteNonQuery();
                myCmd.Dispose();
                _sqlConnection.Close();

                Response.Redirect("index.aspx");
            }
        }

        protected void NotifyButtonClick(object sender, EventArgs e)
        {
            var requestId = RequestId.Text;
            var requestTitle = RequestTitle.Text;
            var requestDetails = RequestDetails.Text;
            int requestStatus = 3;
            if (requestId == "" || requestTitle == "" || requestDetails == "")
            {
                Response.Write("<script>alert('Please fill out all fields!');</script>");
            }
            else
            {
                _sqlConnection.Open();

                var sqlBaseBuilder = new StringBuilder(InsertRequest);
                var sqlStr = string.Format(sqlBaseBuilder.ToString(), requestId, requestTitle, requestDetails, requestStatus, DateTime.Now);

                SqlCommand myCmd = new SqlCommand(sqlStr, _sqlConnection);
                myCmd.ExecuteNonQuery();
                myCmd.Dispose();
                _sqlConnection.Close();

                Response.Redirect("index.aspx");
            }
        }

        protected void CancelButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}