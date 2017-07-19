<%@ Page Title="About GoTournamental" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Email.aspx.cs" Inherits="GoTournamental.UI.Administration.Email" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <asp:Panel ID="StandardEmailsPanel" runat="server">
    						
    <div class="row">
        <div class="col-md-9">
            <h3>GT Standard Emails</h3>

	        <table>
		        <tr>
                    <td>
                        <asp:DropDownList ID="TournamentsDropDown" AppendDataBoundItems="true" runat="server">
                            <asp:ListItem Value="0">Select</asp:ListItem>              
                        </asp:DropDownList> 
                    </td>
			        <td>	
                        <asp:Button ID="EmailTest" Text="Email Test" OnClick="EmailTest_Click" runat="server" />
			        </td>
	   	        </tr>
	        </table>

        </div>
        <div class="col-md-3">

        </div>

    </div>

    </asp:Panel>
    </div>
</asp:Content>
