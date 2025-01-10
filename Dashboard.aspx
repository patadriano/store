<%@ Page  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Store.Dashboard" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Search Block -->
    <div class="search-block" >
        
            <asp:TextBox ID="txtSearch" runat="server" CssClass="txt-search" placeholder="Enter search term" />
            <asp:Button  ID="btnSearch"  runat="server"  CssClass="btn-search" Text="Search" OnClick="btnSearch_Click"  />
       <%--  --%>
        
    </div>
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server" />--%>

    <!-- Welcome.aspx -->
<asp:Label ID="lblUsername" runat="server"></asp:Label>

    <!-- Results Section -->
       <asp:UpdatePanel ID="Results" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
<ContentTemplate>
    <div>
         <asp:Repeater ID="rptProducts" runat="server">
            <HeaderTemplate>
                <div style="display: grid; grid-template-columns: repeat(4, 1fr); gap: 20px; margin: 20px; background-color="#FEF6C8">
            </HeaderTemplate>
            <ItemTemplate>
                <div style="border: 1px solid black; border-radius:15px; padding: 15px; ; box-shadow: 2px 2px rgba(0, 0, 0, 1); text-align: center; transition: transform 0.3s ease-in-out;">
                   
                     <asp:Image ID="Image1" ImageUrl='<%# "~/Handler1.ashx?id=" + Eval("PostID") %>' runat="server" />
                   <%-- <img src="<%# Eval("ImageUrl") %>"  style="width: 100%; height: auto; max-width: 200px; margin-bottom: 15px; object-fit: cover;" />--%>
                    <h3 style="font-size: 18px; margin: 10px 0;"> <%# Eval("PostTitle") %> </h3>
                    <p style="font-size: 14px; color: #555;"> <%# Eval("PostDesc") %> </p>
                    <p style="font-size: 14px; color: #555;"><strong>Post ID:</strong> <%# Eval("PostID") %></p>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div> <!-- Closing product-grid div -->
            </FooterTemplate>
        </asp:Repeater>
    </div>
</ContentTemplate>
           </asp:UpdatePanel>
  
</asp:Content>
