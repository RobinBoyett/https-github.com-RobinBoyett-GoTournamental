<%@ Page Title="Sponsors List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="UploadedFilesList.aspx.cs" Inherits="GoTournamental.UI.Organiser.UploadedFilesList" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="UploadedFilesListTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						

    <asp:Panel ID="UploadedFilesListPanel" runat="server">
    <h4><asp:Label ID="UploadedFilesTypeTitle" runat="server" /></h4>

    <div class="row">
        <div class="col-md-9">
            <asp:HyperLink ID="UploadLink" Visible="false" runat="server" />
            <br /><br />
            <asp:DataList id="UploadedImageGallery" OnItemDataBound="UploadedImageGallery_ItemDataBound" RepeatColumns="5" RepeatDirection=Horizontal runat="server" Width="1000">
            <ItemTemplate>
	            <asp:Image ID="UploadedImage" runat="server" /><br>
	            <asp:Label ID="UploadedImageName" runat="server" />		
            </ItemTemplate>		
            </asp:DataList>	

        </div>
        <div class="col-md-3">
            &nbsp;
        </div>
    </div>

    </asp:Panel>
    </div>
</asp:Content>