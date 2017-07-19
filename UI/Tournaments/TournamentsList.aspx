<%@ Page Title="Tournaments Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="TournamentsList.aspx.cs" Inherits="GoTournamental.UI.Organiser.TournamentsList" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><%: Title %></h3>

    <asp:Panel ID="TournamentsListPanel" runat="server">

    <div class="row">
        <div class="col-md-8">
	        <table>
		        <tr>
			        <td style="font-size:small">Search&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="TournamentType" AppendDataBoundItems="true" runat="server">
					        <asp:ListItem Value="0">Select Sport</asp:ListItem>              
                        </asp:DropDownList>
			        </td>
                    <td>
				        <asp:TextBox ID="SearchText" Width="140" Font-Size="Small" runat="server" />&nbsp;
			        </td>
			        <td>	
				        <asp:Button id="TournamentsSearchButton" runat="server" Font-Size="Small" BorderWidth="1" Text="Go" />
			        </td>
	   	        </tr>
	        </table>
            <br />
	        <asp:GridView id="TournamentsListGridView" OnRowDataBound="TournamentsListGridView_RowDataBound" EmptyDataText="No Tournaments Were Found" runat="server" GridLines="None" AutoGenerateColumns="False">
		        <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="TournamentLink" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="StartTime" ItemStyle-Width="150" ItemStyle-HorizontalAlign="Right" />
		        </Columns>
	        </asp:GridView>
        </div>
        <div class="col-md-4">
            <Advertisements:AdvertPanel id="Advert300By250" runat="server" />
        </div>
    </div>



    </asp:Panel>
    </div>
</asp:Content>