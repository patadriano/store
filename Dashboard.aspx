<%@ Page  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Store.Dashboard" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Search Block -->
    <div class="search-block">
        <input type="text" placeholder="Search here..." id="search-input">
        <button onclick="search()">Search</button>
    </div>

    <!-- Results Section -->
    <div class="results" id="results">
        <div class="result-item">Result 1</div>
        <div class="result-item">Result 2</div>
        <div class="result-item">Result 3</div>
        <div class="result-item">Result 4</div>
        <div class="result-item">Result 5</div>
    </div>
</asp:Content>
