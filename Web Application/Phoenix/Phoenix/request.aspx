<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="request.aspx.cs" Inherits="Phoenix.request" MasterPageFile="~/MasterPage.Master"%>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>jQuery UI DueDatePicker - Default functionality</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
  $( function() {
      $( "#DueDatePicker" ).datepicker();
  } );
  </script>

    <style>
        .form {
         width: 650px;
         height: 30px;
     }
        .formdetails {
         width: 650px;
         height: 220px;
     }
        .messagelable {
        width: 650px;
        display:inline-block;
        text-align:center;
        color:red;
        height: 20px;
        }
    .lable {
        width: 100px;
        display:inline-block;
        text-align:left;
        height: 20px;
    }
    .labledetails {
        width: 100px;
        height: 200px;
        display:inline-block;
        text-align:left;
        vertical-align:top;
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
           <asp:label id="ErrorMessage" runat="server" CssClass="messagelable" />           
        </div>
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
           <asp:label text="Due Date" runat="server" CssClass="lable" />
           <input type="text" id="DueDatePicker" name="DueDate" class="textbox"/>
        </div>
        <div runat="server" class="form">
            <asp:checkbox id="Priority" runat="server" TextAlign="Left"  Text="Important" /> 
        </div>
    </div>
        <asp:Button ID="SendForApprovalButton" runat="server" CssClass="buttons" OnClick="SendForApprovalButtonClick" />         
        <asp:Button ID="CancelButton" runat="server" CssClass="buttons" Text="Cancel" OnClick="CancelButtonClick" /> 

</asp:Content>


