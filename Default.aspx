﻿<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Store._Default" %>


<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - My ASP.NET Application</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

 <%--   <webopt:bundlereference runat="server" path="~/Content/css" />--%>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet"  href="~/Style/newstyle.css" />
   <%-- google font--%>
<link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Bowlby+One&family=Notable&family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&family=Syne:wght@800&display=swap" rel="stylesheet">

    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200&icon_names=local_mall" />
</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>

       
        
        <nav>
        <div class="logo">
            <div class="logo-box"> 
                <img src="images/star-white.png"/>
                <asp:Label  runat="server" Text="Store" CssClass="main-logo"/>

            </div>
        </div>
            
                 <ul class="circle-list">
                          <li></li>
                          <li></li>
                          <li></li>
                        </ul>
            
       
    </nav>

        <div class="container body-content">
            <main class="login-register">
            <div class="inner-login-register">
                <div class="logo-login-register">
                    <img  src="images/icon-black.png"/>
                </div>
                <div class="login-register-form">
                    <asp:Label ID="Label1" runat="server" CssClass="lblregister">Login your Account</asp:Label>
                    <br />
                    <asp:TextBox ID="txtlgnUsername" runat="server" CssClass="txt-register" Placeholder="Username"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtlgnPassword" runat="server" CssClass="txt-register" Placeholder="Password" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn-register" OnClick="Login_Click" />
                    <br />
                    <p runat="server"> Don’t have an account? <a href="~/Register.aspx" runat="server"> Sign up here</a></p>
                    <asp:Label ID="errorMessage" runat="server"></asp:Label>
                    <br />
                </div>
            </div>
    
        </main>
        </div>
     


    </form>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/Scripts/bootstrap.js") %>
    </asp:PlaceHolder>
</body>
</html>
