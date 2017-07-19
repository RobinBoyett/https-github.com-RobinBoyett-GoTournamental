<%@ Page Title="Sponsors List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="KnockoutForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.KnockoutForm" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="CompetitionTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						
    
    <div class="row">
        <div class="col-md-12">
            <asp:Panel ID="KnockoutViewPanel" runat="server">
            <table>
                <tr>
                    <td><h4><asp:Label ID="AgeBand" runat="server" /></h4></td>
                    <td><asp:HyperLink ID="LinkToCompetitionSummary" Text="[View Summary]" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:160px;">No. Teams Attending:</td>
                    <td>
                        <asp:HyperLink ID="NoTeamsAttending" runat="server" /> 
                    </td>
                </tr>
            </table>

            <h3>Competitors</h3>
            <asp:DataList ID="CompetitorsList" BorderStyle="Solid" BorderColor="Black" BorderWidth="1" CellPadding="2" ItemStyle-Width="400" RepeatColumns="2" OnItemDataBound="CompetitorsList_ItemDataBound" runat="server">
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

            <br /><br />
            Select playing areas<br />
            <asp:CheckBoxList ID="PlayingAreasList" RepeatColumns="4" RepeatDirection="Horizontal" Width="500" Font-Size="Small"  runat="server" />
            <asp:CustomValidator ID="PlayingAreasMandatory" Enabled="false" ErrorMessage="Please select the number of Playing Areas" Text="&nbsp;" ClientValidationFunction="ValidatePlayingAreasList" runat="server" />
            <br />
            <asp:ValidationSummary ID="CompetitionValidationSummary" runat="server" />

            <asp:Button ID="MakeDrawButton" Text="Make Cup Draw" OnClick="MakeDrawButton_Click" CssClass="btn btn-default" runat="server" />
  


            </asp:Panel>

        </div>
    </div>
    </div>
</asp:Content>