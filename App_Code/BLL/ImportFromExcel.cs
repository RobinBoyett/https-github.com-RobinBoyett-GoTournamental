using System;
using System.Collections.Generic;
using GoTournamental.API.Interface;
using GoTournamental.API.Utilities;
using GoTournamental.ORM.Organiser;

namespace GoTournamental.BLL.Organiser
{

	public class FileImportStatus: IFileImportStatus
    {

		#region Constructors
        public FileImportStatus() { }
        public FileImportStatus(int numberOfRecords, List<string> messages) 
        {
			this.NumberOfRecords = numberOfRecords;
			this.Messages = messages;
		}
		#endregion

        #region Properties
        public int NumberOfRecords { get; set; }
        public List<string> Messages { get; set; }
		#endregion

	}
	public interface IFileImportStatus
    {
		int NumberOfRecords { get; }
		List<string> Messages { get; }
	}

    public class FileImportAudit: IFileImportAudit 
    {

        #region Member Enumerations & Collections
        public enum FileTypes 
        {
            Undefined = 0,
            Excel = 1
        }
        #endregion

		#region Constructors
        public FileImportAudit() { }
        public FileImportAudit(
            int id, int tournamentID, FileImportAudit.FileTypes fileType, int? noClubs, int? noCompetitions, int? noTeams, int? noPrimaryOfficials, int? noSponsors
        ) 
        {
            this.ID = id;
            this.TournamentID = tournamentID;
            this.FileType = fileType;
            this.NoClubs = noClubs;
            this.NoCompetitions = noCompetitions;
            this.NoTeams = noTeams;
            this.NoPrimaryOfficials = noPrimaryOfficials;
            this.NoSponsors = noSponsors;
        }
        #endregion

        #region Properties
        public int ID { get; set; }
        public int TournamentID { get; set; }
        public FileImportAudit.FileTypes FileType { get; set; }
        public int? NoClubs { get; set; }
        public int? NoCompetitions { get; set; }
        public int? NoTeams { get; set; }
        public int? NoPrimaryOfficials { get; set; }
        public int? NoSponsors { get; set; }
        #endregion

        #region Methods
        public void SQLInsert<T>(T input) 
        {
            if (ObjectExtensions.ObjectTypesMatch<FileImportAudit, T>(input)) 
            {
                FileImportAuditDbContext context = new FileImportAuditDbContext();
                context.FileImportAudits.Add((FileImportAudit)(object)input);
                context.SaveChanges();
            }
        } 

        #endregion

    }
    public interface IFileImportAudit: ISQLInsertable    
    {
        int ID { get; }
        int TournamentID { get; }
        FileImportAudit.FileTypes FileType { get; }
        int? NoClubs { get; }
        int? NoCompetitions { get; }
        int? NoTeams { get; }
        int? NoPrimaryOfficials { get; }
        int? NoSponsors { get; }
    }

	public abstract class DataImportFromExcel 
    {		
		public static DateTime? CleanDateField(string dateField) 
        {
			DateTime? cleanDate = new DateTime();
			int intDate;
			bool dateIsInt = int.TryParse(dateField, out intDate);
			if (dateIsInt) 
            {
				cleanDate = DateTime.FromOADate(intDate);
			}
			else if (dateField.Length != 0 && dateField != "1/1/0001 12:00:00 AM" && dateField != "1/1/1753 12:00:00 AM") 
            {
				cleanDate = (Convert.ToDateTime(dateField));
			}
			else 
            {
				cleanDate = null;
			}
			return cleanDate;
		}		
	}


}