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
using GoTournamental.BLL.Planner;

namespace GoTournamental.BLL.Organiser {
        
    public class Tournament: ITournament {

        #region Member Constants, Enumerations & Collections
        public const int footballMaxTeamSize = 11;
        public const int footballMaxSquadSize = 16;
        public const int rugbyMaxTeamSize = 15;
        public const int rugbyMaxSquadSize = 22;

        public enum TournamentTypes {
            Undefined = 0,
            [DescriptionAttribute("Football - Juniors")] FootballJunior = 1,
            [DescriptionAttribute("Rugby - Juniors")] RugbyJunior = 2
            //Swimming = 3,
            //Tennis = 4,
            //Badminton = 5,
            //Judo = 6,
            //[DescriptionAttribute("Martial Arts")] MartialArts = 7
        }
        public enum TournamentDurations {
            Undefined = 0,
            OneDay = 1,
            TwoDay = 2,
            ThreesDay = 3
        }
        public enum PlayingAreaTypes {
            Undefined = 0,
            Pitches = 1
            //Courts = 2,
            //Mats = 3,
            //Pools = 4
        }
        public enum NumberOfPlayingAreas {
            Undefined = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10
        }
        public enum FixtureTurnarounds {
            Undefined = 0,
			[DescriptionAttribute("5 Minutes")] Five = 5,
			[DescriptionAttribute("6 Minutes")] Six = 6,
			[DescriptionAttribute("7 Minutes")] Seven = 7,
			[DescriptionAttribute("8 Minutes")] Eight = 8,
			[DescriptionAttribute("9 Minutes")] Nine = 9,
			[DescriptionAttribute("10 Minutes")] Ten = 10,
			[DescriptionAttribute("12 Minutes")] Twelve = 12,
			[DescriptionAttribute("15 Minutes")] Fifteen = 15,
			[DescriptionAttribute("20 Minutes")] Twenty = 20,
			[DescriptionAttribute("25 Minutes")] TwentyFive = 25,
			[DescriptionAttribute("30 Minutes")] Thirty = 30,
			[DescriptionAttribute("40 Minutes")] Forty = 40,
			[DescriptionAttribute("60 Minutes")] Sixty = 60,
			[DescriptionAttribute("80 Minutes")] Eighty = 80,
			[DescriptionAttribute("90 Minutes")] Ninety = 90
        } 
        public enum FixtureHalvesNumbers {
            Undefined = 0,
			One = 1,
			Two = 2
        } 
        public enum FixtureHalvesLengths {
            Undefined = 0,
			[DescriptionAttribute("2 Minutes")] Two = 2,
			[DescriptionAttribute("3 Minutes")] Three = 3,
			[DescriptionAttribute("4 Minutes")] Four = 4,
			[DescriptionAttribute("5 Minutes")] Five = 5,
			[DescriptionAttribute("6 Minutes")] Six = 6,
			[DescriptionAttribute("7 Minutes")] Seven = 7,
			[DescriptionAttribute("8 Minutes")] Eight = 8,
			[DescriptionAttribute("9 Minutes")] Nine = 9,
			[DescriptionAttribute("10 Minutes")] Ten = 10,
			[DescriptionAttribute("11 Minutes")] Eleven = 11,
			[DescriptionAttribute("12 Minutes")] Twelve = 12,
			[DescriptionAttribute("13 Minutes")] Thirteen = 13,
			[DescriptionAttribute("14 Minutes")] Fourteen = 14,
			[DescriptionAttribute("15 Minutes")] Fifteen = 15,
			[DescriptionAttribute("20 Minutes")] Twenty = 20,
			[DescriptionAttribute("25 Minutes")] TwentyFive = 25,
			[DescriptionAttribute("30 Minutes")] Thirty = 30,
			[DescriptionAttribute("35 Minutes")] ThirtyFive = 35,
			[DescriptionAttribute("40 Minutes")] Forty = 40,
			[DescriptionAttribute("45 Minutes")] FortyFive = 45
        } 
		#endregion
              
        #region Constructors
		public Tournament() {}
        public Tournament(
            int id, TournamentTypes tournamentType, string name, int? affiliation, DateTime? startTime, DateTime? endTime, string venue, string postcode, string googleMapsURL, 
            NumberOfPlayingAreas noOfPlayingAreas, FixtureTurnarounds fixtureTurnaround, FixtureHalvesNumbers fixtureHalvesNumber, FixtureHalvesLengths fixtureHalvesLength,
            Domains.NumberOfParticipants teamSize, Domains.NumberOfParticipants squadSize, DateTime? rotatorDate, Competition.Sessions rotatorSession
        ) {
            this.ID = id;
            this.TournamentType = tournamentType;
            this.Name = name;
			this.Affiliation = affiliation;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Venue = venue;
            this.Postcode = postcode;
            this.GoogleMapsURL = googleMapsURL;
            this.NoOfPlayingAreas = noOfPlayingAreas;
			this.FixtureTurnaround = fixtureTurnaround;
            this.FixtureHalvesNumber = fixtureHalvesNumber;
            this.FixtureHalvesLength = fixtureHalvesLength;
            this.TeamSize = teamSize;
            this.SquadSize = squadSize;
			this.RotatorDate = rotatorDate;
			this.RotatorSession = rotatorSession;
       }
        #endregion
       
		#region Properties
        public int ID { get; set; }
        public TournamentTypes TournamentType { get; set; }
        public Club HostClub {
            get {
                Club club = new Club();
                IClub iClub = new Club();
                club = iClub.SQLSelectHostClubForTournament(this.ID);
                return club;
            }
        }        
		public string Name { get; set; }        
		public int? Affiliation { get; set; }        
		public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
		public TimeSpan Duration {
            get {
				TimeSpan duration = new TimeSpan();
				if (this.StartTime.HasValue && this.EndTime.HasValue) {
					duration = DateTime.Parse(this.EndTime.Value.ToShortDateString()) - DateTime.Parse(this.StartTime.Value.ToShortDateString());
				}
				return duration;
            }
		}
		public List<DateTime> ScheduledDays {
            get {
				List<DateTime> scheduledDays = new List<DateTime>();
				if (this.StartTime.HasValue && this.EndTime.HasValue) {
					scheduledDays.Add((DateTime)this.StartTime);
				}
				for (int i = 0; i < this.Duration.Days; i++ ) {
					scheduledDays.Add(((DateTime)this.StartTime).AddDays(1));
				}				
				return scheduledDays;
            }
		}
		public string Venue { get; set; }
        public string Postcode { get; set; }
        public string GoogleMapsURL { get; set; }
        public PlayingAreaTypes PlayingAreaType {
            get {
                switch (this.TournamentType) {
                    case TournamentTypes.FootballJunior:
                        return PlayingAreaTypes.Pitches;
                    default:
                        return PlayingAreaTypes.Undefined;
                }
            }
        }
        public NumberOfPlayingAreas NoOfPlayingAreas { get; set; }
        public FixtureTurnarounds FixtureTurnaround { get; set; }
        public FixtureHalvesNumbers FixtureHalvesNumber { get; set; }
        public FixtureHalvesLengths FixtureHalvesLength { get; set; }
        public Domains.NumberOfParticipants TeamSize { get; set; }
        public Domains.NumberOfParticipants SquadSize { get; set; }		
		public DateTime? RotatorDate { get; set; }
		public Competition.Sessions RotatorSession { get; set; }
		#endregion

        #region Methods
        public int SQLInsertAndReturnID<T>(T input) {
            int ret = 0;
            if (ObjectExtensions.ObjectTypesMatch<Tournament, T>(input)) {
                TournamentDbContext context = new TournamentDbContext();
                context.Tournaments.Add((Tournament)(object)input);
                context.SaveChanges();
                ret = ((Tournament)(object)input).ID;
            }
            return ret;
        }
        public T SQLSelect<T, U>(U id) {
            TournamentDbContext context = new TournamentDbContext();
            Tournament selected = context.Tournaments.Where(i => i.ID == (int)(object)id).SingleOrDefault();
            return (T)(object)selected;
        }
        public List<T> SQLSelectAll<T>() {
            TournamentDbContext context = new TournamentDbContext();
            IEnumerable<Tournament> selectedList = context.Tournaments.ToList();
            List<T> selectedTList = new List<T>();
            foreach (Tournament ins in selectedList) {
                selectedTList.Add((T)((object)ins));
            }
            return selectedTList;
        }
        public List<Tournament> SQLSelectSearch(Tournament.TournamentTypes selectedType, string searchFor) {
            TournamentDbContext context = new TournamentDbContext();
            List<Tournament> selectedList = context.Tournaments.OrderBy(i => i.StartTime).ToList();
            IQueryable<Tournament> query = selectedList.ToList().AsQueryable();
            if (selectedType != Tournament.TournamentTypes.Undefined) {
                query = query.Where(i => i.TournamentType == selectedType).OrderByDescending(i => i.StartTime);
            }            
			if (searchFor != "") {
                query = query.Where(i => i.Name.ToUpperInvariant().Contains(searchFor.ToUpperInvariant())).OrderByDescending(i => i.StartTime);
            }
            selectedList = query.ToList();
            return selectedList;
        }
        public void SQLUpdate<T>(T input) {
            if (ObjectExtensions.ObjectTypesMatch<Tournament, T>(input)) {
                TournamentDbContext context = new TournamentDbContext();
                Tournament updated = (Tournament)(object)input;
                Tournament selected = context.Tournaments.Single(i => i.ID == updated.ID);
                selected.Name = updated.Name;
				selected.Affiliation = updated.Affiliation;
                selected.StartTime = updated.StartTime;
                selected.EndTime = updated.EndTime;
                selected.Venue = updated.Venue;
                selected.Postcode = updated.Postcode;
                selected.GoogleMapsURL = updated.GoogleMapsURL;
                selected.NoOfPlayingAreas = updated.NoOfPlayingAreas;
				selected.FixtureTurnaround = updated.FixtureTurnaround;
                selected.FixtureHalvesNumber = updated.FixtureHalvesNumber;
                selected.FixtureHalvesLength = updated.FixtureHalvesLength;
                selected.TeamSize = updated.TeamSize;
                selected.SquadSize = updated.SquadSize;
                selected.RotatorDate = updated.RotatorDate;
                selected.RotatorSession = updated.RotatorSession;
                context.SaveChanges();
            }
        }
        public void SQLTournamentDeleteFileImportWithCascade(int tournamentID) {
            TournamentDbContext context = new TournamentDbContext();
            context.SQLTournamentDeleteFileImportWithCascade(tournamentID);
        }		        
        public int CountPlayingAreasForTournament(int tournamentID) {
            TournamentDbContext context = new TournamentDbContext();
            int noPlayingAreas = context.CountPlayingAreasForTournament(tournamentID).Single();
            return noPlayingAreas;
        }
        public int CountCompetitionsForTournament() {
            TournamentDbContext context = new TournamentDbContext();
            int noCompetitions = context.CountCompetitionsForTournament(this.ID).Single();
            return noCompetitions;
        }
        public int CountTeamsForTournament() {
            TournamentDbContext context = new TournamentDbContext();
            int noTeams = context.CountTeamsForTournament(this.ID).Single();
            return noTeams;
        }
        public int CountTeamsForTournament(Domains.AttendanceTypes attendanceType) {
            TournamentDbContext context = new TournamentDbContext();
            int noTeams = context.CountTeamsForTournamentByAttendanceType(this.ID, attendanceType).Single();
            return noTeams;
        }        		
		public int CountFixturesScheduledForTournament() {
            TournamentDbContext context = new TournamentDbContext();
            int noFixtures = context.CountFixturesScheduledForTournament(this.ID).Single();
            return noFixtures;
        }
        public int CountFixturesPerHourForTournament(NumberOfPlayingAreas noOfPlayingAreas, FixtureTurnarounds fixtureTurnaround) {
			int ret = 0;
			return ret;
		}
		public int CountFixturesPossibleForTournament(DateTime? startTime, DateTime? endTime, NumberOfPlayingAreas noOfPlayingAreas, FixtureTurnarounds fixtureTurnaround) {
			int ret = 0;
			DateTime fixtureEnd = (DateTime)startTime;
			while (fixtureEnd < endTime) {
				fixtureEnd = fixtureEnd.AddMinutes(EnumExtensions.GetIntValue(fixtureTurnaround));
				ret++;
            }
			ret = ret * EnumExtensions.GetIntValue(noOfPlayingAreas);
			return ret;
		}

        public string GetSourceForGoogleMapEmbedString(string input) {
            string output = "";
            if (input.Contains("iframe") && input.Contains("https://www.google.com/maps/embed?")) {
                output = input.Substring(input.IndexOf("https:"),input.IndexOf("wid")-15);
            }
            return output;
        }

		public static ExcelPackage ExportToExcelWorkSheet(ExcelPackage excelPackage, Tournament tournament) {

			ExcelWorksheet tournamentSheet = excelPackage.Workbook.Worksheets.Add("Tournament");
			using (ExcelRange range = tournamentSheet.Cells["A1:A19"]) {
				range.Style.Font.Bold = true;
				range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
				range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
			}
			tournamentSheet.Cells[1, 1].Value = "Tournament ID";
			tournamentSheet.Cells[1, 2].Value = tournament.ID.ToString();
			tournamentSheet.Cells[2, 1].Value = "Sport";
			tournamentSheet.Cells[2, 2].Value = EnumExtensions.GetStringValue(tournament.TournamentType);

			tournamentSheet.Cells[3, 1].Value = "Host Club";
			tournamentSheet.Cells[3, 2].Value = tournament.HostClub.Name;
			tournamentSheet.Cells[3, 2].Style.Font.Bold = true;
			tournamentSheet.Cells[4, 1].Value = "Tournament Name";
			tournamentSheet.Cells[4, 2].Value = tournament.Name;
			tournamentSheet.Cells[4, 2].Style.Font.Bold = true;

			tournamentSheet.Cells[5, 1].Value = "Date & Time";
			if (tournament.EndTime.HasValue && tournament.EndTime != null) {
				tournamentSheet.Cells[5, 2].Value = DateTimeExtensions.FormatDateRange((DateTime)tournament.StartTime, (DateTime)tournament.EndTime) + ", fixtures commence " + DateTimeExtensions.TimeHoursAndMinutes(tournament.StartTime.Value);
			}
			else {
				tournamentSheet.Cells[5, 2].Value = DateTimeExtensions.LongDateWithLongDay(tournament.StartTime.Value) + ", fixtures commence " + DateTimeExtensions.TimeHoursAndMinutes(tournament.StartTime.Value);
			}
			tournamentSheet.Cells[6, 1].Value = "Venue";
			tournamentSheet.Cells[6, 2].Value = tournament.Venue;
			tournamentSheet.Cells[7, 1].Value = "Postcode";
			tournamentSheet.Cells[7, 2].Value = tournament.Postcode;
			tournamentSheet.Cells[8, 1].Value = "Google Maps URL";
			tournamentSheet.Cells[8, 2].Value = tournament.GoogleMapsURL;

		    GoTournamental.BLL.Organiser.IContact iContact = new GoTournamental.BLL.Organiser.Contact();
		    GoTournamental.BLL.Organiser.Contact tournamentContact = iContact.GetTournamentContact(tournament.ID);
            tournamentSheet.Cells[9, 1].Value = "Tournament Contact";
			if (tournamentContact != null) {
				tournamentSheet.Cells[9, 2].Value = tournamentContact.FirstName + " " + tournamentContact.LastName;
				if (tournamentContact.Email != null && tournamentContact.Email != "") {
					tournamentSheet.Cells[10, 2].Value = tournamentContact.Email;
				}
				if (tournamentContact.TelephoneNumber != null && tournamentContact.TelephoneNumber != "") {
					tournamentSheet.Cells[11, 2].Value = tournamentContact.TelephoneNumber;
				}
			}

            tournamentSheet.Cells[13, 1].Value = "No. of " + tournament.PlayingAreaType.ToString();
            if (tournament.NoOfPlayingAreas == Tournament.NumberOfPlayingAreas.Undefined) {
                tournamentSheet.Cells[13, 2].Value = "";
            }
            else {
                tournamentSheet.Cells[13, 2].Value = EnumExtensions.GetIntValue(tournament.NoOfPlayingAreas).ToString();
            }
            tournamentSheet.Cells[14, 1].Value = "Fixture Turnaround";
            tournamentSheet.Cells[14, 2].Value = EnumExtensions.GetIntValue(tournament.FixtureTurnaround).ToString() + " Minutes";
            tournamentSheet.Cells[15, 1].Value = "Team Size";
            tournamentSheet.Cells[15, 2].Value = EnumExtensions.GetIntValue(tournament.TeamSize).ToString() + " Players";
            tournamentSheet.Cells[16, 1].Value = "Squad Size";
            tournamentSheet.Cells[16, 2].Value = EnumExtensions.GetIntValue(tournament.SquadSize).ToString() + " Players";

            tournamentSheet.Cells[17, 1].Value = "No Age Bands";
            tournamentSheet.Cells[17, 2].Value = tournament.CountCompetitionsForTournament().ToString();
            tournamentSheet.Cells[18, 1].Value = "No Teams Attending";
            tournamentSheet.Cells[18, 2].Value = tournament.CountTeamsForTournament().ToString();
            tournamentSheet.Cells[19, 1].Value = "No Fixtures Scheduled";
            tournamentSheet.Cells[19, 2].Value = tournament.CountFixturesScheduledForTournament().ToString();

			tournamentSheet.Cells.AutoFitColumns();

			return excelPackage;
		}
		
		#endregion

    }

    public interface ITournament : ISQLInsertableReturningID, ISQLSelectable, ISQLAllSelectable , ISQLUpdateable {
        int ID { get; }
        Tournament.TournamentTypes TournamentType { get; }
        string Name { get; }
		int? Affiliation { get; }
        DateTime? StartTime { get; }
        DateTime? EndTime { get; }
		TimeSpan Duration { get; }
		List<DateTime> ScheduledDays { get; }
        string Venue { get; }
        string Postcode { get; }
        string GoogleMapsURL { get; }
        Tournament.PlayingAreaTypes PlayingAreaType { get; }
        Tournament.NumberOfPlayingAreas NoOfPlayingAreas { get; }
		Tournament.FixtureTurnarounds FixtureTurnaround { get; }
        Tournament.FixtureHalvesNumbers FixtureHalvesNumber { get; }
        Tournament.FixtureHalvesLengths FixtureHalvesLength { get; }
        Domains.NumberOfParticipants TeamSize { get; }
        Domains.NumberOfParticipants SquadSize { get; }
		DateTime? RotatorDate { get; }
		Competition.Sessions RotatorSession { get; }
        List<Tournament> SQLSelectSearch(Tournament.TournamentTypes selectedType, string searchFor);
        void SQLTournamentDeleteFileImportWithCascade(int tournamentID);
		int CountPlayingAreasForTournament(int tournamentID);
        int CountCompetitionsForTournament();
		int CountTeamsForTournament();
		int CountTeamsForTournament(Domains.AttendanceTypes attendanceType);
        int CountFixturesScheduledForTournament();
		int CountFixturesPerHourForTournament(Tournament.NumberOfPlayingAreas noOfPlayingAreas, Tournament.FixtureTurnarounds fixtureTurnaround);
		int CountFixturesPossibleForTournament(DateTime? startTime, DateTime? endTime, Tournament.NumberOfPlayingAreas noOfPlayingAreas, Tournament.FixtureTurnarounds fixtureTurnaround);
        string GetSourceForGoogleMapEmbedString(string input);
    }

}