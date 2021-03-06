﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Phoenix.index" MasterPageFile="~/MasterPage.Master"%>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    if (!objbeforeItem)
    {
        var objbeforeItem=null;
        var objbeforeItembackgroundColor=null;
    } 
        function ItemOver(obj, id, Priority, DueDate) {
            if (objbeforeItem) {
                objbeforeItem.style.backgroundColor = objbeforeItembackgroundColor;
            }
            objbeforeItembackgroundColor = obj.style.backgroundColor;
            objbeforeItem = obj;
            obj.style.backgroundColor = "#F7CE90";
            document.getElementById("BodyContent_HiddenId").value = id;
            document.getElementById("BodyContent_PriorityHidden").value = Priority;
            document.getElementById("<%=DueDateHidden.ClientID%>").value = DueDate;
        }

    </script>
     <style type="text/css">
        .IndexButton{
           color:white;
            background-color:#077ac3; 
            border:1px solid #077ac3;
            padding-top: 4px; 
            padding-bottom: 2px;
            width: 125px;
            margin-top: 30px;
            margin-right:50px;
            margin-left:50px;
        }
        .LinkButton{
            margin-right:10px;
            margin-left:10px;
            font-size:small;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
           <h1 style="color:#1D7EB1">Request Dashboard</h1>
            <asp:GridView  align="center" ID="RequestGridView"  runat="server" AutoGenerateColumns="False" Height="212px" OnRowDataBound="RequestGridView_RowDataBound" CellPadding="4" Font-Size="Small"  BorderColor="#1D7EB1" BorderWidth="1px" >
                <Columns>
                    <asp:BoundField HeaderText="Id">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RequestTitle" HeaderText="RequestTitle">
                    <ItemStyle  HorizontalAlign="Left" VerticalAlign="Middle" Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RequestStatus" HeaderText="RequestStatus">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CreateDate" HeaderText="CreateDate">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EditDttm" HeaderText="ActionDate">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ActionSource" HeaderText="ActionSource" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RequestId" HeaderText="RequestId" />
                    <asp:BoundField DataField="Priority" HeaderText="Priority" /> 
                     <asp:BoundField DataField="DueDate" HeaderText="DueDate" /> 
                    <asp:TemplateField ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">

                        <ItemTemplate>
                            <asp:LinkButton ID="EditButton" CssClass="LinkButton" runat="server" OnClick="EditButton_Click" Visible="False">View</asp:LinkButton>
                            <asp:LinkButton ID="DetailsButton" CssClass="LinkButton" runat="server" OnClick="DetailsButton_Click" Visible="False">Action</asp:LinkButton>
                        </ItemTemplate>
<ItemStyle Width="120px"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#1d7eb1" Font-Bold="False" ForeColor="white" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            <input type="hidden" id="HiddenId" name="HiddenId" runat="server"/>
            <input type="hidden" id="PriorityHidden" name="PriorityHidden" runat="server" /> 
            <input type="hidden" id="DueDateHidden" name="DueDateHidden" runat="server" /> 
            <asp:Button CssClass="IndexButton" ID="SendNotificationButton" runat="server" OnClick="SendNotificationButton_Click" Text="Create Notification"/>
            <asp:Button CssClass="IndexButton" ID="SendForApprovalButton" runat="server" Text="Create Request" OnClick="SendForApproval_Click" />
</asp:Content>