<%@ Page Title="Clubs List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ClubsList.aspx.cs" Inherits="GoTournamental.UI.Organiser.ClubsList" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="TeamDirectoryTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						

    <h3>Clubs & Teams Directory</h3>
    <asp:Panel ID="ClubsListPanel" runat="server">

    <div class="row">
        <div class="col-md-12">
            <asp:HyperLink ID="LinkToClubsAdd" Text="[Add Club]" Visible="false"  Font-Size="Smaller" runat="server" />
            <br />
            <asp:DataList ID="ClubsDataList" OnItemDataBound="ClubsDataList_ItemDataBound" runat="server">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td style="width:16px;">
					            <asp:HyperLink ID="RequestDeleteClubLink" Visible="false" runat="server">
						            <asp:Image ID="RequestDeleteClubLinkImage" ImageUrl="~/Images/Icons/delete.jpg" BorderWidth=0 runat="server" />&nbsp;
					            </asp:HyperLink>
                            </td>
                            <td>
                                <asp:Table ID="ColourTable" runat="server">
                                    <asp:TableRow ID="ColourTableRow" Height="15" runat="server">
                                        <asp:TableCell ID="ColourPrimaryCell" Text="&nbsp;" Width="20" Height="15" BorderStyle="Solid" BorderWidth="1" BorderColor="Black" runat="server" />
                                        <asp:TableCell ID="ColourSecondaryCell" Text="&nbsp;" Width="20" Height="15" BorderStyle="Solid" BorderWidth="1" BorderColor="Black" runat="server" />
                                        <asp:TableCell ID="ClubAndTeamNameCell" Width="500" Height="15" runat="server">
                                            &nbsp;&nbsp;
                                            <asp:HyperLink ID="LinkToClubEdit" ForeColor="Black" Font-Bold="true" Font-Size="Large" runat="server" />&nbsp;&nbsp;&nbsp;
                                            <asp:HyperLink ID="LinkToClubItinary" Text="Itinerary >>" Font-Size="Small" runat="server" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </td>
                        </tr>
                    </table>            
                    <asp:DataList ID="TeamsListForClub" OnItemDataBound="TeamsListForClub_ItemDataBound" runat="server">
                        <ItemTemplate>
					        <asp:HyperLink ID="RequestDeleteTeamLink" Visible="false" runat="server">
						        <asp:Image ID="RequestDeleteTeamLinkImage" ImageUrl="~/Images/Icons/delete.jpg" BorderWidth=0 runat="server" />&nbsp;
					        </asp:HyperLink>
                            <asp:HyperLink ID="LinkToTeamEdit" ForeColor="Black" Font-Size="Small" Width="250" runat="server" />
                            <asp:Label ID="CompetitionName" Font-Size="Small" Width="150" runat="server" />
                            <asp:HyperLink ID="LinkToTeamItinary" Text="Itinerary >>" Width="80" runat="server" />
                            <asp:Label ID="GroupName" Font-Size="Small" Width="60" runat="server" />
                            <asp:Label ID="Attendance" Font-Size="Small" Width="140" runat="server" />
                            <asp:Label ID="ContactName" Font-Size="Small" Width="140" runat="server" />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:HyperLink ID="LinkToTeamsAdd" Text="[Add Team]" Visible="false" Font-Size="Smaller" runat="server" />
                    <br /><br />
                </ItemTemplate>
            </asp:DataList>
        </div>


    </div>

    </asp:Panel>
    </div>
</asp:Content>