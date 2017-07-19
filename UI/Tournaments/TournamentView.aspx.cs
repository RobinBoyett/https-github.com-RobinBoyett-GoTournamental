using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using GoTournamental.API;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser {

    public partial class TournamentView : Page {

        #region Declare Domain Objects & Page Variables
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
		GoTournamental.BLL.Organiser.IContact iContact = new GoTournamental.BLL.Organiser.Contact();
		GoTournamental.BLL.Organiser.Contact tournamentContact = new GoTournamental.BLL.Organiser.Contact();

		private string hourText = "";
		private string minuteText = "";
		private string endDate = "";
		private string endTime = "";
        #endregion
		#region Declare UI Controls
		Label tournamentTitle = new Label();
		HyperLink linkToTournamentEdit = new HyperLink();
		Label tournamentType = new Label();
        Label tournamentVenue = new Label();
        Label tournamentPostcode = new Label();
        Panel googleMapFramePanel = new Panel();
        Label tournamentDate = new Label();
		Label contactName = new Label();
		HyperLink contactEmailLink = new HyperLink();
		Image contactEmailIcon = new Image();
		Label contactTelephone = new Label();
		HyperLink contactEditLink = new HyperLink();
		Panel administratorViewOnlyPanelOne = new Panel();
        Panel administratorViewOnlyPanelTwo = new Panel();
        Label playingAreaType = new Label();
        Label noOfPlayingAreas = new Label();
		Label fixtureTurnaround = new Label();
		Label teamSize = new Label();
		Label squadSize = new Label();
		Label resultsAndTablesDate = new Label();
		Label resultsAndTablesSession = new Label();
        HyperLink noCompetitions = new HyperLink();
        HyperLink noTeamsAttending = new HyperLink();
        HyperLink numberOfFixturesScheduled = new HyperLink();
 		DropDownList tournamentFinishByHour = new DropDownList();
		DropDownList tournamentFinishByMinute = new DropDownList();
        Label numberOfFixturesPossible = new Label();
        Image clubLogo = new Image();
		HyperLink uploadClubLogoLink = new HyperLink();
		AdvertPanel advert728By90 = new AdvertPanel();
        #endregion

        protected void Page_Load(object sender, EventArgs e) {

            AssignUIControls();

            if (Request.QueryString.Get("TournamentID") != null) {
	            tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
            }

            if (tournament != null) {
	
				tournamentTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
                linkToTournamentEdit.NavigateUrl = "~/UI/Tournaments/TournamentForm.aspx?version=2&TournamentID=" + tournament.ID.ToString();

				if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
					linkToTournamentEdit.Visible = true;
				}
         
				tournamentType.Text = EnumExtensions.GetStringValue(tournament.TournamentType);
				if (tournament.EndTime.HasValue && tournament.EndTime != null) {
					tournamentDate.Text = DateTimeExtensions.FormatDateRange((DateTime)tournament.StartTime, (DateTime)tournament.EndTime) + ",&nbsp;&nbsp;fixtures commence " + DateTimeExtensions.TimeHoursAndMinutes(tournament.StartTime.Value);
				}
				else {
                    tournamentDate.Text = DateTimeExtensions.LongDateWithLongDay(tournament.StartTime.Value) + ",&nbsp;&nbsp;fixtures commence " + DateTimeExtensions.TimeHoursAndMinutes(tournament.StartTime.Value);
				}

				tournamentVenue.Text = tournament.Venue;
				tournamentPostcode.Text = tournament.Postcode;

				if (tournament.GoogleMapsURL != null && tournament.GoogleMapsURL != "") {
                    googleMapFramePanel.Visible = true;
                    GoogleMapIFrame.Src = tournament.GoogleMapsURL;
				}

				tournamentContact = iContact.GetTournamentContact(tournament.ID);
				if (tournamentContact != null) {
					contactName.Text = tournamentContact.FirstName + " " + tournamentContact.LastName;
					if (tournamentContact.Email != null && tournamentContact.Email != "") {
						contactEmailIcon.Visible = true;
						contactEmailLink.NavigateUrl = "mailto:" + tournamentContact.Email;
					}
					if (tournamentContact.TelephoneNumber != null && tournamentContact.TelephoneNumber != "") {
						contactTelephone.Text += "<br>" + tournamentContact.TelephoneNumber + "&nbsp;&nbsp;";
					}
					if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
						contactEditLink.Text = "[Edit Contact]";
						contactEditLink.NavigateUrl = "/UI/Contacts/ContactForm?version=2&TournamentID="+tournament.ID.ToString()+"&ContactType=2&contact_id="+tournamentContact.ID.ToString();
					}
				}
				else if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
					contactEditLink.Text = "[Add Contact]";
					contactEditLink.NavigateUrl = "/UI/Contacts/ContactForm?version=1&TournamentID="+tournament.ID.ToString()+"&ContactType=2";
				}

				fixtureTurnaround.Text = EnumExtensions.GetIntValue(tournament.FixtureTurnaround).ToString() + " Minutes";
				teamSize.Text = EnumExtensions.GetIntValue(tournament.TeamSize).ToString() + " Players";
				squadSize.Text = EnumExtensions.GetIntValue(tournament.SquadSize).ToString() + " Players";

				if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated) {

					administratorViewOnlyPanelOne.Visible = true;
                    administratorViewOnlyPanelTwo.Visible = true;

					playingAreaType.Text = tournament.PlayingAreaType.ToString();
					if (tournament.NoOfPlayingAreas == Tournament.NumberOfPlayingAreas.Undefined) {
						noOfPlayingAreas.Text = "";
					}
					else {
						noOfPlayingAreas.Text = EnumExtensions.GetIntValue(tournament.NoOfPlayingAreas).ToString();
					}

					if (tournament.RotatorDate.HasValue && tournament.RotatorDate != null) {
						resultsAndTablesDate.Text = tournament.RotatorDate.Value.ToShortDateString();
					}
					else {
						resultsAndTablesDate.Text = "Show All Dates";
					}
					if (tournament.RotatorSession != Competition.Sessions.Undefined) {
						resultsAndTablesSession.Text = EnumExtensions.GetStringValue(tournament.RotatorSession);
					}
					else {
						resultsAndTablesSession.Text = "Show All Sessions";
					}

					noCompetitions.Text = tournament.CountCompetitionsForTournament().ToString();
					noCompetitions.NavigateUrl = "~/UI/CompetitionsList?TournamentID=" + tournament.ID.ToString();

					noTeamsAttending.Text = tournament.CountTeamsForTournament(Domains.AttendanceTypes.Attending).ToString();
					noTeamsAttending.NavigateUrl = "~/UI/Clubs/ClubsList?TournamentID=" + tournament.ID.ToString();

					numberOfFixturesScheduled.Text = tournament.CountFixturesScheduledForTournament().ToString();
					numberOfFixturesScheduled.NavigateUrl = "~/UI/FixturesList?TournamentID=" + tournament.ID.ToString();

				}

				if (tournament.HostClub != null && tournament.HostClub.LogoFile != null && tournament.HostClub.LogoFile != "") {
                    clubLogo.ImageUrl = "~/Uploads/Tournament" + tournament.ID.ToString() + "/Logos/" + tournament.HostClub.LogoFile;
					uploadClubLogoLink.Text = "[Delete your host club logo]";
				    uploadClubLogoLink.Attributes.Add("onclick","javascript:return confirm('Are you sure you want to delete the host club logo?')");
					uploadClubLogoLink.NavigateUrl = "~/UI/IO/FileUploadForm.aspx?TournamentID="+tournament.ID.ToString()+"&UploadType=1&Version=2";
				}
				else if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
                    clubLogo.ImageUrl = "~/Images/GTLogo.png";
                    clubLogo.Height = 230;
                    clubLogo.Width = 250;
					uploadClubLogoLink.Text = "[Replace with your host club logo]";
					uploadClubLogoLink.NavigateUrl = "~/UI/IO/FileUploadForm.aspx?TournamentID="+tournament.ID.ToString()+"&UploadType=1";
				}

				advert728By90.graphicFileStyle = Advert.GraphicFileStyles.Advert728By90;
				if (tournament.ID != null) {
					advert728By90.tournamentID = tournament.ID;
				}
			
			}

        }

        protected void AssignUIControls() {
			tournamentTitle = (Label)TournamentViewPanel.FindControl("TournamentTitle");
            linkToTournamentEdit = (HyperLink)TournamentViewPanel.FindControl("LinkToTournamentEdit");
			tournamentType = (Label)TournamentViewPanel.FindControl("TournamentType");
            tournamentVenue = (Label)TournamentViewPanel.FindControl("TournamentVenue");
            tournamentPostcode = (Label)TournamentViewPanel.FindControl("TournamentPostcode");
            googleMapFramePanel = (Panel)TournamentViewPanel.FindControl("GoogleMapFramePanel");
            tournamentDate = (Label)TournamentViewPanel.FindControl("TournamentDate");
			contactName = (Label)TournamentViewPanel.FindControl("ContactName");
			contactEmailLink = (HyperLink)TournamentViewPanel.FindControl("ContactEmailLink");
			contactEmailIcon = (Image)TournamentViewPanel.FindControl("ContactEmailIcon");
			contactTelephone = (Label)TournamentViewPanel.FindControl("ContactTelephone");
			contactEditLink = (HyperLink)TournamentViewPanel.FindControl("ContactEditLink");
			administratorViewOnlyPanelOne = (Panel)TournamentViewPanel.FindControl("AdministratorViewOnlyPanelOne");
            administratorViewOnlyPanelTwo = (Panel)TournamentViewPanel.FindControl("AdministratorViewOnlyPanelTwo");
            playingAreaType = (Label)TournamentViewPanel.FindControl("PlayingAreaType");
            noOfPlayingAreas = (Label)TournamentViewPanel.FindControl("NoOfPlayingAreas");
			fixtureTurnaround = (Label)TournamentViewPanel.FindControl("FixtureTurnaround");
			teamSize = (Label)TournamentViewPanel.FindControl("TeamSize");
			squadSize = (Label)TournamentViewPanel.FindControl("SquadSize");
			resultsAndTablesDate = (Label)TournamentViewPanel.FindControl("ResultsAndTablesDate");
			resultsAndTablesSession = (Label)TournamentViewPanel.FindControl("ResultsAndTablesSession");
            noCompetitions = (HyperLink)TournamentViewPanel.FindControl("NoCompetitions");
            noTeamsAttending = (HyperLink)TournamentViewPanel.FindControl("NoTeamsAttending");
            numberOfFixturesScheduled = (HyperLink)TournamentViewPanel.FindControl("NumberOfFixturesScheduled");
            numberOfFixturesPossible = (Label)TournamentViewPanel.FindControl("NumberOfFixturesPossible");
			tournamentFinishByHour = (DropDownList)TournamentViewPanel.FindControl("TournamentFinishByHour");
			tournamentFinishByMinute = (DropDownList)TournamentViewPanel.FindControl("TournamentFinishByMinute");
            clubLogo = (Image)TournamentViewPanel.FindControl("ClubLogo");
			uploadClubLogoLink = (HyperLink)TournamentViewPanel.FindControl("UploadClubLogoLink");
			advert728By90 = (AdvertPanel)TournamentViewPanel.FindControl("advert728By90");
        }
 
        protected void AssignRequestsToVariables() {

        }

    }

}

