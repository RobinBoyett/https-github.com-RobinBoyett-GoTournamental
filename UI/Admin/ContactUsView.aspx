<%@ Page Title="Pre-Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ContactUsView.aspx.cs" Inherits="GoTournamental.UI.ContactUsView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3>Contact Us Entry</h3>

    <div class="row">
        <div class="col-md-10">

            <asp:Panel ID="ContactUsViewPanel" runat="server">
            <table style="width:700px;">
                <tr>
                    <td style="line-height:16px;">
                        Full Name:
                    </td>
                    <td>
                        <asp:Label ID="FullName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        Contact Date:
                    </td>
                    <td>
                        <asp:Label ID="ContactDate" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        Email:
                    </td>
                    <td>
                        <asp:Label ID="Email" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        Organisation:
                    </td>
                    <td>
                        <asp:Label ID="Organisation" runat="server" />
                   </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        Telephone Number:
                    </td>
                    <td>
                        <asp:Label ID="TelephoneNumber" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Sport:
                    </td>
                    <td>
                        <asp:Label ID="TournamentType" runat="server" />
                    </td>
                </tr> 
                <tr>
                    <td style="vertical-align:top;">
                        Additional Information:
                    </td>
                    <td>
                        <asp:Label ID="AdditionalInformation" Width="500" TextMode="MultiLine" runat="server" />
                    </td>
                </tr>
                <tr><td colspan="2">&nbsp;</td></tr>
             </table>


            </asp:Panel>

        </div>
        <div class="col-md-2" style="text-align:right;">&nbsp;</div>
    </div>

    </div>
</asp:Content>
