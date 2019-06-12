using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using GoTournamental.API.Identity;
using GoTournamental.BLL.Organiser;

public partial class TournamentMenu : System.Web.UI.UserControl
{

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
	HyperLink linkToTournament = new HyperLink();
	HyperLink linkToFixtures = new HyperLink();
	HyperLink linkToCompetitionRotator = new HyperLink();
 	HyperLink linkToDocuments = new HyperLink();
	HyperLink linkToSponsorsList = new HyperLink();
	#endregion

	protected void Page_Load(object sender, EventArgs e)
    {

		AssignUIControls();

        if (Request.QueryString.Get("TournamentID") != null)
        {
	        tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
			competitions = iCompetition.SQLSelectForTournament(tournament.ID, false);
			contacts = iContact.SQLSelectForTournament(tournament.ID);
        }

		// Disable navigation if a tournament is still undefined
		if (Request.RawUrl.Contains("TournamentForm?Version=1"))
        {
			linkToTournament.Visible = false;
			linkToFixtures.Visible = false;
			linkToCompetitionRotator.Visible = false;
			linkToDocuments.Visible = false;
			linkToSponsorsList.Visible = false;
		}
		else
        {
			linkToTournament.NavigateUrl = "~/UI/Planner/TournamentView.aspx?TournamentID=" + tournament.ID.ToString();

            if (tournament.StartTime <= DateTime.Now) 
            {
                linkToFixtures.Visible = true;
			    linkToFixtures.NavigateUrl = "~/UI/Competitions/FixturesList.aspx?TournamentID=" + tournament.ID.ToString();
            }
			linkToCompetitionRotator.NavigateUrl = "~/UI/Competitions/CompetitionRotator.aspx?TournamentID=" + tournament.ID.ToString();
			
			linkToDocuments.NavigateUrl = "~/UI/Utilities/DocumentsList.aspx?TournamentID=" + tournament.ID.ToString();
			linkToSponsorsList.NavigateUrl = "~/UI/Adverts/SponsorsList.aspx?TournamentID=" + tournament.ID.ToString();
            
		}


	}
	
	protected void AssignUIControls()
    {
		linkToTournament = (HyperLink)TournamentNavigationPanel.FindControl("LinkToTournament");
		linkToFixtures = (HyperLink)TournamentNavigationPanel.FindControl("LinkToFixtures");
		linkToCompetitionRotator = (HyperLink)TournamentNavigationPanel.FindControl("LinkToCompetitionRotator");
		linkToDocuments = (HyperLink)TournamentNavigationPanel.FindControl("LinkToDocuments");
		linkToSponsorsList = (HyperLink)TournamentNavigationPanel.FindControl("LinkToSponsorsList");
	}

}
