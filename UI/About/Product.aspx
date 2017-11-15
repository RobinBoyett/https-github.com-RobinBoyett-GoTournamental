<%@ Page Title="About GoTournamental" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="GoTournamental.UI.About" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    
    <asp:Panel ID="ProductPanel" runat="server">
    						
    <div class="row">
        <div class="col-md-9">
            <h3>How will GoTournamental help me plan my sport event?</h3>
            <ul>
                <li>Set up your competitions based on age bands and allocate pitches</li>
                <li>Upload details of your target clubs and their key contacts using our Excel template</li>
                <li>Invite the clubs to register all their teams online</li>
                <li>Organise the attending teams into groups and schedule fixtures for leagues</li>
                <li>Download fixture itineraries for programme printing</li>
                <li>Download printer-ready referee slips</li>
                <li>Email all attending contacts with event details and locality</li>
                <li>Register players online</li>
                <li>Re-schedule fixtures as required on the day</li>
                <li>Record results with GoTournamental and let it calculate league placings and finalists automatically</li>
                <li>Let coaches and parents follow results, tables and schedule alterations online in real time</li>
                <li>Download key contacts details in Excel for your records</li>
            </ul>
 
        </div>
        <div class="col-md-3" style="text-align:right;">
            <Advertisements:AdvertPanel id="Advert120x600" runat="server" />
        </div>

    </div>

    </asp:Panel>
    </div>
</asp:Content>
