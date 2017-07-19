<%@ Page Title="Sponsor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SponsorForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.SponsorForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="SponsorFormTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
    <br />
    <asp:Panel ID="SponsorFormPanel" runat="server">
    <table style="width:1250px;">
       <tr>
           <td style="width:175px; line-height:16px;"><h4><asp:Label ID="FormTitle" runat="server" /></h4></td>
           <td>&nbsp;</td>
       </tr>
       <tr>
            <td style="line-height:16px;">
                Sponsor Name:<div style="color:red; display:inline; line-height:2;">*</div>
            </td>
            <td style="width:1100px;">
                <asp:HiddenField ID="SponsorIDHidden" runat="server" />
                <asp:TextBox ID="SponsorName" Width="400" Height="26" runat="server" />
				<ajaxToolkit:TextBoxWatermarkExtender ID="SponsorNameWatermark" runat="server" TargetControlID="SponsorName" WatermarkText="e.g. Coca Cola" />																		 
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;">
                Sponsor's URL:
            </td>
            <td>
                <asp:TextBox ID="SponsorURL" Font-Size="14px" Width="600" Height="80" TextMode="MultiLine" runat="server" />
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
