<%@ Page Title="Competition" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ScoresEntryForm.aspx.cs" Inherits="GoTournamental.UI.Organiser.ScoresEntryForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">

    <h3><asp:Label ID="CompetitionTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						

    <asp:Panel ID="GroupAllocationFormPanel" runat="server">
    <table style="width:1350px;">
        <tr>
            <td><h4><asp:Label ID="AgeBand" runat="server" /></h4></td>
            <td><asp:HyperLink ID="LinkToCompetitionSummary" Text="[View Summary]" runat="server" /></td>
        </tr>
         
        <asp:Panel ID="FixturesEditPanel" Visible="false" runat="server">
 
        <tr>
            <td style="vertical-align:top;">&nbsp;</td>
            <td>
               <asp:DataList ID="GroupsDataList" OnItemDataBound="GroupsDataList_ItemDataBound" runat="server">
                <ItemTemplate>
                    <h4><asp:Label ID="GroupName" Font-Size="Small" Font-Bold="true" runat="server" /></h4>

                    <asp:GridView ID="FixturesListForGroup" OnRowDataBound="FixturesListForGroup_RowDataBound" runat="server" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Name" ItemStyle-Width="70" ItemStyle-Font-Size="Small" />
                            <asp:BoundField HeaderText="Time" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
                            <asp:BoundField HeaderText="'Home'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
                            <asp:TemplateField ItemStyle-Width="30" ItemStyle-Font-Size="Small" >
                                <Itemtemplate>
                                    <asp:HiddenField ID="FixtureID" runat="server" />
                                    <asp:HiddenField ID="HomeTeamID" runat="server" />
                                    <asp:TextBox ID="HomeTeamScore" Width="25" Style="text-align: right;" runat="server" />                   
                                </Itemtemplate>
                            </asp:TemplateField>
                            <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                            <asp:TemplateField ItemStyle-Width="30" ItemStyle-Font-Size="Small" >
                                <Itemtemplate>
                                    <asp:HiddenField ID="AwayTeamID" runat="server" />
                                    <asp:TextBox ID="AwayTeamScore" Width="25" Style="text-align: left;" runat="server" />                   
                                </Itemtemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="'Away'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
                            <asp:BoundField HeaderText="Pitch" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
                            <asp:BoundField HeaderText="Referee" ItemStyle-Width="120" ItemStyle-Font-Size="Small" />
                       </Columns>
                    </asp:GridView>
                </ItemTemplate>

                </asp:DataList>
                <asp:Button ID="SaveLeagueScoresButton" Text="Save League Scores" OnClick="SaveLeagueScoresButton_Click" CssClass="btn btn-default" Visible="false" runat="server" /><br />
                <asp:Button ID="GenerateFixturesButton" Text="Generate Fixtures" OnClick="GenerateFixtureButton_Click" CssClass="btn btn-default" Visible="false" runat="server" /><br />

                <br />

                <asp:GridView ID="FixturesListForCompetition" OnRowDataBound="FixturesListForCompetition_RowDataBound" runat="server" GridLines="None" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Name" ItemStyle-Width="150" ItemStyle-Font-Size="Small" />
                        <asp:BoundField HeaderText="Time" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
                        <asp:BoundField HeaderText="'Home'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
                        <asp:TemplateField ItemStyle-Width="30" ItemStyle-Font-Size="Small" >
                            <Itemtemplate>
                                <asp:HiddenField ID="FinalsID" runat="server" />
                                <asp:HiddenField ID="FinalsHomeTeamID" runat="server" />
                                <asp:TextBox ID="FinalsHomeTeamScore" Width="25" Style="text-align: right;" runat="server" />                   
                            </Itemtemplate>
                        </asp:TemplateField>
                        <asp:BoundField ItemStyle-Width="20" ItemStyle-Font-Size="Small" />
                        <asp:TemplateField ItemStyle-Width="30" ItemStyle-Font-Size="Small" >
                            <Itemtemplate>
                                <asp:HiddenField ID="FinalsAwayTeamID" runat="server" />
                                <asp:TextBox ID="FinalsAwayTeamScore" Width="25" Style="text-align: left;" runat="server" />                   
                            </Itemtemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="'Away'" ItemStyle-Width="260" ItemStyle-Font-Size="Small" />
                        <asp:BoundField HeaderText="Pitch" ItemStyle-Width="50" ItemStyle-Font-Size="Small" />
                        <asp:BoundField HeaderText="Referee" ItemStyle-Width="120" ItemStyle-Font-Size="Small" />
                    </Columns>
                </asp:GridView>
                <asp:Button ID="SaveFinalsScoresButton" Text="Save Finals Scores" OnClick="SaveFinalsScoresButton_Click" CssClass="btn btn-default" Visible="false" runat="server" /><br />
       


            </td>
        </tr>
        </asp:Panel>

     </table>

    </asp:Panel>
    </div>
</asp:Content>
