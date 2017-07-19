<%@ Page Title="About GoTournamental" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="GoTournamental.UI.Organiser.About" %>
<%@ Register TagPrefix="Navigation" TagName="AboutMenu" Src="~/UI/Menus/AboutMenu.ascx" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
	<Navigation:AboutMenu id="AboutMenuControl" runat="server" />
    
    <asp:Panel ID="AboutPanel" runat="server">
    						
    <div class="row">
        <div class="col-md-9">
            <h3>How will GoTournamental help me plan my sport event?</h3>
            <ul>
                <li>Set up competitions by age and allocate pitches</li>.
                <li>Upload details of target clubs and contacts using our Excel template</li>
                <li>Invite clubs to register their teams online</li>
                <li>Organise teams into groups and schedule fixtures</li>
                <li>Download fixture itineraries for programme printing</li>
                <li>Download printer-ready referee slips</li>
                <li>Email all attending contacts with event details and locality</li>
                <li>Re-schedule fixtures as required on the day</li>
                <li>Coaches and parents can follo results, tables and schedule alterations online in real time</li>
            </ul>
 
        </div>
        <div class="col-md-3" style="text-align:right;">
            <Advertisements:AdvertPanel id="Advert120x600" runat="server" />
        </div>

    </div>

    </asp:Panel>
    </div>
</asp:Content>
