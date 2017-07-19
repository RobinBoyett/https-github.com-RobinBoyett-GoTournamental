<%@ Page Title="Competition" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="CompetitionRotator.aspx.cs" Inherits="GoTournamental.UI.Organiser.CompetitionRotator" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="TournamentTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						

    <asp:Panel ID="CompetitionRotatorPanel" runat="server">
    <h4><asp:Label ID="CompetitionName" runat="server" /></h4>

    <div class="well">

        <div class="row">
            <asp:Panel ID="FixturesListForGroupPanel" runat="server">
                <div class="col-md-10">
                    <asp:GridView ID="FixturesListForGroup" OnRowDataBound="FixturesListForGroup_RowDataBound" runat="server" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Name" ItemStyle-Width="100" ItemStyle-Font-Size="Small" />
                            <asp:BoundField HeaderText="Time" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
                            <asp:TemplateField ItemStyle-Width="40">
                                <ItemTemplate>
                                    <asp:Table ID="HomeColourTable" runat="server">
                                        <asp:TableRow ID="HomeColourTableRow" Height="15" runat="server">
                                            <asp:TableCell ID="HomeColourPrimaryCell" Text="&nbsp;" Width="15" Height="10" BorderStyle="Solid" BorderWidth="1" BorderColor="Black" runat="server"></asp:TableCell>
                                            <asp:TableCell ID="HomeColourSecondaryCell" Text="&nbsp;" Width="15" Height="10" BorderStyle="Solid" BorderWidth="1" BorderColor="Black" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="'Home'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
                            <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                            <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                            <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                            <asp:BoundField HeaderText="'Away'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
                            <asp:TemplateField ItemStyle-Width="35">
                                <ItemTemplate>
                                    <asp:Table ID="AwayColourTable" runat="server">
                                        <asp:TableRow ID="AwayColourTableRow" Height="15" runat="server">
                                            <asp:TableCell ID="AwayColourPrimaryCell" Text="&nbsp;" Width="15" Height="10" BorderStyle="Solid" BorderWidth="1" BorderColor="Black" runat="server"></asp:TableCell>
                                            <asp:TableCell ID="AwayColourSecondaryCell" Text="&nbsp;" Width="15" Height="10" BorderStyle="Solid" BorderWidth="1" BorderColor="Black" runat="server"></asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Pitch" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
                        </Columns>
                    </asp:GridView>

                </div>
                <div class="col-md-2">
                    <b>Powered By</b><br /><br />
                    <asp:Image id="GTLogo1" ImageUrl="~/Images/GTLogo.png" Height="118" Width="157" runat="server" />
                </div>
            </asp:Panel>

            <asp:Panel ID="LeagueTableForGroupPanel" runat="server">
                <div class="col-md-10">
                    <asp:GridView ID="LeagueTableForGroup" OnRowDataBound="LeagueTableForGroup_RowDataBound" CellSpacing="2" runat="server" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="15" ItemStyle-Font-Size="Small" />
                            <asp:BoundField ItemStyle-Width="15" ItemStyle-Font-Size="Small" />
                            <asp:BoundField ItemStyle-Width="5" ItemStyle-Font-Size="Small" />
                            <asp:BoundField DataField="Position" ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                            <asp:BoundField HeaderText="Team" ItemStyle-Width="250" ItemStyle-Font-Size="Small" />
                            <asp:BoundField DataField="Played" HeaderText="P" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                            <asp:BoundField DataField="Wins" HeaderText="W" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                            <asp:BoundField DataField="Draws" HeaderText="D" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                            <asp:BoundField DataField="Defeats" HeaderText="L" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                            <asp:BoundField DataField="GoalsFor" HeaderText="F" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                            <asp:BoundField DataField="GoalsAgainst" HeaderText="A" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                            <asp:BoundField DataField="GoalDifference" HeaderText="GD" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                            <asp:BoundField DataField="Points" HeaderText="Pt" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                        </Columns>  
                    </asp:GridView> 
                </div>
                <div class="col-md-2">
                    <b>Powered By</b><br /><br />
                    <asp:Image id="GTLogo2" ImageUrl="~/Images/GTLogo.png" Height="118" Width="157" runat="server" />
                </div>
            </asp:Panel>

            <asp:Panel ID="FixturesListForCompetitionPanel" runat="server">
               <div class="col-md-10">
                    <asp:GridView ID="FixturesListForCompetition" OnRowDataBound="FixturesListForCompetition_RowDataBound" runat="server" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Name" ItemStyle-Width="150" ItemStyle-Font-Size="Small" />
                            <asp:BoundField HeaderText="Time" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
                            <asp:BoundField HeaderText="'Home'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
                            <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                            <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                            <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                            <asp:BoundField HeaderText="'Away'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
                            <asp:BoundField HeaderText="Pitch" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
                        </Columns>
                    </asp:GridView>
 
                </div>
                <div class="col-md-2">
                    <b>Powered By</b><br /><br />
                    <asp:Image id="GTLogo3" ImageUrl="~/Images/GTLogo.png" Height="118" Width="157" runat="server" />
                </div>
            </asp:Panel>

<%--            <div class="col-md-11"> 
                <asp:Panel ID="FixturesListForGroupPanel" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="FixturesListForGroup" OnRowDataBound="FixturesListForGroup_RowDataBound" runat="server" GridLines="None" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="Name" ItemStyle-Width="100" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField HeaderText="Time" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
                                    <asp:TemplateField ItemStyle-Width="40">
                                        <ItemTemplate>
                                            <asp:Table ID="HomeColourTable" runat="server">
                                                <asp:TableRow ID="HomeColourTableRow" Height="15" runat="server">
                                                    <asp:TableCell ID="HomeColourPrimaryCell" Text="&nbsp;" Width="15" Height="10" BorderStyle="Solid" BorderWidth="1" BorderColor="Black" runat="server"></asp:TableCell>
                                                    <asp:TableCell ID="HomeColourSecondaryCell" Text="&nbsp;" Width="15" Height="10" BorderStyle="Solid" BorderWidth="1" BorderColor="Black" runat="server"></asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="'Home'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField HeaderText="'Away'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
                                    <asp:TemplateField ItemStyle-Width="35">
                                        <ItemTemplate>
                                            <asp:Table ID="AwayColourTable" runat="server">
                                                <asp:TableRow ID="AwayColourTableRow" Height="15" runat="server">
                                                    <asp:TableCell ID="AwayColourPrimaryCell" Text="&nbsp;" Width="15" Height="10" BorderStyle="Solid" BorderWidth="1" BorderColor="Black" runat="server"></asp:TableCell>
                                                    <asp:TableCell ID="AwayColourSecondaryCell" Text="&nbsp;" Width="15" Height="10" BorderStyle="Solid" BorderWidth="1" BorderColor="Black" runat="server"></asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Pitch" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width:100px;">&nbsp;</td>
                        <td style="vertical-align:top;">
                            <b>Tournament Powered By</b><br /><br />
                            <asp:Image id="GTLogo1" ImageUrl="~/Images/GTLogo.png" Height="149" Width="195" runat="server" />
                        </td>
                    </tr>
                </table>
                </asp:Panel> 
            </div>
            <div class="col-md-1">
                &nbsp;
            </div>
            <div class="col-md-11">
                <asp:Panel ID="LeagueTableForGroupPanel" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="LeagueTableForGroup" OnRowDataBound="LeagueTableForGroup_RowDataBound" CellSpacing="2" runat="server" GridLines="None" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField ItemStyle-Width="15" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField ItemStyle-Width="15" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField ItemStyle-Width="5" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField DataField="Position" ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField HeaderText="Team" ItemStyle-Width="250" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField DataField="Played" HeaderText="P" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField DataField="Wins" HeaderText="W" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField DataField="Draws" HeaderText="D" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField DataField="Defeats" HeaderText="L" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField DataField="GoalsFor" HeaderText="F" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField DataField="GoalsAgainst" HeaderText="A" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField DataField="GoalDifference" HeaderText="GD" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField DataField="Points" HeaderText="Pt" ItemStyle-Width="30" ItemStyle-Font-Size="Small" />
                                </Columns>  
                            </asp:GridView> 
                        </td>
                        <td style="width:100px;">&nbsp;</td>
                        <td style="vertical-align:top;">
                            <b>Tournament Powered By</b><br /><br />
                            <asp:Image id="GTLogo2" ImageUrl="~/Images/GTLogo.png" Height="149" Width="195" runat="server" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>          
            </div>
            <div class="col-md-1">
                &nbsp;
            </div>
            <div class="col-md-11">               
                <asp:Panel ID="FixturesListForCompetitionPanel" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="FixturesListForCompetition" OnRowDataBound="FixturesListForCompetition_RowDataBound" runat="server" GridLines="None" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="Name" ItemStyle-Width="150" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField HeaderText="Time" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField HeaderText="'Home'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField HeaderText="'Away'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField HeaderText="Pitch" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width:100px;">&nbsp;</td>
                        <td style="vertical-align:top;">
                            <b>Tournament Powered By</b><br /><br />
                            <asp:Image id="GTLogo3" ImageUrl="~/Images/GTLogo.png" Height="149" Width="195" runat="server" />
                        </td>
                    </tr>
                </table>                            
                </asp:Panel>
                 
                <asp:Label ID="WinnersLabel" runat="server" />

                </div>
            </div>
            <div class="col-md-1">
                &nbsp;
            </div>--%>
        
    
    </div>



       <div class="row">
            <div class="col-md-8">
                <Advertisements:AdvertPanel id="Advert728By90" runat="server" />
            </div>
            <div class="col-md-4">
                &nbsp;
            </div>
        </div>
    </asp:Panel>
    </div>
</asp:Content>