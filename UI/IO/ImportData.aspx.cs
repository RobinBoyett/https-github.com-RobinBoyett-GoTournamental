using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Drawing;
using OfficeOpenXml;
using GoTournamental.API;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using GoTournamental.BLL.Planner;

namespace GoTournamental.UI.Organiser {


	public partial class ImportData : Page {

		#region Declare domain objects
		Tournament tournament = new Tournament();
		ITournament iTournament = new Tournament();
		ICompetition iCompetition = new Competition();
		List<Advertiser> sponsorsList = new List<Advertiser>();
        IAdvertiser iAdvertiser = new Advertiser();
		IClub iClub = new Club();
        ITeam iTeam = new Team();
		IContact iContact = new Contact();
		IFileImportAudit iFileImportAudit = new FileImportAudit();

		private RequestVersion pageVersion = RequestVersion.Undefined;
        protected enum RequestVersion {
            Undefined = 0,
            ImportClubs = 1
        }
        #endregion

		#region Declare page controls
		Label tournamentImportTitle = new Label();
		FileUpload excelFileUpload = new FileUpload();
		#endregion

		protected void Page_Load(object sender, EventArgs e) {

			AssignControlsAll();
			IOExtensions.DeleteAgedFilesInDirectory(Server.MapPath("~/Uploads/"), IOExtensions.TimeUnits.Seconds, 300);

			if (Request.QueryString.Get("TournamentID") != null) {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
				tournamentImportTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
			}
			if (Request.QueryString.Get("Version") != null) {
                pageVersion = (RequestVersion)Int32.Parse(Request.QueryString.Get("Version"));
            }

            ManagePageVersion(pageVersion);

		}

		protected void AssignControlsAll() {
			tournamentImportTitle = (Label)ClubInvitationPanel.FindControl("TournamentImportTitle");
			excelFileUpload = (FileUpload)ClubInvitationPanel.FindControl("ExcelFileUpload");
		}

        protected void ManagePageVersion(RequestVersion pageVersion) {
			switch (pageVersion) {
				case RequestVersion.ImportClubs:
                    ClubInvitationPanel.Visible = true;
                    break;
            }
        }


		protected void DownloadExcelTemplateForClubsButton_Click(object sender, EventArgs e) {
			using (ExcelPackage pck = new ExcelPackage()) {
				string xlTitle = "ImportClubsForTournament_ID"+tournament.ID.ToString()+".xlsx";
				Club.ExportToExcelWorkSheet(pck, tournament, true);
				Response.Clear();
				Response.AddHeader("content-disposition", "attachment; filename=" + xlTitle);
				Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
				Response.BinaryWrite(pck.GetAsByteArray());
				Response.End();
			}
        }


		protected void DownloadExcelTemplateButton_Click(object sender, EventArgs e) {
			GenerateExcelTemplate();
		}
		private void GenerateExcelTemplate() {
			using (ExcelPackage pck = new ExcelPackage()) {

				string xlTitle = "ImportTournament_ID"+tournament.ID.ToString()+".xlsx";
				int rowIndex = 0;

				#region Populate System Worksheets with domains
				ExcelWorksheet systemsSheet = pck.Workbook.Worksheets.Add("System");

				// Yes / No
				using (ExcelRange range = systemsSheet.Cells["A1"]) {
					range.Style.Font.Bold = true;
					range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
					range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
				}
				systemsSheet.Cells[1, 1].Value = "Yes/No";
				systemsSheet.Cells[2, 1].Value = "Yes";
				systemsSheet.Cells[3, 1].Value = "No";

				// Competition Formats
				using (ExcelRange range = systemsSheet.Cells["B1"]) {
					range.Style.Font.Bold = true;
					range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
					range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
				}
				systemsSheet.Cells[1, 2].Value = "CompetitionFormat";
				Array competitionFormatEnumValues = Enum.GetValues(typeof(Competition.CompetitionFormats));
				rowIndex = 2;
                foreach (Enum type in competitionFormatEnumValues) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
						systemsSheet.Cells[rowIndex, 2].Value = EnumExtensions.GetStringValue(type);
						rowIndex++;
                    }
                }
				rowIndex = 0;

				// Kit Colour
				using (ExcelRange range = systemsSheet.Cells["C1"]) {
					range.Style.Font.Bold = true;
					range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
					range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
				}
				systemsSheet.Cells[1, 3].Value = "KitColour";
				Array kitColourEnumValues = Enum.GetValues(typeof(Domains.KitColours));
				rowIndex = 2;
                foreach (Enum type in kitColourEnumValues) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
						systemsSheet.Cells[rowIndex, 3].Value = EnumExtensions.GetStringValue(type);
						systemsSheet.Cells[rowIndex, 3].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
						systemsSheet.Cells[rowIndex, 3].Style.Fill.BackgroundColor.SetColor(Color.FromName(EnumExtensions.GetStringValue(type)));
						rowIndex++;
                    }
                }
				rowIndex = 0;
	
				// Fixture Turnaround
				using (ExcelRange range = systemsSheet.Cells["D1"]) {
					range.Style.Font.Bold = true;
					range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
					range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
				}
				systemsSheet.Cells[1, 4].Value = "FixtureTurnaround";
				Array fixtureTurnaroundsEnumValues = Enum.GetValues(typeof(Tournament.FixtureTurnarounds));
				rowIndex = 2;
                foreach (Enum type in fixtureTurnaroundsEnumValues) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
						systemsSheet.Cells[rowIndex, 4].Value = EnumExtensions.GetStringValue(type);
						rowIndex++;
                    }
                }
				rowIndex = 0;


				//systemsSheet.Hidden = eWorkSheetHidden.VeryHidden;
				#endregion
                systemsSheet.Hidden = eWorkSheetHidden.VeryHidden;

				Tournament.ExportToExcelWorkSheet(pck, tournament);
				Competition.ExportToExcelWorkSheet(pck, tournament, true);
				Club.ExportToExcelWorkSheet(pck, tournament, true);

				Response.Clear();
				Response.AddHeader("content-disposition", "attachment; filename=" + xlTitle);
				Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
				Response.BinaryWrite(pck.GetAsByteArray());
				Response.End();

			}
		}
		
		protected void UploadExcelTemplateButton_Click(object sender, EventArgs e) {   
			foreach (HttpPostedFile htfiles in excelFileUpload.PostedFiles) {   
				string fileName = Path.GetFileName(htfiles.FileName);   
				htfiles.SaveAs(Server.MapPath("~/Uploads/"+fileName));              
			}
			Response.Redirect(Request.RawUrl);
		}

		protected void ImportDataFromExcelButton_Click(object sender, EventArgs e) {
			string fileWithPath = @"";
			fileWithPath = HttpContext.Current.Server.MapPath(@"~");
			fileWithPath += @"Uploads\ImportClubsForTournament_ID"+tournament.ID.ToString()+".xlsx";
			var importFile = new FileInfo(fileWithPath);
			List<string> reportOnImport = new List<string>();
			if (File.Exists(fileWithPath)) {
				reportOnImport = ImportDataFromExcel(importFile);
			}
			else {
				reportOnImport.Add(string.Format("Import File Not Found - Your Uploaded File May Have Timed Out"));					
			}
			foreach (String message in reportOnImport) {
				Response.Write("<script language=javascript>alert('"+message+"');</script>");
			}
		}

		protected List<string> ImportDataFromExcel(FileInfo file) {

			var importStatusMessages = new List<string>();
			var noClubsImported = 0;
			var noCompetitionsImported = 0;
			var noTeamsImported = 0;
			var noRefereesImported = 0;
			var noSponsorsImported = 0;

			try {
				using (ExcelPackage excelPackage = new ExcelPackage(file)) {

					if (!file.Name.EndsWith("xlsx")) {
						importStatusMessages.Add("File selected is not a valid Excel file. The file should be a .xlsx type.");
						return importStatusMessages;
					}
					foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets) {

						#region Import Competitions
						//if (worksheet.Name == "Age Bands") {
						//	FileImportStatus competitionsImportStatus = Competition.ImportFromExcelWorksheet(worksheet, tournament);
						//	noCompetitionsImported = competitionsImportStatus.NumberOfRecords;
						//	importStatusMessages.Insert(0, string.Format("{0} Age Band records successfully imported.", noCompetitionsImported.ToString()));
						//	foreach (string message in competitionsImportStatus.Messages) {
						//		importStatusMessages.Add(message);
						//	}
						//}
						#endregion
		
						#region Clubs
						if (worksheet.Name == "Clubs") {
							noClubsImported = 0;
							string clubNameColumn, contactFirstNameColumn, contactLastNameColumn, contactTelephoneNumberColumn, contactEmailColumn;
							using (var headers = worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column]) {
								var expectedHeaders = new[] { "Club Name", "Contact First Name", "Contact Last Name", "Contact Telephone Number", "Contact Email" };
								if (!expectedHeaders.All(e => headers.Any(h => h.Value.Equals(e)))) {
									importStatusMessages.Add("Some columns are missing from the Clubs Worksheet");
									return importStatusMessages;
								}
								clubNameColumn = headers.First(h => h.Value.Equals("Club Name")).Address[0].ToString();
								contactFirstNameColumn = headers.First(h => h.Value.Equals("Contact First Name")).Address[0].ToString();
								contactLastNameColumn = headers.First(h => h.Value.Equals("Contact Last Name")).Address[0].ToString();
								contactTelephoneNumberColumn = headers.First(h => h.Value.Equals("Contact Telephone Number")).Address[0].ToString();
								contactEmailColumn = headers.First(h => h.Value.Equals("Contact Email")).Address[0].ToString();
							}
							var lastRow = worksheet.Dimension.End.Row;
							while (lastRow >= 1) {
								var range = worksheet.Cells[lastRow, 1, lastRow, 3];
								if (range.Any(i => i.Value != null)) {
									break;
								}
								lastRow--;
							}
							for (var row = 2; row <= lastRow; row++) {
								int? contactID = null;
								Contact clubContact = new Contact();
								clubContact = new Contact(
									id: 0,
									tournamentID: tournament.ID,
									type: Contact.ContactTypes.ClubContact,
									title: null,
									firstName: worksheet.Cells[contactFirstNameColumn + row].Value == null  ? null : worksheet.Cells[contactFirstNameColumn + row].Value.ToString() ,
									lastName: worksheet.Cells[contactLastNameColumn + row].Value == null ? null : worksheet.Cells[contactLastNameColumn + row].Value.ToString() ,
									telephoneNumber: worksheet.Cells[contactTelephoneNumberColumn + row].Value == null ? null : worksheet.Cells[contactTelephoneNumberColumn + row].Value.ToString(),
									email: worksheet.Cells[contactEmailColumn + row].Value == null ? null : worksheet.Cells[contactEmailColumn + row].Value.ToString(),
                                    dateOfBirth : (Nullable<DateTime>)null,
                                    squadNumber : null
								);

								if (clubContact.FirstName != null && clubContact.LastName != null) {
									contactID = iContact.SQLInsertAndReturnID<Contact>(clubContact);
								}
								else {
									contactID = null;
								}
								Club club = new Club(
									id: 0,
									tournamentID: tournament.ID,
									name: worksheet.Cells[clubNameColumn + row].Value.ToString(),
									attendanceType: Domains.AttendanceTypes.Pending,
									websiteURL: null,
									logoFile: null,
									twitter: null,
									colourPrimary: null ,
									colourSecondary: null ,
									affiliation : null ,
									affiliationNumber : null ,
									primaryContactID: contactID
								);
								try {
									if (club.AttendanceType != Domains.AttendanceTypes.HostClub && !iClub.SQLClubExistsForTournament(tournament.ID, club.Name)) {
										iClub.SQLInsert<Club>(club);
										noClubsImported++;
									}
								} 
								catch (Exception exception) {
									importStatusMessages.Add(string.Format("Club record on line #{0} failed: {1}\n", row, exception.Message));
									return importStatusMessages;
								}
							}

						}
						#endregion

						#region Teams
						//if (worksheet.Name == "Teams") {
						//	noTeamsImported = 0;
						//	int clubID = 0;
						//	int competitionID = 0;
						//	int ageBand = 0;
						//	string clubNameColumn, competitionColumn, teamNameColumn, attendanceTypeColumn, contactFirstNameColumn, contactLastNameColumn, contactTelephoneNumberColumn, contactEmailColumn;
						//	string clubName, competitionName, teamName, contactFirstName, contactLastName, contactTelephoneNumber, contactEmail;
						//	Domains.AttendanceTypes attendanceType;
						//	using (var headers = worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column]) {
						//		var expectedHeaders = new[] { "Club Name", "Age Band", "Team Name", "Attendance Type", "Contact First Name", "Contact Last Name", "Contact Telephone Number", "Contact Email" };
						//		if (!expectedHeaders.All(e => headers.Any(h => h.Value.Equals(e)))) {
						//			importStatusMessages.Add("Some columns are missing from the Teams Worksheet");
						//			return importStatusMessages;
						//		}
						//		clubNameColumn = headers.First(h => h.Value.Equals("Club Name")).Address[0].ToString();
						//		competitionColumn = headers.First(h => h.Value.Equals("Age Band")).Address[0].ToString();
						//		teamNameColumn = headers.First(h => h.Value.Equals("Team Name")).Address[0].ToString();
						//		attendanceTypeColumn = headers.First(h => h.Value.Equals("Attendance Type")).Address[0].ToString();
						//		contactFirstNameColumn = headers.First(h => h.Value.Equals("Contact First Name")).Address[0].ToString();
						//		contactLastNameColumn = headers.First(h => h.Value.Equals("Contact Last Name")).Address[0].ToString();
						//		contactTelephoneNumberColumn = headers.First(h => h.Value.Equals("Contact Telephone Number")).Address[0].ToString();
						//		contactEmailColumn = headers.First(h => h.Value.Equals("Contact Email")).Address[0].ToString();
						//	}
						//	var lastRow = worksheet.Dimension.End.Row;
						//	while (lastRow >= 1) {
						//		var range = worksheet.Cells[lastRow, 1, lastRow, 3];
						//		if (range.Any(i => i.Value != null)) {
						//			break;
						//		}
						//		lastRow--;
						//	}
						//	for (var row = 2; row <= lastRow; row++) {
						//		int? contactID = null;
						//		Contact teamContact = new Contact();
						//		teamName = "";
						//		contactFirstName = worksheet.Cells[contactFirstNameColumn + row].Value == null || worksheet.Cells[contactFirstNameColumn + row].Value.ToString() == "" ? "" : worksheet.Cells[contactFirstNameColumn + row].Value.ToString();
						//		contactLastName = worksheet.Cells[contactLastNameColumn + row].Value == null || worksheet.Cells[contactLastNameColumn + row].Value.ToString() == "" ? "" : worksheet.Cells[contactLastNameColumn + row].Value.ToString();
						//		contactTelephoneNumber = worksheet.Cells[contactTelephoneNumberColumn + row].Value == null || worksheet.Cells[contactTelephoneNumberColumn + row].Value.ToString() == "" ? "" : worksheet.Cells[contactTelephoneNumberColumn + row].Value.ToString();
						//		contactEmail = worksheet.Cells[contactEmailColumn + row].Value == null || worksheet.Cells[contactEmailColumn + row].Value.ToString() == "" ? "" : worksheet.Cells[contactEmailColumn + row].Value.ToString();
								
						//		teamContact = new Contact(
						//			id: 0,
						//			tournamentID: tournament.ID,
						//			type: Contact.ContactTypes.TeamContact ,
						//			title: null,
						//			firstName: contactFirstName,
						//			lastName: contactLastName,
						//			telephoneNumber: contactTelephoneNumber,
						//			email: contactEmail
						//		);
						//		if (teamContact.FirstName != null && teamContact.FirstName != "" && teamContact.LastName != null && teamContact.LastName != "") {
						//			contactID = iContact.SQLInsertAndReturnID<Contact>(teamContact);
						//		} 
						//		else {
						//			contactID = null;
						//		}

						//		clubID = iClub.SQLGetClubIDForClubName(tournament.ID, worksheet.Cells[clubNameColumn + row].Value.ToString());
						//		if (worksheet.Cells[teamNameColumn + row].Value != null) {
						//			teamName = worksheet.Cells[teamNameColumn + row].Value.ToString();
						//		}
						//		else {
						//			teamName = worksheet.Cells[competitionColumn + row].Value.ToString();
						//		}
						//		ageBand = EnumExtensions.GetIntValue(EnumExtensions.GetValueFromDescription<Competition.AgeBands>(worksheet.Cells[competitionColumn + row].Value.ToString()));
						//		competitionID = iCompetition.SQLCompetitionIDForAgeBand(tournament.ID, ageBand);
						//		attendanceType = Domains.AttendanceTypes.Undefined;
						//		if (worksheet.Cells[attendanceTypeColumn + row].Value != null) {
						//			attendanceType = EnumExtensions.GetEnumValue<Domains.AttendanceTypes>(worksheet.Cells[attendanceTypeColumn + row].Value.ToString());
						//		}
						//		Team team = new Team(
						//			id : 0 ,
						//			clubID : clubID ,
						//			competitionID: competitionID , 
						//			groupID: null ,
						//			name: teamName ,
						//			attendanceType: attendanceType,
						//			primaryContactID: contactID
						//		);
						//		try {
						//			iTeam.SQLInsert<Team>(team);
						//			noTeamsImported++;
						//		} 
						//		catch (Exception exception) {
						//			importStatusMessages.Add(string.Format("Team record on line #{0} failed: {1}\n", row, exception.Message));
						//			return importStatusMessages;
						//		}
						//	}
						//}
						#endregion

						#region Referees
						//if (worksheet.Name == "Referees") {
						//	noRefereesImported = 0;
						//	string firstNameColumn, lastNameColumn, telephoneNumberColumn, emailColumn;
						//	using (var headers = worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column]) {
						//		var expectedHeaders = new[] { "First Name", "Last Name", "Telephone Number", "Email" };
						//		if (!expectedHeaders.All(e => headers.Any(h => h.Value.Equals(e)))) {
						//			importStatusMessages.Add("Some columns are missing from the Referees Worksheet");
						//			return importStatusMessages;
						//		}
						//		firstNameColumn = headers.First(h => h.Value.Equals("First Name")).Address[0].ToString();
						//		lastNameColumn = headers.First(h => h.Value.Equals("Last Name")).Address[0].ToString();
						//		telephoneNumberColumn = headers.First(h => h.Value.Equals("Telephone Number")).Address[0].ToString();
						//		emailColumn = headers.First(h => h.Value.Equals("Email")).Address[0].ToString();
						//	}
						//	var lastRow = worksheet.Dimension.End.Row;
						//	while (lastRow >= 1) {
						//		var range = worksheet.Cells[lastRow, 1, lastRow, 3];
						//		if (range.Any(i => i.Value != null)) {
						//			break;
						//		}
						//		lastRow--;
						//	}
						//	for (var row = 2; row <= lastRow; row++) {
						//		Contact referee = new Contact(
						//			id: 0,
						//			tournamentID: tournament.ID,
						//			type: Contact.ContactTypes.PrimaryFixtureOfficial,
						//			title: null,
						//			firstName: worksheet.Cells[firstNameColumn + row].Value.ToString(),
						//			lastName: worksheet.Cells[lastNameColumn + row].Value.ToString(),
						//			telephoneNumber: worksheet.Cells[telephoneNumberColumn + row].Value.ToString(),
						//			email: worksheet.Cells[emailColumn + row].Value.ToString()
						//		);
						//		try {
						//			if (referee.FirstName != null && referee.LastName != null) {
						//				iContact.SQLInsert<Contact>(referee);
						//			} 			
						//			noRefereesImported++;
						//		} 
						//		catch (Exception exception) {
						//			importStatusMessages.Add(string.Format("Referee record on line #{0} failed: {1}\n", row, exception.Message));
						//			return importStatusMessages;
						//		}
						//	}

						//}
						#endregion

						#region Import Sponsors
						//if (worksheet.Name == "Sponsors") {
						//	FileImportStatus sponsorsImportStatus = Advertiser.ImportFromExcelWorksheet(worksheet, tournament);
						//	noSponsorsImported = sponsorsImportStatus.NumberOfRecords;
						//	importStatusMessages.Insert(0, string.Format("{0} Sponsor records successfully imported.", noSponsorsImported.ToString()));
						//	foreach (string message in sponsorsImportStatus.Messages) {
						//		importStatusMessages.Add(message);
						//	}
						//}
						#endregion

					}

					FileImportAudit fileImportAudit = new FileImportAudit(
						id : 0 ,
						tournamentID : tournament.ID ,
						fileType : FileImportAudit.FileTypes.Excel ,
						noClubs : noClubsImported ,
						noCompetitions : noCompetitionsImported ,
						noTeams : noTeamsImported ,
						noPrimaryOfficials : noRefereesImported ,
						noSponsors : noSponsorsImported
					);
					iFileImportAudit.SQLInsert<FileImportAudit>(fileImportAudit);

			
					//importStatusMessages.Insert(0, string.Format("{0} Referee records successfully imported.", noRefereesImported.ToString()));
					//importStatusMessages.Insert(0, string.Format("{0} Team records successfully imported.", noTeamsImported.ToString()));
					importStatusMessages.Insert(0, string.Format("{0} Club records successfully imported.", noClubsImported.ToString()));
					return importStatusMessages;

				}
			}
			catch(IOException exception) {
				importStatusMessages.Add("File still open");
				return importStatusMessages;

			}
		}




		protected void ResetTournamentDataButton_Click(object sender, EventArgs e) {
			iTournament.SQLTournamentDeleteFileImportWithCascade(tournament.ID);
		}


	}

}