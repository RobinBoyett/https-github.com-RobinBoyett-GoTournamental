<%@ Page Title="Age Bands" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="CompetitionsList.aspx.cs" Inherits="GoTournamental.UI.Organiser.CompetitionsList" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="CompetitionsListTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						
    <h3>Age Bands</h3>
    <asp:Panel ID="CompetitionsListPanel" runat="server">
    <asp:HyperLink ID="LinkToCompetitionsAdd" Text="[Add Age Band]" Visible="false" Font-Size="Smaller" runat="server" /><br /><br />
	<asp:GridView id="CompetitionsListGridView" OnRowDataBound="CompetitionsListGridView_RowDataBound" runat="server" GridLines="None" AutoGenerateColumns="False">
		<Columns>
		<asp:TemplateField HeaderText="Age Band" ItemStyle-Width="200">
			<ItemTemplate>                        
                <asp:HyperLink ID="CompetitionViewLink" runat="server" />
			</ItemTemplate>
		</asp:TemplateField>
        <asp:BoundField HeaderText="Time" ItemStyle-Width="150" />
        <asp:BoundField HeaderText="Teams Attending" ItemStyle-Width="130" />
        <asp:BoundField HeaderText="Teams Registered" ItemStyle-Width="130" />
        <asp:BoundField HeaderText="Groups" ItemStyle-Width="100" />
        <asp:BoundField HeaderText="Pitches" ItemStyle-Width="100" />
		</Columns>
	</asp:GridView>
    </asp:Panel>
    </div>
</asp:Content>