<%@ Page Title="About GoTournamental" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ErrorView.aspx.cs" Inherits="GoTournamental.UI.Organiser.ErrorView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <asp:Panel ID="ErrorViewPanel" runat="server">
  						
    <div class="row">
        <div class="col-md-12">

            <asp:HyperLink ID="BackToErrorsList" Text="<< Back To List" NavigateUrl="ErrorsList.aspx" runat="server" />
	        <asp:Panel id="Panel1" runat="server">
	        <table style="width:1000px; border-collapse: separate; border-spacing: 5px;">
		        <tr>
			        <td class="crippsFormLabel" style="width:150px;">Exception ID</td>
			        <td class="crippsFormElement"><asp:Label ID="ExceptionIDLabel" runat="server" /></td>
		        </tr>
		        <tr>
			        <td class="crippsFormLabel">User</td>
			        <td class="crippsFormElement">
                        <asp:Label ID="User" runat="server" />
				        <asp:HyperLink ID="MailToLink" runat="server">
					        <asp:Image IID="MailToLinkImage" ImageUrl="~/Images/Icons/mailto.gif" BorderWidth=0 runat="server" />
				        </asp:HyperLink>
			        </td>
		        </tr>
		        <tr>
			        <td class="crippsFormLabel" style="vertical-align:top;">Logged Date</td>
			        <td class="crippsFormElement"><asp:Label ID="LoggedDate" runat="server" /></td>
		        </tr>
		        <tr>
			        <td class="crippsFormLabel" style="vertical-align:top;">Type Name</td>
			        <td class="crippsFormElement"><asp:Label ID="TypeName" runat="server" /></td>
		        </tr>
		        <tr>
			        <td class="crippsFormLabel" style="vertical-align:top;">Message</td>
			        <td class="crippsFormElement"><asp:Label ID="Message" runat="server" /></td>
		        </tr>
		        <tr>
			        <td class="crippsFormLabel" style="vertical-align:top;">Stack Trace</td>
			        <td class="crippsFormElement"><asp:Label ID="StackTrace" runat="server" /></td>
		        </tr>
		        <tr>
			        <td>&nbsp;</td>
			        <td class="crippsFormElement"><asp:Button ID="DeleteButton" Text="Delete" OnClick="DeleteButton_Click" runat="server" /></td>
		        </tr>

	        </table>	
	        </asp:Panel>	
           
        </div>
    </div>

    </asp:Panel>
    </div>
</asp:Content>
