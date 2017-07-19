<%@ Page Title="Club" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ReplacementTeamForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.ReplacementTeamForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="TeamFormTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />
    
    <br /> 
    <asp:Panel ID="ReplacementTeamFormPanel" runat="server">
    <h4>Replace a Team in a Competition</h4>
    <table style="width:700px;">
        <tr>
            <td style="width:100px; line-height:16px;">Replace</td>
            <td>
                <asp:DropDownList ID="TeamsInCompetitionDropDown" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>
            </td>
            <td style="width:50px; line-height:16px;">With</td>
            <td>
                <asp:DropDownList ID="ReplacementTeamsDropDown" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr><td colspan="4">&nbsp;</td></tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="SaveButton" Text="Save" OnClick="SaveButton_Click" runat="server" /><br />
            </td>
        </tr>

     </table>

    </asp:Panel>
    </div>
</asp:Content>
