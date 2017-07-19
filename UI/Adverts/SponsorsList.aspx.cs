using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser {

    public partial class SponsorsList : Page {

        #region Declare Domain Objects & Page Variables
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
		List<Advertiser> sponsorsList = new List<Advertiser>();
        IAdvertiser iAdvertiser = new Advertiser();
		#endregion

        #region Declare page controls
		AdvertPanel advert300x600 = new AdvertPanel();
		TournamentMenu tournamentMenu = new TournamentMenu();
		SetUpMenu setUpMenu = new SetUpMenu();
		Label sponsorsListTitle = new Label();
		#endregion
		
        protected void Page_Load(object sender, EventArgs e) {

            AssignControlsAll();

            if (Request.QueryString.Get("TournamentID") != null) {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
 				sponsorsListTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
			}

			if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
	            LinkToSponsorAdd.NavigateUrl = "~/UI/Adverts/SponsorForm.aspx?version=1&TournamentID=" + tournament.ID.ToString();
				LinkToSponsorAdd.Visible = true;
			}
			else {
				setUpMenu.Visible = false;
			}

            sponsorsList = iAdvertiser.SQLSelectForTournament(tournament.ID);
			SponsorsDataList.DataSource = sponsorsList;
			SponsorsDataList.DataBind();

			advert300x600.graphicFileStyle = Advert.GraphicFileStyles.Advert300By600;
			advert300x600.tournamentID = tournament.ID;

        }

		protected void AssignControlsAll() {
			advert300x600 = (AdvertPanel)SponsorsListPanel.FindControl("Advert300x600");
			tournamentMenu = (TournamentMenu)SponsorsListPanel.FindControl("TournamentMenuControl");
			setUpMenu = (SetUpMenu)SponsorsListPanel.FindControl("SetUpMenuControl");
			sponsorsListTitle = (Label)SponsorsListPanel.FindControl("SponsorsListTitle");
		}

		protected void SponsorsDataList_ItemDataBound(Object sender, DataListItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				Advertiser sponsor = (Advertiser)e.Item.DataItem;
				if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
					HyperLink deleteSponsorLink = (HyperLink)e.Item.FindControl("DeleteSponsorLink");
					deleteSponsorLink.Visible = true;
					deleteSponsorLink.Attributes.Add("onclick","javascript:return confirm('Are you sure you want to delete this item?')");
					deleteSponsorLink.NavigateUrl = "~/UI/Adverts/SponsorForm.aspx?TournamentID="+tournament.ID.ToString()+"&version=3&sponsor_id="+sponsor.ID.ToString();
					HyperLink editSponsorLink = (HyperLink)e.Item.FindControl("EditSponsorLink");
					editSponsorLink.Visible = true;
					editSponsorLink.NavigateUrl = "~/UI/Adverts/SponsorForm.aspx?TournamentID="+tournament.ID.ToString()+"&version=2&sponsor_id="+sponsor.ID.ToString();
				}
				HyperLink advertiserLink = (HyperLink)e.Item.FindControl("AdvertiserLink");
				advertiserLink.NavigateUrl = sponsor.WebsiteURL;
				advertiserLink.Text = sponsor.AdvertiserName;
			}
		}

   
	}

}



