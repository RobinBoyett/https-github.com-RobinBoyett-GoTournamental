using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using GoTournamental.API.Utilities;
using GoTournamental.API.Interface;
using GoTournamental.ORM.Organiser;

namespace GoTournamental.BLL.Organiser 
{

    public class Document: IDocument 
    {

		#region Member Enumerations & Collections
		public enum DocumentTypes 
        {
            Undefined = 0,
            [DescriptionAttribute("Tournament Terms & Conditions")] TournamentToCs = 1,
            [DescriptionAttribute("Tournament Rules")] TournamentRules = 2,
            [DescriptionAttribute("Player Registration Form")] PlayerRegistrationForm = 3,
            [DescriptionAttribute("Pitch Locations")] PitchLocations = 4,
            [DescriptionAttribute("Health And Safety Policy")] HealthAndSafetyPolicy = 5,
            [DescriptionAttribute("Risk Assessment Form")] RiskAssessmentForm = 6
        }
		#endregion

		#region Constructors
		public Document() {}
 		public Document(int id, int tournamentID, DocumentTypes documentType, string fileName)
        {
			this.ID = id;
			this.TournamentID = tournamentID;
			this.DocumentType = documentType;
			this.FileName = fileName;
		}
		#endregion

        #region Properties
        public int ID { get; set; }
        public int TournamentID { get; set; }
		public DocumentTypes DocumentType { get; set; }
		public string FileName { get; set; }
        #endregion

        #region Methods
        public void SQLInsert<T>(T input) 
        {
            if (ObjectExtensions.ObjectTypesMatch<Document, T>(input))
            {
                DocumentDbContext context = new DocumentDbContext();
                context.Documents.Add((Document)(object)input);
                context.SaveChanges();
            }
        }
 		public List<Document> GetDocumentsForTournament(int tournamentID)
        {
            DocumentDbContext context = new DocumentDbContext();
            List<Document> selectedList = context.Documents.Where(i => i.TournamentID == tournamentID).ToList();
            return selectedList;
        }   
		#endregion

    }
    public interface IDocument: ISQLInsertable
    {
        int ID { get; }
		int TournamentID { get; }
		Document.DocumentTypes DocumentType { get; }
		string FileName { get; }
		List<Document> GetDocumentsForTournament(int tournamentID);
	}

}