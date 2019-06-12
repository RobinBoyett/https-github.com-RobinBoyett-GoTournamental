using System;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using System.Drawing;
using OfficeOpenXml;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using GoTournamental.BLL.Planner;

public partial class ExportData : Page 
{

    #region Declare domain objects
 	GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
    Tournament tournament = new Tournament();
    ITournament iTournament = new Tournament();
    Competition competition = new Competition();
    ICompetition iCompetition = new Competition();
	List<Competition> competitionsList = new List<Competition>();
    Group group = new Group();
    IGroup iGroup = new Group();
    List<Group> groupsList = new List<Group>();
    Club club = new Club();
    IClub iClub = new Club();
    List<Club> clubsList = new List<Club>();
    Team team = new Team();
    ITeam iTeam = new Team();
    List<Team> teamsList = new List<Team>();
    IFixture iFixture = new Fixture();
    List<Fixture> fixturesList = new List<Fixture>();
    List<Fixture> subFixturesList = new List<Fixture>();
    List<Fixture> finalsFixturesList = new List<Fixture>();
	List<GoTournamental.BLL.Organiser.Contact> contactsList = new List<GoTournamental.BLL.Organiser.Contact>();
    GoTournamental.BLL.Organiser.IContact iContact = new GoTournamental.BLL.Organiser.Contact();
    PlayingArea playingArea = new PlayingArea();
    IPlayingArea iPlayingArea = new PlayingArea();
    #endregion

    #region Declare page controls
	Label tournamentExportTitle = new Label();
	#endregion

    protected void Page_Load(object sender, EventArgs e) 
    {
		
		AssignControlsAll();

		if (Request.QueryString.Get("TournamentID") != null)
        {
			tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
			tournamentExportTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
            if (tournament.ID > 1 && !identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) 
            {
                throw new Exception("Unauthorised access to tournament admin page.");
            }
        }

    }

	protected void AssignControlsAll() 
    {
		tournamentExportTitle = (Label)TournamentExportPanel.FindControl("TournamentExportTitle");
	}

	protected void ProgrammePrintingButton_Click(object sender, EventArgs e) 
    {
        clubsList = iClub.SQLSelectClubsForTournament(tournament.ID);
        contactsList = iContact.SQLSelectForTournament(tournament.ID);
        GenerateExcelProgrammePrinting();
	}
	protected void RefereesSlipsButton_Click(object sender, EventArgs e) 
    {
        GenerateExcelRefereeSlips();
	}


    private void GenerateExcelProgrammePrinting() 
    {
        using (ExcelPackage pck = new ExcelPackage())
        {

            string xlTitle = tournament.HostClub.Name + " " + tournament.Name + ".xlsx";

			Tournament.ExportToExcelWorkSheet(pck, tournament);
			Advertiser.ExportToExcelWorkSheet(pck, tournament, false);
			competitionsList = iCompetition.SQLSelectForTournament(tournament.ID, false);

			#region Competitions
			foreach (Competition competition in competitionsList)
            {
				if (competition.CountTeamsAttendingCompetition() > 0)
                {

					groupsList = iGroup.SQLSelectForCompetition(competition.ID);
					foreach(Group group in groupsList)
                    {

						teamsList = iTeam.SQLSelectForGroup(group.ID);
						fixturesList = iFixture.SQLSelectForGroup(group.ID);

						int rowIndex = 3;
						int colIndex = 1;
						string sheetName = EnumExtensions.GetStringValue(competition.AgeBand) + " " + group.Name;

						ExcelWorksheet groupSheet = pck.Workbook.Worksheets.Add(sheetName);
						using (ExcelRange range = groupSheet.Cells["A1:F1"]) 
                        {
							range.Merge = true;
							range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
							range.Style.Font.Bold = true;
							range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
							range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
							groupSheet.Cells["A1"].Value = DateTimeExtensions.LongDateWithLongDay(competition.StartTime.Value) + " " + EnumExtensions.GetStringValue(competition.Session).Substring(0,2);
						}
                        string cellRange = "A2:F2";
						using (ExcelRange range = groupSheet.Cells["A2:F2"]) 
                        {
							range.Merge = true;
							range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
							groupSheet.Cells["A2"].Value = EnumExtensions.GetStringValue(competition.AgeBand) + " - " + group.Name;
						}

						using (ExcelRange range = groupSheet.Cells["A3:F7"]) 
                        {
							range.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
						}
						foreach (Team team in teamsList)
                        {
							club = iClub.SQLSelect<Club, int>(team.ClubID);
							if (colIndex == 1)
                            {
								groupSheet.Cells[rowIndex, 1+colIndex].Value = club.Name + " " + team.Name;
							}
							else 
                            {
								groupSheet.Cells[rowIndex, 2+colIndex].Value = club.Name + " " + team.Name;
							}
							if(colIndex % 2 == 0)
                            {
								rowIndex++;
								colIndex = 0;
							}
							colIndex++;
						}

                        using (ExcelRange range = groupSheet.Cells["A8:F8"])
                        {
							range.Merge = true;
							range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
							range.Style.Font.Bold = true;
                            range.Style.Font.Color.SetColor(Color.Red);
                            if (competition.FixtureStructure == Tournament.FixtureStructures.Two && competition.FixtureHalvesLength != Tournament.FixtureHalvesLengths.Undefined) 
                            {
    							groupSheet.Cells["A8"].Value = "ALL GAMES " + (EnumExtensions.GetIntValue(competition.FixtureHalvesLength)).ToString() + " MINUTES EACH WAY";
                            }
                            else if (competition.FixtureStructure == Tournament.FixtureStructures.One && competition.FixtureHalvesLength != Tournament.FixtureHalvesLengths.Undefined) 
                            {
    							groupSheet.Cells["A8"].Value = "ALL GAMES " + (EnumExtensions.GetIntValue(competition.FixtureHalvesLength)).ToString() + " MINUTES - NO HALF TIME";
                            }
                            else if (tournament.FixtureStructure == Tournament.FixtureStructures.Two && tournament.FixtureHalvesLength != Tournament.FixtureHalvesLengths.Undefined)
                            {
    							groupSheet.Cells["A8"].Value = "ALL GAMES " + (EnumExtensions.GetIntValue(tournament.FixtureHalvesLength)).ToString() + " MINUTES EACH WAY";
                            }
                            else if (tournament.FixtureStructure == Tournament.FixtureStructures.One && tournament.FixtureHalvesLength != Tournament.FixtureHalvesLengths.Undefined) 
                            {
    							groupSheet.Cells["A8"].Value = "ALL GAMES " + (EnumExtensions.GetIntValue(tournament.FixtureHalvesLength)).ToString() + "MINUTES - NO HALF TIME";
                            }
						}

						rowIndex = 9;
						groupSheet.Cells[rowIndex, 1].Value = "K-O";
						groupSheet.Cells[rowIndex, 2].Value = "Home";
						groupSheet.Cells[rowIndex, 4].Value = "Away";
						groupSheet.Cells[rowIndex, 5].Value = "Pitch";
						groupSheet.Cells[rowIndex, 6].Value = "Score";
						
						rowIndex = 10;
						foreach(Fixture fixture in fixturesList)
                        {
							groupSheet.Cells[rowIndex, 1].Value = fixture.StartTime.Value.ToShortTimeString();
							club = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID);
							groupSheet.Cells[rowIndex, 2].Value = club.Name + " " + fixture.HomeTeam.Name;
							groupSheet.Cells[rowIndex, 3].Value = "V";
							club = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID);
							groupSheet.Cells[rowIndex, 4].Value = club.Name + " " + fixture.AwayTeam.Name;
							groupSheet.Cells[rowIndex, 5].Value = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID).Name;
							rowIndex++;
						}
						groupSheet.Cells.AutoFitColumns();
					}

					if (competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCompetitive 
						|| competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCup 
						|| competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCupWith3rdPlace 
						|| competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromSemiFinals 
						|| competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals)
                    {
						ExcelWorksheet finalsSheet = pck.Workbook.Worksheets.Add(EnumExtensions.GetStringValue(competition.AgeBand) + " Finals");
						fixturesList = iFixture.SQLSelectFinalsForCompetition(competition.ID);

						using (ExcelRange range = finalsSheet.Cells["A1:F1"]) 
                        {
							range.Merge = true;
							range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
							range.Style.Font.Bold = true;
							range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
							range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
							finalsSheet.Cells["A1"].Value = DateTimeExtensions.LongDateWithLongDay(competition.StartTime.Value) + " " + EnumExtensions.GetStringValue(competition.Session).Substring(0,2);
						}

						using (ExcelRange range = finalsSheet.Cells["A2:F2"])
                        {
							range.Merge = true;
							range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
							finalsSheet.Cells["A2"].Value = EnumExtensions.GetStringValue(competition.AgeBand) + " - Finals";
						}		
                   
						int rowIndex = 4;
 
                        if (competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals)
                        {
							subFixturesList = fixturesList.Where(i => i.Name.Contains("Plate Quarter")).ToList();
							using (ExcelRange range = finalsSheet.Cells[rowIndex, 1, rowIndex, 6])
                            {
								finalsSheet.Cells[rowIndex, 1, rowIndex, 6].Value = "Plate Quarter Finals";
								range.Merge = true;
								range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
							}		
							rowIndex++;
							foreach(Fixture fixture in subFixturesList)
                            {
								finalsSheet.Cells[rowIndex, 1].Value = fixture.StartTime.Value.ToShortTimeString();
								if (fixture.HomeTeamID == null || fixture.HomeTeamID == 0)
                                {
									finalsSheet.Cells[rowIndex, 2].Value = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Home);
								}
 								else
                                {
									finalsSheet.Cells[rowIndex, 2].Value = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID).Name + " " + fixture.HomeTeam.Name;
								}
								finalsSheet.Cells[rowIndex, 3].Value = "V";
								if (fixture.AwayTeamID == null || fixture.AwayTeamID == 0)
                                {
									finalsSheet.Cells[rowIndex, 4].Value = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Away);
								}
 								else 
                                {
									finalsSheet.Cells[rowIndex, 4].Value = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID).Name + " " + fixture.AwayTeam.Name;
								}							
								finalsSheet.Cells[rowIndex, 5].Value = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID).Name;
								rowIndex++;
							}
							rowIndex = rowIndex+1;
							subFixturesList = fixturesList.Where(i => i.Name.Contains("Cup Quarter")).ToList();
							using (ExcelRange range = finalsSheet.Cells[rowIndex, 1, rowIndex, 6])
                            {
								finalsSheet.Cells[rowIndex, 1, rowIndex, 6].Value = "Cup Quarter Finals";
								range.Merge = true;
								range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
							}		
							rowIndex++;
							foreach(Fixture fixture in subFixturesList)
                            {
								finalsSheet.Cells[rowIndex, 1].Value = fixture.StartTime.Value.ToShortTimeString();
								if (fixture.HomeTeamID == null || fixture.HomeTeamID == 0)
                                {
									finalsSheet.Cells[rowIndex, 2].Value = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Home);
								}
 								else
                                {
									finalsSheet.Cells[rowIndex, 2].Value = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID).Name + " " + fixture.HomeTeam.Name;
								}
								finalsSheet.Cells[rowIndex, 3].Value = "V";
								if (fixture.AwayTeamID == null || fixture.AwayTeamID == 0)
                                {
									finalsSheet.Cells[rowIndex, 4].Value = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Away);
								}
 								else 
                                {
									finalsSheet.Cells[rowIndex, 4].Value = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID).Name + " " + fixture.AwayTeam.Name;
								}							
								finalsSheet.Cells[rowIndex, 5].Value = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID).Name;
								rowIndex++;
							}
							rowIndex = rowIndex+1;

                        }


						if (competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromSemiFinals
                            || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals)
                        {
							subFixturesList = fixturesList.Where(i => i.Name.Contains("Plate Semi")).ToList();
							using (ExcelRange range = finalsSheet.Cells[rowIndex, 1, rowIndex, 6])
                            {
								finalsSheet.Cells[rowIndex, 1, rowIndex, 6].Value = "Plate Semi Finals";
								range.Merge = true;
								range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
							}		
							rowIndex++;
							foreach(Fixture fixture in subFixturesList)
                            {
								finalsSheet.Cells[rowIndex, 1].Value = fixture.StartTime.Value.ToShortTimeString();
								if (fixture.HomeTeamID == null || fixture.HomeTeamID == 0)
                                {
									finalsSheet.Cells[rowIndex, 2].Value = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Home);
								}
 								else
                                {
									finalsSheet.Cells[rowIndex, 2].Value = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID).Name + " " + fixture.HomeTeam.Name;
								}
								finalsSheet.Cells[rowIndex, 3].Value = "V";
								if (fixture.AwayTeamID == null || fixture.AwayTeamID == 0)
                                {
									finalsSheet.Cells[rowIndex, 4].Value = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Away);
								}
 								else 
                                {
									finalsSheet.Cells[rowIndex, 4].Value = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID).Name + " " + fixture.AwayTeam.Name;
								}							
								finalsSheet.Cells[rowIndex, 5].Value = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID).Name;
								rowIndex++;
							}
							rowIndex = rowIndex+1;
						}
						if (competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCup 
                            || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromSemiFinals 
                            || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCupWith3rdPlace
                            || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals)
                        {
							subFixturesList = fixturesList.Where(i => i.Name.Contains("Cup Semi")).ToList();
							using (ExcelRange range = finalsSheet.Cells[rowIndex, 1, rowIndex, 6])
                            {
								finalsSheet.Cells[rowIndex, 1, rowIndex, 6].Value = "Cup Semi Finals";
								range.Merge = true;
								range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
							}		
							rowIndex++;
							foreach(Fixture fixture in subFixturesList)
                            {
								finalsSheet.Cells[rowIndex, 1].Value = fixture.StartTime.Value.ToShortTimeString();
								if (fixture.HomeTeamID == null || fixture.HomeTeamID == 0)
                                {
									finalsSheet.Cells[rowIndex, 2].Value = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Home);
								}
 								else 
                                {
									finalsSheet.Cells[rowIndex, 2].Value = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID).Name + " " + fixture.HomeTeam.Name;
								}
								finalsSheet.Cells[rowIndex, 3].Value = "V";
								if (fixture.AwayTeamID == null || fixture.AwayTeamID == 0)
                                {
									finalsSheet.Cells[rowIndex, 4].Value = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Away);
								}
 								else
                                {
									finalsSheet.Cells[rowIndex, 4].Value = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID).Name + " " + fixture.AwayTeam.Name;
								}							
								finalsSheet.Cells[rowIndex, 5].Value = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID).Name;
								rowIndex++;
							}
							rowIndex = rowIndex+1;
						}
                        if (competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCupWith3rdPlace)
                        {
							subFixturesList = fixturesList.Where(i => i.Name.Contains("3rd Place Final")).ToList();
							using (ExcelRange range = finalsSheet.Cells[rowIndex, 1, rowIndex, 6])
                            {
								finalsSheet.Cells[rowIndex, 1, rowIndex, 6].Value = "3rd Place Final";
								range.Merge = true;
								range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
							}		
							rowIndex++;
							foreach(Fixture fixture in subFixturesList)
                            {
								finalsSheet.Cells[rowIndex, 1].Value = fixture.StartTime.Value.ToShortTimeString();
								if (fixture.HomeTeamID == null || fixture.HomeTeamID == 0)
                                {
									finalsSheet.Cells[rowIndex, 2].Value = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Home);
								}
 								else 
                                {
									finalsSheet.Cells[rowIndex, 2].Value = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID).Name + " " + fixture.HomeTeam.Name;
								}
								finalsSheet.Cells[rowIndex, 3].Value = "V";
								if (fixture.AwayTeamID == null || fixture.AwayTeamID == 0) 
                                {
									finalsSheet.Cells[rowIndex, 4].Value = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Away);
								}
 								else 
                                {
									finalsSheet.Cells[rowIndex, 4].Value = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID).Name + " " + fixture.AwayTeam.Name;
								}							
								finalsSheet.Cells[rowIndex, 5].Value = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID).Name;
								rowIndex++;
							}
                        }

						if (competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromSemiFinals
                            || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals)
                        {
							subFixturesList = fixturesList.Where(i => i.Name.Contains("Plate Final")).ToList();
							using (ExcelRange range = finalsSheet.Cells[rowIndex, 1, rowIndex, 6])
                            {
								finalsSheet.Cells[rowIndex, 1, rowIndex, 6].Value = "Plate Final";
								range.Merge = true;
								range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
							}		
							rowIndex++;
							foreach(Fixture fixture in subFixturesList) 
                            {
								finalsSheet.Cells[rowIndex, 1].Value = fixture.StartTime.Value.ToShortTimeString();
								if (fixture.HomeTeamID == null || fixture.HomeTeamID == 0) 
                                {
									finalsSheet.Cells[rowIndex, 2].Value = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Home);
								}
 								else
                                {
									finalsSheet.Cells[rowIndex, 2].Value = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID).Name + " " + fixture.HomeTeam.Name;
								}
								finalsSheet.Cells[rowIndex, 3].Value = "V";
								if (fixture.AwayTeamID == null || fixture.AwayTeamID == 0)
                                {
									finalsSheet.Cells[rowIndex, 4].Value = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Away);
								}
 								else
                                {
									finalsSheet.Cells[rowIndex, 4].Value = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID).Name + " " + fixture.AwayTeam.Name;
								}							
								finalsSheet.Cells[rowIndex, 5].Value = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID).Name;
								rowIndex++;
							}
							rowIndex = rowIndex+1;
						}
						if (competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCup 
                            || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromSemiFinals 
                            || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCupWith3rdPlace
                            || competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals)
                        {
							subFixturesList = fixturesList.Where(i => i.Name.Contains("Cup Final")).ToList();
							using (ExcelRange range = finalsSheet.Cells[rowIndex, 1, rowIndex, 6])
                            {
								finalsSheet.Cells[rowIndex, 1, rowIndex, 6].Value = "Cup Final";
								range.Merge = true;
								range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
							}		
							rowIndex++;
							foreach(Fixture fixture in subFixturesList)
                            {
								finalsSheet.Cells[rowIndex, 1].Value = fixture.StartTime.Value.ToShortTimeString();
								if (fixture.HomeTeamID == null || fixture.HomeTeamID == 0)
                                {
									finalsSheet.Cells[rowIndex, 2].Value = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Home);
								}
 								else 
                                {
									finalsSheet.Cells[rowIndex, 2].Value = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID).Name + " " + fixture.HomeTeam.Name;
								}
								finalsSheet.Cells[rowIndex, 3].Value = "V";
								if (fixture.AwayTeamID == null || fixture.AwayTeamID == 0) 
                                {
									finalsSheet.Cells[rowIndex, 4].Value = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Away);
								}
 								else 
                                {
									finalsSheet.Cells[rowIndex, 4].Value = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID).Name + " " + fixture.AwayTeam.Name;
								}							
								finalsSheet.Cells[rowIndex, 5].Value = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID).Name;
								rowIndex++;
							}
						}


						finalsSheet.Cells.AutoFitColumns();
					}

				}

			}
			#endregion

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=" + xlTitle);
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();

        }
    }


	private void GenerateExcelRefereeSlips()
    {
		using (ExcelPackage excelPackage = new ExcelPackage())
        {

            string xlTitle = tournament.Name + " Referees Slips.xlsx";

            competitionsList = iCompetition.SQLSelectForTournament(tournament.ID, false);
            foreach (Competition competition in competitionsList) 
            {
                ExcelWorksheet competitionsSheet = excelPackage.Workbook.Worksheets.Add(EnumExtensions.GetStringValue(competition.AgeBand));
                competitionsSheet.PrinterSettings.Orientation = eOrientation.Landscape;
                fixturesList = iFixture.SQLSelectForCompetition(competition.ID);

                int rowIndex = 1;
                int recordIndex = 0;
                int offset = 1;

                #region test
                foreach (Fixture fixture in fixturesList) 
                {
                    recordIndex++;
                    if (recordIndex % 2 == 0)
                    {
                        rowIndex = rowIndex - 8;
                        offset = 6;
                    }
                    else
                    {
                        offset = 0;
                    }

                    competitionsSheet.Column(1+offset).Width = 8;
                    competitionsSheet.Column(2+offset).Width = 14;
                    competitionsSheet.Column(3+offset).Width = 8;
                    competitionsSheet.Column(4+offset).Width = 8;
                    competitionsSheet.Column(5+offset).Width = 14;
                    competitionsSheet.Column(6+offset).Width = 8;

                    competitionsSheet.Row(rowIndex).Height = 20;
                    using (ExcelRange range = competitionsSheet.Cells[rowIndex, 1+offset, rowIndex, 3+offset]) 
                    {
                        range.Merge = true;
                        range.Style.Font.Bold = true;
                        range.Style.Font.Size = 10;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                        range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        competitionsSheet.Cells[rowIndex, 1+offset].Value = EnumExtensions.GetStringValue(competition.AgeBand) + " - " + fixture.Group.Name + " - " + fixture.Name;
                    }
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Font.Bold = true;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Font.Size = 10;
                    competitionsSheet.Cells[rowIndex, 4+offset].Value = (iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID)).Name;                      
                    using (ExcelRange range = competitionsSheet.Cells[rowIndex, 5+offset, rowIndex, 6+offset])
                    {
                        range.Merge = true;
                        range.Style.Font.Bold = true;
                        range.Style.Font.Size = 10;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                        if (competition.FixtureStructure != Tournament.FixtureStructures.Undefined && competition.FixtureHalvesLength != Tournament.FixtureHalvesLengths.Undefined) 
                        {
                            competitionsSheet.Cells[rowIndex, 5+offset].Value = fixture.StartTime.Value.ToShortTimeString() + " " + EnumExtensions.GetIntValue(competition.FixtureStructure).ToString() + " x " + EnumExtensions.GetIntValue(competition.FixtureHalvesLength).ToString() + " mins"; 
                        }
                        else 
                        {
                            competitionsSheet.Cells[rowIndex, 5+offset].Value = fixture.StartTime.Value.ToShortTimeString() + " " + EnumExtensions.GetIntValue(tournament.FixtureStructure).ToString() + " x " + EnumExtensions.GetIntValue(tournament.FixtureHalvesLength).ToString() + " mins"; 
                        }
                    }
                    var headers = competitionsSheet.Cells[rowIndex, 1, rowIndex, 6+offset];
                    headers.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                    headers.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                    rowIndex++;
                    competitionsSheet.Row(rowIndex).Height = 22;
                    using (ExcelRange range = competitionsSheet.Cells[rowIndex, 1+offset, rowIndex, 3+offset])
                    {
                        range.Merge = true;
                        range.Style.Font.Bold = true;
                        range.Style.Font.Size = 10;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                        range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        competitionsSheet.Cells[rowIndex, 1+offset].Value = "HOME";
                    }
                    using (ExcelRange range = competitionsSheet.Cells[rowIndex, 4+offset, rowIndex, 6+offset]) 
                    {
                        range.Merge = true;
                        range.Style.Font.Bold = true;
                        range.Style.Font.Size = 10;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                        range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        competitionsSheet.Cells[rowIndex, 4+offset].Value = "AWAY";
                    }
                    rowIndex++;

                    competitionsSheet.Row(rowIndex).Height = 20;
                    using (ExcelRange range = competitionsSheet.Cells[rowIndex, 1+offset, rowIndex, 3+offset]) 
                    {
                        range.Merge = true;
                        range.Style.Font.Bold = true;
                        range.Style.Font.Size = 10;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                        range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        if (fixture.HomeTeam.Club != null) 
                        {
                            competitionsSheet.Cells[rowIndex, 1+offset].Value = fixture.HomeTeam.Club.Name + " " + fixture.HomeTeam.Name;
                        }
                    }
                    using (ExcelRange range = competitionsSheet.Cells[rowIndex, 4+offset, rowIndex, 6+offset]) 
                    {
                        range.Merge = true;
                        range.Style.Font.Bold = true;
                        range.Style.Font.Size = 10;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                        range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        if (fixture.AwayTeam.Club != null)
                        {
                            competitionsSheet.Cells[rowIndex, 4+offset].Value = fixture.AwayTeam.Club.Name + " " + fixture.AwayTeam.Name;
                        }
                    }

                    rowIndex++;
                    competitionsSheet.Row(rowIndex).Height = 22;
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Font.Bold = true;
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Font.Size = 10;
                    competitionsSheet.Cells[rowIndex, 1+offset].Value = "Colours";
                    using (ExcelRange range = competitionsSheet.Cells[rowIndex, 2+offset, rowIndex, 3+offset]) 
                    {
                        range.Merge = true;
                        range.Style.Font.Size = 10;
                        if (fixture.HomeTeam.Club != null)
                        {
                            competitionsSheet.Cells[rowIndex, 2+offset].Value = fixture.HomeTeam.Club.ColourPrimary + " / " + fixture.HomeTeam.Club.ColourSecondary;
                        }
                    }
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Font.Bold = true;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Font.Size = 10;
                    competitionsSheet.Cells[rowIndex, 4+offset].Value = "Colours";
                    using (ExcelRange range = competitionsSheet.Cells[rowIndex, 5+offset, rowIndex, 6+offset])
                    {
                        range.Merge = true;
                        range.Style.Font.Size = 10;
                        if (fixture.AwayTeam.Club != null)
                        {
                            competitionsSheet.Cells[rowIndex, 5+offset].Value = fixture.AwayTeam.Club.ColourPrimary + " / " + fixture.AwayTeam.Club.ColourSecondary;
                        }
                    }                        
                        
                    rowIndex++;
                        
                    competitionsSheet.Row(rowIndex).Height = 22;
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                    competitionsSheet.Cells[rowIndex, 1+offset].Value = "Goals 1st";
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Font.Bold = true;
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Font.Size = 10;
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                    competitionsSheet.Cells[rowIndex, 4+offset].Value = "Goals 1st";
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Font.Bold = true;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Font.Size = 10;
                    rowIndex++;  
         
                    competitionsSheet.Row(rowIndex).Height = 22;
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
                    competitionsSheet.Cells[rowIndex, 1+offset].Value = "Goals 2nd";
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Font.Bold = true;
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Font.Size = 10;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
                    competitionsSheet.Cells[rowIndex, 4+offset].Value = "Goals 2nd";
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Font.Bold = true;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Font.Size = 10;
                    rowIndex++;  

                    competitionsSheet.Row(rowIndex).Height = 85;
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
                    competitionsSheet.Cells[rowIndex, 1+offset].Value = "Notes";
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Font.Bold = true;
                    competitionsSheet.Cells[rowIndex, 1+offset].Style.Font.Size = 10;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
                    competitionsSheet.Cells[rowIndex, 4+offset].Value = "Notes";
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Font.Bold = true;
                    competitionsSheet.Cells[rowIndex, 4+offset].Style.Font.Size = 10;

                    rowIndex++;
                    competitionsSheet.Row(rowIndex).Height = 24;

                    using (ExcelRange range = competitionsSheet.Cells[rowIndex, 1+offset, rowIndex, 2+offset])
                    {
                        range.Merge = true;
                        range.Style.Font.Bold = true;
                        range.Style.Font.Size = 10;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                        range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                        range.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        competitionsSheet.Cells[rowIndex, 1+offset].Value = "Result  ";
                    }
                    using (ExcelRange range = competitionsSheet.Cells[rowIndex, 5+offset, rowIndex, 6+offset])
                    {
                        range.Merge = true;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                    }

                    var horizontal = competitionsSheet.Cells[2, 1+offset, rowIndex, 6+offset];
                    horizontal.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    var left = competitionsSheet.Cells[1, 1+offset, rowIndex, 1+offset];
                    left.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                    var right = competitionsSheet.Cells[1, 6+offset, rowIndex, 6+offset];
                    right.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                    var bottom = competitionsSheet.Cells[rowIndex, 1+offset, rowIndex, 6+offset];
                    bottom.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;

                    var home = competitionsSheet.Cells[rowIndex-5, 2+offset, rowIndex, 2+offset];
                    home.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    var half = competitionsSheet.Cells[rowIndex-6, 4+offset, rowIndex, 4+offset];
                    half.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    var away = competitionsSheet.Cells[rowIndex-5, 5+offset, rowIndex, 5+offset];
                    away.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                    if (recordIndex % 4 == 0)
                    {
                        competitionsSheet.Row(rowIndex).PageBreak = true;
                    }
                    rowIndex++;


                }
                rowIndex++;
                #endregion
            
            }


            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=" + xlTitle);
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.BinaryWrite(excelPackage.GetAsByteArray());
            Response.End();


		}

	}

















			//#region Teams Directory
			//ExcelWorksheet teamsSheet = pck.Workbook.Worksheets.Add("Teams");
			//using (ExcelRange range = teamsSheet.Cells["A1:F1"]) {
			//	range.Style.Font.Bold = true;
			//	range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
			//	range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
			//}
			//teamsSheet.Cells[1, 1].Value = "Club";
			//teamsSheet.Cells[1, 2].Value = "Team";
			//teamsSheet.Cells[1, 3].Value = "Age Band";
			//teamsSheet.Cells[1, 4].Value = "Contact";
			//teamsSheet.Cells[1, 5].Value = "Phone";
			//teamsSheet.Cells[1, 6].Value = "Email";
			//rowIndex = 2;
			//foreach (Club club in clubsList) {
			//	teamsSheet.Cells[rowIndex, 1].Value = club.Name;
			//	teamsSheet.Cells[rowIndex, 1].Style.Font.Bold = true;
			//	foreach (Team team in club.Teams) {
			//		teamsSheet.Cells[rowIndex, 2].Value = team.Name;
			//		if (team.GroupID != null) {
			//			group = iGroup.SQLSelect<Group, int>((int)team.GroupID);
			//			competition = iCompetition.SQLSelect<Competition, int>(group.CompetitionID);
			//			teamsSheet.Cells[rowIndex, 3].Value = EnumExtensions.GetStringValue(competition.AgeBand);
			//		}
			//		if (team.PrimaryContactID != null) {
			//			teamsSheet.Cells[rowIndex, 4].Value = team.PrimaryContact.FirstName.Substring(0, 1) + " " + team.PrimaryContact.LastName;
			//			teamsSheet.Cells[rowIndex, 5].Value = team.PrimaryContact.TelephoneNumber;
			//			teamsSheet.Cells[rowIndex, 6].Value = team.PrimaryContact.Email;
			//		}
			//		rowIndex++;
			//	}
			//	//rowIndex++;
			//}           
			//teamsSheet.Cells.AutoFitColumns();
			//#endregion




			//#region Populate System worksheet with dropdownlists
			//ExcelWorksheet systemsSheet = pck.Workbook.Worksheets.Add("System");
			//using (ExcelRange range = systemsSheet.Cells["A1:B1"]) {
			//	range.Style.Font.Bold = true;
			//	range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
			//	range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
			//}
			//systemsSheet.Cells[1, 1].Value = "Yes/No";
			//systemsSheet.Cells[2, 1].Value = "Yes";
			//systemsSheet.Cells[3, 1].Value = "No";

			//systemsSheet.Cells[1, 2].Value = "Competition Format";
			//Array enumValues = Enum.GetValues(typeof(Competition.CompetitionFormats));
			//rowIndex = 2;
			//foreach (Enum type in enumValues) {
			//	if (EnumExtensions.GetIntValue(type) > 0) {
			//		systemsSheet.Cells[rowIndex, 2].Value = EnumExtensions.GetStringValue(type).ToString();
			//		rowIndex++;
			//	}
			//}
			//#endregion

			//Competition.ExportToExcelWorkSheet(pck, tournament, false);
			//Club.ExportToExcelWorkSheet(pck, tournament, false);

			//List<Competition> competitionsList = new List<Competition>();
			//ICompetition iCompetition = new Competition();
			//competitionsList = iCompetition.SQLSelectForTournament(tournament.ID);

			//systemsSheet.Hidden = eWorkSheetHidden.VeryHidden;


			//#region Entries
			//ExcelWorksheet entriesSheet = pck.Workbook.Worksheets.Add("Entries");
			//columnIndex = 1;
			//rowIndex = 2;
			//using (ExcelRange range = entriesSheet.Cells["A1:Z1"]) {
			//	range.Style.Font.Bold = true;
			//	range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
			//	range.Style.Fill.BackgroundColor.SetColor(Color.Blue);
			//	range.Style.Font.Color.SetColor(Color.White);
			//}
			//foreach (Competition competition in competitionsList) {
			//	entriesSheet.Cells[1, columnIndex].Value = EnumExtensions.GetStringValue(competition.AgeBand) + " : " + competition.StartTime.Value.ToShortDateString(); ;
			//	teamsList = iTeam.SQLSelectForCompetition(competition.ID);

			//	foreach (Team team in teamsList) {
			//		entriesSheet.Cells[rowIndex, columnIndex].Value = team.Name;
			//		rowIndex++;
			//	}
			//	columnIndex++;
			//	rowIndex = 2;
			//}
			//entriesSheet.Cells.AutoFitColumns();
			//#endregion

			//#region Competitions
			//foreach (Competition competition in competitionsList) {
			//	if (competition.CountTeamsAttendingCompetition() > 0) {

			//		ExcelWorksheet competitionSheet = pck.Workbook.Worksheets.Add(EnumExtensions.GetStringValue(competition.AgeBand));
			//		using (ExcelRange range = competitionSheet.Cells["A1"]) {
			//			range.Style.Font.Bold = true;
			//			range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
			//			range.Style.Fill.BackgroundColor.SetColor(Color.Blue);
			//			range.Style.Font.Color.SetColor(Color.White);
			//		}
			//		competitionSheet.Cells[1, 1].Value = EnumExtensions.GetStringValue(competition.AgeBand) + " : " + competition.StartTime.Value.ToShortDateString(); ;

			//		groupsList = iGroup.SQLSelectForCompetition(competition.ID);
			//		int groupInt = 3;
			//		foreach (Group group in groupsList) {

			//			competitionSheet.Cells[groupInt, 1].Value = group.Name;
			//			using (ExcelRange range = competitionSheet.Cells[groupInt, 1]) {
			//				range.Style.Font.Bold = true;
			//				range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
			//				range.Style.Fill.BackgroundColor.SetColor(Color.Blue);
			//				range.Style.Font.Color.SetColor(Color.White);
			//			}
			//			groupInt++;

			//			teamsList = iTeam.SQLSelectForGroup(group.ID);
			//			foreach (Team team in teamsList) {
			//				competitionSheet.Cells[groupInt, 1].Value = team.Name;
			//				groupInt++;
			//			}
			//			groupInt += 2;

			//			fixturesList = iFixture.SQLSelectForGroup(group.ID);
			//			foreach (Fixture fixture in fixturesList) {
			//				competitionSheet.Cells[groupInt, 1].Value = fixture.Name;
			//				competitionSheet.Cells[groupInt, 2].Value = fixture.StartTime.Value.ToShortTimeString();
			//				club = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID);
			//				competitionSheet.Cells[groupInt, 3].Value = club.Name + " " + fixture.HomeTeam.Name;
			//				competitionSheet.Cells[groupInt, 4].Value = "V";
			//				club = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID);
			//				competitionSheet.Cells[groupInt, 5].Value = club.Name + " " + fixture.AwayTeam.Name;
			//				playingArea = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID);
			//				competitionSheet.Cells[groupInt, 6].Value = playingArea.Name;
			//				if (fixture.PrimaryOfficialID != null) {
			//					competitionSheet.Cells[groupInt, 7].Value = "Ref: " + fixture.PrimaryOfficial.FirstName.Substring(0, 1) + " " + fixture.PrimaryOfficial.LastName;
			//				}
			//				groupInt++;
			//			}
			//			groupInt += 3;
			//		}
			//		competitionSheet.Cells.AutoFitColumns();
			//	}

			//}
			//#endregion

			//#region Pitch Schedule
			//ExcelWorksheet pitchesSheet = pck.Workbook.Worksheets.Add("Pitch Schedule");
			//columnIndex = 3;
			//rowIndex = 2;
			//using (ExcelRange range = pitchesSheet.Cells["B1:Z1"]) {
			//	range.Style.Font.Bold = true;
			//	range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
			//	range.Style.Fill.BackgroundColor.SetColor(Color.Blue);
			//	range.Style.Font.Color.SetColor(Color.White);
			//}
			//pitchesSheet.Cells[1, 2].Value = "Time";
			//for (int i = 1; i <= EnumExtensions.GetIntValue(tournament.NoOfPlayingAreas); i++) {
			//	pitchesSheet.Cells[1, columnIndex].Value = "Pitch " + i.ToString();


			//	columnIndex++;
			//}
			//#endregion


			//#region Contacts
			//ExcelWorksheet contactsSheet = pck.Workbook.Worksheets.Add("Contacts");
			//using (ExcelRange range = contactsSheet.Cells["A1:E1"]) {
			//	range.Style.Font.Bold = true;
			//	range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
			//	range.Style.Fill.BackgroundColor.SetColor(Color.Blue);
			//	range.Style.Font.Color.SetColor(Color.White);
			//}
			//contactsSheet.Cells[1, 1].Value = "Contact Name";
			//contactsSheet.Cells[1, 2].Value = "Type";
			//contactsSheet.Cells[1, 3].Value = "Club or Team";
			//contactsSheet.Cells[1, 4].Value = "Phone";
			//contactsSheet.Cells[1, 5].Value = "Email";
			//rowIndex = 2;
			//foreach (GoTournamental.BLL.Organiser.Contact contact in contactsList) {
			//	contactsSheet.Cells[rowIndex, 1].Value = contact.Title + " " + contact.FirstName + " " + contact.LastName;
			//	contactsSheet.Cells[rowIndex, 2].Value = EnumExtensions.GetStringValue(contact.Type);
			//	if (contact.Type == GoTournamental.BLL.Organiser.Contact.ContactTypes.TeamContact) {
			//		team = iTeam.SQLGetTeamForPrimaryContactID(contact.ID);
			//		group = iGroup.SQLSelect<Group, int>((int)team.GroupID);
			//		competition = iCompetition.SQLSelect<Competition, int>(group.CompetitionID);                    
			//		contactsSheet.Cells[rowIndex, 3].Value = team.Name + "  (" + EnumExtensions.GetStringValue(competition.AgeBand) + ")";
			//	}
			//	if (contact.Type == GoTournamental.BLL.Organiser.Contact.ContactTypes.ClubContact) {

			//	}
			//	contactsSheet.Cells[rowIndex, 4].Value = contact.TelephoneNumber;
			//	contactsSheet.Cells[rowIndex, 5].Value = contact.Email;
			//	rowIndex++;
			//}
			//contactsSheet.Cells.AutoFitColumns();
			//#endregion



}