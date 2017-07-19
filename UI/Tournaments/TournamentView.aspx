<%@ Page Title="Tournament" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="TournamentView.aspx.cs" Inherits="GoTournamental.UI.Organiser.TournamentView" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <%--<div class="h3 club-colours-claret-and-blue">--%><h3><asp:Label ID="TournamentTitle" runat="server" /></h3><%--</div>--%>
 <%--   <div class="gt-menu-block">--%>
	    <Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	    <Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />
 <%--   </div>--%>						
    <asp:Panel ID="TournamentViewPanel" runat="server">
    <div class="row">
        <div class="col-md-12">
            <table style="width:1000px;">
                <tr>
                    <td style="vertical-align:top;">
                        <table>
                            <tr>
                                <td style="width:185px; line-height:16px;"><h4>Tournament Summary</h4></td>
                                <td><asp:HyperLink ID="LinkToTournamentEdit" Text="[Edit]" Visible="false" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>Date & Time:</td>
                                <td>
                                    <asp:Label ID="TournamentDate" runat="server" />                
                                </td>
                            </tr>
                            <tr>
                                <td>Venue:</td>
                                <td>
                                    <asp:Label ID="TournamentVenue" runat="server" /><br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Postcode:
                                </td>
                                <td>
                                    <asp:Label ID="TournamentPostcode" runat="server" /><br />
                                </td>
                            </tr>
                            <asp:Panel ID="GoogleMapFramePanel" Visible="false" runat="server">
                            <tr>
                                <td style="vertical-align:top;">
                                    Google Maps:
                                </td>
                                <td>
                                    <iframe id="GoogleMapIFrame" runat="server" width="300" height="200" frameborder="0" style="border:0" allowfullscreen></iframe>
                                </td>
                            </tr>
                            </asp:Panel>
                            <tr>
                                <td style="vertical-align:top;">
                                    Tournament Contact:
                                </td>
                                <td>
                                    <asp:Label ID="ContactName" runat="server" />
                                    <asp:HyperLink ID="ContactEmailLink" Target="_blank" runat="server">
                                        <asp:Image ID="ContactEmailIcon" Visible="false" ImageUrl="~/Images/Icons/mailto.gif" BorderStyle="None" runat="server" />
                                    </asp:HyperLink>
                                    <asp:Label ID="ContactTelephone" runat="server" />                                 
                                    <asp:HyperLink ID="ContactEditLink" runat="server" />
                                </td>
                            </tr>


                            <asp:Panel ID="AdministratorViewOnlyPanelOne" Visible="false" runat="server">
                            <tr><td colspan="2">&nbsp;</td></tr>
                            <tr>
                                <td>Tournament Type:</td>
                                <td>
                                   <asp:Label ID="TournamentType" runat="server" /> 
                                </td>
                            </tr> 
                            <tr>
                                <td>
                                    No. of <asp:Label ID="PlayingAreaType" runat="server" />:
                                </td>
                                <td>
                                    <asp:Label ID="NoOfPlayingAreas" runat="server" />
                                </td>
                            </tr>
                            </asp:Panel>
                            <tr>
                                <td>
                                    Fixture Turnaround Time:*
                                </td>
                                <td>
                                    <asp:Label ID="FixtureTurnaround" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Team Size:*
                                </td>
                                <td>
                                    <asp:Label ID="TeamSize" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Squad Size:*
                                </td>
                                <td>
                                    <asp:Label ID="SquadSize" runat="server" />
                                </td>
                            </tr>
                            <asp:Panel ID="AdministratorViewOnlyPanelTwo" Visible="false" runat="server">
                            <tr>
                                <td>
                                    Results & Tables View:
                                </td>
                                <td>
                                    Settings:&nbsp;
                                    <asp:Label ID="ResultsAndTablesDate" runat="server" />&nbsp;
                                    <asp:Label ID="ResultsAndTablesSession" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    No. Competitions:
                                </td>
                                <td>
                                    <asp:HyperLink ID="NoCompetitions" runat="server" />&nbsp;Age Bands
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    No. Teams Attending:
                                </td>
                                <td>
                                    <asp:HyperLink ID="NoTeamsAttending" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    No. Fixtures Scheduled:
                                </td>
                                <td>
                                    <asp:HyperLink ID="NumberOfFixturesScheduled" runat="server" />
                                </td>
                            </tr>
                            </asp:Panel>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                   * These details may vary slightly for some competitions or age bands
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align:top;">
                       <table>
                            <tr>
                                <td>
                                    <br /><br />
                                    <asp:Image ID="ClubLogo" BorderStyle="None" runat="server" />
                                    <br /><br />
                                    <asp:HyperLink ID="UploadClubLogoLink" runat="server" />
                                </td>
                            </tr>
                           <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td>
                            
                                </td>
                            </tr>
                       </table>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="row">
            <div class="col-md-8">
                <Advertisements:AdvertPanel id="Advert728By90" runat="server" />
            </div>
            <div class="col-md-4">
                &nbsp;
            </div>
        </div>

    </div>

     
    </asp:Panel>
    </div>
</asp:Content>