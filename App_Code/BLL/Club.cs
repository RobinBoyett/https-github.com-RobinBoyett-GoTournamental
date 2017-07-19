using System;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Helpers;
using OfficeOpenXml;
using GoTournamental.API;
using GoTournamental.API.Interface;
using GoTournamental.API.Utilities;
using GoTournamental.ORM.Organiser;

namespace GoTournamental.BLL.Organiser {

    public class Club: IClub {

		#region Constructors
		public Club() {}
        public Club(
			int id, int tournamentID, string name, Domains.AttendanceTypes attendanceType, string websiteURL, string logoFile, string twitter, string colourPrimary, string colourSecondary, 
			int? affiliation, string affiliationNumber, int? primaryContactID
			) {
            this.ID = id;
            this.TournamentID = tournamentID;
            this.Name = name;
            this.AttendanceType = attendanceType;
            this.WebsiteURL = websiteURL;
            this.LogoFile = logoFile;
            this.Twitter = twitter;
            this.ColourPrimary = colourPrimary;
            this.ColourSecondary = colourSecondary;
			this.Affiliation = affiliation;
			this.AffiliationNumber = affiliationNumber;
			this.PrimaryContactID = primaryContactID;
        }
        #endregion

        #region Properties
        public int ID { get; set; }
        public int TournamentID { get; set; }
        public string Name { get; set; }
        public Domains.AttendanceTypes AttendanceType { get; set; }
        public string WebsiteURL { get; set; }
        public string LogoFile { get; set; }
        public string Twitter { get; set; }
        public string ColourPrimary { get; set; }
        public string ColourSecondary { get; set; }
        public int? Affiliation { get; set; }
        public string AffiliationNumber { get; set; }
        public int? PrimaryContactID { get; set; }
        public Contact PrimaryContact {
            get {
                Contact contact = new Contact();
                IContact iContact = new Contact();
                if (this.PrimaryContactID != null) {
                    contact = iContact.SQLSelect<Contact, int?>(PrimaryContactID);
                }
                return contact;
            }
        }
        public virtual ICollection<Team> Teams { get; set; }
        #endregion

        #region Methods
        public void SQLInsert<T>(T input) {
            if (ObjectExtensions.ObjectTypesMatch<Club, T>(input)) {
                ClubDbContext context = new ClubDbContext();
				if (!SQLClubExistsForTournament(((Club)(object)input).TournamentID, ((Club)(object)input).Name)) {
					context.Clubs.Add((Club)(object)input);
					context.SaveChanges();
				}
            }	
		}      
        public int SQLInsertAndReturnID<T>(T input) {
            int ret = 0;
            if (ObjectExtensions.ObjectTypesMatch<Club, T>(input)) {
                ClubDbContext context = new ClubDbContext();
                context.Clubs.Add((Club)(object)input);
                context.SaveChanges();
                ret = ((Club)(object)input).ID;
            }
            return ret;
        }
        public T SQLSelect<T, U>(U id) {
            ClubDbContext context = new ClubDbContext();
            Club selected = context.Clubs.Where(i => i.ID == (int)(object)id).SingleOrDefault();
            return (T)(object)selected;
        }
        public Club SQLSelectHostClubForTournament(int tournamentID) {
            ClubDbContext context = new ClubDbContext();
            Club club = context.Clubs.Where(i => i.TournamentID == tournamentID  && i.AttendanceType == Domains.AttendanceTypes.HostClub).SingleOrDefault();
            return club; 
        }
        public List<Club> SQLSelectClubsForTournament(int tournamentID) {
            ClubDbContext context = new ClubDbContext();
            List<Club> selectedList = context.Clubs.Where(i => i.TournamentID == tournamentID).OrderBy(i => i.Name).ToList();
            return selectedList;
        }
        public List<Club> SQLSelectClubsForCompetition(int competitionID) {
            ClubDbContext context = new ClubDbContext();
			List<Club> clubList = context.SQLGetClubsForCompetition(competitionID).ToList();
			return clubList;
        }		
		public void SQLUpdate<T>(T input) {
            if (ObjectExtensions.ObjectTypesMatch<Club, T>(input)) {
                ClubDbContext context = new ClubDbContext();
                Club updated = (Club)(object)input;
                Club selected = context.Clubs.Single(i => i.ID == updated.ID);
                selected.Name = updated.Name;
				selected.AttendanceType = updated.AttendanceType;
                selected.ColourPrimary = updated.ColourPrimary;
                selected.ColourSecondary = updated.ColourSecondary;
                selected.Affiliation = updated.Affiliation;
                selected.AffiliationNumber = updated.AffiliationNumber;
                selected.PrimaryContactID = updated.PrimaryContactID;
                context.SaveChanges();
            }
        }
		public void SQLUpdatePrimaryContactID(int id, int primaryContactID) {
            ClubDbContext context = new ClubDbContext();
            Club selected = context.Clubs.Single(i => i.ID == id);
			selected.PrimaryContactID = primaryContactID;
            context.SaveChanges();
		}
		public void SQLUpdateAttendanceType(int id, Domains.AttendanceTypes attendanceType) {
            ClubDbContext context = new ClubDbContext();
            Club selected = context.Clubs.Single(i => i.ID == id);
			selected.AttendanceType = attendanceType;
            context.SaveChanges();
		}
        public void SQLDeleteWithCascade<T>(T input) {
            ClubDbContext context = new ClubDbContext();
            Club clubToDelete = (Club)(object)input;
            context.SQLClubDeleteWithCascade(clubToDelete.ID);
        }

        public Club GetClubForPrimaryContactID(int primaryContactID) {
            ClubDbContext context = new ClubDbContext();
            Club club = context.Clubs.Where(i => i.PrimaryContactID == primaryContactID).SingleOrDefault();
			return club;
		}
		public void SQLUpdateClubLogoFile(int id, string logoFile) {
            ClubDbContext context = new ClubDbContext();
            Club selected = context.Clubs.Single(i => i.ID == id);
			selected.LogoFile = logoFile;
            context.SaveChanges();
		}        
		public int SQLGetClubIDForClubName(int tournamentID, string clubName) {
            int clubID = 0;
            ClubDbContext context = new ClubDbContext();
            clubID = context.SQLGetClubIDForClubName(tournamentID, clubName).Single();
            return clubID;
        }       
 		public bool SQLClubExistsForTournament(int tournamentID,  string clubName) {
            ClubDbContext context = new ClubDbContext();
			bool exists = context.Clubs.Any(i => i.TournamentID == tournamentID && i.Name == clubName);
			return exists;
		}
		public string GenerateClubSecurityCode(Club club) {
			string ret = "";
            if (club != null) {
			    ret = Crypto.Hash(club.Name + club.TournamentID.ToString() + "P4!3Sg4t3").Substring(0,8);
            }
			return ret;
		}
		public static ExcelPackage ExportToExcelWorkSheet(ExcelPackage excelPackage, Tournament tournament, bool templateOnly) {

			ExcelWorksheet clubEntriesSheet = excelPackage.Workbook.Worksheets.Add("Clubs");
            int rowIndex = 1;

			IClub iClub = new Club();
			List<Club> clubsList = new List<Club>();
			clubsList = iClub.SQLSelectClubsForTournament(tournament.ID);

            using (ExcelRange range = clubEntriesSheet.Cells["A1:Z1"]) {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                range.Style.Font.Color.SetColor(Color.Black);
            }
            clubEntriesSheet.Cells[1, 1].Value = "Club Name";
            clubEntriesSheet.Cells[1, 2].Value = "Contact First Name";
            clubEntriesSheet.Cells[1, 3].Value = "Contact Last Name";
            clubEntriesSheet.Cells[1, 4].Value = "Contact Telephone Number";
            clubEntriesSheet.Cells[1, 5].Value = "Contact Email";

            rowIndex = 2;

			if (templateOnly == false) {
				foreach (Club club in clubsList) {
					clubEntriesSheet.Cells[rowIndex, 1].Value = club.Name;
					clubEntriesSheet.Cells[rowIndex, 2].Value = club.PrimaryContact.FirstName;
					clubEntriesSheet.Cells[rowIndex, 3].Value = club.PrimaryContact.LastName;
					clubEntriesSheet.Cells[rowIndex, 4].Value = club.PrimaryContact.TelephoneNumber;
					clubEntriesSheet.Cells[rowIndex, 5].Value = club.PrimaryContact.Email;
					rowIndex++;
				}
			}

            clubEntriesSheet.Cells.AutoFitColumns();

			return excelPackage;
		}							
		#endregion

    }

    public interface IClub : ISQLInsertable, ISQLInsertableReturningID, ISQLSelectable, ISQLUpdateable, ISQLDeleteCascadable {
        int ID { get; }
        int TournamentID { get; }
        string Name { get; }
        Domains.AttendanceTypes AttendanceType { get; }
        string WebsiteURL { get; }
        string LogoFile { get; }
        string Twitter { get; }
        string ColourPrimary { get; }
        string ColourSecondary { get; }
        int? Affiliation { get; }
        string AffiliationNumber { get; }
        int? PrimaryContactID { get; }
        Contact PrimaryContact { get; }
        ICollection<Team> Teams { get; }
        Club SQLSelectHostClubForTournament(int tournamentID);
        List<Club> SQLSelectClubsForTournament(int tournamentID);
		List<Club> SQLSelectClubsForCompetition(int competitionID);
		void SQLUpdatePrimaryContactID(int id, int primaryContactID);
        void SQLUpdateAttendanceType(int id, Domains.AttendanceTypes attendanceType);
		Club GetClubForPrimaryContactID(int primaryContactID);
		void SQLUpdateClubLogoFile(int id, string logoFile);
        int SQLGetClubIDForClubName(int tournamentID, string clubName);
		bool SQLClubExistsForTournament(int tournamentID, string clubName);
		string GenerateClubSecurityCode(Club club);
    }

}