using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoTournamental.API;
using GoTournamental.BLL.Organiser;
using GoTournamental.BLL.Planner;

namespace GoTournamental.UI.Organiser {

    public partial class ReplacementTeamForm : Page {

        #region Declare Domain Objects & Page Variables
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
		Competition competition = new Competition();
		ICompetition iCompetition = new Competition();
		ITeam iTeam = new Team();
		Team team = new Team();
        IGroup iGroup = new Group();
        List<Team> teamsInCompetition = new List<Team>();
		IFixture iFixture = new Fixture();

        #endregion

        #region Declare page controls
        Label teamFormTitle = new Label();
		Label formTitle = new Label();
        DropDownList teamsInCompetitionDropDown = new DropDownList();
        DropDownList replacementTeamsDropDown = new DropDownList();
		#endregion

        protected void Page_Load(object sender, EventArgs e) {

            AssignControlsAll();
            if (Request.QueryString.Get("TournamentID") != null) {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
				teamFormTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
            }
			if (Request.QueryString.Get("competition_id") != null) {
				competition = iCompetition.SQLSelect<Competition, int>(Int32.Parse(Request.QueryString.Get("competition_id")));
                teamsInCompetition = iTeam.GetCompetitionTeamsAll(competition.ID).OrderBy(i => i.Club.Name).ThenBy(i => i.Name).ToList();
            }

            if (teamsInCompetitionDropDown.Items.Count < 2) {
			    foreach (Team team in teamsInCompetition.Where(i => i.AttendanceType == Domains.AttendanceTypes.HostClub || i.AttendanceType == Domains.AttendanceTypes.Attending)) {
                    ListItem newItem = new ListItem(team.Club.Name + " - " + team.Name, team.ID.ToString());
                    if (team.GroupID != null) {
                        Group group = iGroup.SQLSelect<Group, int>((int)team.GroupID);
                        if (group.FixturesUnderWay != true) {
                            teamsInCompetitionDropDown.Items.Add(newItem);
                        }
                    }
                }
            }
            if (replacementTeamsDropDown.Items.Count < 2) {
			    foreach (Team team in teamsInCompetition.Where(i => i.AttendanceType == Domains.AttendanceTypes.Reserve)) {
                    replacementTeamsDropDown.Items.Add(new ListItem(team.Club.Name + " - " + team.Name, team.ID.ToString()));
                }
            }


        }
		protected void AssignControlsAll() {
			teamFormTitle = (Label)ReplacementTeamFormPanel.FindControl("TeamFormTitle");
			formTitle = (Label)ReplacementTeamFormPanel.FindControl("FormTitle");
            teamsInCompetitionDropDown = (DropDownList)ReplacementTeamFormPanel.FindControl("TeamsInCompetitionDropDown");
            replacementTeamsDropDown = (DropDownList)ReplacementTeamFormPanel.FindControl("ReplacementTeamsDropDown");
		}
 
        protected void SaveButton_Click(object sender, EventArgs e) {
            if (teamsInCompetitionDropDown.SelectedValue != "0" && replacementTeamsDropDown.SelectedValue != "0") {
                iFixture.ReplaceCancelledTeamInFixtures(Int32.Parse(teamsInCompetitionDropDown.SelectedValue), Int32.Parse(replacementTeamsDropDown.SelectedValue));
            }
		    Response.Redirect("~/UI/Competitions/CompetitionView.aspx?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competition.ID.ToString());
        }
    }

}

