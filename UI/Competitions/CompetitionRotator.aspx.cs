using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using GoTournamental.BLL.Planner;

namespace GoTournamental.UI.Organiser 
{

    public partial class CompetitionRotator : Page
    {

        #region Declare Domain Objects
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
		List<Competition> competitions = new List<Competition>();
		Competition competition = new Competition();
        ICompetition iCompetition = new Competition();
        List<Group> groups = new List<Group>();
        Group group = new Group();
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

        private PageLoadTypes pageLoadType = PageLoadTypes.Undefined;
		public enum PageLoadTypes 
        {
			Undefined = 0,
			LeagueResults = 1,
			LeagueTable = 2
		}	
	
		int competitionID = 0;
		int staticCompetitionID = 0;
		int groupID = 0;
		int noTeamsInGroup = 0;
		int pageDelay = 0;
		string redirectURL = "";
		bool staticCompetition = false;
		#endregion
        #region Declare UI Controls
		Label tournamentTitle = new Label();
		Label competitionName = new Label();
		Label groupName = new Label();
		GridView fixturesListForGroup = new GridView();
		GridView leagueTableForGroup = new GridView();
		Label finalsLabel = new Label();
		GridView fixturesListForCompetition = new GridView();
		Label winnersLabel = new Label();
		AdvertPanel advert728By90 = new AdvertPanel();
		#endregion

        protected void Page_Load(object sender, EventArgs e) 
        {

            AssignUIControls();



			if (Request.QueryString.Get("TournamentID") != null)
            {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
				competitions = iCompetition.SQLSelectForTournament(tournament.ID, true);
			}
			if (Request.QueryString.Get("competition_id") != null)
            {
				competitionID = Int32.Parse(Request.QueryString.Get("competition_id"));
			}
			if (Request.QueryString.Get("group_id") != null) 
            {
				groupID = Int32.Parse(Request.QueryString.Get("group_id"));
			}
			if (Request.QueryString.Get("loadType") != null) 
            {
                pageLoadType = (PageLoadTypes)Int32.Parse(Request.QueryString.Get("loadType"));
			}
			if (Request.QueryString.Get("static") != null && Request.QueryString.Get("static") == "true")
            {
				staticCompetition = true;
				competitions = competitions.Where(i => i.ID == competitionID).ToList();
				staticCompetitionID = competitionID;
			}

 			tournamentTitle.Text = tournament.HostClub.Name + " " + tournament.Name;

            if (tournament.StartTime <= DateTime.Now)
            {
                LoadCompetitionRotator();
            }


        }
            
        protected void AssignUIControls() 
        {
			tournamentTitle = (Label)CompetitionRotatorPanel.FindControl("TournamentTitle");
			competitionName = (Label)CompetitionRotatorPanel.FindControl("CompetitionName");
			groupName = (Label)CompetitionRotatorPanel.FindControl("GroupName");
            fixturesListForGroup = (GridView)CompetitionRotatorPanel.FindControl("FixturesListForGroup");
			leagueTableForGroup = (GridView)CompetitionRotatorPanel.FindControl("LeagueTableForGroup");
			finalsLabel = (Label)CompetitionRotatorPanel.FindControl("FinalsLabel");
			fixturesListForCompetition = (GridView)CompetitionRotatorPanel.FindControl("FixturesListForCompetition");
			winnersLabel = (Label)CompetitionRotatorPanel.FindControl("WinnersLabel");
			//advert728By90 = (AdvertPanel)CompetitionRotatorPanel.FindControl("Advert728By90");
		}

        protected void LoadCompetitionRotator()
        {

            if (competitions.Count > 0)
            {
                if (competitionID >= competitions.Count) 
                {
                    competitionID = 0;
                }
                competition = competitions[competitionID];

                groups = iGroup.SQLSelectForCompetition(competition.ID);

                if (groups.Count > 0) 
                {
                    if (groupID >= groups.Count)
                    {
                        groupID = 0;
                        competitionID++;

                        fixturesList = iFixture.SQLSelectFinalsForCompetition(competition.ID);
                        if (fixturesList.Count > 0) 
                        {
                            fixturesListForCompetition.DataSource = fixturesList;
                            fixturesListForCompetition.DataBind();
                        }
                        if (staticCompetition == true)
                        {
                            redirectURL = "/UI/Competitions/CompetitionRotator?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + staticCompetitionID.ToString() + "&group_id=" + groupID.ToString() + "&static=true";
                        }
                        else 
                        {
                            redirectURL = "/UI/Competitions/CompetitionRotator?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competitionID.ToString() + "&group_id=" + groupID.ToString();
                        }
                        if (competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCompetitive 
                            || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCup
                            || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCupWith3rdPlace
                            || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals
                            || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromSemiFinals
                        ) 
                        {
                            competitionName.Text = EnumExtensions.GetStringValue(competition.AgeBand) + "&nbsp;-&nbsp;Finals";
                            FixturesListForGroupPanel.Visible = false;
                            LeagueTableForGroupPanel.Visible = false;
                            Response.AddHeader("REFRESH", "10;URL=" + redirectURL);
                        }
                        else 
                        {
                            Response.Redirect(redirectURL);
                        }
                    }
                    else 
                    {
                        group = groups[groupID];
                        GroupPlayingArea groupPlayingArea = iGroupPlayingArea.SQLGroupPlayingAreaForGroupID(group.ID);
                        PlayingArea playingArea = iPlayingArea.SQLSelect<PlayingArea, int>(groupPlayingArea.PlayingAreaID);
                        noTeamsInGroup = group.GetNumberOfTeamsInGroup();
                        pageDelay = 2 * noTeamsInGroup;

                        if (competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCup 
                            || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCupWith3rdPlace
                            || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals
                            || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromSemiFinals)
                        {
                            fixturesList = iFixture.SQLSelectForGroup(group.ID);
                            if (fixturesList.Count > 0)
                            {
                                fixturesListForGroup.DataSource = fixturesList;
                                fixturesListForGroup.DataBind();
                            }
                            else
                            {
                                FixturesListForGroupPanel.Visible = false;
                                FixturesListForCompetitionPanel.Visible = false;
                            }
                            leagueTable = iLeagueTable.GetLeagueTableForGroup(group.ID);
                            if (fixturesList.Count > 0)
                            {
                                leagueTableForGroup.DataSource = leagueTable;
                                leagueTableForGroup.DataBind();
                            }
                            if (pageLoadType == PageLoadTypes.Undefined || pageLoadType == PageLoadTypes.LeagueResults) 
                            {
                                competitionName.Text = EnumExtensions.GetStringValue(competition.AgeBand) + "&nbsp;-&nbsp;" + group.Name + " Results";
                                if (staticCompetition == true)
                                {
                                    redirectURL = "/UI/Competitions/CompetitionRotator?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + staticCompetitionID.ToString() + "&group_id=" + groupID.ToString() + "&loadType=2&static=true";
                                }
                                else 
                                {
                                    redirectURL = "/UI/Competitions/CompetitionRotator?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competitionID.ToString() + "&group_id=" + groupID.ToString() + "&loadType=2";
                                }
                                LeagueTableForGroupPanel.Visible = false;
                                FixturesListForCompetitionPanel.Visible = false;
                            }
                            else
                            {
                                competitionName.Text = EnumExtensions.GetStringValue(competition.AgeBand) + "&nbsp;-&nbsp;" + group.Name + " Table";
                                groupID++;
                                if (staticCompetition == true) 
                                {
                                    redirectURL = "/UI/Competitions/CompetitionRotator?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + staticCompetitionID.ToString() + "&group_id=" + groupID.ToString() + "&loadType=1&static=true";
                                }
                                else 
                                {
                                    redirectURL = "/UI/Competitions/CompetitionRotator?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competitionID.ToString() + "&group_id=" + groupID.ToString() + "&loadType=1";
                                }
                                FixturesListForGroupPanel.Visible = false;
                                FixturesListForCompetitionPanel.Visible = false;
                            }
                        }
                        else if (competition.CompetitionFormat == Competition.CompetitionFormats.LeagueNonCompetitive) 
                        {
                            competitionID++;
                            Response.Redirect("~/UI/Competitions/CompetitionRotator?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competitionID.ToString() + "&group_id=" + groupID.ToString());						
                        }
                        Response.AddHeader("REFRESH", + pageDelay + ";URL=" + redirectURL);
                    }
                }
                else 
                {
                    FixturesListForGroupPanel.Visible = false;
                    LeagueTableForGroupPanel.Visible = false;
                    FixturesListForCompetitionPanel.Visible = false;
                    competitionID++;
                    if (staticCompetition == true) 
                    {
                        redirectURL = "/UI/Competitions/CompetitionRotator?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + staticCompetitionID.ToString() + "&group_id=" + groupID.ToString() + "&static=true";
                    }
                    else 
                    {
                        redirectURL = "/UI/Competitions/CompetitionRotator?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competitionID.ToString() + "&group_id=" + groupID.ToString();
                    }
                    Response.AddHeader("REFRESH", "10;URL=" + redirectURL);
                }
                competitionID++;
            }

            advert728By90.graphicFileStyle = Advert.GraphicFileStyles.Advert728By90;
            if (tournament.ID != 0)
            {
                advert728By90.tournamentID = tournament.ID;
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
				Table homeColourTable = (Table)e.Row.FindControl("HomeColourTable");
                TableRow homeColourTableRow = (TableRow)homeColourTable.FindControl("HomeColourTableRow");
                TableCell homeColourPrimaryCell = (TableCell)homeColourTableRow.FindControl("HomeColourPrimaryCell");
				if (club != null && club.ColourPrimary != null) 
                {
	                homeColourPrimaryCell.BackColor = Color.FromName(club.ColourPrimary.ToString());
				}
                TableCell homeColourSecondaryCell = (TableCell)homeColourTableRow.FindControl("HomeColourSecondaryCell");
				if (club != null && club.ColourSecondary != null) 
                {
	                homeColourSecondaryCell.BackColor = Color.FromName(club.ColourSecondary.ToString());
				}
				if (club.ColourPrimary == null || club.ColourPrimary == "") 
                {
					homeColourTable.Visible = false;
				}

				if (club != null && fixture.HomeTeam != null)
                {
					if (fixture.HomeTeam.Name == EnumExtensions.GetStringValue(competition.AgeBand)) 
                    {
						e.Row.Cells[3].Text = club.Name;
					}
					else
                    {
						e.Row.Cells[3].Text = club.Name + "&nbsp;" + fixture.HomeTeam.Name;
					}
				}
				e.Row.Cells[4].Text = fixture.HomeTeamScore.ToString();
				e.Row.Cells[5].Text = "V";
				e.Row.Cells[6].Text = fixture.AwayTeamScore.ToString();
				club = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID);
				if (club != null && fixture.AwayTeam != null) 
                {
					if (fixture.AwayTeam.Name == EnumExtensions.GetStringValue(competition.AgeBand))
                    {
						e.Row.Cells[7].Text = club.Name;
					}
					else 
                    {
						e.Row.Cells[7].Text = club.Name + "&nbsp;" + fixture.AwayTeam.Name;
					}
				}
                Table awayColourTable = (Table)e.Row.FindControl("AwayColourTable");
                TableRow awayColourTableRow = (TableRow)awayColourTable.FindControl("AwayColourTableRow");
                TableCell awayColourPrimaryCell = (TableCell)awayColourTableRow.FindControl("AwayColourPrimaryCell");
				if (club != null && club.ColourPrimary != null)
                {
	                awayColourPrimaryCell.BackColor = Color.FromName(club.ColourPrimary.ToString());
				}
                TableCell awayColourSecondaryCell = (TableCell)awayColourTableRow.FindControl("AwayColourSecondaryCell");
				if (club != null && club.ColourSecondary != null)
                {
	                awayColourSecondaryCell.BackColor = Color.FromName(club.ColourSecondary.ToString());
				}
				if (club.ColourPrimary == null || club.ColourPrimary == "")
                {
					awayColourTable.Visible = false;
				}
				playingArea = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID);
				if (playingArea != null) 
                {
					e.Row.Cells[9].Text = playingArea.Name;
				}

			}
		}
		protected void LeagueTableForGroup_RowDataBound(Object sender, GridViewRowEventArgs e) 
        {
			if (e.Row.RowType == DataControlRowType.DataRow) 
            {
				bool groupCompleted = false;
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
				if (teamRow.Team.Name == EnumExtensions.GetStringValue(competition.AgeBand)) {
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
			}
		}

		protected void FixturesListForCompetition_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
			if (e.Row.RowType == DataControlRowType.DataRow) 
            {
				Fixture fixture = (Fixture)e.Row.DataItem;
				Club club = new Club();
				PlayingArea playingArea = new PlayingArea();
				e.Row.Cells[1].Text = fixture.StartTime.Value.ToShortTimeString();
				if (fixture.HomeTeamID == null || fixture.HomeTeamID == 0)
                {
					e.Row.Cells[2].Text = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Home);
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
				else 
                {
					e.Row.Cells[6].Text = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID).Name + " " + fixture.AwayTeam.Name;
				}
				if (fixture.PlayingAreaID != null)
                {
					playingArea = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID);
		            e.Row.Cells[7].Text = playingArea.Name;
				}
			}
		}

    }

}

