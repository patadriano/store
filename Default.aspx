<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Store._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main> 
        <asp:Label ID="lbllgnUsername" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="txtlgnUsername" runat="server" Placeholder="Username"></asp:TextBox>
        <br />
        <asp:Label ID="lbllgnPassword" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="txtlgnPassword" runat="server" Placeholder="Password"></asp:TextBox>
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Login_Click" />
        <p runat="server"> Don’t have an account? <a href="~/Register.aspx" runat="server"> Sign up here</a></p>
        <asp:Label ID="errorMessage" runat="server"></asp:Label>
    </main>
</asp:Content>
