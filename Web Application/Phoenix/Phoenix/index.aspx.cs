﻿using System.Data;            
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
                DataTable dt = new DataTable();
                // 当DataSource为空时绑定之，否则Gridview控件就不能显示
                DataRow dr;
                for (int i = 0; i < RequestGridView.Columns.Count - 1; i++)
                {
                    dt.Columns.Add(new DataColumn(((BoundField)RequestGridView.Columns[i]).DataField, typeof(string)));
                    dr = dt.NewRow();
                    dr[i] = "&nbsp;";
                }
                dt.Columns.Add("Action");
                dr = dt.NewRow();
                dr[6] = "&nbsp;";
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
                    for (int j = 0; j < RequestGridView.Columns.Count-3; j++)
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

        protected void RequestGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            AutoAddId(e);
            LinkButtonVisiable(e);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Id;
                var Priority = e.Row.Cells[7].Text== "&nbsp;" ? 0 : Convert.ToInt32(e.Row.Cells[7].Text);
                var DueDate = e.Row.Cells[8].Text;
                Id = e.Row.Cells[6].Text;
                if (Id != "&nbsp;")
                {
                    e.Row.Attributes.Add("onclick", "ItemOver(this,'" + Id + "','" + Priority + "','" + DueDate + "')");
                }
            }
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
        }

        protected void AddNewButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("request.aspx");
        }

        protected void SendNotificationButton_Click(object sender, EventArgs e)
        {
            Session["id"] = "";
            Session["BusinessCode"] = "A02";
            Session["Priority"] = 0;
            Session["DueDate"] = "";
            Response.Redirect("request.aspx");
        }

        protected void SendForApproval_Click(object sender, EventArgs e)
        {
            Session["id"] = "";
            Session["BusinessCode"] = "A01";
            Session["Priority"] = 0;
            Session["DueDate"] = "";
            Response.Redirect("request.aspx");
        }
        private void AutoAddId(GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1 && e.Row.Cells[2].Text != "&nbsp;")//自动编号作序号
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }
        private void LinkButtonVisiable(GridViewRowEventArgs e)
        {
            if (e.Row.Cells[2].Text == "COMPLETED" || e.Row.Cells[2].Text == "REJECTED" || e.Row.Cells[2].Text == "APPROVED")
            {
                e.Row.FindControl("EditButton").Visible = true;
            }
            if (e.Row.Cells[2].Text == "PENDINGREVIEW")
            {
                e.Row.FindControl("EditButton").Visible = true;
                e.Row.FindControl("DetailsButton").Visible = true;
            }
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            //string id = HiddenId.Value;
            //string Priority = PriorityHidden.Value;
            //Session["Priority"] = Priority;
            //Session["id"] = id;
            //Session["BusinessCode"] = "";
            //Session["DueDate"] = string.Format("{0}/{1}/{2}", Convert.ToDateTime(DueDateHidden.Value).Month, Convert.ToDateTime(DueDateHidden.Value).Day, Convert.ToDateTime(DueDateHidden.Value).Year);
            //Response.Redirect("request.aspx");
            string id = HiddenId.Value;
            Session["id"] = id;
            Session["BusinessCode"] = "";
            Response.Redirect("View.aspx");
        }

        protected void DetailsButton_Click(object sender, EventArgs e)
        {
            string id = HiddenId.Value;
            Session["id"] = id;
            Session["BusinessCode"] = "";
            Response.Redirect("handle.aspx");
        }
    }
}

