<%@ Page Title="About GoTournamental" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ErrorsList.aspx.cs" Inherits="GoTournamental.UI.Organiser.ErrorsList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <asp:Panel ID="ErrorsListPanel" runat="server">
  						
    <div class="row">
        <div class="col-md-12">

            <asp:GridView id="ErrorsListGridView" OnRowDataBound="ErrorsListGridView_RowDataBound" runat="server" CellPadding="3" EmptyDataRowStyle-Font-Size="11px" EmptyDataText="No errors found" AutoGenerateColumns="False">
                <Columns>
			        <asp:TemplateField ItemStyle-Width="20" ItemStyle-VerticalAlign="top">
				        <ItemTemplate>
					        <asp:HyperLink ID="RequestDeleteLink" runat="server">
						        <asp:Image ID="RequestDeleteLinkImage" ImageUrl="~/Images/Icons/Delete.jpg" BorderWidth=0 runat="server" />
					        </asp:HyperLink>
				        </ItemTemplate>
			        </asp:TemplateField>
                    <asp:HyperLinkField HeaderText="ID" HeaderStyle-HorizontalAlign="Left" ItemStyle-Font-Bold="true" DataTextField="ID" ItemStyle-Font-Size="11px" ItemStyle-Width="50" DataNavigateUrlFormatString="ErrorView.aspx?Version=1&ID={0}" DataNavigateUrlFields="ID" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField HeaderText="User" HeaderStyle-HorizontalAlign="Left" ItemStyle-Font-Size="11px" ItemStyle-Width="150" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField HeaderText="Logged Date" HeaderStyle-HorizontalAlign="Left" DataField="LoggedDate" dataformatstring="{0:dd/MM/yyyy}" htmlencode="false" ItemStyle-Font-Size="11px" ItemStyle-Width="110" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="TypeName" HeaderText="Type Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-Font-Size="11px" ItemStyle-Width="250" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="Message" HeaderText="Message" HeaderStyle-HorizontalAlign="Left" ItemStyle-Font-Size="11px" ItemStyle-Width="600" ItemStyle-VerticalAlign="Top" />
               </Columns>
            </asp:GridView>

        </div>
    </div>

    </asp:Panel>
    </div>
</asp:Content>
