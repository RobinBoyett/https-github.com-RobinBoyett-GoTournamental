using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser {

	public partial class Default : Page {

        GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        AdvertPanel advert728By90 = new AdvertPanel();

		protected void Page_Load(object sender, EventArgs e) {

            if (identityHelper.UserHasCreatedTournament(HttpContext.Current.User.Identity.GetUserId())) {
                int tournamentID = identityHelper.TournamentIDCreatedByUser(HttpContext.Current.User.Identity.GetUserId());
                HyperLink tournamentLink = (HyperLink)GTHomePagePanel.FindControl("TournamentLink");
                tournamentLink.Text = "Your Tournament &raquo;";
                tournamentLink.NavigateUrl = "/UI/Tournaments/TournamentView?TournamentID=" + tournamentID.ToString();
                tournamentLink.Visible = true;
            }
            else if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated) {
                HyperLink tournamentLink = (HyperLink)GTHomePagePanel.FindControl("TournamentLink");
                tournamentLink.Text = "Create Tournament &raquo;";
                tournamentLink.NavigateUrl = "/UI/Tournaments/TournamentForm?Version=1";
                tournamentLink.Visible = true;
            }

            //advert728By90 = (AdvertPanel)GTHomePagePanel.FindControl("Advert728By90");
            //advert728By90.graphicFileStyle = Advert.GraphicFileStyles.Advert728By90;
            //advert728By90.tournamentID = 0;

		}


	}

}