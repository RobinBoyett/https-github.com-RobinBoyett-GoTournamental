<%@ Page Title="About GoTournamental" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ErrorPage.aspx.cs" Inherits="GoTournamental.UI.Organiser.ErrorPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <asp:Panel ID="ErrorPanel" runat="server">
  						
    <div class="row">
        <div class="col-md-12">

            <h3><asp:Label ID="ErrorName" runat="server" /></h3><br />
            <asp:Label ID="ErrorDescription" runat="server" />
            <br /><br />
            <asp:HyperLink ID="LinkToHomePage" Text="To Home Page >>" NavigateUrl="~/Default.aspx" runat="server" />

        </div>
    </div>

    </asp:Panel>
    </div>
</asp:Content>
