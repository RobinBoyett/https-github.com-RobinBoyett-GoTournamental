<%@ Page Title="GoTournamental - Who We Are" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="GoTournamental.UI.About" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <asp:Panel ID="AboutPanel" runat="server">

    <div class="row">
        <div class="col-md-8">
            <h3>About GoTournamental</h3>
            <p>
                GoTournamental came about in 2014 when co-founders Martin and Rob watched their sons in a youth soccer tournament in East Sussex. 
                Martin - the Fixture Secretary for the host club - described the laborious task of using a spreadsheet to organise the fixtures 
                being played out in front of them. Rob, his neighbour, suggested it would be easier to manage the events online.
            </p>
            <p>
                GoTournamental is currently on beta trial. It aims to reduce the administrative burden of organising facilities, fixtures and people for
                what is normally the largest revenue generating event each year for sports clubs. If you wish to have a demonstration, please let us know -
                you won't believe how many hours of effort you can save next time you host a tournament.
            </p>
            <br />
            <table style="width:1200px;">
                 <tr>
                    <td style="width:120px; vertical-align:top; text-align:center;">
                        <asp:Image ImageUrl="~/Images/Staff/RobinBoyett.jpg" Height="100" Width="85" runat="server" />
                    </td>
                    <td style="text-align: left;">
                        <h4>Dr Rob Boyett</h4>
                        An award-winning software developer in the legal profession, Rob is a West Ham United supporter and enjoys training in 
                        <a href="http://www.crosskravmaga.co.uk/" target="_blank">CROSS Krav Maga</a>. 
                    </td>
                </tr>
                <tr><td colspan="2">&nbsp;</td></tr>
                <tr>
                    <td style="width:120px; vertical-align:top; text-align:center;">
                        <asp:Image ImageUrl="~/Images/Staff/MartinBunte.jpg" Height="100" Width="100" runat="server" />
                    </td>
                    <td style="text-align: left;">
                        <h4>Martin Bunte</h4>
                        Martin's normal role is selling management applications to estate agents. Now a protected species, being a Chelsea fan from before 1998, 
                        his barbecues are legendary (even when its snowing).
                    </td>
                </tr>

            </table>

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
