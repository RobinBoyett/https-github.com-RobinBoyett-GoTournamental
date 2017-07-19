<%@ Page Title="Club" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="TeamAttendanceForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.TeamAttendanceForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="TeamAttendanceTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						
    <h3>Teams Attending</h3>

    <asp:Panel ID="TeamAttendancePanel" runat="server">
    
    <table style="width:1250px;">
        <tr>
            <td colspan="5">
                <asp:DropDownList ID="OrderByList" runat="server" AutoPostBack="true">
		            <asp:ListItem Value="">Order By</asp:ListItem>                      
		            <asp:ListItem Value="AgeBand">Age Band</asp:ListItem>                      
		            <asp:ListItem>Club</asp:ListItem>                      
		            <asp:ListItem>Attendance</asp:ListItem>                      
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:GridView ID="TeamAttendanceGridView" Width="800" GridLines="None" OnRowDataBound="TeamAttendanceGridView_RowDataBound"
                   OnRowEditing="TeamAttendanceGridView_RowEditing" OnRowUpdating="TeamAttendanceGridView_RowUpdating" OnRowCancelingEdit="TeamAttendanceGridView_RowCancelingEdit"
                   EmptyDataText="No teams found" runat="server" AutoGenerateColumns="False">
		        <Columns>
			        <asp:TemplateField HeaderText="Age Band" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top">
				        <ItemTemplate>
					        <asp:HyperLink ID="LinkToCompetition" runat="server" />
				        </ItemTemplate>
			        </asp:TemplateField>
			        <asp:TemplateField HeaderText="Club" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top">
				        <ItemTemplate>
					        <asp:HyperLink ID="LinkToClubEdit" runat="server" />
				        </ItemTemplate>
			        </asp:TemplateField>
			        <asp:TemplateField HeaderText="Team" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top">
				        <ItemTemplate>
					        <asp:HyperLink ID="LinkToTeamEdit" runat="server" />
				        </ItemTemplate>
			        </asp:TemplateField>
			        <asp:TemplateField HeaderText="Attendance" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" ItemStyle-Width="200">
				        <ItemTemplate>
					        <asp:Label ID="AttendanceLabel" runat="server" />
				        </ItemTemplate>			
				        <EditItemTemplate>
					        <asp:HiddenField ID="TeamIDHidden" runat="server" />
					        <asp:DropDownList id="AttendanceTypesList" runat="server" AppendDataBoundItems="true" >
					            <asp:ListItem Value="0">Select</asp:ListItem>			
					        </asp:DropDownList>
				        </EditItemTemplate>
			        </asp:TemplateField>
<%--			        <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top">
				        <ItemTemplate>
					        <asp:HyperLink ID="LinkToTeamEdit2" runat="server" />
				        </ItemTemplate>
			        </asp:TemplateField>--%>

 			        <asp:CommandField ShowHeader="false" ShowCancelButton="true" ShowEditButton="true" UpdateText="Save" EditText="Edit " ItemStyle-VerticalAlign="Top" ItemStyle-Width="70"/>                       		
                </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>    
   

    </asp:Panel>
    </div>
</asp:Content>
