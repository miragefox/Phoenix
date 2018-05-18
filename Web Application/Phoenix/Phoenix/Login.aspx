
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Phoenix.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">


        function checkUser() {

            if (document.getElementById("userName").value == "guoyi.gao" && document.getElementById("userPassword").value == "111111") {

                window.open("test.aspx", "_self");

            } else if (document.getElementById("userName").value == "jiang.liu" && document.getElementById("userPassword").value == "111111") {

                window.localStorage.setItem("data", "1");
                window.open("test.aspx", "_self");


            } else if (document.getElementById("userPassword").value == "000000") {

                window.localStorage.setItem("data", "1");
                window.open("test.aspx", "_self");

            } else {
                alert("please enter the right username and password")

            }
        }

    </script>

</head>


<body ">

    <form>
    <div style="padding-top: 200px; padding-left: 40%;">
        <img alt="Banner of Accenture" src="photo/accenture.jpg" style="width: 220px; height: 90px;" />
        <br /> 
        <input id="userName" type="text" placeholder="Enterprise ID" style="border: solid; width: 220px" /><br />
        <br />
        <input id="userPassword" type="password" placeholder="Password" style="border: solid; width: 220px;" />
        <br />
        <br />
        <input id="btn_submit" value="sign in" type="button" style="width: 70px; height: 20px;" onclick="javascript: checkUser()" />
    </div>

    </form>
</body>
</html>
