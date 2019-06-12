using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using GoTournamental.API.Identity;

namespace GoTournamental.UI
{

	public partial class ContactUsView : Page 
    {

		#region Declare Domain Objects & Page Variables
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
		IFeedback iContactUs = new Feedback();
		Feedback contactUs = new Feedback();

        private RequestVersion pageVersion = RequestVersion.Undefined;
        protected enum RequestVersion 
        {
            Undefined = 0,
            PreRegisterInsert = 1,
            PreRegisterMessage = 2
        }
		#endregion
		#region Declare page controls
		Label fullName = new Label();
        Label contactDate = new Label();
		Label email = new Label();
		Label organisation = new Label();
		Label telephoneNumber = new Label();
		Label tournamentType = new Label();
		Label additionalInformation = new Label();
		#endregion

		protected void Page_Load(object sender, EventArgs e)
        {

            AssignControlsAll();

			if (Request.QueryString.Get("ID") != null) 
            {
 				contactUs = iContactUs.SQLSelect<Feedback, int>(Int32.Parse(Request.QueryString.Get("ID"))); 
                ViewLoad();
            }

		}

		protected void AssignControlsAll() 
        {
			fullName = (Label)ContactUsViewPanel.FindControl("FullName");
            contactDate = (Label)ContactUsViewPanel.FindControl("ContactDate");
			email = (Label)ContactUsViewPanel.FindControl("Email");
			organisation = (Label)ContactUsViewPanel.FindControl("Organisation");
			telephoneNumber = (Label)ContactUsViewPanel.FindControl("TelephoneNumber");
			tournamentType = (Label)ContactUsViewPanel.FindControl("TournamentType");
			additionalInformation = (Label)ContactUsViewPanel.FindControl("AdditionalInformation");
		}


		protected void ViewLoad() 
        {
			fullName.Text = contactUs.FirstName + ' ' + contactUs.LastName;
            contactDate.Text = contactUs.FeedbackDate.Value.ToLongDateString();
			email.Text = contactUs.Email;
			organisation.Text = contactUs.Organisation;
			telephoneNumber.Text = contactUs.TelephoneNumber;
			tournamentType.Text = EnumExtensions.GetStringValue(contactUs.TournamentType).ToString();
			additionalInformation.Text = contactUs.AdditionalInformation;

		}


	}

}