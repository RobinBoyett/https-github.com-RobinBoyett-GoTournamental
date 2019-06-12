using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Planner;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Planner 
{

    public partial class ClubsList : Page
    {

        #region Declare domain objects
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
 		List<Competition> competitions = new List<Competition>();
		Competition competition = new Competition();
		ICompetition iCompetition = new Competition();
		List<Club> clubs = new List<Club>();
		IClub iClub = new Club();
		Club club = new Club();
		List<GoTournamental.BLL.Organiser.Contact> contacts = new List<GoTournamental.BLL.Organiser.Contact>();
		GoTournamental.BLL.Organiser.IContact iContact = new GoTournamental.BLL.Organiser.Contact();
		Team team = new Team();
		ITeam iTeam = new Team();
        List<Team> teamsList = new List<Team>();
        DataList clubsDataList = new DataList();

		int competitionID = 0;
        private bool isDemoTournament = false;

        private RequestVersion pageVersion = RequestVersion.Undefined;
        protected enum RequestVersion 
        {
            Undefined = 0,
            TeamsList = 1,
			TeamDelete = 2,
            ClubDelete = 3
        }		
		#endregion
		#region Declare UI Controls
		Label teamDirectoryTitle = new Label();
		#endregion

		protected void Page_Load(object sender, EventArgs e) 
        {

            AssignUIControls();

			if (Request.QueryString.Get("version") != null)
            {
                pageVersion = (RequestVersion)Int32.Parse(Request.QueryString.Get("version"));
            }
			if (Request.QueryString.Get("TournamentID") != null)
            {
	            tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
                if (tournament.ID == 1)
                {
                    isDemoTournament = true;
                }
 				teamDirectoryTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
				competitions = iCompetition.SQLSelectForTournament(tournament.ID, false);
				clubs = iClub.SQLSelectClubsForTournament(tournament.ID).Where(i => i.AttendanceType != API.Domains.AttendanceTypes.Deleted).ToList();
				contacts = iContact.SQLSelectForTournament(tournament.ID);
                if (tournament.ID > 1 && !identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString()))
                {
                    throw new Exception("Unauthorised access to tournament admin page.");
                }

			}
			if (Request.QueryString.Get("team_id") != null) 
            {
                team = iTeam.SQLSelect<Team, int>(Int32.Parse(Request.QueryString.Get("team_id")));
            }
			if (Request.QueryString.Get("club_id") != null) 
            {
                club = iClub.SQLSelect<Club, int>(Int32.Parse(Request.QueryString.Get("club_id")));
            }
			if (Request.QueryString.Get("competition_id") != null)
            {
				competitionID = Int32.Parse(Request.QueryString.Get("competition_id"));
				clubs = iClub.GetCompetitionClubsAll(competitionID).Where(i => i.AttendanceType != API.Domains.AttendanceTypes.Deleted).OrderBy(i => i.Name).ToList();
			}

			LinkToClubsAdd.NavigateUrl = "~/UI/Planner/ClubForm.aspx?version=1&TournamentID=" + tournament.ID.ToString();
			if (isDemoTournament || identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString()))
            {
				LinkToClubsAdd.Visible = true;
			}

            ManagePageVersion(pageVersion);

        }

		protected void AssignUIControls()
        {
			teamDirectoryTitle = (Label)ClubsListPanel.FindControl("TeamDirectoryTitle");
		}
        protected void ManagePageVersion(RequestVersion pageVersion)
        {
			switch (pageVersion)
            {
				case RequestVersion.TeamDelete:
                    if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) 
                    {
					    iTeam.SQLDeleteWithCascade<Team>(team);
                    }
					Response.Redirect("~/UI/Planner/ClubsList.aspx?version=1&TournamentID="+tournament.ID.ToString());
					break;
				case RequestVersion.ClubDelete:
                    if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString()))
                    {
					    iClub.SQLDeleteWithCascade<Club>(club);
                    }
					Response.Redirect("~/UI/Planner/ClubsList.aspx?version=1&TournamentID="+tournament.ID.ToString());
					break;
                case RequestVersion.TeamsList:
					clubsDataList = (DataList)ClubsListPanel.FindControl("ClubsDataList");
					clubsDataList.DataSource = clubs;
					clubsDataList.DataBind();
                    break;

			}
        }

        protected void ClubsDataList_ItemDataBound(Object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Club club = (Club)e.Item.DataItem;
				HyperLink requestDeleteClubLink = (HyperLink)e.Item.FindControl("RequestDeleteClubLink");
				requestDeleteClubLink.Attributes.Add("onclick","javascript:return confirm('Are you sure you want to delete this Club? All the relevant teams and fixtures will also deleted.')");
			    if (isDemoTournament || identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString()))
                {
                    requestDeleteClubLink.NavigateUrl = "ClubsList.aspx?version=3&TournamentID=" + tournament.ID.ToString() + "&club_id="+club.ID.ToString();
                }       
                Table colourTable = (Table)e.Item.FindControl("ColourTable");
                TableRow colourTableRow = (TableRow)colourTable.FindControl("ColourTableRow");
                TableCell clubAndTeamNameCell = (TableCell)colourTableRow.FindControl("ClubAndTeamNameCell");

                TableCell colourPrimaryCell = (TableCell)colourTableRow.FindControl("ColourPrimaryCell");
                if (club.ColourPrimary != null) 
                {
                    colourPrimaryCell.BackColor = Color.FromName(club.ColourPrimary.ToString());
                }
                TableCell colourSecondaryCell = (TableCell)colourTableRow.FindControl("ColourSecondaryCell");
                if (club.ColourSecondary != null)
                {
                    colourSecondaryCell.BackColor = Color.FromName(club.ColourSecondary.ToString());
                }

                HyperLink linkToClubEdit = (HyperLink)e.Item.FindControl("LinkToClubEdit");
				if (tournament.HostClub.ID == club.ID)
                {
					linkToClubEdit.Text = club.Name + " - Tournament Hosts";
				}
				else 
                {
					linkToClubEdit.Text = club.Name;
				}
			    if (isDemoTournament || identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString()))
                {
					linkToClubEdit.NavigateUrl = "~/UI/Planner/ClubForm.aspx?version=2&TournamentID="+tournament.ID.ToString()+"&club_id="+club.ID.ToString();
				}
				HyperLink linkToClubItinary = (HyperLink)e.Item.FindControl("LinkToClubItinary");
				linkToClubItinary.NavigateUrl = "~/UI/Competitions/FixturesList?TournamentID="+tournament.ID.ToString()+"&club_id="+club.ID.ToString();

				HyperLink linkToTeamsAdd = (HyperLink)e.Item.FindControl("LinkToTeamsAdd");
				linkToTeamsAdd.NavigateUrl = "~/UI/Teams/TeamForm.aspx?version=1&TournamentID="+tournament.ID.ToString()+"&club_id="+club.ID.ToString();
			    if (isDemoTournament || identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString()))
                {
					requestDeleteClubLink.Visible = true;
					linkToTeamsAdd.Visible = true;
				}

                DataList teamsListForClub = (DataList)e.Item.FindControl("TeamsListForClub");
                if (competitionID == 0)
                {
                    if (club.Teams != null && club.Teams.Count > 0) 
                    {
                        teamsList = club.Teams.Where(i => i.AttendanceType != API.Domains.AttendanceTypes.Deleted).OrderBy(i => i.CompetitionID).ThenBy(i => i.Name).ToList();
                        teamsListForClub.DataSource = teamsList;
                        teamsListForClub.DataBind();
                    }
                } 
                else
                {
                    teamsList = iTeam.GetCompetitionTeamsAll(competitionID).Where(i => i.ClubID == club.ID && i.AttendanceType != API.Domains.AttendanceTypes.Deleted).OrderBy(i => i.Name).ToList();
                    teamsListForClub.DataSource = teamsList;
                    teamsListForClub.DataBind();
                }
            }
        }
        protected void TeamsListForClub_ItemDataBound(Object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
            {
                Team team = (Team)e.Item.DataItem;
				Club club = iClub.SQLSelect<Club, int>(team.ClubID);
				HyperLink requestDeleteTeamLink = (HyperLink)e.Item.FindControl("RequestDeleteTeamLink");
				requestDeleteTeamLink.Attributes.Add("onclick","javascript:return confirm('Are you sure you want to delete this Team? All the relevant fixtures will also deleted.')");
				requestDeleteTeamLink.NavigateUrl = "ClubsList.aspx?version=2&TournamentID=" + tournament.ID.ToString() + "&team_id="+team.ID.ToString();
                HyperLink linkToTeamEdit = (HyperLink)e.Item.FindControl("LinkToTeamEdit");

                linkToTeamEdit.Text = team.Name;
			    if (isDemoTournament || identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) 
                {
					requestDeleteTeamLink.Visible = true;
					linkToTeamEdit.NavigateUrl = "~/UI/Teams/TeamForm.aspx?version=2&TournamentID="+tournament.ID.ToString()+"&club_id="+club.ID.ToString()+"&team_id="+team.ID.ToString();
				}
				HyperLink linkToTeamItinary = (HyperLink)e.Item.FindControl("LinkToTeamItinary");
				linkToTeamItinary.NavigateUrl = "~/UI/Competitions/FixturesList?TournamentID="+tournament.ID.ToString()+"&club_id="+club.ID.ToString()+"&team_id="+team.ID.ToString();
				
				Label contactName = (Label)e.Item.FindControl("ContactName");
				Label competitionName = (Label)e.Item.FindControl("CompetitionName");
                Competition competition = new Competition();
				ICompetition iCompetition = new Competition();
				if (team.CompetitionID != null)
                {
					competition = iCompetition.SQLSelect<Competition, int>((int)team.CompetitionID);
					if (competition != null)
                    {
						competitionName.Text = EnumExtensions.GetStringValue(competition.AgeBand);
					}
				}
                Label groupName = (Label)e.Item.FindControl("GroupName");
                Group group = new Group();
                IGroup iGroup = new Group();
				if (team.GroupID != null)
                {
	                group = iGroup.SQLSelect<Group, int>((int)team.GroupID);
				}
				Label attendance = (Label)e.Item.FindControl("Attendance");
				attendance.Text = EnumExtensions.GetStringValue(team.AttendanceType);
				if (team.PrimaryContactID != null) 
                {
					contactName.Text = team.PrimaryContact.FirstName + " " + team.PrimaryContact.LastName;
				}
            }
        }

    }

}

