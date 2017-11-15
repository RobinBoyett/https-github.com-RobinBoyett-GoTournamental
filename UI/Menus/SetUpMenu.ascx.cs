using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.BLL.Organiser;

public partial class SetUpMenu : System.Web.UI.UserControl {

    #region Declare Domain Objects & Page Variables
	GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
    Tournament tournament = new Tournament();
    ITournament iTournament = new Tournament();
	List<Competition> competitions = new List<Competition>();
	ICompetition iCompetition = new Competition();
	List<Contact> contacts = new List<Contact>();
	IContact iContact = new Contact();
	#endregion
		
	#region Declare UI Controls
	HyperLink linkToSetUp = new HyperLink();
	HyperLink linkToCompetitions = new HyperLink();
	HyperLink linkToClubsDirectory = new HyperLink();
    HyperLink linkToClubInvitation = new HyperLink();
	HyperLink linkToRegistration = new HyperLink();
	HyperLink linkToTeamAttendance = new HyperLink();
	HyperLink linkToContacts = new HyperLink();
    HyperLink linkToPlayingAreasItinerary = new HyperLink();
 	HyperLink linkToFixtures = new HyperLink();
    HyperLink linkToAdministrativeTasks = new HyperLink();
	HyperLink linkToTrophyRequirements = new HyperLink();
	HyperLink linkToAdverts = new HyperLink();
	HyperLink linkToUploadAndImport = new HyperLink();
	HyperLink linkToExport = new HyperLink();
	#endregion

	protected void Page_Load(object sender, EventArgs e) {

		AssignUIControls();
        if (Request.QueryString.Get("TournamentID") != null) {
            tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
            competitions = iCompetition.SQLSelectForTournament(tournament.ID, false);
            contacts = iContact.SQLSelectForTournament(tournament.ID);
        }

        if (tournament.ID == 1 || identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
            SetUpNavigationPanel.Visible = true;

            linkToSetUp.NavigateUrl = "~/UI/Competitions/SetUp.aspx?TournamentID=" + tournament.ID.ToString();

            if (competitions.Count > 0) {
                linkToCompetitions.NavigateUrl = "~/UI/Competitions/CompetitionsList.aspx?TournamentID=" + tournament.ID.ToString();
                linkToCompetitions.Visible = true;
            }
            else {
                linkToCompetitions.NavigateUrl = "~/UI/Competitions/CompetitionsForm.aspx?TournamentID=" + tournament.ID.ToString();
                linkToCompetitions.Visible = true;
            }

			linkToClubsDirectory.NavigateUrl = "~/UI/Planner/ClubsList.aspx?version=1&TournamentID=" + tournament.ID.ToString();
            linkToClubInvitation.NavigateUrl = "~/UI/Planner/ClubsInvitedForm.aspx?TournamentID=" + tournament.ID.ToString();

            linkToTeamAttendance.NavigateUrl = "~/UI/Teams/TeamAttendanceForm.aspx?TournamentID=" + tournament.ID.ToString();

            if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
                linkToRegistration.Visible = true;
                linkToRegistration.NavigateUrl = "~/UI/Planner/ClubRegistrationForm.aspx?TournamentID=" + tournament.ID.ToString() + "&version=1&club_id=" + tournament.HostClub.ID.ToString();
            }
 
            
			if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated) {
				linkToContacts.Visible = true;
				if (contacts.Count > 0) {
					linkToContacts.NavigateUrl = "~/UI/Planner/ContactsList.aspx?TournamentID=" + tournament.ID.ToString();
				}
				else {
					linkToContacts.NavigateUrl = "~/UI/Planner/ContactForm.aspx?version=1&TournamentID=" + tournament.ID.ToString();
				}
            }

            linkToFixtures.NavigateUrl = "~/UI/Competitions/FixturesList.aspx?TournamentID=" + tournament.ID.ToString();

            linkToPlayingAreasItinerary.Text = tournament.PlayingAreaType.ToString();
            linkToPlayingAreasItinerary.NavigateUrl = "~/UI/Competitions/PlayingAreasItinerary.aspx?TournamentID=" + tournament.ID.ToString();

            //linkToAdministrativeTasks.NavigateUrl = "~/UI/Utilities/AdministrativeTasksList.aspx?TournamentID=" + tournament.ID.ToString();

            //linkToTrophyRequirements.NavigateUrl = "~/UI/Utilities/TrophyRequirements.aspx?TournamentID=" + tournament.ID.ToString();

            linkToAdverts.NavigateUrl = "~/UI/IO/UploadedFilesList.aspx?Version=2&TournamentID=" + tournament.ID.ToString();

            //linkToUploadAndImport.Visible = true;
            //linkToUploadAndImport.NavigateUrl = "~/UI/IO/ImportData.aspx?TournamentID=" + tournament.ID.ToString();
            linkToExport.NavigateUrl = "~/UI/IO/ExportData.aspx?TournamentID=" + tournament.ID.ToString();

        }
	


	}
	
	protected void AssignUIControls() {
        linkToSetUp = (HyperLink)SetUpNavigationPanel.FindControl("LinkToSetUp");
		linkToCompetitions = (HyperLink)SetUpNavigationPanel.FindControl("LinkToCompetitions");
		linkToClubsDirectory = (HyperLink)SetUpNavigationPanel.FindControl("LinkToClubsDirectory");
        linkToClubInvitation = (HyperLink)SetUpNavigationPanel.FindControl("LinkToClubInvitation");
		linkToRegistration = (HyperLink)SetUpNavigationPanel.FindControl("LinkToRegistration");
		linkToTeamAttendance = (HyperLink)SetUpNavigationPanel.FindControl("LinkToTeamAttendance");
		linkToContacts = (HyperLink)SetUpNavigationPanel.FindControl("LinkToContacts");
        linkToPlayingAreasItinerary = (HyperLink)SetUpNavigationPanel.FindControl("LinkToPlayingAreasItinerary");
		linkToFixtures = (HyperLink)SetUpNavigationPanel.FindControl("LinkToFixtures");
        //linkToAdministrativeTasks = (HyperLink)SetUpNavigationPanel.FindControl("LinkToAdministrativeTasks");
        //linkToTrophyRequirements = (HyperLink)SetUpNavigationPanel.FindControl("LinktoTrophyRequirements");
		linkToAdverts = (HyperLink)SetUpNavigationPanel.FindControl("LinktoAdverts");
		linkToUploadAndImport = (HyperLink)SetUpNavigationPanel.FindControl("LinkToUploadAndImport");
		linkToExport = (HyperLink)SetUpNavigationPanel.FindControl("LinkToExport");
	}

}
