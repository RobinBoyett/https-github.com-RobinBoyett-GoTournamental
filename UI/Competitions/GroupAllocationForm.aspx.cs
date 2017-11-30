using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using GoTournamental.BLL.Planner;

namespace GoTournamental.UI.Organiser {

    public partial class GroupAllocationForm : Page {

        #region Declare Domain Objects & Page Variables
 		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
        Competition competition = new Competition();
        ICompetition iCompetition = new Competition();
        Competition competitionToSave = new Competition();
        List<Group> groupsList = new List<Group>();
        IGroup iGroup = new Group();
		List<Club> clubs = new List<Club>();
        IClub iClub = new Club();
        List<Team> teamsList = new List<Team>();
		Team team = new Team();
        ITeam iTeam = new Team();
        List<PlayingArea> playingAreaList = new List<PlayingArea>();
		List<PlayingArea> playingAreasInUseInSession = new List<PlayingArea>();
        IPlayingArea iPlayingArea = new PlayingArea();
		IGroupPlayingArea iGroupPlayingArea = new GroupPlayingArea();
        Fixture fixture = new Fixture();
        IFixture iFixture = new Fixture();
        List<Fixture> fixturesList = new List<Fixture>();

		private string hourText = "";
		private string minuteText = "";
		private string startTimeText = "";
		private int groupsInCompetition = 0;
		private int groupID = 0;

        private RequestVersion pageVersion = RequestVersion.Undefined;
        protected enum RequestVersion {
            Undefined = 0,
            CompetitionEdit = 1,
			TeamDelete = 2,
			ReCalculateFixtures = 3,
			ReCalculateGroups = 4
        }
        #endregion

        #region Declare page controls
		Label competitionTitle = new Label();
		Label ageBand = new Label();
		HyperLink linkToCompetitionSummary = new HyperLink();
 		Label noTeamsAttending = new Label();
		Label noGroupsInCompetition = new Label();
		Label noFixturesInCompetition = new Label();
        HyperLink replaceATeamLink = new HyperLink();
		HyperLink swapTeamsBetweenGroupsLink = new HyperLink();
		Panel competitionEditButtonPanel = new Panel();
		Panel groupAllocationPanel = new Panel();
		DropDownList competitionNoGroups = new DropDownList();
		RequiredFieldValidator competitionNoGroupsMandatory = new RequiredFieldValidator();
        CheckBoxList playingAreasList = new CheckBoxList();
		CustomValidator playingAreasMandatory = new CustomValidator();
        DataList groupsDataList = new DataList();
		Panel groupsEditPanel = new Panel();
		Button allocateTeamsToGroups = new Button();
        Button reAllocateTeamsIntoNewGroups = new Button();
		Button generateFixturesButton = new Button();
		Button saveButton = new Button();
		#endregion

        protected void Page_Load(object sender, EventArgs e) {

            AssignControlsAll();

			if (Request.QueryString.Get("version") != null) {
                pageVersion = (RequestVersion)Int32.Parse(Request.QueryString.Get("version"));
            }
            if (Request.QueryString.Get("TournamentID") != null) {
	            tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
				playingAreaList = iPlayingArea.SQLSelectForTournament(tournament.ID).OrderBy(i => i.ID).ToList();
            }
			if (Request.QueryString.Get("competition_id") != null) {
				competition = iCompetition.SQLSelect<Competition, int>(Int32.Parse(Request.QueryString.Get("competition_id")));
				competitionTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
				linkToCompetitionSummary.NavigateUrl = "~/UI/Competitions/CompetitionView.aspx?TournamentID=" + tournament.ID.ToString() + "&competition_id="+competition.ID.ToString();
				playingAreasInUseInSession = iPlayingArea.SQLSelectInUseForTournamentSession(tournament.ID, competition.ID);
            }        
			if (Request.QueryString.Get("team_id") != null) {
                team = iTeam.SQLSelect<Team, int>(Int32.Parse(Request.QueryString.Get("team_id")));
            }

            ManagePageVersion(pageVersion);

        }
		protected void AssignControlsAll() {
			competitionTitle = (Label)GroupAllocationFormPanel.FindControl("CompetitionTitle");
			ageBand = (Label)GroupAllocationFormPanel.FindControl("AgeBand");
			linkToCompetitionSummary = (HyperLink)GroupAllocationFormPanel.FindControl("LinkToCompetitionSummary");
			noTeamsAttending = (Label)GroupAllocationFormPanel.FindControl("NoTeamsAttending");
			noGroupsInCompetition = (Label)GroupAllocationFormPanel.FindControl("NoGroupsInCompetition");
			noFixturesInCompetition = (Label)GroupAllocationFormPanel.FindControl("NoFixturesInCompetition");
            replaceATeamLink = (HyperLink)GroupAllocationFormPanel.FindControl("ReplaceATeamLink");
			swapTeamsBetweenGroupsLink = (HyperLink)GroupAllocationFormPanel.FindControl("SwapTeamsBetweenGroupsLink");
			competitionEditButtonPanel = (Panel)GroupAllocationFormPanel.FindControl("CompetitionEditButtonPanel");
			groupAllocationPanel = (Panel)GroupAllocationFormPanel.FindControl("GroupAllocationPanel");
			competitionNoGroups = (DropDownList)GroupAllocationFormPanel.FindControl("CompetitionNoGroups");
 			competitionNoGroupsMandatory = (RequiredFieldValidator)GroupAllocationFormPanel.FindControl("CompetitionNoGroupsMandatory");
            playingAreasList = (CheckBoxList)GroupAllocationFormPanel.FindControl("PlayingAreasList");
 			playingAreasMandatory = (CustomValidator)GroupAllocationFormPanel.FindControl("PlayingAreasMandatory");
			groupsEditPanel = (Panel)GroupAllocationFormPanel.FindControl("GroupsEditPanel");
            groupsDataList = (DataList)GroupAllocationFormPanel.FindControl("GroupsDataList");
			allocateTeamsToGroups = (Button)GroupAllocationFormPanel.FindControl("AllocateTeamsToGroups");
            reAllocateTeamsIntoNewGroups = (Button)GroupAllocationFormPanel.FindControl("ReAllocateTeamsIntoNewGroups");
			generateFixturesButton = (Button)GroupAllocationFormPanel.FindControl("GenerateFixturesButton");
			saveButton = (Button)GroupAllocationFormPanel.FindControl("SaveButton");
        }
        protected void ManagePageVersion(RequestVersion pageVersion) {
			switch (pageVersion) {
				case RequestVersion.ReCalculateGroups:
                    CompetitionEditFormLoad();
					break;
                case RequestVersion.ReCalculateFixtures:
                    if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
                        iFixture.DeleteFixturesForCompetition(competition.ID);
	    				iFixture.GenerateFixturesForCompetition(tournament, competition);		
                    }
					Response.Redirect("~/UI/Competitions/CompetitionView.aspx?TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString());
                    break;
				case RequestVersion.TeamDelete:
                    if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
					    iTeam.SQLDeleteWithCascade<Team>(team);
					    iFixture.DeleteFixturesForCompetition(competition.ID);
					    iFixture.GenerateFixturesForCompetition(tournament, competition);		
                    }
                    Response.Redirect("~/UI/Competitions/CompetitionView.aspx?TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString());
					break;
                case RequestVersion.CompetitionEdit:
                    CompetitionEditFormLoad();
                    break;
            }
        }

        protected void CompetitionEditFormLoad() {
			ageBand.Text = EnumExtensions.GetStringValue(competition.AgeBand);
			if (!IsPostBack) {
				noTeamsAttending.Text = competition.CountTeamsAttendingCompetition().ToString();

                
                replaceATeamLink.NavigateUrl = "~/UI/Teams/ReplacementTeamForm.aspx?TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString();
                swapTeamsBetweenGroupsLink.NavigateUrl = "~/UI/Competitions/SwapTeamsBetweenGroupsForm.aspx?TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString();
				
				if (pageVersion == RequestVersion.ReCalculateGroups || (
					competition.CountTeamsAttendingCompetition() > 0 && competition.StartTime != null && competition.CompetitionFormat != null && 
					competition.Session != null && competition.Session != Competition.Sessions.Undefined &&
					competition.FixtureTurnaround != null && competition.FixtureTurnaround != Tournament.FixtureTurnarounds.Undefined && 
					competition.CompetitionFormat != null && competition.CompetitionFormat != Competition.CompetitionFormats.Undefined
				)) {
					groupsEditPanel.Visible = true;
					competitionNoGroupsMandatory.Enabled = true;
					playingAreasMandatory.Enabled = true;
				}

				if (competition.CountGroupsForCompetition() == 0 || pageVersion == RequestVersion.ReCalculateGroups) {
					groupAllocationPanel.Visible = true;
					competitionNoGroups.Items[0].Text = "Select number of Groups";
					Array groupEnum = Enum.GetValues(typeof(Group.NumberOfGroups));
					if (competitionNoGroups.Items.Count < 2) {
						foreach (Enum type in groupEnum) {
							if (EnumExtensions.GetIntValue(type) > 0) {
								competitionNoGroups.Items.Add(new ListItem(EnumExtensions.GetIntValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
							}
						}
					}
					int i = 0;
					foreach (PlayingArea playingArea in playingAreaList) {
						playingAreasList.Items.Add(new ListItem("&nbsp;"+playingArea.Name, playingArea.ID.ToString()));
						foreach (PlayingArea playingAreaUsed in playingAreasInUseInSession) {
							if (playingArea.ID == playingAreaUsed.ID) {
								playingAreasList.Items[i].Enabled = false;
							}
						}
						i++;
					}
					swapTeamsBetweenGroupsLink.Visible = false;
                    replaceATeamLink.Visible = false;
				}
				else {
					noGroupsInCompetition.Text = competition.CountGroupsForCompetition().ToString();
				}

				if (competition.CountTeamsAttendingCompetition() > 0 && competition.CountGroupsForCompetition() == 0) {
					noGroupsInCompetition.Text = "The teams are not allocated to Groups";
				}
                else if (!competition.FixturesUnderwayForCompetition()) {
                    reAllocateTeamsIntoNewGroups.Visible = true;
                }

				if (competition.CountGroupsForCompetition() > 0 && competition.CountFixturesForCompetition() == 0) {
					generateFixturesButton.Visible = true;
                    generateFixturesButton.Text = "Generate Fixtures For All Groups";
				}
				else if (!competition.FixturesUnderwayForCompetition() && iCompetition.CountGroupsForCompetition(competition.ID) > 0 && (iCompetition.CountGroupsForCompetition(competition.ID) != competition.CountGroupsForCompetitionWhereFixturesUnderway(competition.ID))) {
					generateFixturesButton.Visible = true;
                    generateFixturesButton.Text = "Generate Fixtures For All Groups";
				}

				if (competition.CountFixturesForCompetition() > 0 &&  pageVersion != RequestVersion.ReCalculateGroups) {
					noFixturesInCompetition.Text = competition.CountFixturesForCompetition().ToString() + " - You can still regenerate fixtures for groups where the fixtures are not underway.";
				}
				else if (pageVersion != RequestVersion.ReCalculateGroups) {
					noFixturesInCompetition.Text = "The Fixtures have not yet been generated";
                    //if (competition.CountGroupsForCompetition() > 0) {
                    //    generateFixturesButton.Visible = true;
                    //}
				}

                if ((competition.CountGroupsForCompetitionWhereFixturesUnderway(competition.ID) == competition.CountGroupsForCompetition() - 1) || (competition.CountGroupsForCompetitionWhereFixturesUnderway(competition.ID) == competition.CountGroupsForCompetition())) {
                    swapTeamsBetweenGroupsLink.Visible = false;
                }

				
			}
			if (pageVersion != RequestVersion.ReCalculateGroups) {
				groupsList = iGroup.SQLSelectForCompetition(competition.ID);
				groupsDataList.DataSource = groupsList;
				groupsDataList.DataBind();
			}

		


		}
        
		protected void GroupsDataList_ItemDataBound(Object sender, DataListItemEventArgs e) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                Group group = (Group)e.Item.DataItem;
				GroupPlayingArea groupPlayingArea = iGroupPlayingArea.SQLGroupPlayingAreaForGroupID(group.ID);
				PlayingArea playingArea = iPlayingArea.SQLSelect<PlayingArea, int>(groupPlayingArea.PlayingAreaID);
                Label groupName = (Label)e.Item.FindControl("GroupName");
                Label registrationStatus = (Label)e.Item.FindControl("RegistrationStatus");
                if (group.GetNumberOfTeamsInGroup() > 0 && (group.GetNumberOfTeamsInGroup() == group.GetNumberOfTeamsRegisteredInGroup())) {
                    registrationStatus.Text = "All Teams in Group Registered";
                    if (group.FixturesUnderWay == true) {
                        registrationStatus.Text += " - Fixtures Underway";
                    }
                }
                else if (group.GetNumberOfTeamsInGroup() > 0 && (group.GetNumberOfTeamsInGroup() != group.GetNumberOfTeamsRegisteredInGroup())) {
                    registrationStatus.Text = group.GetNumberOfTeamsRegisteredInGroup().ToString() + " Out Of " + group.GetNumberOfTeamsInGroup().ToString() + " Teams in Group Registered";
                    registrationStatus.ForeColor = Color.Crimson;
                }
                HyperLink groupEditLink = (HyperLink)e.Item.FindControl("GroupEditLink");
                groupEditLink.NavigateUrl = "~/UI/Competitions/GroupForm?TournamentID="+tournament.ID.ToString()+"&GroupID="+group.ID.ToString();
                DataList teamsListForGroup = (DataList)e.Item.FindControl("TeamsListForGroup");
                teamsList = iTeam.SQLSelectForGroup(group.ID);
                teamsListForGroup.DataSource = teamsList;
                teamsListForGroup.DataBind();
                groupName.Text = group.Name + " - " + playingArea.Name;
			}
        }
        protected void TeamsListForGroup_ItemDataBound(Object sender, DataListItemEventArgs e) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {				
				Team team = (Team)e.Item.DataItem;
				ITeam iTeam = (Team)e.Item.DataItem;
				HyperLink requestDeleteLink = (HyperLink)e.Item.FindControl("RequestDeleteLink");
                if (team.GroupID != null) {
                    Group group = iGroup.SQLSelect<Group, int>((int)team.GroupID);
                    if (group.FixturesUnderWay == true) {
                        requestDeleteLink.Visible = false;
                    }
                }
				requestDeleteLink.Attributes.Add("onclick","javascript:return confirm('Are you sure you want to remove this team? The fixtures will be recalculated automatically')");
				requestDeleteLink.NavigateUrl = "~/UI/Competitions/GroupAllocationForm.aspx?version=2&TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competition.ID.ToString() + "&team_id="+team.ID.ToString();

                Club club = new Club();
                club = iClub.SQLSelect<Club, int>(team.ClubID);
                Table colourTable = (Table)e.Item.FindControl("ColourTable");
                TableRow colourTableRow = (TableRow)colourTable.FindControl("ColourTableRow");
                TableCell clubAndTeamNameCell = (TableCell)colourTableRow.FindControl("ClubAndTeamNameCell");
				Label clubNameLabel = (Label)clubAndTeamNameCell.FindControl("ClubNameLabel");
				Label teamNameLabel = (Label)clubAndTeamNameCell.FindControl("TeamNameLabel");
				clubNameLabel.Text = club.Name;
				teamNameLabel.Text = team.Name;


                TableCell colourPrimaryCell = (TableCell)colourTableRow.FindControl("ColourPrimaryCell");
                if (club.ColourPrimary != null) {
                    colourPrimaryCell.BackColor = Color.FromName(club.ColourPrimary.ToString());
                }
                TableCell colourSecondaryCell = (TableCell)colourTableRow.FindControl("ColourSecondaryCell");
                if (club.ColourSecondary != null) {
                    colourSecondaryCell.BackColor = Color.FromName(club.ColourSecondary.ToString());
                }
            }
        }
	
		protected void AllocateTeamsIntoGroupsWithPlayingAreas() {

            if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
			    iCompetition.DeleteGroupsForCompetitionWithCascadeToFixtures(competition.ID);

			    groupsInCompetition = iCompetition.CountGroupsForCompetition(competition.ID);

			    int noGroups = Int32.Parse(competitionNoGroups.SelectedValue);
			    int playingAreaID = 0;
			    ArrayList playingAreaIDs = new ArrayList();
			    foreach (ListItem li in playingAreasList.Items) {
				    if (li.Selected == true) {
					    playingAreaIDs.Add(Int32.Parse(li.Value));
				    }
			    }
			    if (groupsInCompetition == 0) {
				    groupsInCompetition = noGroups;
				    for (int i = 1; i <= groupsInCompetition; i++) {
					    Group group = new Group(id: 0, competitionID: competition.ID, name: "Group " + i.ToString(), fixtureTurnaround : 0 , fixturesUnderWay: false);
					    groupID = iGroup.SQLInsertAndReturnID<Group>(group);
					    playingAreaID = (int)playingAreaIDs[i-1];
					    GroupPlayingArea groupPlayingArea = new GroupPlayingArea(id : 0, groupID: groupID, playingAreaID: playingAreaID );
					    iGroupPlayingArea.SQLInsert<GroupPlayingArea>(groupPlayingArea);
				    }
			    }
			    List<Team> teamsInCompetition = iTeam.GetCompetitionTeamsAll(competition.ID).Where(i => i.AttendanceType == Domains.AttendanceTypes.HostClub || i.AttendanceType == Domains.AttendanceTypes.Attending).ToList();
			    List<Group> groupsList = iGroup.SQLSelectForCompetition(competition.ID);
			    groupsInCompetition = groupsList.Count;
			    int currentGroup = 0;
			    foreach (Team team in teamsInCompetition) {
				    if (currentGroup == groupsInCompetition) {
					    currentGroup = 0;
				    }
				    iTeam.SQLUpdateGroupID(team.ID, groupsList[currentGroup].ID);
				    currentGroup++;
			    }
            }
		}

		protected void AllocateTeamsToGroups_Click(object sender, EventArgs e) {
			AllocateTeamsIntoGroupsWithPlayingAreas();
			Response.Redirect("~/UI/Competitions/GroupAllocationForm?version=1&TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString());
		}
		
        protected void ReAllocateTeamsIntoNewGroups_Click(object sender, EventArgs e) {
            if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
			    iCompetition.DeleteGroupsForCompetitionWithCascadeToFixtures(competition.ID);
            }
            Response.Redirect("~/UI/Competitions/GroupAllocationForm?version=1&TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString());
        }

		protected void GenerateFixtureButton_Click(object sender, EventArgs e) {
            if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
			    iFixture.GenerateFixturesForCompetition(tournament, competition);		
            }
            Response.Redirect("~/UI/Competitions/CompetitionView.aspx?TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString());
		}

	

    }

}

