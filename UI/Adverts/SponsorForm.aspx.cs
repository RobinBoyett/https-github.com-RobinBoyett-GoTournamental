using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser 
{

    public partial class SponsorForm : Page
    {

        #region Declare Domain Objects & Page Variables
 		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
        Advertiser sponsor = new Advertiser();
        IAdvertiser iAdvertiser = new Advertiser();

        private RequestVersion pageVersion = RequestVersion.Undefined;
        protected enum RequestVersion
        {
            Undefined = 0,
            SponsorInsert = 1,
            SponsorEdit = 2,
			SponsorDelete = 3
        }
        #endregion

        #region Declare page controls
        Label sponsorFormTitle = new Label();
		Label formTitle = new Label();
		HiddenField sponsorIDHidden = new HiddenField();
		TextBox sponsorName = new TextBox();
        TextBox sponsorURL = new TextBox();
        #endregion

        protected void Page_Load(object sender, EventArgs e) 
        {

            AssignControlsAll();
            if (Request.QueryString.Get("TournamentID") != null)
            {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
				sponsorFormTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
            }
            if (Request.QueryString.Get("version") != null)
            {
                pageVersion = (RequestVersion)Int32.Parse(Request.QueryString.Get("version"));
            }
            if (Request.QueryString.Get("sponsor_id") != null)
            {
				sponsor = iAdvertiser.SQLSelect<Advertiser, int>(Int32.Parse(Request.QueryString.Get("sponsor_id"))); 
            }

            ManagePageVersion(pageVersion);

        }
		protected void AssignControlsAll()
        {
			sponsorFormTitle = (Label)SponsorFormPanel.FindControl("SponsorFormTitle");
			formTitle = (Label)SponsorFormPanel.FindControl("FormTitle");
			sponsorIDHidden = (HiddenField)SponsorFormPanel.FindControl("SponsorIDHidden");
            sponsorName = (TextBox)SponsorFormPanel.FindControl("SponsorName");
            sponsorURL = (TextBox)SponsorFormPanel.FindControl("SponsorURL"); 
        }
        protected void ManagePageVersion(RequestVersion pageVersion) 
        {
			switch (pageVersion) 
            {
				case RequestVersion.SponsorDelete:
                    SponsorDelete();
                    break;
				case RequestVersion.SponsorEdit:
                    SponsorEditFormLoad();
					formTitle.Text = "Edit Sponsor";
                    break;
				case RequestVersion.SponsorInsert:
                    SponsorEditFormLoad();
					formTitle.Text = "Add Sponsor";
                    break;
            }
        }

        protected void SponsorEditFormLoad() 
        {
			if (!IsPostBack) 
            {
				sponsorIDHidden.Value = sponsor.ID.ToString();
				sponsorName.Text = sponsor.AdvertiserName;
				sponsorURL.Text = sponsor.WebsiteURL;
			}		
        }
        protected void SponsorDelete() 
        {
            if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) 
            {
                iAdvertiser.SQLDelete<Advertiser>(sponsor);
            }
            Response.Redirect("~/UI/Adverts/SponsorsList.aspx?TournamentID="+tournament.ID.ToString());
        }

        protected void SaveButton_Click(object sender, EventArgs e) 
        {
            if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) 
            {
			    Advertiser sponsorToSave = new Advertiser(
				    id: Int32.Parse(sponsorIDHidden.Value),
				    tournamentID: tournament.ID,
				    advertiserName: sponsorName.Text,
				    websiteURL: sponsorURL.Text
			    );
                if (sponsorToSave.ID == 0)
                {
                    iAdvertiser.SQLInsert<Advertiser>(sponsorToSave);
                }
			    else 
                {
				    iAdvertiser.SQLUpdate<Advertiser>(sponsorToSave);
			    }
            }
            Response.Redirect("~/UI/Adverts/SponsorsList.aspx?TournamentID="+tournament.ID.ToString());

        }

    }

}

