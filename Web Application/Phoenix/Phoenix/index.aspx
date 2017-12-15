<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Phoenix.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        document.getElementById("HiddenClickId").value = id;
    }
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="RequestRequestGridView1"  runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="286px" OnRowDataBound="RequestGridView1_RowDataBound" Width="248px" >
                <AlternatingRowStyle BackColor="White" />
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
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" Font-Bold="True" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
            <input type="hidden" id="HiddenClickId" name="HiddenClickId" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="DetailsButton" runat="server" OnClick="DetailsButton_Click" Text="Details" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="AddNewButton" runat="server" Text="Add New" OnClick="AddNewButton_Click" />
        </div>
    </form>
</body>
</html>
