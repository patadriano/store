<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Store.Profile" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="profile-container">
        <div class="profile">
            <!-- Profile Image -->

         <%--<asp:UpdatePanel ID="prfupdate" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>--%>
               
            <div class="profile-image"> 
                 <asp:Image ID="Image2"  CssClass="img-profile" runat="server" />
                <br />
                  <h1 ><asp:Label ID="ProfileNameLabel" CssClass="lbl-profile" runat="server"/></h1>
                <br />
                <asp:Button ID="btnEditProfile" CssClass="profile-edit" runat="server" Text="Edit Profile" OnClick="btnEdit_Click" />
            </div>
                

            <!-- Profile Info (Text) -->
             <div>
                  <asp:Repeater ID="prfleProducts" runat="server">
                     <HeaderTemplate>
                         <div class="repeater-results">
                     </HeaderTemplate>
                     <ItemTemplate>
                         <div class="repeater-posts">
                             <div class="repeater-img">
                                <asp:Image ID="Image1" ImageUrl='<%# "~/Handler1.ashx?id=" + Eval("PostID") %>' runat="server" />
                             </div>
                            <div class="repeater-textpart">
                                 <div class="repeater-desc">
                                 <h3> <%# Eval("PostTitle") %> </h3>
                                 <p> <%# Eval("PostDesc") %> </p>
                            </div>
                            <div class="btn-checkpost-div">
                                <asp:Button  ID="btnCheckPost"  runat="server"  CssClass="btn-checkpost" Text=">"   />
                            </div>
                        </div>
                        </div>
                             
                         
                     </ItemTemplate>
                     <FooterTemplate>
                         </div> <!-- Closing product-grid div -->
                     </FooterTemplate>
                 </asp:Repeater>
            </div>


            <%--Profile--%>



                        <div id="moll" runat="server" class="modall" visible="false"  autopostback="true">

                                        <div class="modal-background"></div>
                                        <div id="post-modal"  class="post-modall" >

                                   <div class="post-header">
                                        <h6>EDIT Profile</h6>
                                       <asp:Button runat="server" CssClass="btn-close-popup" Text="X"  />
                                   </div>
                                   <div class="post-body">
     
                                     <!-- Title -->
         
                                     <asp:TextBox ID="txtProfName" runat="server" CssClass="txtbox-popup" Placeholder="Profile Name"></asp:TextBox>
                                     <%--<input type="text" id="title" name="title" placeholder="Enter title here">--%>
	                                  <br>
                                      <asp:FileUpload ID="FileUpload2" CssClass="fileup-popup" runat="server" />
                         
	                                    <br>
                                   </div>
                                   <div class="post-footer">
                                          <asp:Button runat="server" ID="Button" Text="Save" CssClass="btn-save-popup" OnClick="btnSavee_Click" />
                                       <%-- <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />--%>
                                   </div>
                 </div>
                            </div>

</div>


           
    </section>
</asp:Content>