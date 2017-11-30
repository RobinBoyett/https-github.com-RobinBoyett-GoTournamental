<%@ Page Title="GoTournamental - Who We Are" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Testimonials.aspx.cs" Inherits="GoTournamental.UI.Testimonials" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
    <asp:Panel ID="TestimonialsPanel" runat="server">

    <div class="row">
        <div class="col-md-8">
            <h3>Testimonials</h3>
           <table style="width:1200px;">
                 <tr>
                    <td style="width:120px; vertical-align:top;">
                        <asp:Image ImageUrl="~/Images/TestimonialLogos/CrowboroughAthletic.jpg" Height="100" Width="100" runat="server" />
                    </td>
                    <td style="text-align: left;">
                        For the second year running Crowborough Athletic FC have used the GoTournamental system to support the development and delivery of our Football Fiesta
                        this May 2017. With over 150 teams entering this years tournament, the system performed fantastically well and ensured all aspects of administration from
                        sending invites through to managing all fixtures and producing results and tables ran smoothly without fault on both days for over 340 fixtures.
                        This without doubt played a pivotal role in ensuring our fiesta was delivered in a professional and efficient manner and teams left happy.
                        <br /><br />
                        Mark Sawyer<br />
                        Chair of the CAFC Fiesta Committee
                    </td>
                </tr>
                <tr><td colspan="2">&nbsp;</td></tr>
                <tr>
                    <td style="width:120px; vertical-align:top;">
                        <asp:Image ImageUrl="~/Images/TestimonialLogos/JarvisBrook.jpg" Height="100" Width="100" runat="server" />
                    </td>
                    <td style="text-align: left;">
                        As the organiser of one of the biggest and best tournaments in the County, I am only too familiar with the chaos that ensues whenever teams fail to turn 
                        up on the day of a tournament when fixtures have been cast and programmes printed etc. We no longer have that headache as GoTournamental has allowed 
                        us to arrange and run our tournaments without the need for endless reams of paper/copying, pouring over spreadsheets or the worry of last minute changes.<br />
                        Martin and the GT team have very successfully developed what is an invaluable tool which has successfully managed to take pretty much everything we have
                        thrown at it in terms of last minute changes to fixtures, odd sized divisions, different qualifying scenarios, different game durations etc etc.<br />
                        Players, Parents and Coaches love seeing their tournament progress being displayed on the big screen rather than on paper flipcharts or whiteboards and the 
                        whole GT package makes their tournament experience that little bit more special. The automated referee score slip function is a massive bonus too.<br />
                        I would recommend GoTournamental to anyone who wants to take their tournament to the next level!
                        <br /><br />
                        Paul McCarthy<br />
                        Chairman JBJFC
                    </td>
                </tr>

            </table>

            <br />
        </div>
        <div class="col-md-4" style="text-align:right;">
            <Advertisements:AdvertPanel id="Advert300x250" runat="server" />
        </div>

    </div>
    </asp:Panel>
</div>
</asp:Content>
