<%@ Page Title="Tournament" validateRequest="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="TournamentForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.TournamentForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="TournamentFormTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />
    
    <asp:Panel ID="FeatureUnavailablePanel" Visible="false" runat="server">
        <asp:Label ID="FeatureUnavailableLabel" runat="server" /><br /><br />
        <asp:HyperLink ID="TermsAndConditionsLink" Text="Terms and Conditions" NavigateUrl="~/UI/About/Terms.aspx" runat="server" />
    </asp:Panel>   
    
    						
    <asp:Panel ID="TournamentFormPanel" Visible="false" runat="server">
    <table style="width:1250px;">
        <tr>
            <td style="width:175px; line-height:16px;"><h4><asp:Label ID="FormTitle" runat="server" /></h4></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                Tournament Type:<div style="color:red; display:inline; line-height:2;">*</div>
            </td>
            <td>
                <asp:DropDownList ID="TournamentType" AppendDataBoundItems="true" OnSelectedIndexChanged="TournamentType_SelectedIndexChanged" AutoPostBack="true" runat="server">
					<asp:ListItem Value="0">Select Sport</asp:ListItem>              
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="TournamentTypeMandatory" InitialValue="0" ErrorMessage="Please select a Tournament Type" Text="<" ForeColor="Crimson" ControlToValidate="TournamentType" SetFocusOnError="true" Font-Size="12px" runat="server" />				
            </td>
        </tr> 
        <tr>
            <td style="width:150px; line-height:16px;">
                Host Club Name:<div style="color:red; display:inline; line-height:2;">*</div>
            </td>
            <td style="width:1100px;">
                <asp:HiddenField ID="HostClubIDHidden" runat="server" />
                <asp:TextBox ID="HostClubName" Width="400" Height="26" runat="server" />
                <asp:RequiredFieldValidator ID="HostClubNameMandatory" ErrorMessage="Please enter a Host Club Name" Text="<" ForeColor="Crimson" ControlToValidate="HostClubName" SetFocusOnError="true" Font-Size="12px" runat="server" />				
				<ajaxToolkit:TextBoxWatermarkExtender ID="HostClubNameWatermark" runat="server" TargetControlID="HostClubName" WatermarkText="e.g. Broad Beech Juniors" />																		 
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr>
            <td>
                Tournament Name:<div style="color:red; display:inline; line-height:2;">*</div>
            </td>
            <td>
                <asp:TextBox ID="TournamentName" Width="400" Height="26" runat="server" />
                <asp:RequiredFieldValidator ID="TournamentNameMandatory" ErrorMessage="Please enter a Tournament Name" Text="<" ForeColor="Crimson" ControlToValidate="TournamentName" SetFocusOnError="true" Font-Size="12px" runat="server" />				
				<ajaxToolkit:TextBoxWatermarkExtender ID="TournamentNameWatermark" runat="server" TargetControlID="TournamentName" WatermarkText="e.g. Summer Fiesta 2016" />																		 
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;">
                Date(s):<div style="color:red; display:inline; line-height:2;">*</div>
            </td>
            <td>
                <asp:TextBox ID="TournamentStartDate" Width="90" Height="26" runat="server" />
				<asp:CalendarExtender id="StartDateCalendarExtender" PopupButtonID="CalendarImage1" TargetControlID="TournamentStartDate" Format="dd/MM/yyyy" runat="server" />
				<asp:ImageButton ID="CalendarImage1" ImageUrl="~/Images/Icons/Calendar_scheduleHS.png" CausesValidation="false" runat="server" />

                &nbsp;Start&nbsp;Time&nbsp;
                <asp:DropDownList ID="TournamentStartHour" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="">Hour&nbsp;</asp:ListItem>              
                </asp:DropDownList>
                <asp:DropDownList ID="TournamentStartMinute" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="">Minute&nbsp;</asp:ListItem>              
                </asp:DropDownList>

                <br />

                <asp:TextBox ID="TournamentEndDate" Width="90" Height="26" runat="server" />
				<asp:CalendarExtender id="EndDateCalendarExtender" PopupButtonID="CalendarImage2" TargetControlID="TournamentEndDate" Format="dd/MM/yyyy" runat="server" />
				<asp:ImageButton ID="CalendarImage2" ImageUrl="~/Images/Icons/Calendar_scheduleHS.png" runat="server" />
                <asp:RequiredFieldValidator ID="TournamentStartDateMandatory" ErrorMessage="Please enter a Tournament Start Date" Text="<" ForeColor="Crimson" ControlToValidate="TournamentStartDate" SetFocusOnError="true" Font-Size="12px" runat="server" />				
                (leave blank for single day events)
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr>
            <td>
                Venue:
            </td>
            <td>
                <asp:TextBox ID="TournamentVenue" Width="600" Height="26" runat="server" />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                Postcode:
            </td>
            <td>
                <asp:TextBox ID="TournamentPostcode" Width="100" Height="26" runat="server" /><br />
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;">
                Google Maps URL:
            </td>
            <td>
                <asp:TextBox ID="TournamentGoogleMapsURL" Font-Size="14px" Width="600" Height="80" TextMode="MultiLine" runat="server" />
				<ajaxToolkit:TextBoxWatermarkExtender ID="GoogleMapsURLWatermark" runat="server" TargetControlID="TournamentGoogleMapsURL" 
                    WatermarkText="To use this feature, simply find your venue using Google Maps, click on 'share' and then copy and paste the 'embed maps' iframe hyperlink here." />
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr>
            <td>
                No Pitches:<div style="color:red; display:inline; line-height:2;">*</div>
            </td>
            <td>
                <asp:DropDownList ID="TournamentNoPlayingAreas" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>
                <asp:RangeValidator runat="server" id="TournamentNoPlayingAreasMandatory" type="Integer" minimumvalue="1" MaximumValue="9999" errormessage="Please enter No Pitches" ForeColor="Crimson" ControlToValidate="TournamentNoPlayingAreas" SetFocusOnError="true" Font-Size="12px" />
           </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr>
            <td>
                Fixture Turnaround:<div style="color:red; display:inline; line-height:2;">*</div>
            </td>
            <td>
                <asp:DropDownList ID="FixtureTurnaround" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>
                Minutes
                <asp:RangeValidator runat="server" id="FixtureTurnaroundMandatory" type="Integer" minimumvalue="1" MaximumValue="9999" errormessage="Please enter your default Fixture Turnaround" ForeColor="Crimson" ControlToValidate="FixtureTurnaround" SetFocusOnError="true" Font-Size="12px" />
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
                &nbsp;&nbsp;&nbsp;&nbsp;
                Max Squad Size:&nbsp;
                <asp:DropDownList ID="SquadSize" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Select</asp:ListItem>              
                </asp:DropDownList>
                You will need to select tournament type to activate these
            </td>
        </tr>
        <tr>
            <td>
                Results & Tables:
            </td>
            <td>
                <asp:Dropdownlist id="RotatorDate" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="">Show All Dates</asp:ListItem>              
                </asp:Dropdownlist>
                <asp:DropDownList ID="RotatorSession" AppendDataBoundItems="true" runat="server">
					<asp:ListItem Value="0">Show All Sessions</asp:ListItem>              
                </asp:DropDownList>
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr><td colspan="2">&nbsp;<div style="color:red; display:inline; line-height:2;">*</div> fields marked with an asterisk are mandatory</td></tr>
        <tr><td colspan="2"><asp:ValidationSummary ID="TournamentValidationSummary" runat="server" /></td></tr>
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
