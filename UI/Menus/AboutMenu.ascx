<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AboutMenu.ascx.cs" Inherits="AboutMenu" %>

<asp:Panel ID="AboutNavigationPanel" runat="server">
<table>
    <tr>
        <td style="width:120px;"><asp:HyperLink ID="LinkToAbout" NavigateUrl="~/UI/About/About" Text="About GT &raquo;" runat="server" /></td>
        <td style="width:120px;"><asp:HyperLink ID="LinkToWhoWeAre" NavigateUrl="~/UI/About/WhoWeAre" Text="Our Story &raquo;" runat="server" /></td>
        <td style="width:160px;"><asp:HyperLink ID="LinkToTerms" NavigateUrl="~/UI/About/Terms" Text="Terms And Conditions &raquo;" runat="server" /></td>
    </tr>
</table>
</asp:Panel>

				




				