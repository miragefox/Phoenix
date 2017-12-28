using System.Data;            
using System.Data.SqlClient;  
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using Phoenix.PhoenixDataModel;


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
            RequestModel requestModel = new RequestModel();
            var requestList = requestModel.GetAllRequest();
            RequestGridView.DataSource = requestList;
            RequestGridView.DataBind();
            int pageSize = RequestGridView.AllowPaging == true ? RequestGridView.PageSize : 10;//默认行数是10行

            if (RequestGridView.Rows.Count == 0)
            {
                // 当DataSource为空时绑定之，否则Gridview控件就不能显示
                DataTable dt = new DataTable();
                DataRow dr;
                for (int i = 0; i < RequestGridView.Columns.Count; i++)
                {
                    dt.Columns.Add(new DataColumn(((BoundField)RequestGridView.Columns[i]).DataField, typeof(string)));
                    dr = dt.NewRow();
                    dr[i] = "&nbsp;";
                }
                for (int j = 0; j < pageSize - RequestGridView.Rows.Count; j++)
                {
                    dr = dt.NewRow();
                    dt.Rows.Add(dr);
                }
                RequestGridView.DataSource = dt;
                RequestGridView.DataBind();
            }
            else
            {
                for (int i = 0; i < 10 - RequestGridView.Rows.Count; i++)
                {
                    int rowIndex = RequestGridView.Rows.Count + i + 1;
                    GridViewRow row = new GridViewRow(rowIndex, -1, DataControlRowType.EmptyDataRow, DataControlRowState.Normal);
                    for (int j = 0; j < RequestGridView.Columns.Count; j++)
                    {
                        TableCell cell = new TableCell();
                        cell.Text = "&nbsp;";
                        row.Controls.Add(cell);
                        row.Attributes.Add("BorderColor ", "#d2d2d2");
                    }

                    RequestGridView.Controls[0].Controls.AddAt(rowIndex, row);
                }
            }
        }

        protected void DetailsButton_Click(object sender, EventArgs e)
        {
            string id = HiddenId.Value;
            if (id == "" || id == "&nbsp;")
            {
                ErrorMessage.Text = "You should select at least one record.";
                GetData();
            }
            else
            {
                Session["id"] = id;
                Response.Redirect("handle.aspx");
            }
        }

        protected void AddNewButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("request.aspx");
        }

        protected void RequestGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Id;
                Id = e.Row.Cells[0].Text;
                if (Id != "&nbsp;")
                {
                    e.Row.Attributes.Add("onclick", "ItemOver(this,'" + Id + "')");
                }
            }
        }
    }
}

