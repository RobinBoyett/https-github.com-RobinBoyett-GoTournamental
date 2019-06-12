using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.IO;
using GoTournamental.API;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using GoTournamental.BLL.Planner;

namespace GoTournamental.UI.Organiser 
{


    public partial class FileUploadForm: Page
    {	
	
		#region Declare Domain Objects & Page Variables
        ITournament iTournament = new Tournament();
        Tournament tournament = new Tournament();
		IClub iClub = new Club();
		Club club = new Club();
		IAdvertiser iAdvertiser = new Advertiser();
		Advertiser advertiser = new Advertiser();
		List<Advertiser> advertisers = new List<Advertiser>();
		IAdvert iAdvert = new Advert();
		IDocument iDocument = new Document();

		FileUploadTypes fileUploadType = new FileUploadTypes();
		private enum FileUploadTypes 
        {
			Undefined = 0,
			[DescriptionAttribute("Club Logo")] ClubLogo = 1,			
			Advert = 2,
			Document = 3
		}
        private RequestVersion requestVersion = RequestVersion.Undefined;
        protected enum RequestVersion
        {
            Undefined = 0,
            Insert = 1,
			Delete = 2
        }
        #endregion

		#region Declare page controls
		Label fileUploadFormTitle = new Label();
		Panel fileUploadPanel = new Panel();
		Panel uploadControlsPanel = new Panel();
		DropDownList uploadType = new DropDownList();
		Panel graphicsOnlyPanel = new Panel();
		Panel documentsOnlyPanel = new Panel();
		Panel advertsOnlyPanel = new Panel();
		DropDownList advertType = new DropDownList();
		DropDownList documentType = new DropDownList();
		DropDownList associatedSponsor = new DropDownList();
		FileUpload fileUpload = new FileUpload();
		Button uploadFileButton = new Button();
		RequiredFieldValidator fileRequiredValidator = new RequiredFieldValidator();
		Panel graphicFileToReviewPanel = new Panel();
		HiddenField graphicFileName = new HiddenField();
		HiddenField graphicFileType = new HiddenField();
		HiddenField advertTypeHidden = new HiddenField();
		HiddenField associatedSponsorHidden = new HiddenField();

		System.Web.UI.WebControls.Image graphicToReview = new System.Web.UI.WebControls.Image();
		Label userMessage = new Label();
		Button saveButton = new Button();
		Button rejectButton = new Button();
		HyperLink backToReferrerLink = new HyperLink();
		#endregion

		protected void Page_Load(object sender, EventArgs e) 
        {

			IOExtensions.DeleteAgedFilesInDirectory(Server.MapPath("~/Uploads/"), IOExtensions.TimeUnits.Seconds, 300);

			AssignControlsAll();

			if (Request.QueryString.Get("TournamentID") != null) 
            {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
				club = iClub.SQLSelectHostClubForTournament(tournament.ID);
			}
			if (Request.QueryString.Get("UploadType") != null) 
            {
				fileUploadType = (FileUploadTypes)Int32.Parse(Request.QueryString.Get("UploadType"));
			}
			if (Request.QueryString.Get("Version") != null)
            {
				requestVersion = (RequestVersion)Int32.Parse(Request.QueryString.Get("Version"));
			}            
            fileUploadFormTitle.Text = "Upload " + EnumExtensions.GetStringValue(fileUploadType);

            ManagePageVersion(requestVersion);

            LoadUploadPage();

		}

		protected void AssignControlsAll()
        {
			fileUploadFormTitle = (Label)FileUploadPanel.FindControl("FileUploadFormTitle");
			fileUploadPanel = (Panel)FileUploadPanel.FindControl("FileUploadPanel");
			uploadControlsPanel = (Panel)FileUploadPanel.FindControl("UploadControlsPanel");
			uploadType = (DropDownList)FileUploadPanel.FindControl("UploadType");
			graphicsOnlyPanel = (Panel)FileUploadPanel.FindControl("GraphicsOnlyPanel");
			documentsOnlyPanel = (Panel)FileUploadPanel.FindControl("DocumentsOnlyPanel");
			advertsOnlyPanel = (Panel)FileUploadPanel.FindControl("AdvertsOnlyPanel");
			advertType = (DropDownList)FileUploadPanel.FindControl("AdvertType");
			documentType = (DropDownList)FileUploadPanel.FindControl("DocumentType");
			associatedSponsor = (DropDownList)FileUploadPanel.FindControl("AssociatedSponsor");
			fileUpload = (FileUpload)FileUploadPanel.FindControl("FileUpload");
			uploadFileButton = (Button)FileUploadPanel.FindControl("UploadFileButton");
			fileRequiredValidator = (RequiredFieldValidator)FileUploadPanel.FindControl("FileRequiredValidator");
			graphicFileToReviewPanel = (Panel)FileUploadPanel.FindControl("GraphicFileToReviewPanel");
			graphicFileName = (HiddenField)FileUploadPanel.FindControl("GraphicFileName");
			graphicFileType = (HiddenField)FileUploadPanel.FindControl("GraphicFileType");
			advertTypeHidden = (HiddenField)FileUploadPanel.FindControl("AdvertTypeHidden");
			associatedSponsorHidden = (HiddenField)FileUploadPanel.FindControl("AssociatedSponsorHidden");
			graphicToReview = (System.Web.UI.WebControls.Image)FileUploadPanel.FindControl("GraphicToReview");
			userMessage = (Label)FileUploadPanel.FindControl("UserMessage");
			saveButton = (Button)FileUploadPanel.FindControl("SaveButton");
			rejectButton = (Button)FileUploadPanel.FindControl("RejectButton");
			backToReferrerLink = (HyperLink)FileUploadPanel.FindControl("BackToReferrerLink");
		}

        protected void ManagePageVersion(RequestVersion pageVersion) 
        {
			switch (requestVersion) {
				case RequestVersion.Delete:
                    DeleteFile();
                    break;
            }
        }
 
        protected void LoadUploadPage() 
        {
			Array fileUploadTypesEnum = Enum.GetValues(typeof(FileUploadTypes));
            if (uploadType.Items.Count < 2) 
            {
                foreach (Enum type in fileUploadTypesEnum)
                {
                    if (EnumExtensions.GetIntValue(type) > 0)
                    {
                        uploadType.Items.Add(new ListItem(EnumExtensions.GetStringValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
			if (fileUploadType != FileUploadTypes.Undefined)
            {
				uploadType.SelectedValue = EnumExtensions.GetIntValue(fileUploadType).ToString();
				uploadType.Enabled = false;
				fileUpload.Visible = true;
				uploadFileButton.Visible = true;
			}
			if (fileUploadType == FileUploadTypes.ClubLogo || fileUploadType == FileUploadTypes.Advert) 
            {
				graphicsOnlyPanel.Visible = true;
			}
			if (fileUploadType == FileUploadTypes.Advert)
            {
				advertsOnlyPanel.Visible = true;
				Array advertTypesEnum = Enum.GetValues(typeof(Advert.GraphicFileStyles));
				if (advertType.Items.Count < 2)
                {
					foreach (Enum type in advertTypesEnum) 
                    {
						if (EnumExtensions.GetIntValue(type) > 0) 
                        {
							advertType.Items.Add(new ListItem(EnumExtensions.GetStringValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
						}
					}
				}
				advertisers = iAdvertiser.SQLSelectForTournament(tournament.ID);
				if (associatedSponsor.Items.Count < 2)
                {
					foreach (Advertiser advertiser in advertisers) 
                    {
						associatedSponsor.Items.Add(new ListItem(advertiser.AdvertiserName, advertiser.ID.ToString()));
					}
				}
			}
			else if (fileUploadType == FileUploadTypes.Document)
            {
				documentsOnlyPanel.Visible = true;
				Array documentTypesEnum = Enum.GetValues(typeof(Document.DocumentTypes));
				if (documentType.Items.Count < 2)
                {
					foreach (Enum type in documentTypesEnum)
                    {
						if (EnumExtensions.GetIntValue(type) > 0)
                        {
							documentType.Items.Add(new ListItem(EnumExtensions.GetStringValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
						}
					}
				}
			}
        }

        protected void DeleteFile()
        {
			if (fileUploadType == FileUploadTypes.ClubLogo)
            {
                string filePath = "~/Uploads/Tournament"+tournament.ID.ToString()+"/Logos/"+tournament.HostClub.LogoFile;
                iClub.SQLUpdateClubLogoFile(tournament.HostClub.ID,null);
                IOExtensions.DeleteExistingFile(Server.MapPath(filePath));
            }
            Response.Redirect("~/UI/Planner/TournamentView?TournamentID="+tournament.ID.ToString());
        }

		protected void UploadType_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (uploadType.SelectedValue != "")
            {
				fileUpload.Visible = true;
				uploadFileButton.Visible = true;
			}
			else
            {
				fileUpload.Visible = false;
				uploadFileButton.Visible = false;
			}
		}

		protected void UploadFileButton_Click(object sender, EventArgs e)
        {
			string uploadedFileName = "";
			if (fileUpload.HasFile)
            {
				foreach (HttpPostedFile htfiles in fileUpload.PostedFiles)
                {   
					uploadedFileName = Path.GetFileName(htfiles.FileName);
					htfiles.SaveAs(Server.MapPath("~/Uploads/"+uploadedFileName));
					try
                    {
						string fileExtention = htfiles.ContentType;
						int fileSize = htfiles.ContentLength;

						// IMAGE FILES ONLY
						if (fileExtention == "image/jpeg" || fileExtention == "image/gif" || fileExtention == "image/png")
                        {
							System.Drawing.Bitmap bmpPostedImage = new System.Drawing.Bitmap(htfiles.InputStream);
							System.Drawing.Image objImage = bmpPostedImage;

							// image resizing
							if (fileUploadType == FileUploadTypes.ClubLogo)
                            {
								if (objImage.Height > 250 && objImage.Width > 250)
                                {
									objImage = ImageExtensions.RescaleImage(bmpPostedImage, 250, 250);
								}
								else if (objImage.Height > 250)
                                {
									objImage = ImageExtensions.RescaleImage(bmpPostedImage, 250, objImage.Width);
								}
								else if (objImage.Width > 250) 
                                {
									objImage = ImageExtensions.RescaleImage(bmpPostedImage, objImage.Height, 250);
								}
							}
							else if (fileUploadType == FileUploadTypes.Advert) 
                            {
								if ((Advert.GraphicFileStyles)Int32.Parse(advertType.SelectedValue) == Advert.GraphicFileStyles.Advert120By600) 
                                {
									objImage = ImageExtensions.RescaleImage(bmpPostedImage, 600, 120);
								}
								else if((Advert.GraphicFileStyles)Int32.Parse(advertType.SelectedValue) == Advert.GraphicFileStyles.Advert300By250)
                                {
									objImage = ImageExtensions.RescaleImage(bmpPostedImage, 250, 300);
								}
								else if((Advert.GraphicFileStyles)Int32.Parse(advertType.SelectedValue) == Advert.GraphicFileStyles.Advert300By600)
                                {
									objImage = ImageExtensions.RescaleImage(bmpPostedImage, 600, 300);
								}
								else if((Advert.GraphicFileStyles)Int32.Parse(advertType.SelectedValue) == Advert.GraphicFileStyles.Advert728By90)
                                {
									objImage = ImageExtensions.RescaleImage(bmpPostedImage, 90, 728);
								}
							}

							if (fileExtention == "image/jpeg")
                            {
								objImage.Save(Server.MapPath("~/Uploads/" + uploadedFileName), System.Drawing.Imaging.ImageFormat.Jpeg);
								graphicFileType.Value = (EnumExtensions.GetIntValue(Domains.GraphicFileTypes.JPEG)).ToString();
							}
							else if (fileExtention == "image/gif")
                            {
								objImage.Save(Server.MapPath("~/Uploads/" + uploadedFileName), System.Drawing.Imaging.ImageFormat.Gif);
								graphicFileType.Value = (EnumExtensions.GetIntValue(Domains.GraphicFileTypes.GIF)).ToString();
							}
							else if (fileExtention == "image/png")
                            {
								objImage.Save(Server.MapPath("~/Uploads/" + uploadedFileName), System.Drawing.Imaging.ImageFormat.Png);
								graphicFileType.Value = (EnumExtensions.GetIntValue(Domains.GraphicFileTypes.PNG)).ToString();
							}

							graphicFileToReviewPanel.Visible = true;
							graphicFileName.Value = uploadedFileName;
							advertTypeHidden.Value = advertType.SelectedValue;
							associatedSponsorHidden.Value = associatedSponsor.SelectedValue;

							graphicToReview.ImageUrl = "~/Uploads/" + uploadedFileName;
							if (fileUploadType == FileUploadTypes.ClubLogo) 
                            {
								userMessage.Text = "The maximum dimensions are 250 x 250 pixels - larger images are automatically re-scaled. ";
								userMessage.Text = "If your club logo has been skewed, please reject this version and amend the image before repeating the upload process";
							}
							else if (fileUploadType == FileUploadTypes.Advert)
                            {
								userMessage.Text = "If your advert has been skewed, please reject this version and amend the image before repeating the upload process";							
							}

						}
						else if (fileExtention == "application/pdf") 
                        {
							string newFileName = "TournamentID" + tournament.ID.ToString() + "_" + documentType.SelectedValue + uploadedFileName.Substring(uploadedFileName.IndexOf("."), 4);
                            IOExtensions.CopyFile(Server.MapPath("~/Uploads/" + uploadedFileName), Server.MapPath("~/Uploads/Tournament" + tournament.ID.ToString() + "/Documents/" + newFileName));
							Document documentToSave = new Document(
								id : 0 ,
								tournamentID : tournament.ID ,
								documentType : (Document.DocumentTypes)Int32.Parse(documentType.SelectedValue) ,
								fileName : newFileName
							);
							iDocument.SQLInsert<Document>(documentToSave);	
							Response.Redirect("~/UI/Utilities/DocumentsList.aspx?TournamentID=" + tournament.ID.ToString());
						}

					}
					catch { }
				}
			}
			uploadControlsPanel.Visible = false;
			uploadType.Enabled = false;
			fileUpload.Visible = false;
			uploadFileButton.Visible = false;
		}

		protected void SaveButton_Click(object sender, EventArgs e)
        {

            IOExtensions.DeleteAgedFilesInDirectory(Server.MapPath("~/Uploads/"), IOExtensions.TimeUnits.Seconds, 300);

            fileRequiredValidator.Enabled = false;
			string newFileName = "";

			if (fileUploadType == FileUploadTypes.ClubLogo) 
            {
				newFileName = "ClubID" + club.ID.ToString() + "Logo" + graphicFileName.Value.Substring(graphicFileName.Value.IndexOf("."), 4);
				iClub.SQLUpdateClubLogoFile(club.ID, newFileName);
                IOExtensions.CopyFile(Server.MapPath("~/Uploads/" + graphicFileName.Value), Server.MapPath("~/Uploads/Tournament" + tournament.ID.ToString() + "/Logos/" + newFileName));
				userMessage.Text = "Your graphic has been copied to the club logo image directory";
			}
			else if (fileUploadType == FileUploadTypes.Advert)
            {
				advertiser = iAdvertiser.SQLSelect<Advertiser, int>(Int32.Parse(associatedSponsorHidden.Value));				
				newFileName = advertiser.AdvertiserName.Replace(" ","") + "_" + advertTypeHidden.Value;

				Advert advertToSave = new Advert(
					id : 0 ,
					advertiserID : advertiser.ID ,
					graphicFileName : newFileName ,
					graphicFileType : (Domains.GraphicFileTypes)Int32.Parse(graphicFileType.Value) ,
					graphicStyle : (Advert.GraphicFileStyles)Int32.Parse(advertTypeHidden.Value) ,
					clicksThrough : 0
				);
				iAdvert.SQLInsert<Advert>(advertToSave);
                IOExtensions.CopyFile(Server.MapPath("~/Uploads/" + graphicFileName.Value), Server.MapPath("~/Uploads/Tournament" + tournament.ID.ToString() + "/Adverts/" + newFileName + graphicFileName.Value.Substring(graphicFileName.Value.IndexOf("."), 4)));
				userMessage.Text = "Your graphic has been copied to the advert image directory";
			}

			saveButton.Visible = false;
			rejectButton.Visible = false;

			if (fileUploadType == FileUploadTypes.ClubLogo)
            {
				backToReferrerLink.Text = "Back to Tournament Home Page >>";
				backToReferrerLink.NavigateUrl = "~/UI/Planner/TournamentView?TournamentID=" + tournament.ID.ToString();
			}
			else if (fileUploadType == FileUploadTypes.Advert)
            {
				backToReferrerLink.Text = "Back to Adverts List >>";
				backToReferrerLink.NavigateUrl = "~/UI/UploadedFilesList?Version=2&TournamentID=" + tournament.ID.ToString();
			}
			
		}

		protected void RejectButton_Click(object sender, EventArgs e)
        {
			IOExtensions.DeleteExistingFile(Server.MapPath("~/Uploads/"+graphicFileName.Value));
			Response.Redirect("~/UI/Planner/TournamentView?TournamentID=" + tournament.ID.ToString());
		}

	}

}
	