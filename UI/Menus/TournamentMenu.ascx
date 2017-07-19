<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TournamentMenu.ascx.cs" Inherits="TournamentMenu" %>

<asp:Panel ID="TournamentNavigationPanel" Height="22px" runat="server">
<ul class="nav nav-pills">
    <li><asp:HyperLink ID="LinkToTournament" Text="Tournament" runat="server" /></li>
    <li><asp:HyperLink ID="LinkToFixtures" Text="Fixtures" Visible="false" runat="server" /></li>
    <li><asp:HyperLink ID="LinkToCompetitionRotator" Text="Results &amp; Tables" runat="server" /></li>
    <li><asp:HyperLink ID="LinkToDocuments" Text="Documents" runat="server" /></li>
    <li><asp:HyperLink ID="LinkToSponsorsList" Text="Sponsors" runat="server" /></li>
</ul>
</asp:Panel>


				