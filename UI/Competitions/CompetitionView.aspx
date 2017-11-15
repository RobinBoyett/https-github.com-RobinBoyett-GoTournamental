<%@ Page Title="Competition" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="CompetitionView.aspx.cs" Inherits="GoTournamental.UI.Organiser.CompetitionView" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="TournamentTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						
    <asp:Panel ID="CompetitionViewPanel" runat="server">
    <table>
        <tr>
            <td><h4><asp:Label ID="AgeBand" runat="server" /></h4></td>
            <td><asp:HyperLink ID="LinkToCompetitionEdit" Text="[Edit]" Visible="false" runat="server" /></td>
        </tr>
        <tr>
            <td style="width:160px;">No. Teams Attending:</td>
            <td>
                <asp:HyperLink ID="NoTeamsAttending" runat="server" /> 
            </td>
        </tr>
        <tr>
            <td>Start Time:</td>
            <td>
                <asp:Label ID="StartTime" runat="server" /> 
            </td>
        </tr>
        <tr>
            <td>
                Session:
            </td>
            <td>
                <asp:Label ID="Session" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Fixture Turnaround:
            </td>
            <td>
                <asp:Label ID="FixtureTurnaround" runat="server" /> 
                <asp:Label ID="FixtureHalvesNumber" runat="server" />
                <asp:Label ID="FixtureHalvesLength" runat="server" />           
            </td>
        </tr>
        <tr>
            <td>Competition Format:</td>
            <td>
                <asp:Label ID="CompetitionFormat" runat="server" /> 
            </td>
        </tr>
        <tr>
            <td>Team Size:</td>
            <td>
                <asp:Label ID="TeamSize" runat="server" /> 
            </td>
        </tr>
        <tr>
            <td>Squad Size:</td>
            <td>
                <asp:Label ID="SquadSize" runat="server" /> 
            </td>
        </tr>
        <tr>
            <td>No. Groups:</td>
            <td>
                <asp:Label ID="NoGroupsInCompetition" runat="server" />&nbsp;
                <asp:HyperLink ID="LinkToGroupsSetUp" Visible="false" runat="server" /> 
            </td>
        </tr>
        <tr>
            <td>No. Fixtures:</td>
            <td>
                <asp:Label ID="NoFixturesInCompetition" runat="server" />&nbsp;
                <asp:HyperLink ID="LinkToGenerateFixtures" Visible="false" runat="server" /> 
            </td>
        </tr>
        <tr>
            <td>No. Teams Registered:</td>
            <td>
                <asp:Label ID="NoTeamsRegistered" runat="server" />&nbsp;
                <asp:HyperLink ID="LinkToCompetitionRegister" Text="[Register Teams]" runat="server" /> 
            </td>
        </tr>
    </table>
    <br />

    <asp:DataList ID="GroupsDataList" OnItemDataBound="GroupsDataList_ItemDataBound" runat="server">
        <ItemTemplate>
            <h4><asp:Label ID="GroupName" Font-Size="Small" Font-Bold="true" runat="server" /></h4>
            <asp:Label ID="RegistrationStatus" runat="server" />&nbsp;&nbsp;
            <asp:HiddenField ID="GroupIDHidden" runat="server" />
            <asp:Button ID="StartFixturesButton" Visible="false" OnClick="StartFixturesButton_Click" runat="server" />
            <asp:DataList ID="TeamsListForGroup" BorderStyle="Solid" BorderColor="Black" BorderWidth="1" CellPadding="2" ItemStyle-Width="400" RepeatColumns="2" OnItemDataBound="TeamsListForGroup_ItemDataBound" runat="server">
                <ItemTemplate>
                    <asp:Table ID="ColourTable" runat="server">
                        <asp:TableRow ID="ColourTableRow" Height="15" runat="server">
                            <asp:TableCell ID="ClubAndTeamNameCell" Width="350" Height="15" runat="server"><asp:Label ID="ClubNameLabel" Font-Bold="true" runat="server" />&nbsp;-&nbsp;<asp:Label ID="TeamNameLabel" runat="server" /></asp:TableCell>
                            <asp:TableCell ID="ColourPrimaryCell" Text="&nbsp;" Width="20" Height="15" BorderStyle="Solid" BorderWidth="1" BorderColor="Black" runat="server" />
                            <asp:TableCell ID="ColourSecondaryCell" Text="&nbsp;" Width="20" Height="15" BorderStyle="Solid" BorderWidth="1" BorderColor="Black" runat="server" />
                        </asp:TableRow>
                    </asp:Table>
                </ItemTemplate>
            </asp:DataList>
            <asp:GridView ID="FixturesListForGroup" OnRowDataBound="FixturesListForGroup_RowDataBound" runat="server" GridLines="None" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Name" ItemStyle-Width="100" ItemStyle-Font-Size="Small" />
                    <asp:BoundField HeaderText="Time" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
                    <asp:BoundField HeaderText="'Home'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
                    <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                    <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                    <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                    <asp:BoundField HeaderText="'Away'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
                    <asp:BoundField HeaderText="Pitch" ItemStyle-Width="60" ItemStyle-Font-Size="Small" />
                    <asp:BoundField HeaderText="Referee" ItemStyle-Width="120" ItemStyle-Font-Size="Small" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:GridView ID="LeagueTableForGroup" OnRowDataBound="LeagueTableForGroup_RowDataBound" CellSpacing="2" runat="server" GridLines="None" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField ItemStyle-Width="15" ItemStyle-Font-Size="Small" />
                    <asp:BoundField ItemStyle-Width="15" ItemStyle-Font-Size="Small" />
                    <asp:BoundField ItemStyle-Width="5" ItemStyle-Font-Size="Small" />
                    <asp:BoundField DataField="Position" ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                    <asp:BoundField HeaderText="Team" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
                    <asp:BoundField DataField="Played" HeaderText="P" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                    <asp:BoundField DataField="Wins" HeaderText="W" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                    <asp:BoundField DataField="Draws" HeaderText="D" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                    <asp:BoundField DataField="Defeats" HeaderText="L" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                    <asp:BoundField DataField="GoalsFor" HeaderText="F" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                    <asp:BoundField DataField="GoalsAgainst" HeaderText="A" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                    <asp:BoundField DataField="GoalDifference" HeaderText="GD" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                    <asp:BoundField DataField="Points" HeaderText="Pt" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                    <asp:BoundField HeaderText="Registered" ItemStyle-Width="60" ItemStyle-Font-Size="Small" Visible="false" />
                </Columns>  
            </asp:GridView>          
            <hr />

        </ItemTemplate>
    </asp:DataList>

    <br />
    <h4><asp:Label ID="FinalsLabel" Text="Finals" Font-Size="Small" Font-Bold="true" Visible="false" runat="server" /></h4>
    <asp:HyperLink ID="EditFinalistsLink" Text="[Edit Finalists]" Visible="false" runat="server" />
    <asp:GridView ID="FixturesListForCompetition" OnRowDataBound="FixturesListForCompetition_RowDataBound" runat="server" GridLines="None" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Name" ItemStyle-Width="150" ItemStyle-Font-Size="Small" />
            <asp:BoundField HeaderText="Time" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
            <asp:BoundField HeaderText="'Home'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
            <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
            <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
            <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
            <asp:BoundField HeaderText="'Away'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
            <asp:BoundField HeaderText="" ItemStyle-Width="80" ItemStyle-Font-Size="Small" />
            <asp:BoundField HeaderText="Pitch" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
            <asp:BoundField HeaderText="Referee" ItemStyle-Width="120" ItemStyle-Font-Size="Small" />
        </Columns>
    </asp:GridView>


    </asp:Panel>
    </div>
</asp:Content>