<%@ Page Title="Competition" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="CompetitionForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.CompetitionForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="CompetitionTitle" runat="server" /></h3>
 	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						

    <asp:Panel ID="CompetitionFormPanel" runat="server">
    <table style="width:1350px;">
        <tr>
            <td><h4><asp:Label ID="AgeBand" runat="server" /></h4></td>
            <td><asp:HyperLink ID="LinkToCompetitionSummary" Text="[View Summary]" runat="server" /></td>
        </tr>
        <tr>
            <td style="width:160px; vertical-align:top;">
                No. Teams Attending:
            </td>
            <td style="width:1100px;">
                <asp:Label ID="NoTeamsAttending" runat="server" />
            </td>
        </tr>                
        <tr>
            <td style="line-height:16px;">
                Start Time:<div style="color:red; display:inline; line-height:2;">*</div>
            </td>
            <td>
                Date&nbsp;
                <asp:Dropdownlist id="CompetitionStartDate" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="">Select</asp:ListItem>              
                </asp:Dropdownlist>
                &nbsp;Time&nbsp;
                <asp:DropDownList ID="CompetitionStartHour" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="">Hour&nbsp;</asp:ListItem>              
                </asp:DropDownList>
                <asp:DropDownList ID="CompetitionStartMinute" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="">Minute&nbsp;</asp:ListItem>              
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Session:<div style="color:red; display:inline; line-height:2;">*</div>
            </td>
            <td>
                <asp:DropDownList ID="Session" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Fixture Turnaround:<div style="color:red; display:inline; line-height:2;">*</div>
            </td>
            <td>
                <asp:DropDownList ID="FixtureTurnaround" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>
                Minutes
            </td>
        </tr>
        <tr>
            <td>
                Team Size:
            </td>
            <td>
                <asp:DropDownList ID="TeamSize" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Squad Size:
            </td>
            <td>
                <asp:DropDownList ID="SquadSize" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;">
                Format:<div style="color:red; display:inline; line-height:2;">*</div>
            </td>
            <td>
                <asp:DropDownList ID="CompetitionFormat" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>
				<asp:ImageButton ID="CompetitionFormatHelp" CausesValidation="false" ImageUrl="~/Images/Icons/Information.gif" runat="server" />
                <ajaxToolkit:PopupControlExtender ID="CompetitionFormatPopup" runat="server" TargetControlID="CompetitionFormatHelp" PopupControlID="CompetitionFormatHelpText" Position="Right" />
                <asp:Panel ID="CompetitionFormatHelpText" Width="500" runat="server">
                    <ul>
                        <li style="list-style-type: none;">
                            <h5>Competition Format</h5><br /><br />
                            Select a format to....
                        </li>
                    </ul>
                </asp:Panel>
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>

        <asp:Panel ID="CompetitionEditButtonPanel" runat="server">
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="SaveButton" Text="Save Edit" OnClick="SaveButton_Click" CssClass="btn btn-default" runat="server" />
                &nbsp;<div style="color:red; display:inline; line-height:2;">*</div> these fields are not mandatory but ARE required to generate fixtures
            </td>
        </tr>
        </asp:Panel>
        <tr><td colspan="2">&nbsp;</td></tr>

     </table>

    </asp:Panel>
    </div>
</asp:Content>
