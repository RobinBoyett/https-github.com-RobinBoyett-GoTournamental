<%@ Page Title="Club" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="TeamForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.TeamForm" %>
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
    <asp:Panel ID="TeamFormPanel" runat="server">
    <table style="width:1250px;">
        <tr>
            <td style="width:175px; line-height:16px;"><h4><asp:Label ID="FormTitle" runat="server" /></h4></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width:150px; line-height:16px;">
                Club Name
            </td>
            <td style="width:1100px;">
                <asp:HiddenField ID="ClubIDHidden" runat="server" />
                <asp:Label ID="ClubName" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="line-height:16px;">
                Team Name:
            </td>
            <td style="width:1100px;">
                <asp:HiddenField ID="TeamIDHidden" runat="server" />
                <asp:TextBox ID="TeamName" Width="400" runat="server" />* If left blank this will default to the competiton / age band name e.g. 'Under 8s'
           </td>
        </tr>
        <tr>
            <td style="line-height:16px; vertical-align:top;">
                Attendance
            </td>
            <td>
                <asp:DropDownList ID="AttendanceType" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>
                <div style="font-size:smaller;">Note: If a team is changed from or to 'Attending' the relevant Groups and Fixtures will need to be re-allocated.</div>
            </td>
        </tr>
        <tr>
            <td style="line-height:18px; vertical-align:top;">
                Competition / Age-Band
            </td>
            <td style="width:1100px;">
                <asp:DropDownList ID="AgeBands" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>               
            </td>
        </tr>
        <tr>
            <td style="line-height:16px; vertical-align:top;">
                Primary Contact
            </td>
            <td>
                <asp:HiddenField ID="PrimaryContactID" runat="server" />
                <asp:LinkButton ID="LinkToContactAdd" OnClick="LinkToContactAdd_Click" Text="[Add Contact]" Visible="false" runat="server" />
                <asp:Label ID="PrimaryContact" runat="server" />&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="LinkToContactEdit" Text="[Edit]" Visible="false" runat="server" /><br />
                <asp:Label ID="PrimaryContactPhone" Visible="false" runat="server" /><br />
                <asp:Label ID="PrimaryContactEmail" Visible="false" runat="server" />
           </td>
        </tr>      
        <tr>
            <td style="line-height:16px;">
                Registered:
            </td>
            <td style="width:1100px;">
                <asp:CheckBox ID="Registered" runat="server" />
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="SaveButton" Text="Save" OnClick="SaveButton_Click" runat="server" /><br />
            </td>
        </tr>

     </table>

    </asp:Panel>
    </div>
</asp:Content>
