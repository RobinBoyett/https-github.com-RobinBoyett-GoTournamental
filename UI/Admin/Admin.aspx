<%@ Page Title="About GoTournamental" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="GoTournamental.UI.Administration.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    
    <asp:Panel ID="AdminPanel" runat="server">
    						
    <div class="row">
        <div class="col-md-9">
            <h3>GT Admin Tools</h3>
            <a href="/UI/Admin/ErrorsList">Application Errors List</a><br />
            <a href="/UI/Admin/ContactUsList">Contact Us - Queries List</a><br />

        </div>
        <div class="col-md-3">

        </div>

    </div>

    </asp:Panel>
    </div>
</asp:Content>
