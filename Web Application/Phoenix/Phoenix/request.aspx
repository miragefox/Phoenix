<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="request.aspx.cs" Inherits="Phoenix.request" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: #f5ebeb;height: 800px; width: 650px;">
    <header style="width: 100%; height: 37px;">
        Add a New Request
    </header>
    <form id="addnewform" runat="server" style="height: 600px; width: 650px;">   
        <div class="form-group" style="height: 60px; width: 460px;">
            <label for="RequestId"  >RequestId</label>
            <asp:TextBox ID="RequestId" runat="server" align="right" Width="300px"/>                
        </div>
        <div class="form-group" style="height: 60px; width: 460px;">
            <label for="RequestTitle" >RequestTitle</label>
            <asp:TextBox id="RequestTitle" runat="server" align="right" Width="300px"/>
        </div>
        <div class="form-group" style="height: 250px; width: 460px;">
            <label class="control-label" for="RequestDetails">RequestDetails</label>
            <asp:TextBox align="right" id="RequestDetails" runat="server" Width="300" height="200" />
        </div>
        <div class="form-group" style="height: 250px; width: 650px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="SendForApprovalButton" runat="server" Text="Send for Approval" OnClick="SendForApprovalButtonClick" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="NotifyButton" runat="server" Text="Notify" OnClick="NotifyButtonClick" />          
        </div>
    </form>
</body>
</html>


