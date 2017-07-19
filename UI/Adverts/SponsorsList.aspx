<%@ Page Title="Sponsors List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SponsorsList.aspx.cs" Inherits="GoTournamental.UI.Organiser.SponsorsList" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="SponsorsListTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						

    <h3>Official Sponsors</h3>
    <asp:Panel ID="SponsorsListPanel" runat="server">

    <div class="row">
        <div class="col-md-9">
            <asp:HyperLink ID="LinkToSponsorAdd" Text="[Add Sponsor]" Visible="false" Font-Size="Smaller" runat="server" />
            <asp:DataList ID="SponsorsDataList" Width="800" CellPadding="2" RepeatColumns="2" OnItemDataBound="SponsorsDataList_ItemDataBound" runat="server">
                <ItemTemplate>
		        <asp:HyperLink ID="DeleteSponsorLink" Visible="false" runat="server">
			        <asp:Image ID="DeleteIconImage" ImageUrl="~/Images/Icons/Delete.jpg" BorderWidth=0 runat="server" />
		        </asp:HyperLink>
		        <asp:HyperLink ID="EditSponsorLink" Text="[Edit]" Visible="false" runat="server" />&nbsp;
		        <asp:HyperLink ID="AdvertiserLink" Target="_blank" runat="server" />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="col-md-3">
            <Advertisements:AdvertPanel id="Advert300x600" runat="server" />
        </div>
    </div>

    </asp:Panel>
    </div>
</asp:Content>