<%@ Page Title="Club" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ClubForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.ClubForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="ClubFormTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						
    <br /> 
    <asp:Panel ID="ClubFormPanel" runat="server">
    <table style="width:1250px;">
        <tr>
            <td style="width:175px; line-height:16px;"><h4><asp:Label ID="FormTitle" runat="server" /></h4></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width:150px; line-height:16px;">
                Club Name:<div style="color:red; display:inline; line-height:2;">*</div>
            </td>
            <td style="width:1100px;">
                <asp:HiddenField ID="ClubIDHidden" runat="server" />
                <asp:TextBox ID="ClubName" Width="400" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="line-height:16px;">
                Attendance
            </td>
            <td>
                <asp:DropDownList ID="AttendanceType" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="line-height:16px;">
                 Club Colours:
            </td>
            <td>
               <asp:DropDownList ID="ClubColourPrimary" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="">Primary Colour&nbsp;</asp:ListItem>                      
               </asp:DropDownList>
               <asp:DropDownList ID="ClubColourSecondary" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="">Secondary Colour</asp:ListItem>                      
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="line-height:16px; vertical-align:top;">
                Primary Contact
            </td>
            <td>
                <asp:HiddenField ID="PrimaryContactID" runat="server" />

                <asp:Button ID="AddContactButton" Text="Add Contact" OnClick="AddContactButton_Click" Visible="false" runat="server" />


                <asp:Label ID="PrimaryContact" runat="server" />&nbsp;&nbsp;&nbsp;<asp:Button ID="EditContactButton" Text="Edit" OnClick="EditContactButton_Click" Visible="false" runat="server" />
                <br />
                <asp:Label ID="PrimaryContactPhone" Visible="false" runat="server" /><br />
                <asp:Label ID="PrimaryContactEmail" Visible="false" runat="server" />
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
