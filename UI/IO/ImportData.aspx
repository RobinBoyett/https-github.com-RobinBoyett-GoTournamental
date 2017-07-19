<%@ Page Title="Import Tournament Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ImportData.aspx.cs" Inherits="GoTournamental.UI.Organiser.ImportData" %>
<%@ Register TagPrefix="Navigation" TagName="SetUpMenu" Src="~/UI/Menus/SetUpMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <h3><asp:Label ID="TournamentImportTitle" runat="server" /></h3>
    <Navigation:SetUpMenu id="SetUpMenuControl" runat="server" />	
    <br />					
    <asp:Panel ID="ClubInvitationPanel" Visible="false" runat="server">
        <h3>Import Clubs List</h3>
        <p>
            You can upload details for the clubs you wish to invite to participate in your tournament. Just follow the simple stepwise process outlined below: 
        </p>
        <br />
        <p>
            <b>Step One</b> - Download and save our Excel template - this is specific to your tournament.
            <asp:Button ID="DownloadExcelTemplateForClubsButton" Text="Download" OnClick="DownloadExcelTemplateForClubsButton_Click" class="btn btn-default" runat="server" />
        </p>
        <p>
            <b>Step Two</b> - Fill out and re-save your Excel template - making sure you leave the file name unchanged, and do not alter the column names or the import will not work.
        </p>
        <p>
            <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell><b>Step Three</b></asp:TableCell>
                <asp:TableCell> - Upload your completed template.  </asp:TableCell>
                <asp:TableCell> <asp:FileUpload ID="ExcelFileUpload" Width="500" class="btn btn-default" runat="server" /></asp:TableCell>
                <asp:TableCell> <asp:Button ID="UploadExcelTemplateButton" Text="Upload File" OnClick="UploadExcelTemplateButton_Click" class="btn btn-default" runat="server" /></asp:TableCell>
            </asp:TableRow>
            </asp:Table>
        </p>
        <p>
            <b>Step Four</b> - To import your information to the GoTournamental database, use this button.
            <asp:Button ID="ImportDataFromExcelButton" Text="Import Data" OnClick="ImportDataFromExcelButton_Click" class="btn btn-default" runat="server" />
        </p>
    </asp:Panel>


 <%--       <p>
            You can upload and import information about your tournament, such as clubs and teams that have registered, details of contacts, officials and sponsors, and outlines for competition formats. This will reduce the amount of data
            you need to type online in the various GoTournamental web forms. Just follow the simple stepwise process outlined below: 
        </p>
        <br />
        <p>
            <b>Step One</b> - Download and save our Excel template - this is specific to your tournament.
            <asp:Button ID="DownloadExcelTemplateButton" Text="Download" OnClick="DownloadExcelTemplateButton_Click" class="btn btn-default" runat="server" />
        </p>
        <p>
            <b>Step Two</b> - Fill out and save your Excel template - making sure you leave the file name unchanged.
        </p>
        <p>
            <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell><b>Step Three</b></asp:TableCell>
                <asp:TableCell> - Upload your completed template.  </asp:TableCell>
                <asp:TableCell> <asp:FileUpload ID="ExcelFileUpload" Width="500" class="btn btn-default" runat="server" /></asp:TableCell>
                <asp:TableCell> <asp:Button ID="UploadExcelTemplateButton" Text="Upload File" OnClick="UploadExcelTemplateButton_Click" class="btn btn-default" runat="server" /></asp:TableCell>
            </asp:TableRow>
            </asp:Table>
        </p>
        <p>
            <b>Step Four</b> - Import your information to the GoTournamental database.
            <asp:Button ID="ImportDataFromExcelButton" Text="Import Data" OnClick="ImportDataFromExcelButton_Click" class="btn btn-default" runat="server" />
        </p>
        <p>
            <b>GoTournamental Administrators Only</b> - Reset all but primary data for tournament - this enables a fresh import for testing.
            <asp:Button ID="ResetTournamentDataButton" Text="Reset" OnClick="ResetTournamentDataButton_Click" class="btn btn-default" runat="server" />
        </p>--%>

    </div>
</asp:Content>
