<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Store.Profile" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="profile-container">
        <div class="profile">
            <!-- Profile Image -->
            <div class="profile-image">
                <img src="https://via.placeholder.com/150" alt="Profile Picture">
                  <h1>John Doe</h1>
            </div>

            <!-- Profile Info (Text) -->
            <div class="profile-info">
                <!-- Posts Grid Inside Profile Info -->
                <div class="posts-grid">
                    <div class="post">
                        <img src="https://via.placeholder.com/500" alt="Post Image">
                        <h3>Post Title 1</h3>
                        <p>This is the description for the first post. It gives a quick overview of the content.</p>
                    </div>
                    <div class="post">
                        <img src="https://via.placeholder.com/500" alt="Post Image">
                        <h3>Post Title 2</h3>
                        <p>This is the description for the second post. It provides some details about what this post covers.</p>
                    </div>
                    <div class="post">
                        <img src="https://via.placeholder.com/500" alt="Post Image">
                        <h3>Post Title 3</h3>
                        <p>This is the description for the third post. Here, you can learn more about the topic covered in the post.</p>
                    </div>
                    <div class="post">
                        <img src="https://via.placeholder.com/500" alt="Post Image">
                        <h3>Post Title 4</h3>
                        <p>This is the description for the fourth post. It gives a sneak peek into the article's content.</p>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>