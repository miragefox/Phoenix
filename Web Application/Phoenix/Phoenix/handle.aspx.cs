using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace Phoenix
{
    public partial class handle : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            var requestId = Request.QueryString["Id"];

            if (!IsPostBack)
            {            
                DisplayRequest(requestId);
            }

        }

        protected void DisplayRequest(string requestId)
        {
            var request = GetRequestList(requestId);

            DisplayRequestDetal(request, requestId);

            if (request.RequestStatus != Convert.ToInt32(RequestStatus.RequestStatusDetail.PENDINGREVIEW))
            {
                txt_Comments.Enabled = false;
                btn_Approval.Enabled = false;
                btn_Reject.Enabled = false;
            }
        }

        private readonly SqlConnection _sqlConnection = new SqlConnection(@"server=.\SQL2014;database=Phoenix;integrated security=sspi");
        private const string GetRequestListFromDb = "SELECT RE.RequestTitle,RE.RequestDetail,RE.Comments,RE.RequestStatus FROM REQUEST RE WHERE RE.REQUESTID = '{0}'";
        private const string UpdateRequestToDb = "UPDATE REQUEST SET RequestStatus={0},Comments = '{1}' WHERE REQUESTID = '{2}'";
        public PhoenixDataModel.PhoenixDataModel.Request GetRequestList(string requestId)
        {
            var request = new PhoenixDataModel.PhoenixDataModel.Request();

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
                request.RequestStatus = configs.Tables[0].Rows[0].Field<Int32>("RequestStatus");
            }

            return request;
        }

        protected void btn_Approval_Click(object sender, EventArgs e)
        {
            var requestId = txt_requestId.Text;
            var addcomment = txt_Comments.Text;
            var newtStatus = 1;
            updateDbRequest(newtStatus, addcomment, requestId);

            Response.Redirect("index.aspx");
        }
        protected void btn_Reject_Click(object sender, EventArgs e)
        {
            var requestId = txt_requestId.Text;
            var addcomment = txt_Comments.Text;
            var newtStatus = 2;

            updateDbRequest(newtStatus, addcomment, requestId);

            Response.Redirect("index.aspx");
        }

        public void updateDbRequest(int newtStatus, string addComment, string requestId) {

            _sqlConnection.Open();

            var sqlBaseBuilder = new StringBuilder(UpdateRequestToDb);
            var sqlStr = string.Format(sqlBaseBuilder.ToString(), newtStatus, addComment, requestId);

            SqlCommand myCmd = new SqlCommand(sqlStr, _sqlConnection);
            myCmd.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public void DisplayRequestDetal(PhoenixDataModel.PhoenixDataModel.Request request, string requestId)
        {
            txt_requestId.Text = requestId;
            txt_Title.Text = request.RequestTitle;
            txt_Details.Text = request.RequestDetail;
            txt_Comments.Text = request.Comments;
        }

        protected void btn_Close_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}