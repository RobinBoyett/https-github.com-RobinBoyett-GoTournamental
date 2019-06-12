using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.BLL.Organiser;
using GoTournamental.API.Identity;

namespace GoTournamental.UI.Organiser 
{

	public partial class Terms : Page 
    {

        GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
		AdvertPanel advert300x250 = new AdvertPanel();

		protected void Page_Load(object sender, EventArgs e)
        {

            TermsAndConditionsLink.NavigateUrl = "~/Documents/GTTerms.pdf";

            if (HttpContext.Current.User.Identity.GetUserId() != null && !identityHelper.RoleExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentOwner")) 
            {
                TermsSignatoryPanel.Visible = true;
            }

			advert300x250 = (AdvertPanel)TermsPanel.FindControl("Advert300x250");
			advert300x250.graphicFileStyle = Advert.GraphicFileStyles.Advert300By250;
			advert300x250.tournamentID = 0;

		}

        protected void SaveTermsSigned_Click(object sender, EventArgs e) 
        {
            CheckBox saveTermsSigned = (CheckBox)TermsSignatoryPanel.FindControl("TermsSigned");
            if (saveTermsSigned.Checked == true) {
                ITermsSignatory iTermsSignatory = new TermsSignatory();
                TermsSignatory termsSignatory = new TermsSignatory(
                    id : 0 , 
                    userID : HttpContext.Current.User.Identity.GetUserId() ,
                    userName: HttpContext.Current.User.Identity.GetUserName()
                );
                iTermsSignatory.SQLInsert<TermsSignatory>(termsSignatory);
                identityHelper.AddRoleForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentOwner");
                Response.Redirect("~/UI/Planner/TournamentForm.aspx?version=1");
            }
        }

	}

}