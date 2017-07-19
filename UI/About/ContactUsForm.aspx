<%@ Page Title="Pre-Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ContactUsForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.ContactUsForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3>Contact Us</h3>

    <div class="row">
        <div class="col-md-10">

            <asp:Panel ID="ContactUsFormPanel" Visible="false" runat="server">
            <table style="width:700px;">
                <asp:Panel ID="WelcomeTextPanel" Visible="false" runat="server">
                <tr>
                    <td colspan="2">
                        Welcome to GoTournamental ! We are now taking pre-registration enquires from clubs/individuals who would like to either find out more about our web based Tournament planner or to take part in our pre-launch trials. 
                        Simply fill out the enquiry form below and we’ll be in touch with you. 
                    </td>
                </tr>
                <tr>
                    <td style="width:175px; line-height:16px;">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                </asp:Panel>
                <tr>
                    <td style="line-height:16px;">
                        Full Name:<div style="color:red; display:inline; line-height:2;">*</div>
                    </td>
                    <td>
                        <asp:TextBox ID="FirstName" Width="150" Height="26" MaxLength="50" runat="server" />
                        <asp:RequiredFieldValidator ID="FirstNameMandatory" ErrorMessage="Please enter a First Name" Text="<" ForeColor="Crimson" ControlToValidate="FirstName" SetFocusOnError="true" Font-Size="12px" runat="server" />				
                        <asp:TextBox ID="LastName" Width="200" Height="26" MaxLength="50" runat="server" />
                        <asp:RequiredFieldValidator ID="LastNameMandatory" ErrorMessage="Please enter a Last Name" Text="<" ForeColor="Crimson" ControlToValidate="LastName" SetFocusOnError="true" Font-Size="12px" runat="server" />				
				        <ajaxToolkit:TextBoxWatermarkExtender ID="FirstNameWatermark" runat="server" TargetControlID="FirstName" WatermarkText="First Name" />
 				        <ajaxToolkit:TextBoxWatermarkExtender ID="LastNameWatermark" runat="server" TargetControlID="LastName" WatermarkText="Last Name" />              																		 
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        Email:<div style="color:red; display:inline; line-height:2;">*</div>
                    </td>
                    <td>
                        <asp:TextBox ID="Email" Width="400" MaxLength="100" runat="server" />
                        <asp:RequiredFieldValidator ID="EmailMandatory" ErrorMessage="Please enter your Email address" Text="<" ForeColor="Crimson" ControlToValidate="Email" SetFocusOnError="true" Font-Size="12px" runat="server" />				
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        Organisation:<div style="color:red; display:inline; line-height:2;">*</div>
                    </td>
                    <td>
                        <asp:TextBox ID="Organisation" Width="400" MaxLength="100" runat="server" />
 				        <ajaxToolkit:TextBoxWatermarkExtender ID="OrganisationWatermark" runat="server" TargetControlID="Organisation" WatermarkText="Club Name or Organisation" />
                        <asp:RequiredFieldValidator ID="OrganisationMandatory" ErrorMessage="Please enter an Organisation" Text="<" ForeColor="Crimson" ControlToValidate="Organisation" SetFocusOnError="true" Font-Size="12px" runat="server" />				
                   </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        Telephone Number:
                    </td>
                    <td>
                        <asp:TextBox ID="TelephoneNumber" Width="150" MaxLength="50" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Sport:<div style="color:red; display:inline; line-height:2;">*</div>
                    </td>
                    <td>
                        <asp:DropDownList ID="TournamentType" AppendDataBoundItems="true" runat="server">
					        <asp:ListItem Value="0">Select Sport</asp:ListItem>              
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="TournamentTypeMandatory" ErrorMessage="Please select a Sport" Text="<" ForeColor="Crimson" ControlToValidate="TournamentType" SetFocusOnError="true" Font-Size="12px" runat="server" />				
                    </td>
                </tr> 
                <tr>
                    <td style="vertical-align:top;">
                        Additional Information:
                    </td>
                    <td>
                        <asp:TextBox ID="AdditionalInformation" Width="500" TextMode="MultiLine" Height="100" MaxLength="2000" runat="server" />
                    </td>
                </tr>
                <tr><td colspan="2">&nbsp;</td></tr>
                <tr><td colspan="2">&nbsp;<div style="color:red; display:inline; line-height:2;">*</div> fields marked with an asterisk are mandatory</td></tr>
                <tr><td colspan="2"><asp:ValidationSummary ID="ContactUsFormValidationSummary" runat="server" /></td></tr>
                <tr><td colspan="2">&nbsp;</td></tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:HiddenField ID="ContactUsIDHidden" runat="server" />
                        <asp:Button ID="SaveButton" Text="Save" OnClick="SaveButton_Click" runat="server" />&nbsp;
                        <asp:Button ID="DeleteButton" Text="Delete" OnClick="DeleteButton_Click" Visible="false" runat="server" />
                        <br />
                    </td>
                </tr>

             </table>


            </asp:Panel>
   
            <asp:Panel ID="ContactUsMessagePanel" Visible="false" runat="server">
                Thank you for your enquiry, we'll contact you as soon as we can.
            </asp:Panel>


        </div>
        <div class="col-md-2" style="text-align:right;">
            <Advertisements:AdvertPanel id="Advert120x600" runat="server" />
        </div>
    </div>

    </div>
</asp:Content>
