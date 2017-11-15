<%@ Page Title="Online Sports Tournament Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="GoTournamental.UI.Organiser.Default" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <asp:Panel ID="GTHomePagePanel" runat="server">
 
        <div class="row">
            <div class="col-md-3">
                <br />
                &nbsp;&nbsp;&nbsp;<asp:Image id="GTLogo" ImageUrl="~/Images/GTLogo.png" Height="230" Width="250" runat="server" />
            </div>
            <div class="col-md-7">
                <h3>Junior Sports Tournament Management</h3><br />

                <p style="font-size:medium;">
                    GoTournamental offers a complete web-based toolkit for your club to host sporting events.
                </p>
                <p style="font-size:medium;">
                    Invite and register clubs, teams and players online. Organise pitches and generate fixture schedules. 
                    You view them from the clubhouse, let your visiting coaches
                    keep updated on their tablets or phones. Let GoTournamental help with contacts, prepare your programme and 
                    help print your referee slips. We'll even prompt you to book the ice cream van.
                    See <a href="/UI/About/About.aspx">About</a> for more details, and be sure 
                    to <a href="/UI/About/ContactUsForm.aspx">Contact Us</a> for a free trial tournament.
                </p>
                 <p style="font-size:medium;">
                    The annual tournament or festival is usually your club's biggest income stream. Don't let it drive you mad - GoTournamental!
                </p>
                <p>
                    <a href="/UI/Planner/TournamentsList.aspx">Search Tournaments &raquo;</a>
                </p>
                <p>
                    <asp:HyperLink ID="TournamentLink" class="btn btn-default" Visible="false" runat="server" />
                </p>
                <p>
                    <asp:LoginView runat="server" ViewStateMode="Disabled">
                        <AnonymousTemplate>
                            Please <a runat="server" href="~/Account/Login">Log In</a> to <%--or <a runat="server" href="~/Account/Register">Register</a> with--%> GoTournamental to create and edit your tournaments
                        </AnonymousTemplate>
                    </asp:LoginView> 
                </p>
            </div>
            <div class="col-md-2">
                &nbsp;
            </div>
        </div>

    
                 
    </asp:Panel>
    </div> 

</asp:Content>
