<%@ Page Title="Competition" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SwapTeamsBetweenGroupsForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.SwapTeamsBetweenGroupsForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="CompetitionTitle" runat="server" /></h3>
 	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
    <br />
    <asp:Panel ID="SwapTeamsBetweenGroupsFormPanel" runat="server">
    <h4><asp:Label ID="AgeBand" runat="server" /></h4>
    Select a pair of teams from the menus below<br /><br />
    <asp:Table ID="GroupsTable" runat="server">
        <asp:TableRow ID="DropDownsTableRow" Height="15" runat="server" />
    </asp:Table>
    <br />
    <asp:Button ID="SwapTeamsButton" Text="Swap Teams" OnClick="SwapTeamsButton_Click" class="btn btn-default" runat="server" />

    </asp:Panel>
    </div>
</asp:Content>
