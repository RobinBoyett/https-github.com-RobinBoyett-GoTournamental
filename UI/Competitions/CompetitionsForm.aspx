<%@ Page Title="Competition - Selection" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="CompetitionsForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.CompetitionsForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="CompetitionsFormTitle" runat="server" /></h3>
 	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />	
    
    <h3>Competitions Selection</h3>
    <asp:Panel ID="CompetitionsFormPanel" runat="server">
        Select the Age Bands that apply
        <br /><br />
        <asp:CheckBoxList ID="AgeBandsList" RepeatColumns="3" Width="500"  runat="server" />
        <br />
        <asp:Button ID="SaveButton" Text="Save" OnClick="SaveButton_Click" runat="server" />

    </asp:Panel>
    </div>
</asp:Content>
