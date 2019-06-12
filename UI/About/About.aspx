<%@ Page Title="GoTournamental - Who We Are" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="GoTournamental.UI.About" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    
    <asp:Panel ID="HelpPanel" runat="server">
    						
    <div class="row">
        <div class="col-md-9">
            <h3>How will GoTournamental help me plan my sport event?</h3>

            Follow the YouTube links below to watch our demonstration and tutorial videos<br /><br />        

            <b>First Steps</b><br />
            <ul>
                <li>Register to use GoTournamental&nbsp;&nbsp;
                    <a href="https://www.youtube.com/watch?v=WeELQFKlCkk" target="_blank"><asp:Image id="Image1" ImageUrl="~/Images/Icons/youtube.png" Height="14" Width="20" runat="server" /></a></li>
                <li>Create your tournament home page - detailing when and where - who to contact - customise with your club logo&nbsp;&nbsp; 
                    <a href="https://www.youtube.com/watch?v=ZBNmur_or3g" target="_blank"><asp:Image id="Image4" ImageUrl="~/Images/Icons/youtube.png" Height="14" Width="20" runat="server" /></a></li>
                <li>Upload documentation for tournament rules and safety forms etc</li>
                <li>Catalogue tournament sponsors - upload advert graphics - enable click-through adverts</li>  
            </ul>

            <b>Prepare Your Tournament</b><br />
            <ul>
                <li>Set up your competitions based on age bands. Allocate pitches&nbsp;&nbsp;
                    <a href="https://www.youtube.com/watch?v=S5q0CGfaNlQ" target="_blank"><asp:Image id="Image2" ImageUrl="~/Images/Icons/youtube.png" Height="14" Width="20" runat="server" /></a></li>             
                <li>Register all teams competing for the host club with relevant team contacts</li>
                <li>Upload details of your target clubs and their key contacts using our Excel template</li>                
                <li>Invite clubs to tournament - other clubs can register their teams remotely and securely online&nbsp;&nbsp;
                    <a href="https://www.youtube.com/watch?v=Oh_GE0iwSIM" target="_blank"><asp:Image id="Image3" ImageUrl="~/Images/Icons/youtube.png" Height="14" Width="20" runat="server" /></a></li>    
                <li>Assign registered teams to groups - allocate pitches and session times</li>           
                <li>Generate fixtures automatically for group stages and competitive finals</li>           
                <li>Provide all registered contacts with personal online tournament itineries - times, locations</li>           
                <li>Download pre-formatted fixture schedules and all tournament data ready for programme printing</li>           
            </ul>

            <b>At The Printers</b>
            <ul>
                <li>Download full fixture itineraries for programme printing</li>
                <li>Download printer-ready referee slips</li>
            </ul>

            <b>Run Your Event</b><br />
            <ul>
                <li>Re-organise competitive groups and/or fixture schedules in real time - manage 'no-shows', replacement teams, and other 'gotchas'</li>
                <li>Enter match results online, updating league tables and calculating qualitification to finals etc automatically</li>
                <li>Display live event summaries. Volunteers, coaches and parents can follow results, tables and schedule alterations online in real time</li>
            </ul>

            <b>Afterwards...</b>
            <ul>
                <li>Download key contacts details in Excel for your records</li>
            </ul>

            <b>Easy Registration for Tournament Entrants</b><br />
            <ul>
                <li>Register your teams once you are invited to a tournament&nbsp;&nbsp;
                    <a href="https://www.youtube.com/watch?v=HErov9aH1j8" target="_blank"><asp:Image id="Image5" ImageUrl="~/Images/Icons/youtube.png" Height="14" Width="20" runat="server" /></a></li>             
            </ul>

        </div>
        <div class="col-md-3" style="text-align:right;">
            <Advertisements:AdvertPanel id="Advert120x600" runat="server" />
        </div>

    </div>

    </asp:Panel>
    </div>
</asp:Content>