<%@ Page Title="GoTournamental - Who We Are" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="WhoWeAre.aspx.cs" Inherits="GoTournamental.UI.Organiser.WhoWeAre" %>
<%@ Register TagPrefix="Navigation" TagName="AboutMenu" Src="~/UI/Menus/AboutMenu.ascx" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
	<Navigation:AboutMenu id="AboutMenuControl" runat="server" />						
    <asp:Panel ID="WhoWeArePanel" runat="server">

    <div class="row">
        <div class="col-md-8">
            <h3>Our Story</h3>
            <p>
                GoTournamental came about in 2014 when co-founders Martin and Rob watched their sons in a youth soccer tournament in East Sussex. 
                Martin - the Fixture Secretary for the host club - described the laborious task of using a spreadsheet to organise the fixtures 
                being played out in front of them. Rob, his neighbour, suggested it would be easier to manage the events online.
            </p>
            <p>
                GoTournamental is currently free to use. It aims to reduce the administrative burden of organising facilities, fixtures and people for
                what is normally the largest revenue generating event each year for sports clubs. If you wish to have a demonstration, please let us know -
                you won't believe many hours of effort you can save next time you host a tournament.
            </p>
            <br />
            <h4>Dr Rob Boyett</h4>
            <p>
                An award-winning software developer in the legal profession, Rob is a West Ham United supporter and enjoys training in 
                <a href="http://www.crosskravmaga.co.uk/" target="_blank">CROSS Krav Maga</a>. 
            </p>
            <br />
            <h4>Martin Bunte</h4>
            <p>
                Martin's normal role is selling management applications to estate agents. Now a protected species, being a Chelsea fan from before 1998, 
                his barbecues are legendary (even when its snowing).
            </p>
            <br />
<%--            <h4>Registered Address</h4>
            <p>
                <address>
                Hawley Manor<br />
                Hawley Road<br />
                Dartford<br />
                Kent<br />
                DA11PX<br />
                </address>
            </p>--%>
        </div>
        <div class="col-md-4" style="text-align:right;">
            <Advertisements:AdvertPanel id="Advert300x250" runat="server" />
        </div>

    </div>
    </asp:Panel>
</div>
</asp:Content>
