<%@ Page Title="Export Tournament Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ExportData.aspx.cs" Inherits="ExportData" %>
<%@ Register TagPrefix="Navigation" TagName="TournamentMenu" Src="~/UI/Menus/TournamentMenu.ascx" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="TournamentExportTitle" runat="server" /></h3>
	<Navigation:TournamentMenu id="TournamentMenuControl" runat="server" />						
	<Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />						
    <h3>Export Your Tournament Information</h3>
    <asp:Panel ID="TournamentExportPanel" runat="server">
        <p>
            Export your tournament fixtures into an Excel file for printing event programmes, and generate referee slips for each fixture.
        </p>
        <br />
        <asp:Button ID="ExportForPrintingButton" Text="Export For Programme Printing" OnClick="ProgrammePrintingButton_Click" class="btn btn-default" runat="server" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ExportForRefereesSlipsButton" Text="Export Referees Slips" OnClick="RefereesSlipsButton_Click" class="btn btn-default" runat="server" />
    </asp:Panel>
    </div>
</asp:Content>
