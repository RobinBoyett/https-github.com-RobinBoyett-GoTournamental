<%@ Page Title="Competition Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="CompetitionRegister.aspx.cs" Inherits="GoTournamental.UI.Organiser.CompetitionRegister" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="TournamentTitle" runat="server" /></h3>

	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						
    <asp:Panel ID="CompetitionRegisterPanel" runat="server">
        <br /><br />
        <asp:CheckBoxList ID="TeamsInCompetitionList" RepeatColumns="2" Width="700"  runat="server" />
        <br />
        <asp:Button ID="SaveButton" Text="Save" OnClick="SaveButton_Click" runat="server" />

    </asp:Panel> 

    </div>
</asp:Content>
