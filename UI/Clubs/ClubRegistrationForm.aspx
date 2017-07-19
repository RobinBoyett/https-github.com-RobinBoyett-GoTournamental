<%@ Page Title="Club Registration Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ClubRegistrationForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.ClubRegistrationForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="ClubRegistrationFormTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						
    
    <asp:Panel ID="ErrorMessagePanel" Visible="false" runat="server">
        The URL you have used has not been recognised. Have you used the correct and full address you received in your registration email?
    </asp:Panel>    
    
    <asp:Panel ID="ConfirmationMessagePanel" Visible="false" runat="server">
        Thank you for registering
    </asp:Panel>     
     
    <asp:Panel ID="ClubRegistrationFormPanel" Visible="false" runat="server">
    <table style="width:1250px;">
        <tr>
            <td>

                <table style="width:750px;">
                    <tr>
                        <td style="width:175px; line-height:16px;"><h4><asp:Label ID="FormTitle" runat="server" /></h4></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:150px; line-height:16px;">
                            Club Name:
                        </td>
                        <td style="width:600px;">
                            <asp:HiddenField ID="ClubIDHidden" runat="server" />
                            <asp:Label ID="ClubName" Font-Bold="true" runat="server" />
                        </td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td></tr>

                    <asp:Panel ID="SecuredPanel" Visible="false" runat="server">
                    <tr>
                        <td style="line-height:16px;">
                             Club Colours:<div style="color:red; display:inline; line-height:2;">*</div>
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
                        <td style="vertical-align:top;">
                            English County FA:
                        </td>
                        <td>
                            <asp:DropDownList ID="Affiliation" AppendDataBoundItems="true" runat="server">
	                            <asp:ListItem Value="0">Select</asp:ListItem>                      
                            </asp:DropDownList>&nbsp;&nbsp;
                            Affiliation No.
                            <asp:TextBox ID="AffiliationNumber" Width="80" runat="server" />
                        </td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr>
                        <td style="line-height:16px;">
                            Contact Type:
                        </td>
                        <td style="width:1100px;">
                            <asp:DropDownList ID="ContactType" AppendDataBoundItems="true" runat="server">
					            <asp:ListItem Value="0">Select</asp:ListItem>              
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="line-height:16px;">
                            Contact Name:
                        </td>
                        <td>
                            <asp:HiddenField ID="ContactIDHidden" runat="server" />
                            <asp:TextBox ID="FirstName" Width="120" Height="26" runat="server" />
                            <asp:TextBox ID="LastName" Width="150" Height="26" runat="server" />
				            <ajaxToolkit:TextBoxWatermarkExtender ID="FirstNameWatermark" runat="server" TargetControlID="FirstName" WatermarkText="e.g. Gordon" />
 				            <ajaxToolkit:TextBoxWatermarkExtender ID="LastNameWatermark" runat="server" TargetControlID="LastName" WatermarkText="e.g. Strachan" />              																		 
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top;">
                            Telephone Number:
                        </td>
                        <td>
                            <asp:TextBox ID="TelephoneNumber" Width="150" Height="26" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top;">
                            Email:
                        </td>
                        <td>
                            <asp:TextBox ID="Email" Width="400" Height="26" runat="server" />
                        </td>
                    </tr>             
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                           <asp:Button ID="SaveClubButton" Text="Save" OnClick="SaveClubButton_Click" runat="server" />
                           &nbsp;&nbsp;See how to register your teams&nbsp;<a href="https://www.youtube.com/watch?v=HErov9aH1j8" target="_blank"><asp:Image id="Image5" ImageUrl="~/Images/Icons/youtube.png" Height="14" Width="20" runat="server" /></a>
                           <br />
                        </td>
                    </tr>
                    </asp:Panel>
                </table>
            </td>
            <td style="width:50px;">&nbsp;</td>
            <td style="vertical-align:top;">
                <asp:Panel ID="CompetitionsListPanel" Visible="false" runat="server">
                <br /><br />
                <h4 style="font-size:small; font-weight:bold;">Competitions / Age Bands</h4>
	            <asp:GridView id="CompetitionsListGridView" OnRowDataBound="CompetitionsListGridView_RowDataBound" Font-Size="12px" BorderStyle="Solid" BorderColor="Blue" BorderWidth="1" runat="server" GridLines="None" AutoGenerateColumns="False">
		            <Columns>
                    <asp:BoundField HeaderText="Band" ItemStyle-Width="130" />
                    <asp:BoundField HeaderText="Time" ItemStyle-Width="200" />
                    <asp:BoundField HeaderText="Session" ItemStyle-Width="100" />
		            </Columns>
	            </asp:GridView>
                </asp:Panel>


            </td>
        </tr>
    </table>


    <br />
    <asp:Panel ID="TeamsRegistrationPanel" Visible="false" runat="server">
    <b>Registered Teams</b>
    <table style="width:1250px;">
        <tr>
            <td colspan="6">
                <asp:DataList ID="TeamsListForClub" OnItemDataBound="TeamsListForClub_ItemDataBound" runat="server">
                    <ItemTemplate>
                        <asp:Label ID="CompetitionName" Font-Size="Small" Width="130" runat="server" />
                        <asp:HyperLink ID="LinkToTeamEdit" ForeColor="Black" Font-Size="Small" Width="260" runat="server" />
                        <asp:Label ID="ContactName" Font-Size="Small" Width="140" runat="server" />
                        <asp:Label ID="ContactTelephone" Font-Size="Small" Width="140" runat="server" />
                        <asp:HyperLink ID="ContactEmail" Font-Size="Small" Width="200" runat="server" />
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr><td colspan="6">&nbsp;</td></tr>
        <tr><td colspan="6"><b>Add Team</b></td></tr>
        <tr>
            <td>Competition</td>
            <td>Team Name</td>
            <td colspan="2">Contact Name</td>
            <td>Telephone</td>
            <td>Email</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="AgeBands" AppendDataBoundItems="true" Height="26" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>  
            </td>
            <td>
                <asp:TextBox ID="TeamName" Width="250" Height="26" runat="server" />
				<ajaxToolkit:TextBoxWatermarkExtender ID="TeamNameWatermark" runat="server" TargetControlID="TeamName" WatermarkText="e.g. Wanderers" />
            </td>
            <td>
                <asp:TextBox ID="TeamContactFirstName" Width="120" Height="26" runat="server" />
				<ajaxToolkit:TextBoxWatermarkExtender ID="TeamContactFirstNameWatermark" runat="server" TargetControlID="TeamContactFirstName" WatermarkText="e.g. Chris" />
            </td>           
            <td>
                <asp:TextBox ID="TeamContactLastName" Width="150" Height="26" runat="server" />
				<ajaxToolkit:TextBoxWatermarkExtender ID="TeamContactLastNameWatermark" runat="server" TargetControlID="TeamContactLastName" WatermarkText="e.g. Coleman" />
            </td>
            <td><asp:TextBox ID="TeamContactTelephoneNumber" Width="130" Height="26" runat="server" /></td>
            <td>
                <asp:TextBox ID="TeamContactEmail" Width="250" Height="26" runat="server" />
                <asp:Button ID="SaveTeamButton" Text="Save" OnClick="SaveTeamButton_Click" runat="server" />
            </td>
        </tr>

    </table>
    </asp:Panel>

    </asp:Panel>
    </div>
</asp:Content>
