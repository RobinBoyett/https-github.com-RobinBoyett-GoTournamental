<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SetUpMenu.ascx.cs" Inherits="SetUpMenu" %>

<asp:Panel ID="SetUpNavigationPanel" Visible="false" Height="22px" runat="server">
<ul class="nav nav-pills">
    <li><asp:HyperLink ID="LinkToSetUp" Text="Set-Up" runat="server" /></li>
    <li><asp:HyperLink ID="LinkToClubsDirectory" Text="Clubs & Teams" runat="server" /></li>
    <li><asp:HyperLink ID="LinkToClubInvitation" Text="Invitations" runat="server" /></li>
    <li><asp:HyperLink ID="LinkToRegistration" Text="Club Register" runat="server" /></li>
    <li><asp:HyperLink ID="LinkToTeamAttendance" Text="Attendance" runat="server" /></li>
    <li><asp:HyperLink ID="LinkToContacts" Text="Contacts" Visible="false" runat="server" /></li>
    <li><asp:HyperLink ID="LinkToCompetitions" Text="Age Bands" runat="server" /></li>
    <li><asp:HyperLink ID="LinkToPlayingAreasItinerary" runat="server" /></li>
    <li><asp:HyperLink ID="LinkToFixtures" Text="Fixtures" runat="server" /></li>
<%--    <li><asp:HyperLink ID="LinkToAdministrativeTasks" Text="Tasks" runat="server" /></li>
    <li><asp:HyperLink ID="LinktoTrophyRequirements" Text="Trophies" runat="server" /></li>--%>
    <li><asp:HyperLink ID="LinkToAdverts" Text="Adverts" runat="server" /></li>
    <li><asp:HyperLink ID="LinkToUploadAndImport" Text="Import XL" Visible="false" runat="server" /></li>
    <li><asp:HyperLink ID="LinkToExport" Text="Export XL" runat="server" /></li>
</ul>
</asp:Panel>


				