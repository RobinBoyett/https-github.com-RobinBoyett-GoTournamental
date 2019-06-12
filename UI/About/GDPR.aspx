<%@ Page Title="GoTournamental - GDPR" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="GDPR.aspx.cs" Inherits="GoTournamental.UI.Organiser.GDPR" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <asp:Panel ID="GDPRPanel" runat="server">

    <div class="row">
        <div class="col-md-8">
            <h3>GDPR</h3>
            <ul>
                <li>GoTournamental encrpyts all contact details used on the site - names, phones numbers and email addresses</li>
                <li>All contacts data is deleted annually</li>
            </ul>
            <br />

        </div>
        <div class="col-md-4" style="text-align:right;">
            <Advertisements:AdvertPanel id="Advert300x250" runat="server" />
        </div>

    </div>
    </asp:Panel>
</div>
</asp:Content>
