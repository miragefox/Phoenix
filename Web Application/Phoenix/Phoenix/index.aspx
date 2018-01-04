<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Phoenix.index" MasterPageFile="~/MasterPage.Master"%>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
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
        document.getElementById("BodyContent_HiddenId").value = id;
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
<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
            <asp:GridView  align="center" ID="RequestGridView"  runat="server" AutoGenerateColumns="False" Height="212px" OnRowDataBound="RequestGridView_RowDataBound" CellPadding="4" EnableModelValidation="True" Font-Size="Small"  BorderColor="#1d7eb1" BorderWidth="1px" >
                <Columns>
                    <asp:BoundField DataField="RequestId" HeaderText="RequestId">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="250px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RequestTitle" HeaderText="RequestTitle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RequestStatus" HeaderText="RequestStatus">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                    </asp:BoundField>
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
            <div><asp:Label ID="ErrorMessage" runat="server" Font-Size="Medium" ForeColor="Red" Text="" Visible="true" Height="5px"></asp:Label></div>
            <input type="hidden" id="HiddenId" name="HiddenId" runat="server"/>
            <asp:Button CssClass="IndexButton" ID="DetailsButton" runat="server" OnClick="DetailsButton_Click" Text="Details"/>
            <asp:Button CssClass="IndexButton" ID="AddNewButton" runat="server" Text="Add New" OnClick="AddNewButton_Click" />
</asp:Content>