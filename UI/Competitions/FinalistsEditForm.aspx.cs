using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using GoTournamental.BLL.Planner;

namespace GoTournamental.UI.Organiser {

    public partial class FinalistsEditForm : Page {

        #region Declare Domain Objects & Page Variables
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
        Competition competition = new Competition();
        ICompetition iCompetition = new Competition();
        IFixture iFixture = new Fixture();
        IClub iClub = new Club();
        ITeam iTeam = new Team();
        List<Team> teamsInFinals = new List<Team>();
        List<Team> teamsInCompetition = new List<Team>();
		#endregion

        #region Declare page controls
		Label competitionTitle = new Label();
		Label ageBand = new Label();
        DropDownList finalistTeamList = new DropDownList();
        DropDownList replacementTeamList = new DropDownList();
		#endregion

        protected void Page_Load(object sender, EventArgs e) {
           
            AssignControlsAll();

			if (Request.QueryString.Get("TournamentID") != null) {
	            tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
            }
			if (Request.QueryString.Get("competition_id") != null) {
				competition = iCompetition.SQLSelect<Competition, int>(Int32.Parse(Request.QueryString.Get("competition_id")));
				competitionTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
			}        
			ageBand.Text = "Edit Team In " + EnumExtensions.GetStringValue(competition.AgeBand) + " Finals";
            teamsInFinals = iTeam.GetCompetitionFinalsTeams(competition.ID);
            var finalsTeamsIDs = (from teams in teamsInFinals select teams.ID);
            teamsInCompetition = iTeam.GetCompetitionTeamsAll(competition.ID);
            teamsInCompetition.RemoveAll(i => finalsTeamsIDs.Contains(i.ID));

            if (finalistTeamList.Items.Count < 2) {
                foreach (Team team in teamsInFinals) {
                    Club club = iClub.SQLSelect<Club, int>(team.ClubID);
                    finalistTeamList.Items.Add(new ListItem(club.Name + " " + team.Name, team.ID.ToString()));
                }
            }
            if (replacementTeamList.Items.Count < 2) {
                foreach (Team team in teamsInCompetition) {
                    Club club = iClub.SQLSelect<Club, int>(team.ClubID);
                    replacementTeamList.Items.Add(new ListItem(club.Name + " " + team.Name, team.ID.ToString()));
                }
            }
        }

		protected void AssignControlsAll() {
			competitionTitle = (Label)FinalistsEditFormPanel.FindControl("CompetitionTitle");
			ageBand = (Label)FinalistsEditFormPanel.FindControl("AgeBand");
            finalistTeamList = (DropDownList)FinalistsEditFormPanel.FindControl("FinalistTeamList");
            replacementTeamList = (DropDownList)FinalistsEditFormPanel.FindControl("ReplacementTeamList");
		}

		protected void SaveButton_Click(object sender, EventArgs e) {
            if (finalistTeamList.SelectedValue != "0" && replacementTeamList.SelectedValue != "0") {
                iFixture.ReplaceFinalistTeamInFixtures(Int32.Parse(finalistTeamList.SelectedValue), Int32.Parse(replacementTeamList.SelectedValue));
            }
			Response.Redirect("~/UI/Competitions/CompetitionView.aspx?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competition.ID.ToString());
        }

    }

}

