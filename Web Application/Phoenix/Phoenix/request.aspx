<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="request.aspx.cs" Inherits="Phoenix.request" MasterPageFile="~/MasterPage.Master"%>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <style>
        .form {
         width: 650px;
         height: 30px;
     }
        .formdetails {
         width: 650px;
         height: 220px;
     }
    .lable {
        width: 100px;
        display:inline-block;
        text-align:left;
        background-color:#077ac3;
        color:white;
        height: 20px;
    }
    .labledetails {
        width: 100px;
        height: 200px;
        display:inline-block;
        text-align:left;
        color:white;
        vertical-align:top;
        background-color:#077ac3;
    }
    .textbox {
        width: 400px;
        height: 20px;
    }
    .textboxdetails{
         width: 400px;
         height: 200px;
     }
    .buttons {
            color:white;
            background-color:#077ac3; 
            border:1px solid #077ac3;
            padding-top: 4px; 
            padding-bottom: 2px;
            width: 120px;
            margin-top: 10px;
            margin-right:50px;
            margin-left:50px;
    }
        .radiobutttons {
            background-color:#077ac3;
            color:white;
        }

</style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div runat="server" style=" width: 650px;margin-left: 350px">   
        <div runat="server" class="form">
           <asp:label associatedcontrolid="RequestId" text="RequestId" runat="server" CssClass="lable" />
           <asp:TextBox id="RequestId" Enabled="false" runat="server" CssClass="textbox"/>                
        </div>
        <div runat="server" class="form">
            <asp:label associatedcontrolid="RequestTitle" text="RequestTitle" runat="server" CssClass="lable" />
            <asp:TextBox id="RequestTitle" runat="server" CssClass="textbox"/>
        </div>
        <div runat="server" class="formdetails">
            <asp:label associatedcontrolid="RequestDetails" text="RequestDetails" runat="server" CssClass="labledetails" />
            <asp:TextBox id="RequestDetails" textmode="MultiLine" runat="server" CssClass="textboxdetails"/>
        </div>
        <div runat="server" class="form">
            <asp:RadioButtonList id="Priority" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radiobutttons">
            <asp:ListItem Selected="True">Default</asp:ListItem>
            <asp:ListItem>Low Importance</asp:ListItem>
            <asp:ListItem>High Importance</asp:ListItem>
           </asp:RadioButtonList>  
        </div>
    </div>
        <asp:Button ID="SendForApprovalButton" runat="server" CssClass="buttons" Text="Send for Approval" OnClick="SendForApprovalButtonClick" />
        <asp:Button ID="NotifyButton" runat="server" CssClass="buttons" Text="Notify" OnClick="NotifyButtonClick" />          
        <asp:Button ID="CancelButton" runat="server" CssClass="buttons" Text="Cancel" OnClick="CancelButtonClick" /> 

</asp:Content>


