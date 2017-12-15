using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace Phoenix
{
    public partial class handle : System.Web.UI.Page
    {
        public class RequestList
        {
            public string RequestId { get; set; }
            public string RequestTitle { get; set; }
            public string RequestDetail { get; set; }
            public string Comments { get; set; }
            public int Status { get; set; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            var requestId = Request.QueryString["Id"];

            if (txt_Comments.Text == "")
            {
                DisplayRequest(requestId);
            }

        }

        protected void DisplayRequest(string requestId)
        {
            var request = new RequestList();
            request = GetRequestList(requestId);

            txt_requestId.Text = requestId.ToString();
            txt_Title.Text = request.RequestTitle;
            txt_Details.Text = request.RequestDetail;
            txt_Comments.Text = request.Comments;

            if (request.Status != 0)
            {
                txt_Comments.Enabled = false;
                btn_Approval.Enabled = false;
                btn_Reject.Enabled = false;
            }

            txt_requestId.Enabled = false;
            txt_Title.Enabled = false;
            txt_Details.Enabled = false;
        }

        private readonly SqlConnection _sqlConnection = new SqlConnection(@"server=.\SQL2014;database=Phoenix;integrated security=sspi");
        private const string GetRequestListFromDb = "SELECT RE.RequestTitle,RE.RequestDetail,RE.Comments,RE.RequestStatus FROM REQUEST RE WHERE RE.REQUESTID = {0}";
        private const string UpdateRequestListToDb = "UPDATE REQUEST SET RequestStatus={0},Comments = '{1}' WHERE REQUESTID = '{2}'";
        public RequestList GetRequestList(string requestId)
        {
            var request = new RequestList();

            var sqlBaseBuilder = new StringBuilder(GetRequestListFromDb);
            var sqlStr = string.Format(sqlBaseBuilder.ToString(), requestId);

            var da = new SqlDataAdapter(sqlStr, _sqlConnection);
            var configs = new DataSet();
            da.Fill(configs, "receiptConfigInfo");

            if (configs.Tables[0].Rows.Count != 0)
            {
                request.RequestTitle = configs.Tables[0].Rows[0].Field<string>("RequestTitle");
                request.RequestDetail = configs.Tables[0].Rows[0].Field<string>("RequestDetail");
                request.Comments = configs.Tables[0].Rows[0].Field<string>("Comments");
                request.Status = configs.Tables[0].Rows[0].Field<Int32>("RequestStatus");
            }

            return request;
        }

        protected void btn_Approval_Click(object sender, EventArgs e)
        {
            var requestId = txt_requestId.Text;
            var addcomment = txt_Comments.Text;
            var approvestatus = 1;

            _sqlConnection.Open();

            var sqlBaseBuilder = new StringBuilder(UpdateRequestListToDb);
            var sqlStr = string.Format(sqlBaseBuilder.ToString(), approvestatus, addcomment, requestId);

            SqlCommand myCmd = new SqlCommand(sqlStr, _sqlConnection);
            myCmd.ExecuteNonQuery();
            myCmd.Dispose();
            _sqlConnection.Close();

            //webservice???
            Response.Redirect("index.aspx");
        }
        protected void btn_Reject_Click(object sender, EventArgs e)
        {
            var requestId = txt_requestId.Text;
            var addcomment = txt_Comments.Text;
            var rejectstatus = 2;

            _sqlConnection.Open();

            var sqlBaseBuilder = new StringBuilder(UpdateRequestListToDb);
            var sqlStr = string.Format(sqlBaseBuilder.ToString(), rejectstatus, addcomment, requestId);

            SqlCommand myCmd = new SqlCommand(sqlStr, _sqlConnection);
            myCmd.ExecuteNonQuery();
            myCmd.Dispose();
            _sqlConnection.Close();

            //webservice???
            Response.Redirect("index.aspx");
        }

        protected void btn_Close_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}