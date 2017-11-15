using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using GoTournamental.BLL.Planner;

namespace GoTournamental.UI.Organiser {

    public partial class CompetitionsList : Page {

        #region Declare domain objects
 		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
		Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
        List<Competition> competitions = new List<Competition>();
		ICompetition iCompetition = new Competition();
		List<Club> clubs = new List<Club>();
		IClub iClub = new Club();
		List<GoTournamental.BLL.Organiser.Contact> contacts = new List<GoTournamental.BLL.Organiser.Contact>();
		GoTournamental.BLL.Organiser.IContact iContact = new GoTournamental.BLL.Organiser.Contact();
		#endregion

		#region Declare page controls
		Label competitionsListTitle = new Label();
		HyperLink linkToCompetitionsAdd = new HyperLink();
        #endregion

        protected void Page_Load(object sender, EventArgs e) {

			AssignControlsAll();

            if (Request.QueryString.Get("TournamentID") != null) {
	            tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
 				competitionsListTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
				competitions = iCompetition.SQLSelectForTournament(tournament.ID, false);
				clubs = iClub.SQLSelectClubsForTournament(tournament.ID);
				contacts = iContact.SQLSelectForTournament(tournament.ID);
            }


			if (competitions.Count < Enum.GetNames(typeof(Competition.AgeBands)).Length) {
				linkToCompetitionsAdd.NavigateUrl = "~/UI/Competitions/CompetitionsForm.aspx?TournamentID="+tournament.ID.ToString();
			}
			if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
				linkToCompetitionsAdd.Visible = true;
			}

            CompetitionsListGridView.DataSource = competitions;
            CompetitionsListGridView.DataBind();

        }

		protected void AssignControlsAll() {
			competitionsListTitle = (Label)CompetitionsListPanel.FindControl("CompetitionsListTitle");
			linkToCompetitionsAdd = (HyperLink)CompetitionsListPanel.FindControl("LinkToCompetitionsAdd");
        }

        protected void CompetitionsListGridView_RowDataBound(Object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                Competition competition = (Competition)e.Row.DataItem;
                HyperLink competitionLink = (HyperLink)e.Row.FindControl("CompetitionViewLink");
                competitionLink.Text = EnumExtensions.GetStringValue(competition.AgeBand);
                competitionLink.NavigateUrl = "~/UI/Competitions/CompetitionView?TournamentID="+tournament.ID.ToString()+"&competition_id=" + competition.ID.ToString();
				if (competition.StartTime != null && competition.CountFixturesForCompetition() > 0) {
					e.Row.Cells[1].Text = competition.StartTime.Value.ToString("ddd d MMM,") + "&nbsp;&nbsp;&nbsp;" + competition.StartTime.Value.ToShortTimeString() + " - " ;
				}
				
				if (competition.StartTime != null) {
	                e.Row.Cells[1].Text = competition.StartTime.Value.ToString("ddd d MMM,") + "&nbsp;&nbsp;&nbsp;" + competition.StartTime.Value.ToShortTimeString();
				}

                e.Row.Cells[2].Text = competition.CountTeamsAttendingCompetition().ToString();
                e.Row.Cells[3].Text = competition.CountTeamsRegisteredAtCompetition().ToString();
                e.Row.Cells[4].Text = competition.CountGroupsForCompetition().ToString();
				e.Row.Cells[5].Text = competition.CountPlayingAreasForCompetition().ToString();
            }
        }


    }

}

