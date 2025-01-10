<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Store.Profile" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="profile-container">
        <div class="profile">
            <!-- Profile Image -->

         <%--<asp:UpdatePanel ID="prfupdate" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>--%>
               
            <div class="profile-image"> 
                 <asp:Image ID="Image2"  runat="server" />
                  <h1 style="font-size: 18px; margin: 10px 0;">
    <asp:Label ID="ProfileNameLabel" runat="server"></asp:Label>
</h1>

                <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" OnClick="btnEdit_Click" />
            </div>
                

            <!-- Profile Info (Text) -->
             <div>
                  <asp:Repeater ID="prfleProducts" runat="server">
                     <HeaderTemplate>
                         <div style="display: grid; grid-template-columns: repeat(2, 1fr); gap: 20px; margin: 20px;">
                     </HeaderTemplate>
                     <ItemTemplate>
                         <div style="border: 1px solid #ddd; padding: 15px; background-color: #fff; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); text-align: center; transition: transform 0.3s ease-in-out;">
                            <asp:Image 
                                 ID="imgProduct" 
                                 runat="server" 
 
                                 Style="width: 100%; height: auto; max-width: 200px; margin-bottom: 15px; object-fit: cover;" 
                                 />
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

            <%--Profile--%>
             <div id="moll" runat="server" class="post" visible="false" style="display: block; position: fixed; z-index: 100;  left: 50%; top:  50%; transform: translateX(-50%); translateY(-50%); background-color: rgba(0, 0, 0, 0.37); overflow-y: auto;" autopostback="true">
       <div class="post-header">
         <h6>EDIT Profile</h6>
       </div>
       <div class="post-body">
     
         <!-- Title -->
         
         <asp:TextBox ID="txtProfName" runat="server" Placeholder="Profile Name"></asp:TextBox>
         <%--<input type="text" id="title" name="title" placeholder="Enter title here">--%>
	      <br>
          <asp:FileUpload ID="FileUpload2" runat="server" />
          <asp:Button runat="server" ID="Button" Text="Save" OnClick="btnSavee_Click" />
	        <br>
       </div>
       <div class="post-footer">
         
           <%-- <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />--%>
       </div>
 </div>

        </div>


           <%-- </ContentTemplate>
          </asp:UpdatePanel>--%>
    </section>
</asp:Content>