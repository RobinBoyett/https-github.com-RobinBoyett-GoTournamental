<%@ Page Title="GoTournamental - Our Mission" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Mission.aspx.cs" Inherits="GoTournamental.UI.Organiser.Mission" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <asp:Panel ID="MissionPanel" runat="server">

    <div class="row">
        <div class="col-md-8">
            <h3>Our Mission</h3>
            <p>
                GoTournamental came about in 2014 after co-founders Martin and Rob watched their sons in a youth soccer tournament in East Sussex. 
                Martin - the Fixture Secretary for the host club - described the laborious task of using a spreadsheet to organise the fixtures 
                being played out in front of them, having dedicated several entire weekends to administration for the event.
                Rob, his neighbour, suggested it would be easier if the tournament was managed online. 
            </p>
            <p>
                For many sports clubs, a tournament is the largest revenue generator for the year. GoTournamental aims to reduce the administrative 
                burden of organising facilities, fixtures and people for events, in an easy to use manner. If you wish to have a demonstration, please let us know -
                you won't believe how many hours of effort you can save next time you host a tournament. The system is currently on beta trial.
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
