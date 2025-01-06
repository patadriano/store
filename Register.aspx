<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Store.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main> 
        <asp:Label ID="lblName" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="txtName" runat="server" Placeholder="Name"></asp:TextBox>
        <br />
        <asp:Label ID="lblrgstrUsername" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="txtrgstrUsername" runat="server" Placeholder="Username"></asp:TextBox>
        <br />
        <asp:Label ID="lblrgstrPassword" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="txtrgstrPassword" runat="server" Placeholder="Password" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="Register_Click"/>
         <br />
        <p runat="server"> Already have an account? <a href="~/Default.aspx"  runat="server"> Login here</a></p>
         <asp:Label ID="errorrgstrMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    </main>
</asp:Content>
