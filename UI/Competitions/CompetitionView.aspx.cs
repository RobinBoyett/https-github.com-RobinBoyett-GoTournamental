using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.API;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using GoTournamental.BLL.Planner;

namespace GoTournamental.UI.Organiser
{

    public partial class CompetitionView : Page 
    {

        #region Declare Domain Objects
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
		List<Competition> competitions = new List<Competition>();
		Competition competition = new Competition();
        ICompetition iCompetition = new Competition();
		List<Contact> contacts = new List<Contact>();
		IContact iContact = new Contact();
        List<Group> groupsList = new List<Group>();
        IGroup iGroup = new Group();
		List<Club> clubs = new List<Club>();
        IClub iClub = new Club();
        List<Team> teamsList = new List<Team>();
        ITeam iTeam = new Team();
        List<Fixture> fixturesList = new List<Fixture>();
        IFixture iFixture = new Fixture();
        List<LeagueTable> leagueTable = new List<LeagueTable>();
        ILeagueTable iLeagueTable = new LeagueTable();
        PlayingArea playingArea = new PlayingArea();
        IPlayingArea iPlayingArea = new PlayingArea();
        GroupPlayingArea groupPlayingArea = new GroupPlayingArea();
        IGroupPlayingArea iGroupPlayingArea = new GroupPlayingArea();
		bool groupCompleted = false;

		string hourString = "";
		string minuteString = "";
        #endregion
        #region Declare UI Controls
        Label tournamentTitle = new Label();
		HyperLink linkToCompetitionEdit = new HyperLink();
		Label ageBand = new Label();
		HyperLink noTeamsAttending = new HyperLink();
        Label startTime = new Label();
		Label session = new Label();
		Label fixtureTurnaround = new Label();
        Label fixtureHalvesNumber = new Label();
        Label fixtureHalvesLength = new Label();
		Label competitionFormat = new Label();
        Label teamSize = new Label();
        Label squadSize = new Label();
		Label noGroupsInCompetition = new Label();
		HyperLink linkToGroupsSetUp = new HyperLink();
		Label noFixturesInCompetition = new Label();
		HyperLink linkToGenerateFixtures = new HyperLink();
        Label noTeamsRegistered = new Label();
        HyperLink linkToCompetitionRegister = new HyperLink();
        DataList groupsDataList = new DataList();
		Label finalsLabel = new Label();
        HyperLink editFinalistsLink = new HyperLink();
		GridView fixturesListForCompetition = new GridView();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            AssignUIControls();

			if (Request.QueryString.Get("TournamentID") != null) 
            {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
 				tournamentTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
				competitions = iCompetition.SQLSelectForTournament(tournament.ID, false);
				clubs = iClub.SQLSelectClubsForTournament(tournament.ID);
				contacts = iContact.SQLSelectForTournament(tournament.ID);
			}
			if (Request.QueryString.Get("competition_id") != null)
            {
				competition = iCompetition.SQLSelect<Competition, int>(Int32.Parse(Request.QueryString.Get("competition_id")));
				linkToCompetitionEdit.NavigateUrl = "~/UI/Competitions/CompetitionForm.aspx?version=1&TournamentID=" + tournament.ID.ToString() + "&competition_id="+competition.ID.ToString();
            }
			if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) 
            {
				linkToCompetitionEdit.Visible = true;
			}
           

			CompetitionViewLoad();
        }
            
        protected void AssignUIControls()
        {
            TournamentTitle = (Label)CompetitionViewPanel.FindControl("TournamentTitle");
			linkToCompetitionEdit = (HyperLink)CompetitionViewPanel.FindControl("LinkToCompetitionEdit");
			ageBand = (Label)CompetitionViewPanel.FindControl("AgeBand");
			noTeamsAttending = (HyperLink)CompetitionViewPanel.FindControl("NoTeamsAttending");
            startTime = (Label)CompetitionViewPanel.FindControl("StartTime");
			session = (Label)CompetitionViewPanel.FindControl("Session");
			fixtureTurnaround = (Label)CompetitionViewPanel.FindControl("FixtureTurnaround");
            fixtureHalvesNumber = (Label)CompetitionViewPanel.FindControl("FixtureHalvesNumber");
            fixtureHalvesLength = (Label)CompetitionViewPanel.FindControl("FixtureHalvesLength");
			competitionFormat = (Label)CompetitionViewPanel.FindControl("CompetitionFormat");
            teamSize = (Label)CompetitionViewPanel.FindControl("TeamSize");
            squadSize = (Label)CompetitionViewPanel.FindControl("SquadSize");
			noGroupsInCompetition = (Label)CompetitionViewPanel.FindControl("NoGroupsInCompetition");
			linkToGroupsSetUp = (HyperLink)CompetitionViewPanel.FindControl("LinkToGroupsSetUp");
			noFixturesInCompetition = (Label)CompetitionViewPanel.FindControl("NoFixturesInCompetition");
			linkToGenerateFixtures = (HyperLink)CompetitionViewPanel.FindControl("LinkToGenerateFixtures");
            noTeamsRegistered = (Label)CompetitionViewPanel.FindControl("NoTeamsRegistered");
            linkToCompetitionRegister = (HyperLink)CompetitionViewPanel.FindControl("LinkToCompetitionRegister");
            groupsDataList = (DataList)CompetitionViewPanel.FindControl("GroupsDataList");
			finalsLabel = (Label)CompetitionViewPanel.FindControl("FinalsLabel");
            editFinalistsLink = (HyperLink)CompetitionViewPanel.FindControl("EditFinalistsLink");
			fixturesListForCompetition = (GridView)CompetitionViewPanel.FindControl("FixturesListForCompetition");
        }

		protected void CompetitionViewLoad()
        {
            groupsList = iGroup.SQLSelectForCompetition(competition.ID);
			ageBand.Text = EnumExtensions.GetStringValue(competition.AgeBand);
			if (competition.CountTeamsAttendingCompetition() != 0)
            {
				noTeamsAttending.Text = competition.CountTeamsAttendingCompetition().ToString();
				noTeamsAttending.NavigateUrl = "~/UI/Planner/ClubsList?version=1&TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString();
			}
			if (competition.StartTime.HasValue) 
            {
				hourString = competition.StartTime.Value.Hour.ToString();
				if (hourString.Length == 1)
                {
					hourString = "0" + hourString;
				}
				minuteString = competition.StartTime.Value.Minute.ToString();
				if (minuteString.Length == 1)
                {
					minuteString = "0" + minuteString;
				}
			}

			if (competition.StartTime.HasValue && competition.CountFixturesForCompetition() > 0) 
            {
	            startTime.Text = competition.StartTime.Value.ToLongDateString() + "&nbsp;at&nbsp;" + hourString + ":"+ minuteString;
			}
			else if (competition.StartTime.HasValue)
            {
	            startTime.Text = competition.StartTime.Value.ToLongDateString() + "&nbsp;at&nbsp;" + hourString + ":"+ minuteString;
			}
			if (competition.Session != Competition.Sessions.Undefined)
            {
				session.Text = EnumExtensions.GetStringValue(competition.Session).ToString();
			}	
			if (competition.FixtureTurnaround != Tournament.FixtureTurnarounds.Undefined) 
            {
				fixtureTurnaround.Text = EnumExtensions.GetIntValue(competition.FixtureTurnaround).ToString() + " Minutes";
			}
			if (competition.FixtureStructure != Tournament.FixtureStructures.Undefined)
            {
                fixtureHalvesNumber.Text = "- matches are " + EnumExtensions.GetIntValue(competition.FixtureStructure).ToString() + " x " + EnumExtensions.GetIntValue(competition.FixtureHalvesLength).ToString() + " mins";
            } 
        	
			if (competition.CompetitionFormat != Competition.CompetitionFormats.Undefined) 
            {
				competitionFormat.Text = EnumExtensions.GetStringValue(competition.CompetitionFormat);
			}
			if (competition.TeamSize != Domains.NumberOfParticipants.Undefined)
            {
				teamSize.Text = EnumExtensions.GetIntValue(competition.TeamSize).ToString();
			}
			if (competition.SquadSize != Domains.NumberOfParticipants.Undefined)
            {
				squadSize.Text = EnumExtensions.GetIntValue(competition.SquadSize).ToString();
			}


            if (competition.CountGroupsForCompetition() != 0) 
            {
                noGroupsInCompetition.Text = competition.CountGroupsForCompetition().ToString();
                linkToGroupsSetUp.NavigateUrl = "~/UI/Competitions/GroupAllocationForm?version=1&TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competition.ID.ToString();
                linkToGroupsSetUp.Text = "[Edit Groups & Allocated Pitches]";
                linkToGroupsSetUp.Visible = true;
            }
            else if (competition.CountTeamsAttendingCompetition() > 0 && competition.StartTime != null && competition.CompetitionFormat != null &&
                    competition.Session != null && competition.Session != Competition.Sessions.Undefined &&
                    competition.FixtureTurnaround != null && competition.FixtureTurnaround != Tournament.FixtureTurnarounds.Undefined &&
                    competition.CompetitionFormat != null && competition.CompetitionFormat != Competition.CompetitionFormats.Undefined
            )
            {
                linkToGroupsSetUp.NavigateUrl = "~/UI/Competitions/GroupAllocationForm?version=1&TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competition.ID.ToString();
                linkToGroupsSetUp.Text = "[Set Up Groups & Allocate Pitches]";
                linkToGroupsSetUp.Visible = true;
            }

			if (competition.CountFixturesForCompetition() != 0) 
            {
				noFixturesInCompetition.Text = competition.CountFixturesForCompetition().ToString();
				linkToGenerateFixtures.NavigateUrl = "~/UI/Competitions/ScoresEntryForm?version=1&TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString();
				linkToGenerateFixtures.Text = "[Enter Scores]"; 
				linkToGenerateFixtures.Visible = true;
			}
			else if (competition.CountGroupsForCompetition() > 0 && competition.CountFixturesForCompetition() == 0)
            {
				linkToGenerateFixtures.NavigateUrl = "~/UI/Competitions/GroupAllocationForm?version=1&TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString();
				linkToGenerateFixtures.Text = "[Generate Fixtures For All Groups]"; 
				linkToGenerateFixtures.Visible = true;
			}

            noTeamsRegistered.Text = competition.CountTeamsRegisteredAtCompetition().ToString();
            linkToCompetitionRegister.NavigateUrl = "~/UI/Competitions/CompetitionRegister?TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString();

            groupsDataList.DataSource = groupsList;
            groupsDataList.DataBind();

            fixturesList = iFixture.SQLSelectFinalsForCompetition(competition.ID);
            if (fixturesList.Count > 0)
            {
				finalsLabel.Visible = true;
				fixturesListForCompetition.DataSource = fixturesList;
				fixturesListForCompetition.DataBind();
            }
            if (iCompetition.CompetitionAllLeaguesFixturesCompleted(competition.ID)) 
            {
                editFinalistsLink.Visible = true;
                editFinalistsLink.NavigateUrl = "~/UI/Competitions/FinalistsEditForm?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competition.ID.ToString();
            }

        }

        protected void GroupsDataList_ItemDataBound(Object sender, DataListItemEventArgs e) 
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Group group = (Group)e.Item.DataItem;
				GroupPlayingArea groupPlayingArea = iGroupPlayingArea.SQLGroupPlayingAreaForGroupID(group.ID);
				PlayingArea playingArea = iPlayingArea.SQLSelect<PlayingArea, int>(groupPlayingArea.PlayingAreaID);
                Label groupName = (Label)e.Item.FindControl("GroupName");
                HiddenField groupIDHidden = (HiddenField)e.Item.FindControl("GroupIDHidden");
                Label registrationStatus = (Label)e.Item.FindControl("RegistrationStatus");
                Button startFixturesButton = (Button)e.Item.FindControl("StartFixturesButton");
                DataList teamsListForGroup = (DataList)e.Item.FindControl("TeamsListForGroup");
				if (competition.CountFixturesForCompetition() == 0) 
                {
					teamsList = iTeam.SQLSelectForGroup(group.ID);
					teamsListForGroup.DataSource = teamsList;
					teamsListForGroup.DataBind();
				}
                groupName.Text = group.Name + " - " + playingArea.Name;
                if (group.GetNumberOfTeamsInGroup() > 0 && (group.GetNumberOfTeamsInGroup() == group.GetNumberOfTeamsRegisteredInGroup())) 
                {
                    registrationStatus.Text = "All Teams in Group Registered";
                    if (group.FixturesUnderWay != true)
                    {
                        groupIDHidden.Value = group.ID.ToString();
                        startFixturesButton.Text = "Start " + group.Name + " Fixtures" ;
                        startFixturesButton.Visible = true;
                        startFixturesButton.CommandName = "Start Group";
                        startFixturesButton.CommandArgument = group.ID.ToString();
                    }
                    else
                    {
                        registrationStatus.Text += " - Fixtures Underway";
                    }
                }
                else if (group.GetNumberOfTeamsInGroup() > 0 && (group.GetNumberOfTeamsInGroup() != group.GetNumberOfTeamsRegisteredInGroup()))
                {
                    registrationStatus.Text = group.GetNumberOfTeamsRegisteredInGroup().ToString() + " Out Of " + group.GetNumberOfTeamsInGroup().ToString() + " Teams in Group Registered";
                    registrationStatus.ForeColor = Color.Crimson;
                }
				GridView fixturesListForGroup = (GridView)e.Item.FindControl("FixturesListForGroup");
                fixturesList = iFixture.SQLSelectForGroup(group.ID);
                fixturesListForGroup.DataSource = fixturesList;
                fixturesListForGroup.DataBind();

				if (competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCompetitive 
                    || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCup
                    || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCupWith3rdPlace
                    || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals
                    || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromSemiFinals)
                {
					GridView leagueTableForGroup = (GridView)e.Item.FindControl("LeagueTableForGroup");
					leagueTable = iLeagueTable.GetLeagueTableForGroup(group.ID);
					if (fixturesList.Count > 0)
                    {
						leagueTableForGroup.DataSource = leagueTable;
						leagueTableForGroup.DataBind();
					}
				}

            }
        }
        protected void TeamsListForGroup_ItemDataBound(Object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Team team = (Team)e.Item.DataItem;
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
                if (club.ColourPrimary != null)
                {
                    colourPrimaryCell.BackColor = Color.FromName(club.ColourPrimary.ToString());
                }
                TableCell colourSecondaryCell = (TableCell)colourTableRow.FindControl("ColourSecondaryCell");
                if (club.ColourSecondary != null)
                {
                    colourSecondaryCell.BackColor = Color.FromName(club.ColourSecondary.ToString());
                }
            }
        }
        protected void FixturesListForGroup_RowDataBound(Object sender, GridViewRowEventArgs e) 
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                Fixture fixture = (Fixture)e.Row.DataItem;
                Club club = new Club();
                PlayingArea playingArea = new PlayingArea();
                e.Row.Cells[1].Text = fixture.StartTime.Value.ToShortTimeString();
                club = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID);
				if (club != null && fixture.HomeTeam != null) 
                {
					if (fixture.HomeTeam.Name == EnumExtensions.GetStringValue(competition.AgeBand)) 
                    {
						e.Row.Cells[2].Text = club.Name;
					}
					else 
                    {
						e.Row.Cells[2].Text = club.Name + "&nbsp;" + fixture.HomeTeam.Name;
					}
				}
                e.Row.Cells[3].Text = fixture.HomeTeamScore.ToString();
                e.Row.Cells[4].Text = "V";
                e.Row.Cells[5].Text = fixture.AwayTeamScore.ToString();
                club = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID);
				if (club != null && fixture.AwayTeam != null) 
                {
					if (fixture.AwayTeam.Name == EnumExtensions.GetStringValue(competition.AgeBand)) 
                    {
						e.Row.Cells[6].Text = club.Name;
					}
					else 
                    {
						e.Row.Cells[6].Text = club.Name + "&nbsp;" + fixture.AwayTeam.Name;
					}
				}
				playingArea = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID);
				if (playingArea != null) 
                {
					e.Row.Cells[7].Text = playingArea.Name;
				}
                if (fixture.PrimaryOfficialID != null)
                {
                    e.Row.Cells[8].Text = fixture.PrimaryOfficial.FirstName.Substring(0, 1) + " " + fixture.PrimaryOfficial.LastName;
                }
            }
        }
        protected void LeagueTableForGroup_RowDataBound(Object sender, GridViewRowEventArgs e) 
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                LeagueTable teamRow = (LeagueTable)e.Row.DataItem;
                Team team = iTeam.SQLSelect<Team, int>(teamRow.Team.ID);
				groupCompleted = iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>((int)team.GroupID));
                Club club = iClub.SQLSelect<Club, int>(team.ClubID);
				if (club.ColourPrimary != null) 
                {
					e.Row.Cells[0].BackColor = Color.FromName(club.ColourPrimary);
				}
				if (club.ColourSecondary != null)
                {
					e.Row.Cells[1].BackColor = Color.FromName(club.ColourSecondary);
				}
				if (teamRow.Team.Name == EnumExtensions.GetStringValue(competition.AgeBand)) 
                {
					e.Row.Cells[4].Text = club.Name;
				}
				else 
                {
	                e.Row.Cells[4].Text = club.Name + "&nbsp;" + teamRow.Team.Name;
				}
				if (groupCompleted && e.Row.RowIndex == 0) 
                {
					e.Row.Cells[3].Font.Bold = true;
					e.Row.Cells[3].Text = "W";
					e.Row.Cells[4].Font.Bold = true;
					e.Row.Cells[4].ForeColor = Color.Crimson;
				}
                //13
            }
        }

		protected void FixturesListForCompetition_RowDataBound(Object sender, GridViewRowEventArgs e) 
        {
			if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Fixture fixture = (Fixture)e.Row.DataItem;
                IClub iClub = new Club();
                Club club = new Club();
                PlayingArea playingArea = new PlayingArea();
                e.Row.Cells[1].Text = fixture.StartTime.Value.ToShortTimeString();
				if (fixture.HomeTeamID == null || fixture.HomeTeamID == 0) 
                {
                    e.Row.Cells[2].Text = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Home);
                }
				else if (fixture.HomeTeam.Name == EnumExtensions.GetStringValue(competition.AgeBand))
                {
					e.Row.Cells[2].Text = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID).Name;
				}
				else 
                {
					e.Row.Cells[2].Text = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID).Name + " " + fixture.HomeTeam.Name;
				}
				e.Row.Cells[3].Text = fixture.HomeTeamScore.ToString();
                e.Row.Cells[4].Text = "V";
				e.Row.Cells[5].Text = fixture.AwayTeamScore.ToString();
				if (fixture.AwayTeamID == null || fixture.AwayTeamID == 0) 
                {
                    e.Row.Cells[6].Text = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Away);
                }
				else if (fixture.AwayTeam.Name == EnumExtensions.GetStringValue(competition.AgeBand))
                {
					e.Row.Cells[6].Text = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID).Name;
				}
				else
                {
					e.Row.Cells[6].Text = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID).Name + " " + fixture.AwayTeam.Name;
				}

                if (fixture.HomeTeamPenaltiesScore != null && fixture.AwayTeamPenaltiesScore != null) 
                {
                    e.Row.Cells[7].Text = fixture.HomeTeamPenaltiesScore.ToString() + "-" + fixture.AwayTeamPenaltiesScore + " on pens";
                }
                else 
                {

                }

				if (fixture.PlayingAreaID != null)
                {
					playingArea = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID);
		            e.Row.Cells[8].Text = playingArea.Name;
				}
			}
		}
        protected void StartFixturesButton_Click(object sender, EventArgs e) 
        {
            Button buttonClicked = (Button)sender;
            if (buttonClicked.CommandName != null) 
            {
                iGroup.SQLUpdateFixturesUnderway(Int32.Parse(buttonClicked.CommandArgument), true);
            }
            Response.Redirect("~/UI/Competitions/CompetitionView?TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString());
        }
  

    }

}

