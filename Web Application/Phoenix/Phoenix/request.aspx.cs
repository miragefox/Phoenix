
using System.Data.SqlClient;
using System;
using System.Text;
using Phoenix.PhoenixDataModel;

namespace Phoenix
{
    public partial class request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var requestid = Guid.NewGuid().ToString();
            RequestId.Text = requestid;
        }

        //private readonly SqlConnection _sqlConnection = new SqlConnection(@"server=.\SQL2014;database=Phoenix;integrated security=sspi");
        //private const string InsertRequest = "insert into Request(RequestId,RequestTitle,RequestDetail,Comments,RequestStatus,EditDttm) values('{0}','{1}','{2}','',{3},'{4}')";
       

        protected void SendForApprovalButtonClick(object sender, EventArgs e)
        {

            if (RequestId.Text == "" || RequestTitle.Text == "" || RequestDetails.Text == "")
            {
                Response.Write("<script>alert('Please fill out all fields!');</script>");
            }
            else
            {
                var addRequestResult = RequestModel.AddRequest(new Request{
                    RequestId = RequestId.Text,
                    RequestTitle= RequestTitle.Text,
                    RequestDetail= RequestDetails.Text,
                    RequestStatus=0,
                    EditTime= DateTime.Now
                });
                if (addRequestResult)
                {
                    Response.Write("<script>alert('Add a new request successfully!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Add a new request failed!');</script>");
                }
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
                var addRequestResult = RequestModel.AddRequest(new Request
                {
                    RequestId = RequestId.Text,
                    RequestTitle = RequestTitle.Text,
                    RequestDetail = RequestDetails.Text,
                    RequestStatus = 3,
                    EditTime = DateTime.Now
                });
                if (addRequestResult)
                {
                    Response.Write("<script>alert('Add a new request successfully!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Add a new request failed!');</script>");
                }
                Response.Redirect("index.aspx");
            }
        }

        protected void CancelButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}