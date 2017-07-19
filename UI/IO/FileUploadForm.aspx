<%@ Page Title="File Upload Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="FileUploadForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.FileUploadForm" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="FileUploadFormTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						
    <br />

    <div class="row">
        <div class="col-md-10">
            <asp:Panel ID="FileUploadPanel" Width="1100" runat="server">

		    <table style="width:800px; border-collapse: separate; border-spacing: 5px;">
                <asp:Panel ID="UploadControlsPanel" runat="server" >
                <tr>
				    <td style="width:200px; vertical-align:top;">Upload Type:</td>
				    <td style="width:600px; vertical-align:top;">
					    <asp:DropDownList ID="UploadType" AppendDataBoundItems="true" OnSelectedIndexChanged="UploadType_SelectedIndexChanged" AutoPostBack="true" runat="server">
						    <asp:ListItem Value="">Please Select</asp:ListItem>
                        </asp:DropDownList>
				    </td>
			    </tr>
                <asp:Panel ID="GraphicsOnlyPanel" Visible="false" runat="server">
                <tr>
                    <td colspan="2">
                        This form will accept uploaded graphics with .jpeg, .png and .gif file extensions. Select the required upload, and please ensure that your image
                        has the correct dimensions - the file will be rescaled automatically, but this may skew images sized incorrectly.
                    </td>
                </tr>
                <tr><td colspan="2">&nbsp;</td></tr>
                </asp:Panel>
                <asp:Panel ID="DocumentsOnlyPanel" Visible="false" runat="server">
                <tr>
                    <td colspan="2">
                        This form will accept uploaded documents with a .pdf file extension only.
                    </td>
                </tr>
                <tr><td colspan="2">&nbsp;</td></tr>
                <tr>
 				    <td style="vertical-align:top;">Document Type:<div style="color:red; display:inline; line-height:2;">*</div></td>
                    <td>
					    <asp:DropDownList ID="DocumentType" AppendDataBoundItems="true" runat="server">
						    <asp:ListItem Value="">Please Select</asp:ListItem>
                        </asp:DropDownList>	
                        <asp:RequiredFieldValidator ID="DocumentTypeValidator" runat="server" ControlToValidate="DocumentType" ErrorMessage="You haven't selected a document type" />	                                    	            
                    </td>
                </tr>
                </asp:Panel>

                <asp:Panel ID="AdvertsOnlyPanel" Visible="false" runat="server">
                <tr>
 				    <td style="vertical-align:top;">Associated Sponsor:<div style="color:red; display:inline; line-height:2;">*</div></td>
                    <td>
					    <asp:DropDownList ID="AssociatedSponsor" AppendDataBoundItems="true" runat="server">
						    <asp:ListItem Value="">Please Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="AssociatedSponsorValidator" runat="server" ControlToValidate="AssociatedSponsor" ErrorMessage="You haven't selected an associated sponsor" />	            
                    </td>
                </tr>
                <tr>
 				    <td style="vertical-align:top;">Dimensions:<div style="color:red; display:inline; line-height:2;">*</div></td>
                    <td>
					    <asp:DropDownList ID="AdvertType" AppendDataBoundItems="true" runat="server">
						    <asp:ListItem Value="">Please Select</asp:ListItem>
                        </asp:DropDownList>	
                        <asp:RequiredFieldValidator ID="AdvertTypeValidator" runat="server" ControlToValidate="AdvertType" ErrorMessage="You haven't selected image dimensions" />	                                    	            
                    </td>
                </tr>
                </asp:Panel>
                <tr>
 				    <td style="vertical-align:top;">File:<div style="color:red; display:inline; line-height:2;">*</div></td>
                    <td >
		                <asp:FileUpload ID="FileUpload" Width="500" Visible="false" runat="server" />
                        <asp:RequiredFieldValidator ID="FileRequiredValidator" runat="server" ControlToValidate="FileUpload" ErrorMessage="You haven't selected a file to upload" />
                    </td>
                </tr>
                <tr>
 				    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="UploadFileButton" Text="Upload File" Visible="false" OnClick="UploadFileButton_Click" runat="server" />
                    </td>
                </tr>

                </asp:Panel>
                <asp:Panel ID="GraphicFileToReviewPanel" Visible="false" runat="server">
                <tr>
				    <td style="vertical-align:top;">Your Graphic</td>
				    <td style="vertical-align:top;">
                        <asp:HiddenField ID="GraphicFileName" runat="server" />
                        <asp:HiddenField ID="GraphicFileType" runat="server" />
                        <asp:HiddenField ID="AdvertTypeHidden" runat="server" />
                        <asp:HiddenField ID="AssociatedSponsorHidden" runat="server" />
                        <asp:Image ID="GraphicToReview" BorderStyle="Solid" BorderWidth="1" BorderColor="#FB4F13" runat="server" />
				    </td>
			    </tr>
                <tr>
				    <td>&nbsp;</td>
				    <td style="vertical-align:top;">
                        <asp:Button ID="SaveButton" Text="Save Your Graphic" OnClick="SaveButton_Click" runat="server" />&nbsp;
                        <asp:Button ID="RejectButton" Text="Reject" OnClick="RejectButton_Click" runat="server" /><br /><br />
                        <asp:Label ID="UserMessage" runat="server" /><br />
                        <asp:HyperLink ID="BackToReferrerLink" runat="server" />
				    </td>
			    </tr>
                </asp:Panel>

            </table>

            </asp:Panel>


        </div>
        <div class="col-md-2">
            <Advertisements:AdvertPanel id="Advert120x600" runat="server" />
        </div>
    </div>
    </div>
</asp:Content>


