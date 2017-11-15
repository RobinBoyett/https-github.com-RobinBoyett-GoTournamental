<%@ Page Title="Club" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ClubsInvitedForm.aspx.cs" Inherits="GoTournamental.UI.Planner.ClubsInvitedForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="ClubsInvitedFormTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						
    <h3>Clubs Invited</h3>

    <asp:Panel ID="ClubsInvitedFormPanel" runat="server">
    <table style="width:1250px;">
        <tr>
            <td colspan="5">
                <table style="border-collapse: separate; border-spacing: 0px;">
                    <tr>
                        <td style="width:264px;"><b>Club Name</b></td>
                        <td style="width:104px;"><b>Unique ID</b></td>
                        <td style="width:144px;"><b>Contact Name</b></td>
                        <td style="width:144px;"><b>Telephone</b></td>
                        <td style="width:204px;"><b>Email</b></td>
                        <td style="width:54px;"><b>Invite</b></td>
                        <td style="width:144px;"><b>Attendance</b></td>
                   </tr>
                </table>
                <table style="border-collapse: separate; border-spacing: 0px;">
                    <tr>
                        <td style="width:264px;"><b><asp:Label ID="HostClubName" runat="server" /></b></td>
                        <td style="width:104px;">N/A</td>
                        <td style="width:144px;"><asp:Label ID="HostClubContactName" runat="server" /></td>
                        <td style="width:144px;"><asp:Label ID="HostClubContactTelephone" runat="server" /></td>
                        <td style="width:204px;"><asp:Label ID="HostClubContactEmail" runat="server" /></td>
                        <td style="width:54px;">N/A</td>
                        <td style="width:144px;"><b>Host Club</b></td>
                    </tr>
                </table>

                <asp:GridView ID="ClubsInvitedGridView" OnRowDataBound="ClubsInvitedGridView_RowDataBound" OnRowEditing="ClubsInvitedGridView_RowEditing" 
                    OnRowUpdating="ClubsInvitedGridView_RowUpdating" OnRowCancelingEdit="ClubsInvitedGridView_RowCancelingEdit" GridLines="None" EmptyDataText="No clubs found" runat="server" AutoGenerateColumns="False">
		        <Columns>
			        <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top">
				        <ItemTemplate>
					        <asp:HyperLink ID="LinkToClubEdit" ForeColor="Black" Font-Size="Small" Width="260" runat="server" />
				        </ItemTemplate>
			        </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="100" ItemStyle-Font-Size="Small" />
                    <asp:BoundField ItemStyle-Width="150" ItemStyle-Font-Size="Small" />
                    <asp:BoundField ItemStyle-Width="140" ItemStyle-Font-Size="Small" />
			        <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top">
				        <ItemTemplate>
					        <asp:HyperLink ID="ContactEmail" Font-Size="Small" Width="200" runat="server" />
				        </ItemTemplate>
			        </asp:TemplateField>
 			        <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top">
				        <ItemTemplate>
					        <asp:HyperLink ID="InviteEmail" Target="_blank" Width="50" runat="server">
						        <asp:Image ID="MailToImage" ImageUrl="~/Images/Icons/mailto.gif" BorderWidth=0 runat=server />
					        </asp:HyperLink>
				        </ItemTemplate>
			        </asp:TemplateField> 
			        <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" ItemStyle-Width="200">
				        <ItemTemplate>
					        <asp:Label ID="AttendanceLabel" runat="server" />
				        </ItemTemplate>			
				        <EditItemTemplate>
					        <asp:HiddenField ID="ClubIDHidden" runat="server" />
					        <asp:DropDownList id="AttendanceTypesList" runat="server" AppendDataBoundItems="true" >
					            <asp:ListItem Value="0">Select</asp:ListItem>			
					        </asp:DropDownList>
				        </EditItemTemplate>
			        </asp:TemplateField>
 			        <asp:CommandField ShowHeader="false" ShowCancelButton="true" ShowEditButton="true" UpdateText="Save" EditText="Edit " ItemStyle-VerticalAlign="Top" ItemStyle-Width="70"/>                                                                       		
                </Columns>
                </asp:GridView>

            </td>
        </tr>
        <tr><td colspan="5">&nbsp;</td></tr>
        <tr><td colspan="5">&nbsp;</td></tr>
        <tr><td colspan="5"><b>Add Club</b>&nbsp;&nbsp;or &nbsp;<asp:HyperLink ID="ImportClubsLink" Text="import clubs from Excel" runat="server" /></td></tr>
        <tr>
            <td>Club Name</td>
            <td colspan="2">Contact Name</td>
            <td>Telephone</td>
            <td>Email</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="ClubName" Width="250" Height="26" runat="server" />
				<ajaxToolkit:TextBoxWatermarkExtender ID="ClubNameWatermark" runat="server" TargetControlID="ClubName" WatermarkText="e.g. High Weald" />
            </td>
            <td>
                <asp:TextBox ID="ClubContactFirstName" Width="120" Height="26" runat="server" />
				<ajaxToolkit:TextBoxWatermarkExtender ID="ClubContactFirstNameWatermark" runat="server" TargetControlID="ClubContactFirstName" WatermarkText="e.g. Brian" />
            </td>           
            <td>
                <asp:TextBox ID="ClubContactLastName" Width="150" Height="26" runat="server" />
				<ajaxToolkit:TextBoxWatermarkExtender ID="ClubContactLastNameWatermark" runat="server" TargetControlID="ClubContactLastName" WatermarkText="e.g. Clough" />
            </td>
            <td><asp:TextBox ID="ClubContactTelephoneNumber" Width="130" Height="26" runat="server" /></td>
            <td>
                <asp:TextBox ID="ClubContactEmail" Width="250" Height="26" runat="server" />
                <asp:Button ID="SaveClubButton" Text="Save" OnClick="SaveButton_Click" runat="server" />
            </td>
        </tr>

    </table>
   

    </asp:Panel>
    </div>
</asp:Content>
