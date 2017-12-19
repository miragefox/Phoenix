<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Phoenix.index" MasterPageFile="~/MasterPage.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    if (!objbeforeItem)
    {
        var objbeforeItem=null;
        var objbeforeItembackgroundColor=null;
    } 
    function ItemOver(obj,id)
    {
        if(objbeforeItem)
        {
            objbeforeItem.style.backgroundColor = objbeforeItembackgroundColor;
        }
        objbeforeItembackgroundColor = obj.style.backgroundColor;
        objbeforeItem = obj;
        obj.style.backgroundColor = "#F7CE90";
        document.getElementById("ContentPlaceHolder1_HiddenId").value = id;
    }
    </script>
     <style type="text/css">
        .IndexButton{
            color:white;
            background-color:#077ac3; 
            border:1px solid #077ac3;
            padding-top: 4px; 
            padding-bottom: 2px;
            width: 80px;
            margin-top: 30px;
            margin-right:50px;
            margin-left:50px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:GridView  align="center" ID="RequestRequestGridView1"  runat="server" AutoGenerateColumns="False" CellPadding="3" Height="212px" OnRowDataBound="RequestGridView1_RowDataBound" Width="610px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"  >
                <Columns>
                    <asp:BoundField DataField="RequestId" HeaderText="RequestId">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RequestTitle" HeaderText="RequestTitle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RequestStatus" HeaderText="RequestStatus">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            <input type="hidden" id="HiddenId" name="HiddenId" runat="server" style="margin:0em 0 3em 0;"/>
            <asp:Button CssClass="IndexButton" ID="DetailsButton" runat="server" OnClick="DetailsButton_Click" Text="Details"/>
            <asp:Button CssClass="IndexButton" ID="AddNewButton" runat="server" Text="Add New" OnClick="AddNewButton_Click" />
</asp:Content>