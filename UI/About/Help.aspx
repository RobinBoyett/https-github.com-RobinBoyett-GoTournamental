<%@ Page Title="Help" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Help.aspx.cs" Inherits="GoTournamental.UI.Organiser.Help" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    
    <asp:Panel ID="HelpPanel" runat="server">
    						
    <div class="row">
        <div class="col-md-9">
            <h3>How will GoTournamental help me plan my sport event?</h3>
            Follow the YouTube links below to watch our demonstration and tutorial videos<br /><br />        
            
            <b>The Basics</b><br />
            <ul>
                <li>Register to use GoTournamental&nbsp;&nbsp;
                    <a href="https://www.youtube.com/watch?v=WeELQFKlCkk" target="_blank"><asp:Image id="Image1" ImageUrl="~/Images/Icons/youtube.png" Height="14" Width="20" runat="server" /></a></li>
                <li>Create your tournament home page - detailing when and where - who to contact - customise with your club logo&nbsp;&nbsp; 
                    <a href="https://www.youtube.com/watch?v=ZBNmur_or3g" target="_blank"><asp:Image id="Image4" ImageUrl="~/Images/Icons/youtube.png" Height="14" Width="20" runat="server" /></a></li>
                <li>Upload documentation for tournament rules and safety forms etc</li>
                <li>Catalogue tournament sponsors - upload advert graphics - enable click-through adverts</li>  
            </ul>

            <b>Tournament Preparation</b><br />
            <ul>
                <li>Scope requirements for competitions / age bands based on host teams&nbsp;&nbsp;
                    <a href="https://www.youtube.com/watch?v=S5q0CGfaNlQ" target="_blank"><asp:Image id="Image2" ImageUrl="~/Images/Icons/youtube.png" Height="14" Width="20" runat="server" /></a></li>             
                <li>Designate the host club - register all host teams competing with relevant team contacts</li>             
                <li>Invite clubs to tournament - other clubs can register their teams remotely and securely online&nbsp;&nbsp;
                    <a href="https://www.youtube.com/watch?v=Oh_GE0iwSIM" target="_blank"><asp:Image id="Image3" ImageUrl="~/Images/Icons/youtube.png" Height="14" Width="20" runat="server" /></a></li>    
                <li>Assign registered teams to groups - allocate pitches and session times</li>           
                <li>Generate fixtures automatically for group stages and competitive finals</li>           
                <li>Provide all registered contacts with personal online tournament itineries - times, locations</li>           
                <li>Download pre-formatted fixture schedules and all tournament data ready for programme printing</li>           
<%--                <li>Track delegated organisational tasks and responsibilities</li>           --%>
            </ul>

            <b>Run Your Event</b><br />
            <ul>
                <li>Re-organise competitive groups and/or fixture schedules in real time - manage 'no-shows', replacement teams, and other 'gotchas'</li>
                <li>Enter match results online, updating league tables automatically</li>
                <li>Display live event summaries</li>
<%--                <li>Download your data ready to prepare next year's tournament</li>--%>
            </ul>

            <b>For Tournament Entrants</b><br />
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
