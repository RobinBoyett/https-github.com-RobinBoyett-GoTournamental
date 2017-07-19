using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using GoTournamental.API;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser {

    public partial class SwapTeamsBetweenGroupsForm : Page {

        #region Declare Domain Objects & Page Variables
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
        Competition competition = new Competition();
        ICompetition iCompetition = new Competition();
        List<Group> groupsList = new List<Group>();
        IGroup iGroup = new Group();
        IClub iClub = new Club();
        IFixture iFixture = new Fixture();
        List<Team> teamsList = new List<Team>();
		Team team = new Team();
        ITeam iTeam = new Team();
		private int groupsInCompetition = 0;
		#endregion

        #region Declare page controls
		Label competitionTitle = new Label();
		Label ageBand = new Label();
		Table groupsTable = new Table();
		TableRow dropDownsTableRow = new TableRow();
		#endregion

        protected void Page_Load(object sender, EventArgs e) {
           
            AssignControlsAll();

			if (Request.QueryString.Get("TournamentID") != null) {
	            tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
            }
			if (Request.QueryString.Get("competition_id") != null) {
				competition = iCompetition.SQLSelect<Competition, int>(Int32.Parse(Request.QueryString.Get("competition_id")));
				competitionTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
				groupsList = iGroup.SQLSelectForCompetition(competition.ID);
				groupsInCompetition = competition.CountGroupsForCompetition();
			}        
			ageBand.Text = "Swap Teams Between Groups For " + EnumExtensions.GetStringValue(competition.AgeBand);


			foreach (Group group in groupsList) {
                if (group.FixturesUnderWay != true) {
                    teamsList = iTeam.SQLSelectForGroup(group.ID);
				    DropDownList groupMenu = new DropDownList();
				    groupMenu.ID = group.Name;
				    if (groupMenu.Items.Count < 2) {
					    groupMenu.Items.Add(new ListItem(group.Name, ""));
					    foreach (Team team in teamsList) {
						    Club club = iClub.SQLSelect<Club, int>(team.ClubID);
						    groupMenu.Items.Add(new ListItem(club.Name	+ " " + team.Name, team.ID.ToString()));
					    }
				    }
				    TableCell groupCell = new TableCell();
				    groupCell.Controls.Add(groupMenu);
				    dropDownsTableRow.Cells.Add(groupCell);				
                }
			}


        }

		protected void AssignControlsAll() {
			competitionTitle = (Label)SwapTeamsBetweenGroupsFormPanel.FindControl("CompetitionTitle");
			ageBand = (Label)SwapTeamsBetweenGroupsFormPanel.FindControl("AgeBand");
			groupsTable = (Table)SwapTeamsBetweenGroupsFormPanel.FindControl("GroupsTable");
			dropDownsTableRow = (TableRow)groupsTable.FindControl("DropDownsTableRow");
		}

		protected void SwapTeamsButton_Click(object sender, EventArgs e) {
			Team teamOne = new Team();
			Team teamTwo = new Team();
			DropDownList group1 = (DropDownList)dropDownsTableRow.FindControl("Group 1");
			if (group1 != null && group1.SelectedIndex > 0) {
				if (teamOne.ID == 0) {
					teamOne = iTeam.SQLSelect<Team, int>(Int32.Parse(group1.SelectedValue));
				}
			}
			if (groupsInCompetition >= 2) {
				DropDownList group2 = (DropDownList)dropDownsTableRow.FindControl("Group 2");
				if (group2 != null && group2.SelectedIndex > 0 && teamOne.ID == 0) {
					teamOne = iTeam.SQLSelect<Team, int>(Int32.Parse(group2.SelectedValue));
				}
				else if (group2.SelectedIndex > 0 && teamTwo.ID == 0) {
					teamTwo = iTeam.SQLSelect<Team, int>(Int32.Parse(group2.SelectedValue));
				}
			}			
			if (groupsInCompetition >= 3) {
				DropDownList group3 = (DropDownList)dropDownsTableRow.FindControl("Group 3");
				if (group3 != null && group3.SelectedIndex > 0 && teamOne.ID == 0) {
					teamOne = iTeam.SQLSelect<Team, int>(Int32.Parse(group3.SelectedValue));
				}
				else if (group3.SelectedIndex > 0 && teamTwo.ID == 0) {
					teamTwo = iTeam.SQLSelect<Team, int>(Int32.Parse(group3.SelectedValue));
				}
			}
			if (groupsInCompetition > 3) {
				DropDownList group4 = (DropDownList)dropDownsTableRow.FindControl("Group 4");
				if (group4 != null && group4.SelectedIndex > 0 && teamTwo.ID == 0) {
					teamTwo = iTeam.SQLSelect<Team, int>(Int32.Parse(group4.SelectedValue));
				}
			}
			if (teamOne.ID != 0 && teamTwo.ID != 0) {
				iCompetition.SwapTeamsBetweenGroupsWithCascadeToFixtures(teamOne.ID, teamTwo.ID);
			}

		    Response.Redirect("~/UI/Competitions/CompetitionView.aspx?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competition.ID.ToString());


		}

    }

}

