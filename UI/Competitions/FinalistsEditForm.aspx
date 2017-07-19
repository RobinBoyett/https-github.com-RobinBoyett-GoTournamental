<%@ Page Title="Competition" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="FinalistsEditForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.FinalistsEditForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="CompetitionTitle" runat="server" /></h3>
 	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
    <br />
    <asp:Panel ID="FinalistsEditFormPanel" runat="server">
    <h4><asp:Label ID="AgeBand" runat="server" /></h4>
    <table>
        <tr>
            <td>
                <asp:DropDownList ID="FinalistTeamList" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select Finalist</asp:ListItem>              
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ReplacementTeamList" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select Replacement</asp:ListItem>              
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="SaveButton" Text="Save" OnClick="SaveButton_Click" runat="server" />
            </td>
        </tr>
    </table>    


    </asp:Panel>
    </div>
</asp:Content>
