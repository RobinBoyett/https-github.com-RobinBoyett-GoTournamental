<%@ Page Title="Fixtures List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="FixturesList.aspx.cs" Inherits="GoTournamental.UI.Organiser.FixturesList" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="FixturesListTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						
    
    <asp:Panel ID="FixturesListPanel" runat="server">
    <h3><asp:Label ID="FixturesTypeTitle" runat="server" /></h3>


    <div class="well">

        <div class="row">
            <div class="col-md-12">

	            <table>
		            <tr>
                        <td>
                            <asp:DropDownList ID="AgeBands" AppendDataBoundItems="true" runat="server">
                                <asp:ListItem Value="0">Select Age Band</asp:ListItem>              
                            </asp:DropDownList>&nbsp;&nbsp;&nbsp; 
                        </td>
			            <td style="font-size:small">Order By&nbsp;</td>
                        <td>
				            <asp:DropDownList ID="OrderBy" Font-Size="Small" AppendDataBoundItems="true" runat="server" />&nbsp;
			            </td>
                        <td><asp:Label ID="ListTypeLabel" runat="server" /></td>
			            <td>	
				            <asp:Button id="FixturesFilterOrderByButton" runat="server" Font-Size="Small" BorderWidth="1" Text="Go" />
			            </td>
	   	            </tr>
	            </table>
                <br />
                <asp:GridView ID="FixturesListGridView" OnRowDataBound="FixturesList_RowDataBound" runat="server" GridLines="None" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Competition" ItemStyle-Width="120" ItemStyle-Font-Size="Small" />
                        <asp:BoundField HeaderText="Group" ItemStyle-Width="70" ItemStyle-Font-Size="Small" />
                        <asp:BoundField HeaderText="Fixture" DataField="Name" ItemStyle-Width="190" ItemStyle-Font-Size="Small" />
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
                        <asp:BoundField HeaderText="'Home'" ItemStyle-Width="275" ItemStyle-Font-Size="Small" />
                        <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                        <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                        <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                        <asp:BoundField HeaderText="'Away'" HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="275" ItemStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField ItemStyle-Width="10" ItemStyle-Font-Size="Small" />
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
                        <asp:BoundField ItemStyle-Width="10" ItemStyle-Font-Size="Small" />
                        <asp:BoundField HeaderText="Pitch" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
                    </Columns>
                </asp:GridView>
                </div>
            </div>
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