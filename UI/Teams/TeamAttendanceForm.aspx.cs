using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoTournamental.API;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using GoTournamental.BLL.Planner;

namespace GoTournamental.UI.Organiser {

    public partial class TeamAttendanceForm : Page {

	    #region Member Enumerations
	    public enum OrderBy {
		    Undefined = 0,
		    AgeBand = 1,
            Club = 2,                   
		    Attendance = 3                      
	    }
        #endregion

        #region Declare Domain Objects & Page Variables
 		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
		Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
        Domains.AttendanceTypes attendanceType = new Domains.AttendanceTypes();
		ITeam iTeam = new Team();
		List<Team> teamsList = new List<Team>();
        int competitionID = 0;
        OrderBy orderBy = new OrderBy();
        #endregion

        #region Declare page controls
        Label teamAttendanceTitle = new Label();
        DropDownList orderByList = new DropDownList();
        GridView teamAttendanceGridView = new GridView();
		#endregion

        protected void Page_Load(object sender, EventArgs e) {

            AssignControlsAll();

            if (Request.QueryString.Get("TournamentID") != null) {
	            tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
    			teamAttendanceTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
			}

            if (!IsPostBack) {
                orderBy = OrderBy.Undefined;
            }
            else {
                switch (orderByList.SelectedValue) {
                     case "AgeBand":
                        orderBy = OrderBy.AgeBand;
                        break;
                     case "Attendance":
                        orderBy = OrderBy.Attendance;
                        break;
                     case "Club":
                        orderBy = OrderBy.Club;
                        break;
                    default:
                        orderBy = OrderBy.Undefined;
                        break;
                }
            }
            if (!IsPostBack) {
                BindTeams();
            }

        }

		protected void AssignControlsAll() {
			teamAttendanceTitle = (Label)TeamAttendancePanel.FindControl("TeamAttendanceTitle");
            orderByList = (DropDownList)TeamAttendancePanel.FindControl("OrderByList");
            teamAttendanceGridView = (GridView)TeamAttendancePanel.FindControl("TeamAttendanceGridView");
		}

        protected void BindTeams() {
            switch (orderBy) {
                 case OrderBy.AgeBand:
                    teamsList = iTeam.SQLSelectForTournament(tournament.ID).OrderBy(i => i.CompetitionID).ToList();
                    break;
                 case OrderBy.Attendance:
                    teamsList = iTeam.SQLSelectForTournament(tournament.ID).OrderBy(i => i.AttendanceType).ToList();
                    break;
                case OrderBy.Club:
                    teamsList = iTeam.SQLSelectForTournament(tournament.ID).OrderBy(i => i.Club.Name).ToList();
                    break;
                case OrderBy.Undefined:
                default:
                    teamsList = iTeam.SQLSelectForTournament(tournament.ID);
                    break;
            }
            teamAttendanceGridView.DataSource = teamsList;
            teamAttendanceGridView.DataBind();
        }

        protected void TeamAttendanceGridView_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                Team team = (Team)e.Row.DataItem;
				IClub iclub = new Club();
                ICompetition iCompetition = new Competition();
				HyperLink linkToCompetition = (HyperLink)e.Row.FindControl("LinkToCompetition");
                HyperLink linkToClubEdit = (HyperLink)e.Row.FindControl("LinkToClubEdit");
                HyperLink linkToTeamEdit = (HyperLink)e.Row.FindControl("LinkToTeamEdit");
                //HyperLink linkToTeamEdit2 = (HyperLink)e.Row.FindControl("LinkToTeamEdit2");

                linkToCompetition.Text = EnumExtensions.GetStringValue(iCompetition.SQLSelect<Competition, int>((int)team.CompetitionID).AgeBand);
                linkToCompetition.NavigateUrl = "~/UI/Competitions/CompetitionView?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + team.CompetitionID.ToString();
                linkToClubEdit.Text = (iclub.SQLSelect<Club, int>(team.ClubID)).Name;
                linkToClubEdit.NavigateUrl = "~/UI/Planner/ClubForm?version=2&TournamentID=" + tournament.ID.ToString() + "&club_id=" + team.ClubID.ToString();
                linkToTeamEdit.Text = team.Name;
                linkToTeamEdit.NavigateUrl = "~/UI/Teams/TeamForm?version=2&TournamentID=" + tournament.ID.ToString() + "&club_id=" + team.ClubID.ToString() + "&team_id=" + team.ID.ToString();

                //UI/Teams/TeamForm?version=2&TournamentID=1&club_id=1&team_id=1

                if (teamAttendanceGridView.EditIndex == -1) { // gridview NOT in edit mode
                    Label attendanceLabel = (Label)e.Row.FindControl("AttendanceLabel");
                    attendanceLabel.Text = EnumExtensions.GetStringValue(team.AttendanceType);
                    //linkToTeamEdit2.Text = "Edit";
                    //linkToTeamEdit2.NavigateUrl = "~/UI/Teams/TeamForm?version=2&TournamentID=" + tournament.ID.ToString() + "&club_id=" + team.ClubID.ToString() + "&team_id=" + team.ID.ToString();
                }
                if ((e.Row.RowState & DataControlRowState.Edit) > 0) {
                    HiddenField teamIDHidden = (HiddenField)e.Row.FindControl("TeamIDHidden");
                    DropDownList attendanceTypesList = (DropDownList)e.Row.FindControl("AttendanceTypesList");
                    teamIDHidden.Value = team.ID.ToString();

                    Array enumValues = Enum.GetValues(typeof(Domains.AttendanceTypes));
                    foreach (Enum type in enumValues) {
                        if (EnumExtensions.GetIntValue(type) > 0 && EnumExtensions.GetStringValue(type) != "Deleted") {
                            attendanceTypesList.Items.Add(new ListItem(EnumExtensions.GetStringValue(type), EnumExtensions.GetIntValue(type).ToString()));
                        }
                    }
                    attendanceTypesList.SelectedValue = EnumExtensions.GetIntValue(team.AttendanceType).ToString();
                }
			}
		}
        protected void TeamAttendanceGridView_RowEditing(object sender, GridViewEditEventArgs e) {
            teamAttendanceGridView.EditIndex = e.NewEditIndex;
            BindTeams();
        }
        protected void TeamAttendanceGridView_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            HiddenField teamIDHidden = (HiddenField)teamAttendanceGridView.Rows[e.RowIndex].FindControl("TeamIDHidden");
            DropDownList attendanceTypesList = (DropDownList)teamAttendanceGridView.Rows[e.RowIndex].FindControl("AttendanceTypesList");
            iTeam.SQLUpdateAttendanceType(Int32.Parse(teamIDHidden.Value), (Domains.AttendanceTypes)Int32.Parse(attendanceTypesList.SelectedValue));
            teamAttendanceGridView.EditIndex = -1;
            BindTeams();
        }
        protected void TeamAttendanceGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            teamAttendanceGridView.EditIndex = -1;
            BindTeams();
        }
	
    }

}

