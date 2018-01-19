<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="request.aspx.cs" Inherits="Phoenix.request" MasterPageFile="~/MasterPage.Master"%>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>jQuery UI DueDatePicker - Default functionality</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
      $(function () {
          $("#DueDatePicker").datepicker();
          $('#DueDatePicker').val("<%=Session["DueDate"] %>") ;
        Priority = '<%=Session["Priority"] %>';
        if (Priority == 1) {
            $("#checkbox").attr("checked", true);
            $('#img').css("visibility", "visible");
            $('#checkboxHidden').val("1");
        } else {
            $("#checkbox").attr("checked", false);
            $('#img').css("visibility", "hidden");
            $('#checkboxHidden').val("0");
        }
    });
    $(function () {
        $('#checkbox').click(function () {
            if ($('input[name="checkbox"]').prop("checked")) {
                $('#img').css("visibility", "visible");
                $('#checkboxHidden').val("1");
            }
            else {
                $('#img').css("visibility", "hidden");
                $('#checkboxHidden').val("0");
            }
        });
      })

      

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
    .duedate {
        width: 200px;
        height: 20px;
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
           <input type="text" id="DueDatePicker" class="duedate" name="DueDate" />
           <asp:label runat="server" width="200px"/>
        </div>
      <div id="check" runat="server" style="height:30px; width:255px;">
            <label style="display:inline-block;width:120px;" >Important</label>
            <input type="checkbox" id="checkbox" name="checkbox" style="width:20px"/>
            <img src="photo/important.jpg" id="img" style="height:15px;visibility:hidden" />
            <asp:HiddenField ID="checkboxHidden" runat="server" Value="0" ClientIDMode="Static" />
        </div>
    </div>
        <asp:Button ID="SendForApprovalButton" runat="server" CssClass="buttons" OnClick="SendForApprovalButtonClick" />         
        <asp:Button ID="CancelButton" runat="server" CssClass="buttons" Text="Cancel" OnClick="CancelButtonClick" /> 

</asp:Content>


