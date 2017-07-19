<%@ Page Title="Contacts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ContactsList.aspx.cs" Inherits="GoTournamental.UI.Organiser.ContactsList" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="ContactsListTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						
    <h3>Contacts Directory</h3>

    <asp:Panel ID="ContactsListPanel" runat="server">
    <asp:HyperLink ID="LinkToContactAdd" Text="[Add Contact]" Visible="false" Font-Size="Smaller" runat="server" />
    <br /><br />
    <asp:GridView ID="ContactsListGridView" OnDataBound="ContactsList_DataBound" OnRowDataBound="ContactsList_RowDataBound" runat="server" GridLines="None" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Name" ItemStyle-Width="200">
                <ItemTemplate>
                    <asp:HyperLink ID="EditContactLink" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Role" ItemStyle-Width="350" ItemStyle-Font-Size="Small" />
            <asp:TemplateField HeaderText="Itinerary" ItemStyle-Width="100">
                <ItemTemplate>
                    <asp:HyperLink ID="LinkToItinary" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Phone" DataField="TelephoneNumber" ItemStyle-Width="130" ItemStyle-Font-Size="Small" />
            <asp:BoundField HeaderText="Email" DataField="Email" ItemStyle-Width="400" ItemStyle-Font-Size="Small" />
        </Columns>
    </asp:GridView>

    </asp:Panel>

</div>
</asp:Content>
