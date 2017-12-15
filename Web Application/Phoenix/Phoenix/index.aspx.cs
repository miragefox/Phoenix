using System.Data;            
using System.Data.SqlClient;  
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;


namespace Phoenix
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }

        }
        protected void GetData()
        {
            SqlConnection con = new SqlConnection();        //定义数据库连接对象
            con = new SqlConnection(@"server=.\SQL2014;database=Phoenix;integrated security=sspi");
            SqlCommand com = new SqlCommand();              //定义数据库操作命令对象
            com.Connection = con;                           //连接数据库
            com.CommandText = "select RequestId,RequestTitle,RequestStatus from Request"; //定义执行查询操作的sql语句
            SqlDataAdapter da = new SqlDataAdapter();       //创建数据适配器对象
            da.SelectCommand = com;                         //执行数据库操作命令
            DataSet ds = new DataSet();                     //创建数据集对象
            da.Fill(ds, "request");                        //填充数据集
            RequestRequestGridView1.DataSource = ds.Tables["Request"].DefaultView;//设置gridview控件的数据源为创建的数据集ds
            RequestRequestGridView1.DataBind();                           //绑定数据库表中数据
            if (ds.Tables[0].Rows.Count == 0)
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                RequestRequestGridView1.DataSource = ds;
                RequestRequestGridView1.DataBind();
                int columnCount = RequestRequestGridView1.Rows[0].Cells.Count;
                RequestRequestGridView1.Rows[0].Cells.Clear();
                RequestRequestGridView1.Rows[0].Cells.Add(new TableCell());
                RequestRequestGridView1.Rows[0].Cells[0].ColumnSpan = columnCount;
                RequestRequestGridView1.Rows[0].Cells[0].Text = "No Records Found.";
            }
        }

        protected void DetailsButton_Click(object sender, EventArgs e)
        {
            string id = HiddenClickId.Value;
            if (id.Equals(""))
            {
                Response.Write("<script>alert('您没有选择一条记录!');</script>");
            }
            else
            {
                string ToNewPage = "handle.aspx?id=" + id;
                Response.Redirect(ToNewPage);
            }
            
        }

        protected void AddNewButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("request.aspx");
        }

        protected void RequestGridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Id;
                Id = e.Row.Cells[0].Text;
                e.Row.Attributes.Add("onclick", "ItemOver(this,(" + Id + "))");

                if (e.Row.Cells[2].Text == "0")
                {
                    e.Row.Cells[2].Text = RequestStatus.RequestStatusDetail.PENDINGREVIEW.ToString();
                }
                else if (e.Row.Cells[2].Text == "1")
                {
                    e.Row.Cells[2].Text = RequestStatus.RequestStatusDetail.APPROVED.ToString();
                }
                else if (e.Row.Cells[2].Text == "2")
                {
                    e.Row.Cells[2].Text = RequestStatus.RequestStatusDetail.REJECTED.ToString();
                }
                else if (e.Row.Cells[2].Text == "3")
                {
                    e.Row.Cells[2].Text = RequestStatus.RequestStatusDetail.COMPLETED.ToString();
                }
            }
        }
    }
}