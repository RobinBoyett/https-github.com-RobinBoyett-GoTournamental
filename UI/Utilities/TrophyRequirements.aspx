<%@ Page Title="Cup Requirements" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="TrophyRequirements.aspx.cs" Inherits="GoTournamental.UI.Organiser.TrophyRequirements" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="TrophyRequirementsTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						

    <h3>Cup & Medal Requirements</h3>
    <asp:Panel ID="TrophyRequirementsPanel" runat="server">

    </asp:Panel>
    </div>
</asp:Content>