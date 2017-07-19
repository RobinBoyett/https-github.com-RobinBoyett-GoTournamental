using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.API;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser {

    public partial class CompetitionRegister : Page {

        #region Declare Domain Objects & Page Variables
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        ITournament iTournament = new Tournament();
        Tournament tournament = new Tournament();
        ICompetition iCompetition = new Competition();
		Competition competition = new Competition();
        ITeam iTeam = new Team();
        List<Team> teamsList = new List<Team>();


        #endregion

        #region Declare page controls
        Label tournamentTitle = new Label();
		CheckBoxList teamsInCompetitionList = new CheckBoxList();
		#endregion

        protected void Page_Load(object sender, EventArgs e) {

            AssignControlsAll();

			if (Request.QueryString.Get("TournamentID") != null) {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
 				tournamentTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
			}
			if (Request.QueryString.Get("competition_id") != null) {
				competition = iCompetition.SQLSelect<Competition, int>(Int32.Parse(Request.QueryString.Get("competition_id")));
                teamsList = iTeam.SQLSelectForCompetition(competition.ID).OrderBy(i => i.Club.Name).ThenBy(i => i.Name).ToList();
            }
			if (teamsInCompetitionList.Items.Count < 2) {
                foreach (Team team in teamsList) {
                    teamsInCompetitionList.Items.Add(new ListItem("&nbsp;" + team.Club.Name + " " + team.Name, team.ID.ToString()));
                }
			}
            if (!IsPostBack) {
                for (int i = 0; i < teamsInCompetitionList.Items.Count; i++ ) {
                    foreach (Team team in teamsList) {
                        if (teamsInCompetitionList.Items[i].Value == team.ID.ToString() && team.Registered == true) {
                            teamsInCompetitionList.Items[i].Selected = true; 
                        }
                    }
                }
            }
        }

		protected void AssignControlsAll() {
			tournamentTitle = (Label)CompetitionRegisterPanel.FindControl("TournamentTitle");
			teamsInCompetitionList = (CheckBoxList)CompetitionRegisterPanel.FindControl("TeamsInCompetitionList");
        }

        protected void SaveButton_Click(object sender, EventArgs e) {
            foreach (ListItem li in teamsInCompetitionList.Items) {
                if (li.Selected == true) {
                    iTeam.SQLUpdateRegistration(Int32.Parse(li.Value), true);
                }
                else {
                    iTeam.SQLUpdateRegistration(Int32.Parse(li.Value), false);
                }
            }
            Response.Redirect("~/UI/Competitions/CompetitionView?TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString());
        }

    }

}

