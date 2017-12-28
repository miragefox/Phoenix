<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="handle.aspx.cs" Inherits="Phoenix.handle" MasterPageFile="~/MasterPage.Master"%>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <style>
     .requestDetials {
         width: 600px;
         height: 390px;
         margin-left: auto;
         margin-right: auto;
     }
    .detail {
        width: 300px;
    }
    .comment {
        width: 300px;
        height: 150px;
    }
    .buttons {
        width: 120px;
        background-color: #007DBB;
    }

</style>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
        <div class="requestDetials">
            <div class="labels" style="height: 25px;">
                <asp:label id="lbl_id" associatedcontrolid="txt_requestId" runat="server" text="RequestId:"/>
			    <asp:textbox id="txt_requestId" align="right" runat="server" CssClass="detail" Enabled="false"/>
            </div>
            <div class="labels" style="height: 25px;">
			    <asp:label id="lbl_Title" associatedcontrolid="txt_Title" runat="server" text="Title: "/>
			    <asp:textbox id="txt_Title" align="right" runat="server"  Enabled="false" CssClass="detail" style="margin-left: 35px;"/>
            </div>
            <div class="labels" style="height: 25px;">
                <asp:label id="Status" associatedcontrolid="txt_status" runat="server" text="Status: "/>
			    <asp:textbox id="txt_status" align="right" runat="server" CssClass="detail" Enabled="false" style="margin-left: 25px;"/>
            </div>

            <asp:label id="lbl_Details" associatedcontrolid="txt_Details" runat="server" text="Details: " style="position: relative;left:0;top:-140px;"/>
            <asp:textbox id="txt_Details" textmode="MultiLine" align="right" runat="server" CssClass="comment" Enabled="false" style="margin-left: 25px;"/>
            <br />
            <asp:label id="lbl_Comments" associatedcontrolid="txt_Comments" runat="server" text="Comments: " style="position: relative;left:0;top:-140px;"/>
			<asp:textbox id="txt_Comments" textmode="MultiLine" align="right" runat="server" CssClass="comment"/>	
	
		</div>
        <br />
            <asp:button id="btn_Approval" Text="Approval" runat="server" onclick="btn_Approval_Click" CssClass="buttons"/>
            <asp:button id="btn_Reject" text="Reject" runat="server" onclick="btn_Reject_Click" CssClass="buttons"/>
            <asp:button id="Close" text="Close" runat="server" onclick="btn_Close_Click" CssClass="buttons"/>

</asp:Content>
