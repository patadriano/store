<%@ Page  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Store.Dashboard" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Search Block -->
    <div class="search-block" >
       
                <asp:TextBox ID="txtSearch" runat="server" CssClass="txt-search" placeholder="Enter search term" />
            <asp:Button  ID="btnSearch"  runat="server"  CssClass="btn-search" Text="Search" OnClick="btnSearch_Click"/>
       
           
       <%--  --%>
        
    </div>
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server" />--%>

    <!-- Welcome.aspx -->


    <!-- Results Section -->
       <asp:UpdatePanel ID="Results" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
<ContentTemplate>
    <div>
         <asp:Repeater ID="rptProducts" runat="server">
            <HeaderTemplate>
                <div class="repeater-results">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="repeater-posts">
                    <div class="repeater-img">
                         <asp:Image CssClass="image-post" ID="Image1" ImageUrl='<%# "~/Handler1.ashx?id=" + Eval("PostID") %>' runat="server" />
                    </div>
                   <div class="repeater-textpart">
                       <div class="repeater-desc">
                        <h3 > <%# Eval("PostTitle") %> </h3>
                        
                       <p> <%# Eval("PostDesc") %> </p>
                       
                        </div>
                       <div class="btn-checkpost-div">
                         <asp:Button  ID="btnCheckPost"  runat="server"  CssClass="btn-checkpost" Text=">"   />
                                                <%--<p style="font-size: 14px; color: #555;"><strong>Post ID:</strong> <%# Eval("PostID") %></p>--%>
                       </div>
                        
                      
                        
                   </div>
                                            
                                          
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
