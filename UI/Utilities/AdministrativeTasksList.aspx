<%@ Page Title="Sponsors List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="AdministrativeTasksList.aspx.cs" Inherits="GoTournamental.UI.Planner.AdministrativeTasksList" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="AdministrativeTasksListTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						

    <h3>Administrative Tasks</h3>
    <asp:Panel ID="AdministrativeTasksListPanel" runat="server">

    <div class="row">
        <div class="col-md-9">

            <table style="width:1300px; border-collapse: separate; border-spacing: 1px;">		
			    <tr>
                    <td style="width:500px; vertical-align:top;">

                        <b>Participation Tasks</b>
                        <asp:DataList ID="ParticipationTasksList" CellPadding="0" ItemStyle-Width="500" RepeatColumns="1" OnItemDataBound="ParticipationTasksList_ItemDataBound" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="ParticipationTaskLabel" Width="275" runat="server" />
                                <asp:HiddenField ID="ParticipationTaskID" runat="server" />
                                <asp:DropDownList ID="ParticipationTaskStatus" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:DataList>
                        <br /><br />

                        <b>Facilities Tasks</b>
                        <asp:DataList ID="FacilitiesTasksList" CellPadding="0" ItemStyle-Width="500" RepeatColumns="1" OnItemDataBound="FacilitiesTasksList_ItemDataBound" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="FacilitiesTaskLabel" Width="275" runat="server" />
                                <asp:HiddenField ID="FacilitiesTaskID" runat="server" />
                                <asp:DropDownList ID="FacilitiesTaskStatus" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:DataList>
                        <br /><br />


                    </td>
                    <td style="width:75px; vertical-align:top;">&nbsp;</td>
                    <td style="width:500px; vertical-align:top;">
                       
                        <b>Communications Tasks</b>
                        <asp:DataList ID="CommunicationsTasksList" CellPadding="0" ItemStyle-Width="500" RepeatColumns="1" OnItemDataBound="CommunicationsTasksList_ItemDataBound" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="CommunicationsTaskLabel" Width="275" runat="server" />
                                <asp:HiddenField ID="CommunicationsTaskID" runat="server" />
                                <asp:DropDownList ID="CommunicationsTaskStatus" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:DataList>
                        <br /><br />

                        <b>Safety Tasks</b>
                        <asp:DataList ID="SafetyTasksList" CellPadding="0" ItemStyle-Width="500" RepeatColumns="1" OnItemDataBound="SafetyTasksList_ItemDataBound" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="SafetyTaskLabel" Width="275" runat="server" />
                                <asp:HiddenField ID="SafetyTaskID" runat="server" />
                                <asp:DropDownList ID="SafetyTaskStatus" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:DataList>
                        <br /><br />

                    </td>
			    </tr>
           </table>

            

        </div>
        <div class="col-md-3">
            <Advertisements:AdvertPanel id="Advert300x600" runat="server" />
        </div>
    </div>

    </asp:Panel>
    </div>
</asp:Content>