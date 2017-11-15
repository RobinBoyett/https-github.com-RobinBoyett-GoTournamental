<%@ Page Title="Sponsors List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ContactUsList.aspx.cs" Inherits="GoTournamental.UI.Admin.ContactUsList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3>Contact Us - Queries List</h3>

    <asp:Panel ID="ContactUsListListPanel" runat="server">

    <div class="row">
        <div class="col-md-9">
            <br />
	        <asp:GridView id="ContactUsListGridView" OnRowDataBound="ContactUsListGridView_RowDataBound" EmptyDataText="No Queries Were Found" runat="server" GridLines="None" AutoGenerateColumns="False" Width="1000">
		        <Columns>
			        <asp:HyperLinkField HeaderText="ID" HeaderStyle-HorizontalAlign="Left" DataTextField="ID" ItemStyle-Font-Size="11px" ItemStyle-Width="40" DataNavigateUrlFormatString="~/UI/Planner/ContactUsForm.aspx?ID={0}" DataNavigateUrlFields="ID" />
                    <asp:BoundField HeaderText="Date" ItemStyle-Width="100" />
                    <asp:BoundField HeaderText="From" ItemStyle-Width="250" />
                    <asp:BoundField HeaderText="Organisation" DataField="Organisation" ItemStyle-Width="250" />
                    <asp:BoundField HeaderText="Query" ItemStyle-Width="400" />
		        </Columns>
	        </asp:GridView>
        </div>
        <div class="col-md-3">

        </div>
    </div>

    </asp:Panel>
    </div>
</asp:Content>