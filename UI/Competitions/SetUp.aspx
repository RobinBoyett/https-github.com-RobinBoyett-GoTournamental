<%@ Page Title="Age Bands" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SetUp.aspx.cs" Inherits="GoTournamental.UI.Organiser.SetUp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="CompetitionsListTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						
    <h3>Set-Up Summary</h3>
    
    <asp:Panel ID="CompetitionsListPanel" runat="server">
    <h4>Capacity</h4>
    <table style="width:1250px;">
        <tr>
            <td style="line-height:16px; width:65px;"><asp:Label ID="PlayingAreaType" runat="server" /></td>
            <td style="line-height:16px; width:110px;">Turnaround</td>
            <td style="line-height:16px; width:90px;">Start Time</td>
            <td style="line-height:16px; width:90px;">No Days</td>
            <td style="line-height:16px; width:90px;">Sessions</td>
            <td style="line-height:16px; width:140px;">Fixture Capacity</td>
        </tr>
        <tr>
            <td style="line-height:16px;"><asp:Label ID="NoPitchesAvailable" runat="server" /></td>
            <td><asp:Label ID="Turnaround" runat="server" /></td>
            <td><asp:Label ID="StartTime" runat="server" /></td>
            <td><asp:Label ID="Days" runat="server" /></td>
            <td><asp:Label ID="Sessions" runat="server" /></td>
            <td><asp:Label ID="Fixtures" runat="server" /></td>
       </tr>
    </table>

    <br /><br />

	<asp:GridView id="CompetitionsListGridView" OnRowDataBound="CompetitionsListGridView_RowDataBound" runat="server" GridLines="None" AutoGenerateColumns="False">
		<Columns>
		    <asp:TemplateField HeaderText="Age Bands Selected" ItemStyle-Width="200">
			    <ItemTemplate>                        
                    <asp:HyperLink ID="CompetitionViewLink" runat="server" />
			    </ItemTemplate>
		    </asp:TemplateField>
            <asp:BoundField HeaderText="Possible Organisation" ItemStyle-Width="220" />
            <asp:BoundField HeaderText="Pitches" ItemStyle-Width="60" />
            <asp:BoundField HeaderText="Turnaround" ItemStyle-Width="110" />
            <asp:BoundField HeaderText="Duration" ItemStyle-Width="160" />
            <asp:BoundField HeaderText="Host Teams" ItemStyle-Width="100" />
            <asp:BoundField HeaderText="Others Attending" ItemStyle-Width="140" />
            <asp:BoundField HeaderText="Others Accepted" ItemStyle-Width="140" />
            <asp:BoundField HeaderText="Registration" ItemStyle-Width="140" />
		</Columns>
	</asp:GridView>

    <br /><br />

    </asp:Panel>
</div>
 </asp:Content>