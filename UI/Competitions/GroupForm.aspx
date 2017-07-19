<%@ Page Title="Group Edit Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="GroupForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.GroupForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="CompetitionTitle" runat="server" /></h3>
 	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						

    <asp:Panel ID="GroupFormPanel" runat="server">
    <table style="width:1350px;">
        <tr>
            <td><h4><asp:Label ID="GroupTitle" runat="server" /></h4></td>
            <td>...</td>
        </tr>            
 
        <tr>
            <td style="width:220px; vertical-align:top;">
                Reset Fixture Turnaround:<div style="color:red; display:inline; line-height:2;">*</div>
            </td>
            <td>
                <asp:DropDownList ID="FixtureTurnaround" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>
                Minutes - NOTE - changing this value will alter start times for existing fixtures for this group
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="SaveButton" Text="Save Edit" OnClick="SaveButton_Click" CssClass="btn btn-default" runat="server" />
            </td>
        </tr>

     </table>

    </asp:Panel>
    </div>
</asp:Content>
