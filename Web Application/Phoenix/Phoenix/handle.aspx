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
    th{border:1px solid gray;
       background-color:lightblue;
    }

</style>
        <script>
            function changetext(id) {
                id.innerHTML = "重要信息!";
            }
</script>
       
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
      <div style="align-self"></div>
            <table align="center" border="0" >
                <tr>
                    <th>
                         <asp:label id="lbl_id" associatedcontrolid="txt_requestId" runat="server" text="RequestId:"/>
                   </th>
                    <th>
			            <asp:textbox id="txt_requestId" align="right" runat="server" CssClass="detail" Enabled="false"/>
                    </th>
                    <td >
                     <asp:Image ID="Image1" Visible="false" runat="server" height="25px" ImageUrl='~/photo/important.jpg' ToolTip="此为重要信息" />
                    </td>
             </tr>
                <tr>
                    <th>
			        <asp:label id="lbl_Title" associatedcontrolid="txt_Title" runat="server" text="Title: "/>
                    </th>
                    <th>
			        <asp:textbox id="txt_Title" align="right" runat="server"  Enabled="false" CssClass="detail" />
                   </th>
          
             </tr>
                <tr>
                    <th>
                    <asp:label id="Status" associatedcontrolid="txt_status" runat="server" text="Status: "/>
                    </th>
                    <th>
			        <asp:textbox id="txt_status" align="right" runat="server" CssClass="detail" Enabled="false" />
                    </th>
               </tr>   
                <tr>
                    <th>
                        <asp:label id="SendDate" associatedcontrolid="txt_SendDate" runat="server" text="SendDate: "/>
                    </th>
                    <th>
			             <asp:textbox id="txt_SendDate" align="right" runat="server" CssClass="detail" Enabled="false" />
                    </th>
                </tr>
                 <tr>
                    <th>
                        <asp:label id="DueDate" associatedcontrolid="txt_DueDate" runat="server" text="DueDate: "/>
                    </th>
                    <th>
			             <asp:textbox id="txt_DueDate" align="right" runat="server" CssClass="detail" Enabled="false" />
                    </th>
                </tr>
           <tr>
               <th>
            <asp:label id="lbl_Details" associatedcontrolid="txt_Details" runat="server" text="Details: "/>
                </th>
               <th>
            <asp:textbox id="txt_Details" textmode="MultiLine" align="right" runat="server" CssClass="comment" Enabled="false" />
                </th>
           </tr>
             <tr>
                 <th>
                    <asp:label id="lbl_Comments" associatedcontrolid="txt_Comments" runat="server" text="Comments: " />
                </th>
                 <th>
			    <asp:textbox id="txt_Comments" textmode="MultiLine" align="right" runat="server" CssClass="comment"/>	
                 </th>
	        </tr>
     </table>
        <br />
            <asp:button id="btn_Approval" Text="Approve" runat="server" onclick="btn_Approval_Click" CssClass="buttons"/>
            <asp:button id="btn_Reject" text="Reject" runat="server" onclick="btn_Reject_Click" CssClass="buttons"/>
            <asp:button id="Close" text="Close" runat="server" onclick="btn_Close_Click" CssClass="buttons"/>

</asp:Content>
