<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Store.Register" %>


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
    <link rel="stylesheet"  href="~/Style/style.css" />
   <%-- google font--%>
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=DM+Serif+Text:ital@0;1&display=swap" rel="stylesheet">

    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=DM+Serif+Text:ital@0;1&family=Ubuntu+Mono:ital,wght@0,400;0,700;1,400;1,700&display=swap" rel="stylesheet">

    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=DM+Serif+Text:ital@0;1&family=Ubuntu+Mono:ital,wght@0,400;0,700;1,400;1,700&family=Ultra&display=swap" rel="stylesheet">
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

       
        </nav>
        <nav>
        <div class="logo">
            <span><asp:Label  runat="server" Text="BlahBlahStore" CssClass="main-logo"/></span>
        </div>
        <ul>
             
           
        </ul>
    </nav>

        <div class="container body-content">
            

                    <main class="login-register">
                        <div class="inner-login-register">
                            <div class="logo-login-register">
                                <img src="images/icon.png"/>
                            </div>
                             <div class="login-register-form">
                                    <asp:Label ID="Label1" runat="server" CssClass="lblregister">Create your Account</asp:Label>
                    
                                    <br />
                                    <asp:TextBox ID="txtName" runat="server" CssClass="txt-register" Placeholder="Name"></asp:TextBox>
                    
                                    <br />
                                    <asp:TextBox ID="txtrgstrUsername" runat="server" CssClass="txt-register" Placeholder="Username"></asp:TextBox>
                    
                                    <br />
                                    <asp:TextBox ID="txtrgstrPassword" runat="server" CssClass="txt-register" Placeholder="Password" TextMode="Password"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="btnRegister" runat="server" CssClass="btn-register" Text="Register" OnClick="Register_Click"/>
                                     <br />
                                    <p runat="server"> Already have an account? <a href="~/Default.aspx"  runat="server"> Login here</a></p>
                                     <asp:Label ID="errorrgstrMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
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