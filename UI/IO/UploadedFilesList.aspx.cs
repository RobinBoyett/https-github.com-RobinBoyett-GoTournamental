using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser
{

    public partial class UploadedFilesList : Page 
    {

        #region Declare Domain Objects & Page Variables
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
		IAdvert iAdvert = new Advert();
		List<Advert> advertsList = new List<Advert>();

        private RequestVersion pageVersion = RequestVersion.Undefined;
        protected enum RequestVersion 
        {
            Undefined = 0,
            AllFileTypes = 1,
			AdvertFilesOnly = 2,
			DocumentFilesOnly = 3
        }
		#endregion

        #region Declare page controls
		Label uploadedFilesListTitle = new Label();
		Label uploadedFilesTypeTitle = new Label();
		HyperLink uploadLink = new HyperLink();
		DataList uploadedImageGallery = new DataList();
		#endregion
		
        protected void Page_Load(object sender, EventArgs e) 
        {

            AssignControlsAll();

            if (Request.QueryString.Get("TournamentID") != null) 
            {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
 				uploadedFilesListTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
			}
            if (Request.QueryString.Get("version") != null) 
            {
                pageVersion = (RequestVersion)Int32.Parse(Request.QueryString.Get("version"));
            }


			if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) 
            {
				if (pageVersion == RequestVersion.AdvertFilesOnly) 
                {
					uploadedFilesTypeTitle.Text = "Uploaded Adverts";
					uploadLink.Text = "Upload a new advert";
					uploadLink.NavigateUrl = "~/UI/IO/FileUploadForm.aspx?TournamentID="+tournament.ID.ToString()+"&UploadType=2";
					uploadLink.Visible = true;
					advertsList = iAdvert.GetAdvertsForTournament(tournament.ID);
					uploadedImageGallery.DataSource = advertsList;
					uploadedImageGallery.DataBind();
				}
				else if (pageVersion == RequestVersion.DocumentFilesOnly) 
                {
					uploadedFilesTypeTitle.Text = "Upload Document";
					uploadLink.Text = "Upload a new document";
					uploadLink.NavigateUrl = "~/UI/IO/FileUploadForm.aspx?TournamentID="+tournament.ID.ToString()+"&UploadType=3";
					uploadLink.Visible = true;
				}

			}

        }

		protected void AssignControlsAll()
        {
			uploadedFilesListTitle = (Label)UploadedFilesListPanel.FindControl("UploadedFilesListTitle");
			uploadedFilesTypeTitle = (Label)UploadedFilesListPanel.FindControl("UploadedFilesTypeTitle");
			uploadLink = (HyperLink)UploadedFilesListPanel.FindControl("UploadLink");
			uploadedImageGallery = (DataList)UploadedFilesListPanel.FindControl("UploadedImageGallery");
		}

		protected void UploadedImageGallery_ItemDataBound(object sender, DataListItemEventArgs e) 
        {
		    if (e.Item.DataItem == null) return;
            Advert advert = (Advert)e.Item.DataItem;
            System.Web.UI.WebControls.Image uploadedImage = (System.Web.UI.WebControls.Image)e.Item.FindControl("UploadedImage");
			uploadedImage.ImageUrl = advert.GraphicFilePath;

			if (advert.GraphicStyle == Advert.GraphicFileStyles.Advert120By600) 
            {
				uploadedImage.Width = 24;
				uploadedImage.Height = 120;
			}
			else if (advert.GraphicStyle == Advert.GraphicFileStyles.Advert300By250)
            {
				uploadedImage.Width = 60;
				uploadedImage.Height = 50;
			}
			else if (advert.GraphicStyle == Advert.GraphicFileStyles.Advert300By600) 
            {
				uploadedImage.Width = 60;
				uploadedImage.Height = 120;
			}
			else if (advert.GraphicStyle == Advert.GraphicFileStyles.Advert728By90) 
            {
				uploadedImage.Width = 145;
				uploadedImage.Height = 18;
			}
		}

	}

}



