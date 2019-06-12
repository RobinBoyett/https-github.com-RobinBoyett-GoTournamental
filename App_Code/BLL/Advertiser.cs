using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using OfficeOpenXml;
using GoTournamental.API.Interface;
using GoTournamental.API.Utilities;
using GoTournamental.ORM.Organiser;

namespace GoTournamental.BLL.Organiser
{

    public class Advertiser: IAdvertiser
    {

		#region Constructors
		public Advertiser() {}
        public Advertiser(int id, int? tournamentID, string advertiserName, string websiteURL)
			: this(
				id : 0 , 
				tournamentID : tournamentID , 
				advertiserName : advertiserName ,
				websiteURL : websiteURL ,
				tooltipText : null
			) {	}
		public Advertiser(int id, int? tournamentID, string advertiserName, string websiteURL, string tooltipText) 
        {
			this.ID = id;
			this.TournamentID = tournamentID;
			this.AdvertiserName = advertiserName;
			this.WebsiteURL = websiteURL;
			this.TooltipText = tooltipText;
		}
        #endregion

        #region Properties
        public int ID { get; set; }
        public int? TournamentID { get; set; }
        public string AdvertiserName { get; set; }
        public string WebsiteURL { get; set; }
        public string TooltipText { get; set; }	
		#endregion

        #region Methods
        public void SQLInsert<T>(T input) 
        {
            if (ObjectExtensions.ObjectTypesMatch<Advertiser, T>(input)) 
            {
                AdvertiserDbContext context = new AdvertiserDbContext();
                Advertiser existing = context.Advertisers.Where(i => i.TournamentID == ((Advertiser)(object)input).TournamentID && i.AdvertiserName == ((Advertiser)(object)input).AdvertiserName).SingleOrDefault();
				if (existing == null)
                {
                    context.Advertisers.Add((Advertiser)(object)input);
                    context.SaveChanges();
                }
            }
        }
        public T SQLSelect<T, U>(U id)
        {
            AdvertiserDbContext context = new AdvertiserDbContext();
            Advertiser selected = context.Advertisers.Where(i => i.ID == (int)(object)id).SingleOrDefault();
            return (T)(object)selected;
        }      
        public List<Advertiser> SQLSelectForGoTournamental() 
        {
            AdvertiserDbContext context = new AdvertiserDbContext();
            List<Advertiser> selectedList = context.Advertisers.Where(i => i.TournamentID == null).OrderBy(i => i.ID).ToList();
            return selectedList;
        }
		public List<Advertiser> SQLSelectForTournament(int tournamentID)
        {
            AdvertiserDbContext context = new AdvertiserDbContext();
            List<Advertiser> selectedList = context.Advertisers.Where(i => i.TournamentID == tournamentID).OrderBy(i => i.ID).ToList();
            return selectedList;
        }
 	
		public void SQLUpdate<T>(T input)
        {
            if (ObjectExtensions.ObjectTypesMatch<Advertiser, T>(input)) 
            {
                AdvertiserDbContext context = new AdvertiserDbContext();
                Advertiser updated = (Advertiser)(object)input;
                Advertiser selected = context.Advertisers.Single(i => i.ID == updated.ID);
                selected.AdvertiserName = updated.AdvertiserName;
				selected.WebsiteURL = updated.WebsiteURL;
                context.SaveChanges();
            }
        }
		public void SQLDelete<T>(T input) 
        {
			if (ObjectExtensions.ObjectTypesMatch<Advertiser, T>(input)) 
            {
				AdvertiserDbContext context = new AdvertiserDbContext();
				Advertiser itemToDelete = (Advertiser)(object)input;	
				Advertiser selected = context.Advertisers.Single(i => i.ID == itemToDelete.ID);
                context.Advertisers.Remove(selected);
                context.SaveChanges();
			}
		}

		public static FileImportStatus ImportFromExcelWorksheet(ExcelWorksheet worksheet, Tournament tournament)
        {
			FileImportStatus importStatus = new FileImportStatus();
			IAdvertiser iAdvertiser = new Advertiser();
			int sponsorsImported = 0;
			List<string> messages = new List<string>();
			string nameColumn, websiteURLColumn;
			string name, websiteURL;

			using (var headers = worksheet.Cells[1,1,1,worksheet.Dimension.End.Column]) 
            {
				var expectedHeaders = new[] { "Sponsors Name", "Website URL" };
				if (!expectedHeaders.All(e => headers.Any(h => h.Value.Equals(e)))) 
                {
					messages.Add("Some columns are missing from the Sponsors Worksheet");
					importStatus = new FileImportStatus(sponsorsImported, messages);
					return importStatus;
				}
				nameColumn = headers.First(h => h.Value.Equals("Sponsors Name")).Address[0].ToString();
				websiteURLColumn = headers.First(h => h.Value.Equals("Website URL")).Address[0].ToString();
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
				name = worksheet.Cells[nameColumn + row].Value == null || worksheet.Cells[nameColumn + row].Value.ToString() == "" ? "" : worksheet.Cells[nameColumn + row].Value.ToString();
				websiteURL = worksheet.Cells[websiteURLColumn + row].Value == null || worksheet.Cells[websiteURLColumn + row].Value.ToString() == "" ? "" : worksheet.Cells[websiteURLColumn + row].Value.ToString();
	
				Advertiser sponsor = new Advertiser(
					id: 0,
					tournamentID: tournament.ID,
					advertiserName: name,
					websiteURL: websiteURL
				);
				try 
                {
					AdvertiserDbContext context = new AdvertiserDbContext();
					bool alreadyExists = context.Advertisers.Any(i => i.TournamentID == tournament.ID && i.AdvertiserName == name && i.WebsiteURL == websiteURL);
					if (!alreadyExists)
                    {
						iAdvertiser.SQLInsert<Advertiser>(sponsor);
						sponsorsImported++;
					}
				} 
				catch (Exception exception)
                { 
					messages.Add(string.Format("Sponsor record on line #{0} failed: {1}\n", row, exception.Message));					
					importStatus = new FileImportStatus(sponsorsImported, messages);
					return importStatus;
				}

			}
					
			importStatus = new FileImportStatus(sponsorsImported, messages);
			return importStatus;
		}
		public static ExcelPackage ExportToExcelWorkSheet(ExcelPackage excelPackage, Tournament tournament, bool templateOnly) 
        {

			ExcelWorksheet sponsorsSheet = excelPackage.Workbook.Worksheets.Add("Sponsors");
            int rowIndex = 0;
			
			List<Advertiser> sponsorsList = new List<Advertiser>();
			IAdvertiser iAdvertiser = new Advertiser();
			sponsorsList = iAdvertiser.SQLSelectForTournament(tournament.ID);

            using (ExcelRange range = sponsorsSheet.Cells["A1:B1"]) 
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
            }
            sponsorsSheet.Cells[1, 1].Value = "Sponsors Name";
            sponsorsSheet.Cells[1, 2].Value = "Website URL";
            rowIndex = 2; 

			if (templateOnly == false) 
            {
				foreach (Advertiser sponsor in sponsorsList) 
                {
					sponsorsSheet.Cells[rowIndex, 1].Value = sponsor.AdvertiserName;
					sponsorsSheet.Cells[rowIndex, 2].Value = sponsor.WebsiteURL;
					rowIndex++;
				}
			}

            sponsorsSheet.Cells.AutoFitColumns();
			return excelPackage;
		}					
		#endregion

    }
    public interface IAdvertiser: ISQLInsertable, ISQLSelectable, ISQLUpdateable, ISQLDeletable 
    {
        int ID { get; }
        int? TournamentID { get; }
        string AdvertiserName { get; }
        string WebsiteURL { get; }
		string TooltipText { get; }
		List<Advertiser> SQLSelectForGoTournamental();
		List<Advertiser> SQLSelectForTournament(int tournamentID);
    }

}
