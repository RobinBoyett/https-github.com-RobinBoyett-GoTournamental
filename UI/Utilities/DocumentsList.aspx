<%@ Page Title="Documents List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DocumentsList.aspx.cs" Inherits="GoTournamental.UI.Organiser.DocumentsList" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="DocumentsListTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						
    <h3>Tournament Documents</h3>
    <asp:Panel ID="DocumentsListPanel" runat="server">

    <div class="row">
        <div class="col-md-9">
            
            <asp:DataList ID="DocumentsDataList" Width="800" CellPadding="2" RepeatColumns="1" OnItemDataBound="DocumentsDataList_ItemDataBound" runat="server">
                <ItemTemplate>
		        <asp:HyperLink ID="DocumentLink" Target="_blank" runat="server" />
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