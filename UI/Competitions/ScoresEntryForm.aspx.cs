using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using GoTournamental.BLL.Planner;

namespace GoTournamental.UI.Organiser {

    public partial class ScoresEntryForm : Page {

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
		HyperLink reallocateTeamsIntoNewGroupsLink = new HyperLink();
        HyperLink replaceATeamLink = new HyperLink();
		HyperLink swapTeamsBetweenGroupsLink = new HyperLink();
		Panel competitionEditButtonPanel = new Panel();
		Panel groupAllocationPanel = new Panel();
		DropDownList competitionNoGroups = new DropDownList();
		RequiredFieldValidator competitionNoGroupsMandatory = new RequiredFieldValidator();
        CheckBoxList playingAreasList = new CheckBoxList();
		CustomValidator playingAreasMandatory = new CustomValidator();
        DataList groupsDataList = new DataList();
		Panel fixturesEditPanel = new Panel();
		Button allocateTeamsToGroups = new Button();
        Button reAllocateTeamsIntoNewGroups = new Button();
		Button generateFixturesButton = new Button();
		GridView fixturesListForCompetition = new GridView();
		Button saveLeagueScoresButton = new Button();
		Button saveFinalsScoresButton = new Button();
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
			competitionEditButtonPanel = (Panel)GroupAllocationFormPanel.FindControl("CompetitionEditButtonPanel");
			groupAllocationPanel = (Panel)GroupAllocationFormPanel.FindControl("GroupAllocationPanel");
			competitionNoGroups = (DropDownList)GroupAllocationFormPanel.FindControl("CompetitionNoGroups");
 			competitionNoGroupsMandatory = (RequiredFieldValidator)GroupAllocationFormPanel.FindControl("CompetitionNoGroupsMandatory");
            playingAreasList = (CheckBoxList)GroupAllocationFormPanel.FindControl("PlayingAreasList");
 			playingAreasMandatory = (CustomValidator)GroupAllocationFormPanel.FindControl("PlayingAreasMandatory");
			fixturesEditPanel = (Panel)GroupAllocationFormPanel.FindControl("FixturesEditPanel");
            groupsDataList = (DataList)GroupAllocationFormPanel.FindControl("GroupsDataList");
			allocateTeamsToGroups = (Button)GroupAllocationFormPanel.FindControl("AllocateTeamsToGroups");
            reAllocateTeamsIntoNewGroups = (Button)GroupAllocationFormPanel.FindControl("ReAllocateTeamsIntoNewGroups");
			generateFixturesButton = (Button)GroupAllocationFormPanel.FindControl("GenerateFixturesButton");
			fixturesListForCompetition = (GridView)GroupAllocationFormPanel.FindControl("FixturesListForCompetition");
			saveLeagueScoresButton = (Button)GroupAllocationFormPanel.FindControl("SaveLeagueScoresButton");
			saveFinalsScoresButton = (Button)GroupAllocationFormPanel.FindControl("SaveFinalsScoresButton");
			saveButton = (Button)GroupAllocationFormPanel.FindControl("SaveButton");
        }
        protected void ManagePageVersion(RequestVersion pageVersion) {
			switch (pageVersion) {
				case RequestVersion.ReCalculateGroups:
                    CompetitionEditFormLoad();
					break;
                case RequestVersion.ReCalculateFixtures:
					iFixture.DeleteFixturesForCompetition(competition.ID);
					iFixture.GenerateFixturesForCompetition(tournament, competition);		
					Response.Redirect("~/UI/Competitions/CompetitionView.aspx?TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString());
                    break;
				case RequestVersion.TeamDelete:
					iTeam.SQLDeleteWithCascade<Team>(team);
					iFixture.DeleteFixturesForCompetition(competition.ID);
					iFixture.GenerateFixturesForCompetition(tournament, competition);		
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

				//reallocateTeamsIntoNewGroupsLink.NavigateUrl = "~/UI/Competitions/GroupAllocationForm.aspx?version=4&TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString();
								
				if (pageVersion == RequestVersion.ReCalculateGroups || (
					competition.CountTeamsAttendingCompetition() > 0 && competition.StartTime != null && competition.CompetitionFormat != null && 
					competition.Session != null && competition.Session != Competition.Sessions.Undefined &&
					competition.FixtureTurnaround != null && competition.FixtureTurnaround != Tournament.FixtureTurnarounds.Undefined && 
					competition.CompetitionFormat != null && competition.CompetitionFormat != Competition.CompetitionFormats.Undefined
				)) {
					fixturesEditPanel.Visible = true;
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



				if (competition.CountFixturesForCompetition() > 0 &&  pageVersion != RequestVersion.ReCalculateGroups) {
					saveLeagueScoresButton.Visible = true;
				}
				else if (pageVersion != RequestVersion.ReCalculateGroups) {
					if (competition.CountGroupsForCompetition() > 0) {
						generateFixturesButton.Visible = true;
					}
				}


				
			}
			if (pageVersion != RequestVersion.ReCalculateGroups) {
				groupsList = iGroup.SQLSelectForCompetition(competition.ID);
				groupsDataList.DataSource = groupsList;
				groupsDataList.DataBind();
				fixturesList = iFixture.SQLSelectFinalsForCompetition(competition.ID);
				if (fixturesList.Count > 0) {
					fixturesListForCompetition.DataSource = fixturesList;
					fixturesListForCompetition.DataBind();
				}

				if (competition.CountFixturesForCompetition() > 0 && iFixture.AllLeagueFixturesCompleted(competition) == true) {
					saveFinalsScoresButton.Visible = true;
				}	
			}

		


		}
        
		protected void GroupsDataList_ItemDataBound(Object sender, DataListItemEventArgs e) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                Group group = (Group)e.Item.DataItem;
				GroupPlayingArea groupPlayingArea = iGroupPlayingArea.SQLGroupPlayingAreaForGroupID(group.ID);
				PlayingArea playingArea = iPlayingArea.SQLSelect<PlayingArea, int>(groupPlayingArea.PlayingAreaID);
                Label groupName = (Label)e.Item.FindControl("GroupName");
                groupName.Text = group.Name + " - " + playingArea.Name + " - Enter Scores";
                GridView fixturesListForGroup = (GridView)e.Item.FindControl("FixturesListForGroup");
                fixturesList = iFixture.SQLSelectForGroup(group.ID);
                fixturesListForGroup.DataSource = fixturesList;
                fixturesListForGroup.DataBind();			
			}
        }
        protected void TeamsListForGroup_ItemDataBound(Object sender, DataListItemEventArgs e) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {				
				Team team = (Team)e.Item.DataItem;
				ITeam iTeam = (Team)e.Item.DataItem;
				HyperLink requestDeleteLink = (HyperLink)e.Item.FindControl("RequestDeleteLink");
				requestDeleteLink.Attributes.Add("onclick","javascript:return confirm('Are you sure you want to remove this team?')");
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
        protected void FixturesListForGroup_RowDataBound(Object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                Fixture fixture = (Fixture)e.Row.DataItem;
                Club club = new Club();
                PlayingArea playingArea = new PlayingArea();
                e.Row.Cells[1].Text = fixture.StartTime.Value.ToShortTimeString();
                club = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID);
				if (club != null && fixture.HomeTeam != null) {
					if (fixture.HomeTeam.Name == EnumExtensions.GetStringValue(competition.AgeBand)) {
						e.Row.Cells[2].Text = club.Name;
					}
					else {
						e.Row.Cells[2].Text = club.Name + "&nbsp;" + fixture.HomeTeam.Name;
					}
				}
 				HiddenField fixtureID = (HiddenField)e.Row.FindControl("FixtureID");
				fixtureID.Value = fixture.ID.ToString();
				HiddenField homeTeamID = (HiddenField)e.Row.FindControl("HomeTeamID");
				homeTeamID.Value = fixture.HomeTeamID.ToString();
				TextBox homeTeamScore = (TextBox)e.Row.FindControl("HomeTeamScore");
				homeTeamScore.Text = fixture.HomeTeamScore.ToString();
                if (fixture.Group.FixturesUnderWay != true) {
                    homeTeamScore.Enabled = false;
                }
                e.Row.Cells[4].Text = "V";
 				HiddenField awayTeamID = (HiddenField)e.Row.FindControl("AwayTeamID");
				awayTeamID.Value = fixture.AwayTeamID.ToString();
				TextBox awayTeamScore = (TextBox)e.Row.FindControl("AwayTeamScore");
				awayTeamScore.Text = fixture.AwayTeamScore.ToString();
                if (fixture.Group.FixturesUnderWay != true) {
                    awayTeamScore.Enabled = false;
                }
                club = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID);
				if (club != null && fixture.AwayTeam != null) {
					if (fixture.AwayTeam.Name == EnumExtensions.GetStringValue(competition.AgeBand)) {
						e.Row.Cells[6].Text = club.Name;
					}
					else {
						e.Row.Cells[6].Text = club.Name + "&nbsp;" + fixture.AwayTeam.Name;
					}
				}
				playingArea = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID);
				e.Row.Cells[7].Text = playingArea.Name;
                if (fixture.PrimaryOfficialID != null) {
                    e.Row.Cells[8].Text = fixture.PrimaryOfficial.FirstName.Substring(0, 1) + " " + fixture.PrimaryOfficial.LastName;
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

		protected void FixturesListForCompetition_RowDataBound(Object sender, GridViewRowEventArgs e) {
			if (e.Row.RowType == DataControlRowType.DataRow) {
                IFixture iFixture = new Fixture();
                Fixture fixture = (Fixture)e.Row.DataItem;
                IClub iClub = new Club();
                Club club = new Club();
                PlayingArea playingArea = new PlayingArea();
                e.Row.Cells[1].Text = fixture.StartTime.Value.ToShortTimeString();
				if (fixture.HomeTeamID == null || fixture.HomeTeamID == 0) {
                    e.Row.Cells[2].Text = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Home);
				}
				else if (fixture.HomeTeam.Name == EnumExtensions.GetStringValue(competition.AgeBand)) {
					e.Row.Cells[2].Text = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID).Name;
				}
				else {
					e.Row.Cells[2].Text = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID).Name + " " + fixture.HomeTeam.Name;
				}

                e.Row.Cells[4].Text = "V";
				if (fixture.AwayTeamID == null || fixture.AwayTeamID == 0) {
                    e.Row.Cells[6].Text = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Away);
				}
				else if (fixture.AwayTeam.Name == EnumExtensions.GetStringValue(competition.AgeBand)) {
					e.Row.Cells[6].Text = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID).Name;
				}
				else {
					e.Row.Cells[6].Text = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID).Name + " " + fixture.AwayTeam.Name;
				}

 				HiddenField fixtureID = (HiddenField)e.Row.FindControl("FinalsID");
				fixtureID.Value = fixture.ID.ToString();
				HiddenField homeTeamID = (HiddenField)e.Row.FindControl("FinalsHomeTeamID");
				homeTeamID.Value = fixture.HomeTeamID.ToString();
				TextBox homeTeamScore = (TextBox)e.Row.FindControl("FinalsHomeTeamScore");
				homeTeamScore.Text = fixture.HomeTeamScore.ToString();
                if (iFixture.AllLeagueFixturesCompleted(fixture.Competition)) {
                    homeTeamScore.Enabled = true;
                }
                else {
                    homeTeamScore.Enabled = false;
                }
                e.Row.Cells[4].Text = "V";
 				HiddenField awayTeamID = (HiddenField)e.Row.FindControl("FinalsAwayTeamID");
				awayTeamID.Value = fixture.AwayTeamID.ToString();
				TextBox awayTeamScore = (TextBox)e.Row.FindControl("FinalsAwayTeamScore");
				awayTeamScore.Text = fixture.AwayTeamScore.ToString();
                if (iFixture.AllLeagueFixturesCompleted(fixture.Competition)) {
                    awayTeamScore.Enabled = true;
                }
                else {
                    awayTeamScore.Enabled = false;
                }

				if (fixture.PlayingAreaID != null) {
					playingArea = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID);
		            e.Row.Cells[7].Text = playingArea.Name;
				}

                if (fixture.HomeTeamScore != null && (fixture.HomeTeamScore == fixture.AwayTeamScore)) {
                    e.Row.Cells[10].Text = "-";
                }
                else {
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[10].Visible = false;
                    e.Row.Cells[11].Visible = false;
                }

			}
		}

		protected void SaveLeagueScoresButton_Click(object sender, EventArgs e) {
            if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
			    ArrayList scoresList = new ArrayList();
			    int i = 0;
			    foreach (string item in Request.Form.Keys) {
				    if (item.Contains("FixtureID")) {		
                        Fixture fixture = iFixture.SQLSelect<Fixture,int>(Int32.Parse(Request.Form[i]));
                        if (fixture.GroupID != null) {
                            Group group = iGroup.SQLSelect<Group, int>((int)fixture.GroupID);
                            if (group.FixturesUnderWay == true) {
                                if (Request.Form[i + 2] != "" && Request.Form[i + 5] != "") {
                                    Fixture fixtureToUpdate = new Fixture(
                                        id: Int32.Parse(Request.Form[i]),
                                        competitionID: null,
                                        groupID: null,
                                        isLeagueFixture: null,
                                        playingAreaID: null,
                                        name: null,
                                        startTime: null,
                                        homeTeamID: Int32.Parse(Request.Form[i + 1]),
                                        homeTeamScore: Int32.Parse(Request.Form[i + 2]),
                                        homeTeamPenaltiesScore: null,
                                        awayTeamID: Int32.Parse(Request.Form[i + 3]),
                                        awayTeamScore: Int32.Parse(Request.Form[i + 4]),
                                        awayTeamPenaltiesScore: null,
                                        primaryOfficialID: null
                                    );
                                    scoresList.Add(fixtureToUpdate);
                                }
                            }
                        }
                        else {
                            if (Request.Form[i + 2] != "" && Request.Form[i + 5] != "") {
                                Fixture fixtureToUpdate = new Fixture(
                                    id: Int32.Parse(Request.Form[i]),
                                    competitionID: null,
                                    groupID: null,
                                    isLeagueFixture: null,
                                    playingAreaID: null,
                                    name: null,
                                    startTime: null,
                                    homeTeamID: Int32.Parse(Request.Form[i + 1]),
                                    homeTeamScore: Int32.Parse(Request.Form[i + 2]),
                                    homeTeamPenaltiesScore: null,
                                    awayTeamID: Int32.Parse(Request.Form[i + 3]),
                                    awayTeamScore: Int32.Parse(Request.Form[i + 4]),
                                    awayTeamPenaltiesScore: null,
                                    primaryOfficialID: null
                                );
                                scoresList.Add(fixtureToUpdate);
                            }
                        }                    			
				    }
				    i++;
			    }
			    foreach (Fixture newScore in scoresList) {
				    iFixture.SQLUpdateScores(newScore);				
			    }
            }
			Response.Redirect("~/UI/Competitions/CompetitionView.aspx?TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString());
		}

		protected void SaveFinalsScoresButton_Click(object sender, EventArgs e) {
            if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
			    ArrayList scoresList = new ArrayList();
			    int i = 0;
			    foreach (string item in Request.Form.Keys) {
				    if (item.Contains("FinalsID")) {        // score in normal time
                        if (Request.Form[i+2] != "" && Request.Form[i+4] != "") {
						    Fixture fixtureToUpdate = new Fixture(
							    id: Int32.Parse(Request.Form[i]) ,
							    competitionID : null ,
							    groupID : null ,
							    isLeagueFixture : null ,
							    playingAreaID : null ,
							    name : null ,
							    startTime : null ,
							    homeTeamID : Int32.Parse(Request.Form[i+1]) ,
							    homeTeamScore : Int32.Parse(Request.Form[i+2]) ,
                                homeTeamPenaltiesScore: null ,
							    awayTeamID : Int32.Parse(Request.Form[i+3]) ,
							    awayTeamScore : Int32.Parse(Request.Form[i+4]) ,
                                awayTeamPenaltiesScore: null,
							    primaryOfficialID : null
						    );
						    scoresList.Add(fixtureToUpdate);
					    }
				    }
				    if (item.Contains("PenaltiesRequired")) {        // score from penalties
                        if (Request.Form[i + 1] != "" && Request.Form[i + 2] != "") {
                            Fixture fixtureToUpdate = new Fixture(
                                id: Int32.Parse(Request.Form[i - 5]),
                                competitionID: null,
                                groupID: null,
                                isLeagueFixture: null,
                                playingAreaID: null,
                                name: null,
                                startTime: null,
                                homeTeamID: Int32.Parse(Request.Form[i - 4]),
                                homeTeamScore: Int32.Parse(Request.Form[i - 3]),
                                homeTeamPenaltiesScore: Int32.Parse(Request.Form[i + 1]),
                                awayTeamID: Int32.Parse(Request.Form[i - 2]),
                                awayTeamScore: Int32.Parse(Request.Form[i -1]),
                                awayTeamPenaltiesScore: Int32.Parse(Request.Form[i + 2]),
                                primaryOfficialID: null
                            );
                            scoresList.Add(fixtureToUpdate);
                        }
                    }
				    i++;
			    }
			    foreach (Fixture newScore in scoresList) {
				    iFixture.SQLUpdateScores(newScore);				
			    }
            }
			Response.Redirect("~/UI/Competitions/CompetitionView.aspx?TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString());
		}

	

    }

}

