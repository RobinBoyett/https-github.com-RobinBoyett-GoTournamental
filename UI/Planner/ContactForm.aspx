<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ContactForm.aspx.cs" Inherits="GoTournamental.UI.Planner.ContactForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="ContactFormTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						
    <br />
    <asp:Panel ID="ContactFormPanel" runat="server">
    <table style="width:1250px;">
        <tr>
            <td style="width:175px; line-height:16px;"><h4><asp:Label ID="FormTitle" runat="server" /></h4></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="line-height:16px;">
                Contact Type:<div style="color:red; display:inline; line-height:2;">*</div>
            </td>
            <td style="width:1100px;">
                <asp:HiddenField ID="ContactIDHidden" runat="server" />
                <asp:DropDownList ID="ContactType" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="line-height:16px;">
                Contact Name:<div style="color:red; display:inline; line-height:2;">*</div>
            </td>
            <td>
                <asp:TextBox ID="FirstName" Width="120" Height="26" runat="server" />
                <asp:TextBox ID="LastName" Width="150" Height="26" runat="server" />
				<ajaxToolkit:TextBoxWatermarkExtender ID="FirstNameWatermark" runat="server" TargetControlID="FirstName" WatermarkText="e.g. Roy" />
 				<ajaxToolkit:TextBoxWatermarkExtender ID="LastNameWatermark" runat="server" TargetControlID="LastName" WatermarkText="e.g. Hodgson" />              																		 
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;">
                Telephone Number:
            </td>
            <td>
                <asp:TextBox ID="TelephoneNumber" Width="150" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;">
                Email:
            </td>
            <td>
                <asp:TextBox ID="Email" Width="400" runat="server" />
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
