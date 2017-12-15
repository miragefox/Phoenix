<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="handle.aspx.cs" Inherits="Phoenix.handle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
     .requestDetials {
         width: 600px;
         height: 480px;
         margin-right: 10px;
     }
    .detail {
        width: 300px;
        height: 200px;
        margin-right: 10px;
    }
    .comment {
        width: 300px;
        height: 200px;
        margin-right: 10px;
        margin-top: 3px;
    }
    .buttons {
        width: 120px;
        margin-right: 10px;
    }
     .labels {
        width: 120px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
         <h2>RequestDetails</h2>
        <div class="requestDetials">

            <asp:label id="lbl_id" associatedcontrolid="txt_requestId" runat="server" text="RequestId: " CssClass="labels"/>
			<asp:textbox id="txt_requestId" align="right" oninput="onInput(this)" runat="server" CssClass="rid"/>
            <br/>
			<asp:label id="lbl_Title" associatedcontrolid="txt_Title" runat="server" text="Title: " CssClass="labels"/>
			<asp:textbox id="txt_Title" align="right" oninput="onInput(this)" runat="server" CssClass="title" />
            <br/>
            <asp:label id="lbl_Details" associatedcontrolid="txt_Details" runat="server" text="Details: " CssClass="labels"/>
            <asp:textbox id="txt_Details" textmode="MultiLine" align="right" oninput="onInput(this)" runat="server" CssClass="detail"/>
            <br/>
            <asp:label id="lbl_Comments" associatedcontrolid="txt_Comments" runat="server" text="Comments: " CssClass="labels"/>
			<asp:textbox id="txt_Comments" textmode="MultiLine" align="right" oninput="onInput(this)" runat="server" CssClass="comment"/>			
		</div>
        
            <asp:button id="btn_Approval" Text="Approval" runat="server" onclick="btn_Approval_Click" CssClass="buttons"/>
            <asp:button id="btn_Reject" text="Reject" runat="server" onclick="btn_Reject_Click" CssClass="buttons"/>
            <asp:button id="Close" text="Close" runat="server" onclick="btn_Close_Click" CssClass="buttons"/>

    </form>
</body>
</html>
