using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using OfficeOpenXml;
using GoTournamental.API;
using GoTournamental.API.Interface;
using GoTournamental.API.Utilities;
using GoTournamental.ORM.Organiser;

namespace GoTournamental.BLL.Organiser 
{

    public class Competition: ICompetition 
    {

        #region Member Enumerations & Collections
        public enum AgeBands 
        {
            Undefined = 0,
            [DescriptionAttribute("Under 7s")] Under7s = 1,
            [DescriptionAttribute("Under 8s")] Under8s = 2,
	        [DescriptionAttribute("Under 9s")] Under9s = 3,
            [DescriptionAttribute("Under 10s")] Under10s = 4,
            [DescriptionAttribute("Under 11s")] Under11s = 5,
			[DescriptionAttribute("Under 12s")] Under12s = 6,
			[DescriptionAttribute("Under 13s")] Under13s = 7,
            [DescriptionAttribute("Under 14s")] Under14s = 8,
            [DescriptionAttribute("Under 15s")] Under15s = 9,
            [DescriptionAttribute("Under 16s")] Under16s = 10,
            [DescriptionAttribute("Under 18 Boys")] Under18Boys = 11,
            [DescriptionAttribute("Under 19s Men")] Under19sMen = 12,
            [DescriptionAttribute("Under 21s Men")] Under21sMen = 13,
            [DescriptionAttribute("Mens Seniors")] MensSeniors = 14,
            [DescriptionAttribute("Under 14 Girls")] Under14Girls = 15,
            [DescriptionAttribute("Under 15 Girls")] Under15Girls = 16,
            [DescriptionAttribute("Under 16 Girls")] Under16Girls = 17,
            [DescriptionAttribute("Under 18 Girls")] Under18Girls = 18,
            [DescriptionAttribute("Under 19s Women")] Under19sWomen = 19,
            [DescriptionAttribute("Under 21s Women")] Under21sWomen = 20,
            [DescriptionAttribute("Womens Seniors")] WomensSeniors = 21,
            [DescriptionAttribute("Under 12 Girls")] Under12Girls = 22,
            [DescriptionAttribute("Under 13 Girls")] Under13Girls = 23,
            [DescriptionAttribute("Under 17 Boys")] Under17Boys = 24,
            [DescriptionAttribute("Under 6s")] Under6s = 25,
            Veterans = 26,
            [DescriptionAttribute("Under 8 Girls")] Under8Girls = 27,
            [DescriptionAttribute("Under 9 Girls")] Under9Girls = 28,
            [DescriptionAttribute("Under 10 Girls")] Under10Girls = 29,
            [DescriptionAttribute("Under 11 Girls")] Under11Girls = 30,
            [DescriptionAttribute("Under 17 / Under 18")] Under1718 = 31,
            [DescriptionAttribute("Under 11 Dev")] Under11Dev = 32
        }
        public enum CompetitionFormats 
        {
            Undefined = 0,
            [DescriptionAttribute("Non Competitive - Round Robins In Group(s)")] LeagueNonCompetitive = 1,
            [DescriptionAttribute("Competitive League(s)")] LeagueCompetitive = 2,
            [DescriptionAttribute("Competitive League(s) With Cup Final")] LeagueAndCup = 3,
            [DescriptionAttribute("Competitive League(s) With Cup Final and 3rd Place Play-Off")] LeagueAndCupWith3rdPlace = 4,
            [DescriptionAttribute("Competitive League(s) With Cup and Plate From Semi-Finals")] LeagueCupAndPlateFromSemiFinals = 5,
            [DescriptionAttribute("Competitive League(s) With Cup and Plate From Quarter-Finals")] LeagueCupAndPlateFromQuarterFinals = 6
        }
		public enum Sessions 
        {
			Undefined = 0,
			[DescriptionAttribute("All Day")] AllDay = 1,
			[DescriptionAttribute("AM Only")] AMOnly = 2,
			[DescriptionAttribute("PM Only")] PMOnly = 3
		}
		public enum Seeding 
        {
			Undefined = 0,
			[DescriptionAttribute("Top Level Seeding Only")] OneLevel = 1,
			[DescriptionAttribute("Two Level Seeding")] TwoLevels = 2,
			[DescriptionAttribute("Three Level Seeding")] ThreeLevels = 3,
			[DescriptionAttribute("All Level Seeded")] AllLevels = 4
		}		
		#endregion
        
        #region Constructors
        public Competition() { }
        public Competition(int tournamentID, AgeBands ageBand)
			: this(
				id : 0 , 
				tournamentID : tournamentID , 
				ageBand : ageBand , 
				startTime : null ,
 				session : Sessions.Undefined,
				competitionFormat : Competition.CompetitionFormats.Undefined ,
				fixtureTurnaround : Tournament.FixtureTurnarounds.Undefined ,
                fixtureStructure : Tournament.FixtureStructures.Undefined ,
                fixtureHalvesLength : Tournament.FixtureHalvesLengths.Undefined ,
				teamSize : Domains.NumberOfParticipants.Undefined ,
				squadSize : Domains.NumberOfParticipants.Undefined 		
			) 
            {	
		}
        public Competition(
            int id, int tournamentID, AgeBands ageBand, DateTime? startTime, Sessions session, CompetitionFormats competitionFormat, 
            Tournament.FixtureTurnarounds fixtureTurnaround, Tournament.FixtureStructures fixtureStructure, Tournament.FixtureHalvesLengths fixtureHalvesLength,
            Domains.NumberOfParticipants teamSize, Domains.NumberOfParticipants squadSize
        ) 
        {
			this.ID = id;
			this.TournamentID = tournamentID;
			this.AgeBand = ageBand;
			this.StartTime = startTime;
			this.Session = session;
			this.CompetitionFormat = competitionFormat;
			this.FixtureTurnaround = fixtureTurnaround;
            this.FixtureStructure = fixtureStructure;
            this.FixtureHalvesLength = fixtureHalvesLength;
            this.TeamSize = teamSize;
            this.SquadSize = squadSize;
		}
        #endregion

        #region Properties
        public int ID { get; set; }
        public int TournamentID { get; set; }
        public AgeBands AgeBand { get; set; }
        public DateTime? StartTime { get; set; }
		public Sessions Session { get; set; } 
        public CompetitionFormats CompetitionFormat { get; set; }
        public Tournament.FixtureTurnarounds FixtureTurnaround { get; set; }
        public Tournament.FixtureStructures FixtureStructure { get; set; }
        public Tournament.FixtureHalvesLengths FixtureHalvesLength { get; set; }
        public Domains.NumberOfParticipants TeamSize { get; set; }
        public Domains.NumberOfParticipants SquadSize { get; set; }
        #endregion

        #region Methods
        public void SQLInsert<T>(T input) 
        {
            if (ObjectExtensions.ObjectTypesMatch<Competition, T>(input)) 
            {
                CompetitionDbContext context = new CompetitionDbContext();
                Competition existing = context.Competitions.Where(i => i.TournamentID == ((Competition)(object)input).TournamentID && i.AgeBand == ((Competition)(object)input).AgeBand).SingleOrDefault();
                if (existing == null) 
                {
                    context.Competitions.Add((Competition)(object)input);
                    context.SaveChanges();
                }
            }
        }   
        public T SQLSelect<T, U>(U id) 
        {
            CompetitionDbContext context = new CompetitionDbContext();
            Competition selected = context.Competitions.Where(i => i.ID == (int)(object)id).SingleOrDefault();
            return (T)(object)selected;
        }    
		public List<Competition> SQLSelectForTournament(int tournamentID, bool sessionBased) 
        {
            CompetitionDbContext context = new CompetitionDbContext();
			List<Competition> selectedList = context.Competitions.Where(i => i.TournamentID == tournamentID).OrderBy(i => i.AgeBand).ToList();
			IQueryable<Competition> query = selectedList.ToList().AsQueryable();
			if (sessionBased == true) 
            {
				ITournament iTournament = new Tournament();
				Tournament tournament = iTournament.SQLSelect<Tournament, int>(tournamentID);
				if (tournament.RotatorDate.HasValue && tournament.RotatorDate != null) 
                {
					query = query.Where(i => i.TournamentID == tournamentID 
						&& i.StartTime.Value.Year == tournament.RotatorDate.Value.Year 
						&& i.StartTime.Value.Month == tournament.RotatorDate.Value.Month 
						&& i.StartTime.Value.Day == tournament.RotatorDate.Value.Day
					);
				}
				if (tournament.RotatorSession != Sessions.Undefined) 
                {
					query = query.Where(i => i.Session == tournament.RotatorSession);
				}
			}
			selectedList = query.ToList();
            return selectedList;		
		}
        public void SQLUpdate<T>(T input) 
        {
            if (ObjectExtensions.ObjectTypesMatch<Competition, T>(input)) 
            {
                CompetitionDbContext context = new CompetitionDbContext();
                Competition updated = (Competition)(object)input;
                Competition selected = context.Competitions.Single(i => i.ID == updated.ID);
                selected.StartTime = updated.StartTime;
                selected.Session = updated.Session;
                selected.CompetitionFormat = updated.CompetitionFormat;
                selected.FixtureTurnaround = updated.FixtureTurnaround;
                selected.FixtureStructure = updated.FixtureStructure;
                selected.FixtureHalvesLength = updated.FixtureHalvesLength;
                selected.TeamSize = updated.TeamSize;
                selected.SquadSize = updated.SquadSize;
                context.SaveChanges();
            }
        }					
		public int SQLCompetitionIDForAgeBand(int tournamentID, int ageBand) 
        {
            CompetitionDbContext context = new CompetitionDbContext();
            int teams = context.SQLCompetitionIDForAgeBand(tournamentID, ageBand).Single();
            return teams;
        }		
		public int CountTeamsAttendingCompetition()
        {
            CompetitionDbContext context = new CompetitionDbContext();
            int teams = context.CountTeamsAttendingCompetition(this.ID).Single();
            return teams;
        }
		public int CountTeamsRegisteredAtCompetition() 
        {
            CompetitionDbContext context = new CompetitionDbContext();
            int teams = context.CountTeamsRegisteredAtCompetition(this.ID).Single();
            return teams;
        }        
		public int CountTeamsAcceptedInviteForCompetition() 
        {
            CompetitionDbContext context = new CompetitionDbContext();
            int teams = context.CountTeamsAcceptedInviteForCompetition(this.ID).Single();
            return teams;
        }
		public int CountHostTeamsAttendingCompetition() 
        {
            CompetitionDbContext context = new CompetitionDbContext();
            int teams = context.CountHostTeamsAttendingCompetition(this.ID).Single();
            return teams;
        }		
		public int CountGroupsForCompetition() 
        {
            CompetitionDbContext context = new CompetitionDbContext();
            int teams = context.CountGroupsForCompetition(this.ID).Single();
            return teams;
        }
		public int CountGroupsForCompetition(int competitionID) 
        {
            CompetitionDbContext context = new CompetitionDbContext();
            int teams = context.CountGroupsForCompetition(competitionID).Single();
            return teams;
        }
        public int CountGroupsForCompetitionWhereFixturesUnderway(int competitionID)
        {
            CompetitionDbContext context = new CompetitionDbContext();
            int teams = context.CountGroupsForCompetitionWhereFixturesUnderway(competitionID).Single();
            return teams;
        }
		public int CountPlayingAreasForCompetition() 
        {
			CompetitionDbContext context = new CompetitionDbContext();
			int playingAreas = context.CountPlayingAreasForCompetition(this.ID).Single();
			return playingAreas;
		}
		public int CountFixturesForCompetition() 
        {
            CompetitionDbContext context = new CompetitionDbContext();
            int noFixtures = context.CountFixturesForCompetition(this.ID).Single();
            return noFixtures;
        } 
 		public int CountLeagueFixturesForCompetition()
        {
            CompetitionDbContext context = new CompetitionDbContext();
            int noFixtures = context.CountFixturesForCompetition(this.ID).Single();
            return noFixtures;
        }
        public bool FixturesUnderwayForCompetition() 
        {
            bool underway = false;
            IGroup iGroup = new Group();
            List<Group> groups = new List<Group>();
            groups = iGroup.SQLSelectForCompetition(this.ID);
            foreach (Group group in groups) 
            {
                if (group.FixturesUnderWay == true) 
                {
                    underway = true;
                }
            }
            return underway;
        }
        public int CountCompletedLeagueFixturesForCompetition() 
        {
            CompetitionDbContext context = new CompetitionDbContext();
            int noFixtures = context.CountFixturesForCompetition(this.ID).Single();
            return noFixtures;
        }
        public bool CompetitionAllLeaguesFixturesCompleted(int competitionID) 
        {
            CompetitionDbContext context = new CompetitionDbContext();
            bool completed = context.CompetitionAllLeaguesFixturesCompleted(competitionID).Single();
            return completed;
        }
        public bool SQLAgeBandExistsForTournament(int tournamentID,  AgeBands ageBand)
        {
            CompetitionDbContext context = new CompetitionDbContext();
			bool exists = context.Competitions.Any(i => i.TournamentID == tournamentID && i.AgeBand == ageBand);
			return exists;
		}
		public void SwapTeamsBetweenGroupsWithCascadeToFixtures(int teamOneID, int teamTwoID) 
        {
            CompetitionDbContext context = new CompetitionDbContext();
			context.SwapTeamsBetweenGroupsWithCascadeToFixtures(teamOneID, teamTwoID);
		}
		public void DeleteGroupsForCompetitionWithCascadeToFixtures(int competitionID) 
        {
            CompetitionDbContext context = new CompetitionDbContext();
			context.DeleteGroupsForCompetitionWithCascadeToFixtures(competitionID);
		}

		public static FileImportStatus ImportFromExcelWorksheet(ExcelWorksheet worksheet, Tournament tournament) 
        {
			FileImportStatus importStatus = new FileImportStatus();
			ICompetition iCompetition = new Competition();
			int competitionsImported = 0;
			List<string> messages = new List<string>();
			string ageBandColumn, requiredColumn, competitionFormatColumn, startTimeColumn, fixtureTurnaroundColumn;
			string required;
			Competition.AgeBands ageBand;
			Competition.CompetitionFormats competitionFormat;
            DateTime? startTime = new DateTime();
            Tournament.FixtureTurnarounds fixtureTurnaround = Tournament.FixtureTurnarounds.Undefined;

			using (var headers = worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column]) 
            {
				var expectedHeaders = new[] { "Age Band", "Required", "Competition Format", "Start Time", "Fixture Turnaround" };
				if (!expectedHeaders.All(e => headers.Any(h => h.Value.Equals(e))))
                {
					messages.Add("Some columns are missing from the Competitions Worksheet");
					importStatus = new FileImportStatus(competitionsImported, messages);
					return importStatus;
				}
				ageBandColumn = headers.First(h => h.Value.Equals("Age Band")).Address[0].ToString();
				requiredColumn = headers.First(h => h.Value.Equals("Required")).Address[0].ToString();
				competitionFormatColumn = headers.First(h => h.Value.Equals("Competition Format")).Address[0].ToString();
                startTimeColumn = headers.First(h => h.Value.Equals("Start Time")).Address[0].ToString();
				fixtureTurnaroundColumn = headers.First(h => h.Value.Equals("Fixture Turnaround")).Address[0].ToString();
            }
			var lastRow = worksheet.Dimension.End.Row;
			while (lastRow >= 1) 
            {
				var range = worksheet.Cells[lastRow, 1, lastRow, 3];
				if (range.Any(i => i.Value != null))
                {
					break;
				}
				lastRow--;
			}
			for (var row = 2; row <= lastRow; row++) 
            {
				ageBand = worksheet.Cells[ageBandColumn + row].Value == null || worksheet.Cells[ageBandColumn + row].Value.ToString() == "" ? AgeBands.Undefined : EnumExtensions.GetValueFromDescription<Competition.AgeBands>(worksheet.Cells[ageBandColumn + row].Value.ToString());
				required = worksheet.Cells[requiredColumn + row].Value == null || worksheet.Cells[requiredColumn + row].Value.ToString() == "" ? "" : worksheet.Cells[requiredColumn + row].Value.ToString(); 
				competitionFormat = worksheet.Cells[competitionFormatColumn + row].Value == null || worksheet.Cells[competitionFormatColumn + row].Value.ToString() == "" ? CompetitionFormats.Undefined : EnumExtensions.GetValueFromDescription<Competition.CompetitionFormats>(worksheet.Cells[competitionFormatColumn + row].Value.ToString()); 
				startTime = worksheet.Cells[startTimeColumn + row].Value == null ? (DateTime?) null : DataImportFromExcel.CleanDateField(worksheet.Cells[startTimeColumn + row].Value.ToString());
				fixtureTurnaround = worksheet.Cells[fixtureTurnaroundColumn + row].Value == null || worksheet.Cells[fixtureTurnaroundColumn + row].Value.ToString() == "" ? tournament.FixtureTurnaround : EnumExtensions.GetValueFromDescription<Tournament.FixtureTurnarounds>(worksheet.Cells[fixtureTurnaroundColumn + row].Value.ToString()); 
					Competition competition = new Competition(
					id: 0,
					tournamentID: tournament.ID,
					ageBand: ageBand ,
					startTime: startTime ,
					session : Sessions.Undefined ,
					competitionFormat: competitionFormat ,
					fixtureTurnaround : fixtureTurnaround ,
                    fixtureStructure : Tournament.FixtureStructures.Undefined ,
                    fixtureHalvesLength : Tournament.FixtureHalvesLengths.Undefined ,
                    teamSize : tournament.TeamSize ,
                    squadSize : tournament.SquadSize 
				);
				try 
                {
					bool alreadyExists = true;
					alreadyExists = iCompetition.SQLAgeBandExistsForTournament(tournament.ID, ageBand);
					if (required == "Yes" && !alreadyExists) 
                    {
						iCompetition.SQLInsert<Competition>(competition);
						competitionsImported++;
					}
				} 
				catch (Exception exception) 
                {
					messages.Add(string.Format("Competition record on line #{0} failed: {1}\n", row, exception.Message));
					importStatus = new FileImportStatus(competitionsImported, messages);
					return importStatus;
				}

			}
					
			importStatus = new FileImportStatus(competitionsImported, messages);
			return importStatus;
		}		
		public static ExcelPackage ExportToExcelWorkSheet(ExcelPackage excelPackage, Tournament tournament, bool templateOnly) 
        {

			ExcelWorksheet competitionsSheet = excelPackage.Workbook.Worksheets.Add("Age Bands");
            int rowIndex = 0;
			
			List<Competition> competitionsList = new List<Competition>();
			ICompetition iCompetition = new Competition();
			competitionsList = iCompetition.SQLSelectForTournament(tournament.ID, false);
			string hourString = "";
			string minuteString = "";

            using (ExcelRange range = competitionsSheet.Cells["A1:E1"]) 
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
            }
            competitionsSheet.Cells[1, 1].Value = "Age Band";
            competitionsSheet.Cells[1, 2].Value = "Required";
            competitionsSheet.Cells[1, 3].Value = "Competition Format";
            competitionsSheet.Cells[1, 4].Value = "Start Time";
            competitionsSheet.Cells[1, 5].Value = "Fixture Turnaround";
            rowIndex = 2; 

            Array ageBandValues = Enum.GetValues(typeof(Competition.AgeBands));
            Array formatValues = Enum.GetValues(typeof(Competition.CompetitionFormats));
            foreach (Enum ageBand in ageBandValues) 
            {
                if (EnumExtensions.GetIntValue(ageBand) > 0) 
                {
					competitionsSheet.Cells[rowIndex, 1].Value = EnumExtensions.GetStringValue(ageBand);

					var requiredValidation = competitionsSheet.Cells[rowIndex, 2].DataValidation.AddListDataValidation();
					requiredValidation.ShowErrorMessage = true;
					requiredValidation.ErrorTitle = "An invalid value was entered";
					requiredValidation.Error = "Select a value from the list";
					foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets) 
                    {
						if (worksheet.Name == "System")
                        {
							var formula = "=System!$A$2:$A$3";
							requiredValidation.Formula.ExcelFormula = formula;
						}
					}

					var formatValidation = competitionsSheet.Cells[rowIndex, 3].DataValidation.AddListDataValidation();
					formatValidation.ShowErrorMessage = true;
					formatValidation.ErrorTitle = "An invalid value was entered";
					formatValidation.Error = "Select a value from the list";
					foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets) 
                    {
						if (worksheet.Name == "System") 
                        {
							var formula = "=System!$B$2:$B$"+(formatValues.Length);
							formatValidation.Formula.ExcelFormula = formula;
						}
					}


					rowIndex++;
               }
            }

			var lastRow = competitionsSheet.Dimension.End.Row;
			while (lastRow >= 1) 
            {
				var range = competitionsSheet.Cells[lastRow, 1, lastRow, 3];
				if (range.Any(i => i.Value != null))
                {
					break;
				}
				lastRow--;
			}

			for (var row = 2; row <= lastRow; row++) 
            {
				competitionsSheet.Cells[row, 2].Value = "No";
				if (competitionsSheet.Cells[row, 1].Value.ToString() == EnumExtensions.GetStringValue(Competition.AgeBands.Under7s) || competitionsSheet.Cells[row, 1].Value.ToString() == EnumExtensions.GetStringValue(Competition.AgeBands.Under8s)) 
                {
					competitionsSheet.Cells[row, 3].Value = EnumExtensions.GetStringValue(Competition.CompetitionFormats.LeagueNonCompetitive);
				}

			}

			
			if (templateOnly == false) 
            {
				for (var row = 2; row <= lastRow; row++) 
                {
                    Competition selected = competitionsList.Where(i => EnumExtensions.GetStringValue(i.AgeBand) == competitionsSheet.Cells[row, 1].Value.ToString()).SingleOrDefault();
					if (selected != null) 
                    {
						competitionsSheet.Cells[row, 2].Value = "Yes";
						if (selected.CompetitionFormat != CompetitionFormats.Undefined) 
                        {
							competitionsSheet.Cells[row, 3].Value = EnumExtensions.GetStringValue(selected.CompetitionFormat);
						}
						if (selected.StartTime.HasValue) 
                        {
							hourString = selected.StartTime.Value.Hour.ToString();
							if (hourString.Length == 1) 
                            {
								hourString = "0" + hourString;
							}
							minuteString = selected.StartTime.Value.Minute.ToString();
							if (minuteString.Length == 1) 
                            {
								minuteString = "0" + minuteString;
							}
						}
						competitionsSheet.Cells[row, 4].Value = selected.StartTime.Value.ToShortDateString() + " " + hourString + ":" + minuteString;
						competitionsSheet.Cells[row, 5].Value = EnumExtensions.GetStringValue(selected.FixtureTurnaround);
					}
					else 
                    {
						competitionsSheet.Cells[row, 2].Value = "No";
					}

				}
			}

            competitionsSheet.Cells.AutoFitColumns();
			return excelPackage;
		}
		#endregion

    }

    public interface ICompetition : ISQLInsertable, ISQLSelectable, ISQLUpdateable  
    {
        int ID { get; }
        int TournamentID { get; }
        Competition.AgeBands AgeBand { get; }
        DateTime? StartTime { get; }
		Competition.Sessions Session { get; }
        Competition.CompetitionFormats CompetitionFormat { get; }
		Tournament.FixtureTurnarounds FixtureTurnaround { get; }
        Tournament.FixtureStructures FixtureStructure { get; }
        Tournament.FixtureHalvesLengths FixtureHalvesLength { get; }
        Domains.NumberOfParticipants TeamSize { get; }
        Domains.NumberOfParticipants SquadSize { get; }
		List<Competition> SQLSelectForTournament(int tournamentID, bool sessionBased);
		int SQLCompetitionIDForAgeBand(int tournamentID, int ageBand);
        int CountTeamsAttendingCompetition();
        int CountTeamsRegisteredAtCompetition();
		int CountTeamsAcceptedInviteForCompetition();
		int CountHostTeamsAttendingCompetition();
		int CountGroupsForCompetition();
		int CountGroupsForCompetition(int competitionID);
        int CountGroupsForCompetitionWhereFixturesUnderway(int competitionID);
		int CountPlayingAreasForCompetition();
        int CountFixturesForCompetition();
        bool FixturesUnderwayForCompetition();
        bool CompetitionAllLeaguesFixturesCompleted(int competitionID);
		bool SQLAgeBandExistsForTournament(int tournamentID, Competition.AgeBands ageBand);
		void SwapTeamsBetweenGroupsWithCascadeToFixtures(int teamOneID, int teamTwoID);
		void DeleteGroupsForCompetitionWithCascadeToFixtures(int competitionID);
    }

}