<%@ Page Title="Competition" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="GroupAllocationForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.GroupAllocationForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <script type="text/javascript">
        function ValidatePlayingAreasList(sender, args) {
            var checkBoxList = document.getElementById("<%=PlayingAreasList.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    isValid = true;
                    break;
                }
            }
            args.IsValid = isValid;
        }

    </script>

    <h3><asp:Label ID="CompetitionTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						

    <asp:Panel ID="GroupAllocationFormPanel" runat="server">
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

        <asp:Panel ID="GroupsEditPanel" Visible="false" runat="server">
        <tr>
            <td style="vertical-align:top;">
                No. Groups:
            </td>
            <td>
                <asp:Label ID="NoGroupsInCompetition" runat="server" />
                <asp:Panel ID="GroupAllocationPanel" Visible="false" runat="server">
                    <br />
                    <asp:DropDownList ID="CompetitionNoGroups" AppendDataBoundItems="true" runat="server">
					    <asp:ListItem Value="0"></asp:ListItem>              
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="CompetitionNoGroupsMandatory" Enabled="false" InitialValue="0" ErrorMessage="Please select the number of Groups" Text="<" ForeColor="Crimson" ControlToValidate="CompetitionNoGroups" SetFocusOnError="true" Font-Size="12px" runat="server" />				
                    
                    <br /><br />
                    Select playing areas<br />
                    <asp:CheckBoxList ID="PlayingAreasList" RepeatColumns="4" RepeatDirection="Horizontal" Width="500" Font-Size="Small"  runat="server" />
                    <asp:CustomValidator ID="PlayingAreasMandatory" Enabled="false" ErrorMessage="Please select the number of Playing Areas" Text="&nbsp;" ClientValidationFunction="ValidatePlayingAreasList" runat="server" />
                    <br />
                    <asp:ValidationSummary ID="CompetitionValidationSummary" runat="server" />

                    <asp:Button ID="AllocateTeamsToGroups" Text="Allocate Teams To Groups" OnClick="AllocateTeamsToGroups_Click" CssClass="btn btn-default" runat="server" />
                </asp:Panel>
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr>
            <td style="vertical-align:top;">
                No. Fixtures:
            </td>
            <td>
                <asp:Label ID="NoFixturesInCompetition" runat="server" />
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr>
            <td style="vertical-align:top;">
                &nbsp;
            </td>
            <td style="vertical-align:top;">
                <asp:Button ID="ReAllocateTeamsIntoNewGroups" Text="Reallocate Teams Into New Group(s)" OnClick="ReAllocateTeamsIntoNewGroups_Click" CssClass="btn btn-default" Visible="false" Runat="server" />
                <br />
                <asp:HyperLink ID="ReplaceATeamLink" Text="Replace a Team In a Competition >>" runat="server" />
                <br />
                <asp:HyperLink ID="SwapTeamsBetweenGroupsLink" Text="Swap Teams Between Groups >>" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;">&nbsp;</td>
            <td>
               <asp:DataList ID="GroupsDataList" OnItemDataBound="GroupsDataList_ItemDataBound" runat="server">
                <ItemTemplate>
                    <h4><asp:Label ID="GroupName" Font-Size="Small" Font-Bold="true" runat="server" /></h4>
                    <asp:Label ID="RegistrationStatus" runat="server" />&nbsp;&nbsp;
                    <asp:HyperLink ID="GroupEditLink" Text="Edit Group >>" runat="server" />
                    <asp:DataList ID="TeamsListForGroup" BorderStyle="Solid" BorderColor="Black" BorderWidth="1" CellPadding="2" ItemStyle-Width="400" RepeatColumns="2" OnItemDataBound="TeamsListForGroup_ItemDataBound" runat="server">
                        <ItemTemplate>
                            <asp:Table ID="ColourTable" runat="server">
                                <asp:TableRow ID="ColourTableRow" Height="15" runat="server">
                                    <asp:TableCell ID="ClubAndTeamNameCell" Width="350" Height="15" runat="server">
					                    <asp:HyperLink ID="RequestDeleteLink" runat="server">
						                    <asp:Image ID="RequestDeleteLinkImage" ImageUrl="~/Images/Icons/delete.jpg" BorderWidth=0 runat="server" />
					                    </asp:HyperLink>
                                        &nbsp;
                                        <asp:Label ID="ClubNameLabel" Font-Bold="true" runat="server" />&nbsp;-&nbsp;<asp:Label ID="TeamNameLabel" runat="server" />
                                    </asp:TableCell>
                                    <asp:TableCell ID="ColourPrimaryCell" Text="&nbsp;" Width="20" Height="15" BorderStyle="Solid" BorderWidth="1" BorderColor="Black" runat="server"></asp:TableCell>
                                    <asp:TableCell ID="ColourSecondaryCell" Text="&nbsp;" Width="20" Height="15" BorderStyle="Solid" BorderWidth="1" BorderColor="Black" runat="server"></asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </ItemTemplate>
                    </asp:DataList>                  
                </ItemTemplate>

                </asp:DataList>
                <br />
                <asp:Button ID="GenerateFixturesButton" OnClick="GenerateFixtureButton_Click" CssClass="btn btn-default" Visible="false" runat="server" /><br />
                <br />

      


            </td>
        </tr>
        </asp:Panel>

     </table>

    </asp:Panel>
    </div>
</asp:Content>
