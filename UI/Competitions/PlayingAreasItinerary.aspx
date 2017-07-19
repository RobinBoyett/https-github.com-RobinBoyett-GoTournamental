<%@ Page Title="Playing Areas Itinerary" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="PlayingAreasItinerary.aspx.cs" Inherits="GoTournamental.UI.Organiser.PlayingAreasItinerary" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="FixturesListTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />	
    					
    <asp:Panel ID="PlayingAreasItineraryPanel" runat="server">
         

    <asp:DataList ID="ScheduledDaysList" OnItemDataBound="ScheduledDaysList_ItemDataBound" runat="server">
        <ItemTemplate>
            <asp:Label ID="ScheduledDayLabel" Font-Bold="true" Font-Size="Larger" runat="server" />

            <asp:DataList ID="PlayingAreasList" OnItemDataBound="PlayingAreasList_ItemDataBound" RepeatDirection="Horizontal" ItemStyle-VerticalAlign="Top" CellPadding="2" ItemStyle-Width="350" runat="server">
                <ItemTemplate>
                    <asp:Label ID="PlayingAreaName" Font-Size="Small" Font-Bold="true" runat="server" />
                    
                    <asp:Table ID="FixtureItineraryTable" runat="server" />


<%--                    
                    <asp:DataList ID="ItineraryForPlayingArea" BorderStyle="Solid" BorderColor="Black" BorderWidth="1" CellPadding="0" ItemStyle-Width="160" RepeatColumns="1" OnItemDataBound="ItineraryForPlayingArea_ItemDataBound"  runat="server">
                        <ItemTemplate>
                            <asp:Table ID="FixtureItineraryTable" runat="server">
                                <asp:TableRow ID="FixtureItineraryTableRow" Height="10" runat="server">
                                    <asp:TableCell ID="FixtureNameCell" Width="160" Height="10" Font-Size="X-Small" runat="server"></asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </ItemTemplate>
                    </asp:DataList>--%>


                </ItemTemplate>
            </asp:DataList>
            <br />

        </ItemTemplate>
    </asp:DataList>


    </asp:Panel>
 </div>
</asp:Content>