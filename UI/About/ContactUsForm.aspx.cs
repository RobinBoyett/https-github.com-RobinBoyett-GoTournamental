using System;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;

namespace GoTournamental.UI 
{

	public partial class ContactUsForm : Page 
    {

		//AdvertPanel advert120x600 = new AdvertPanel();

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
		Panel welcomeTextPanel = new Panel();
		TextBox firstName = new TextBox();
		TextBox lastName = new TextBox();
		TextBox email = new TextBox();
		TextBox organisation = new TextBox();
		TextBox telephoneNumber = new TextBox();
		DropDownList tournamentType = new DropDownList();
		TextBox additionalInformation = new TextBox();
		HiddenField contactUsIDHidden = new HiddenField();
		Button deleteButton = new Button();
		#endregion

		protected void Page_Load(object sender, EventArgs e)
        {

            AssignControlsAll();

			if (Request.QueryString.Get("Version") != null) 
            {
                pageVersion = (RequestVersion)Int32.Parse(Request.QueryString.Get("version"));
            }
			if (Request.QueryString.Get("ID") != null) 
            {
 				contactUs = iContactUs.SQLSelect<Feedback, int>(Int32.Parse(Request.QueryString.Get("ID"))); 
            }

			ManagePageVersion(pageVersion);
			
			//advert120x600 = (AdvertPanel)ContactUsFormPanel.FindControl("Advert120x600");
			//advert120x600.graphicFileStyle = Advert.GraphicFileStyles.Advert120By600;
			//advert120x600.tournamentID = 0;

		}

		protected void AssignControlsAll() 
        {
			welcomeTextPanel = (Panel)ContactUsFormPanel.FindControl("WelcomeTextPanel");
			firstName = (TextBox)ContactUsFormPanel.FindControl("FirstName");
			lastName = (TextBox)ContactUsFormPanel.FindControl("LastName");
			email = (TextBox)ContactUsFormPanel.FindControl("Email");
			organisation = (TextBox)ContactUsFormPanel.FindControl("Organisation");
			telephoneNumber = (TextBox)ContactUsFormPanel.FindControl("TelephoneNumber");
			tournamentType = (DropDownList)ContactUsFormPanel.FindControl("TournamentType");
			additionalInformation = (TextBox)ContactUsFormPanel.FindControl("AdditionalInformation");
			contactUsIDHidden = (HiddenField)ContactUsFormPanel.FindControl("ContactUsIDHidden");
			deleteButton = (Button)ContactUsFormPanel.FindControl("DeleteButton");
		}

        protected void ManagePageVersion(RequestVersion pageVersion)
        {
			switch (pageVersion) 
            {
				case RequestVersion.PreRegisterMessage:
					ContactUsMessagePanel.Visible = true;
					break;
				case RequestVersion.PreRegisterInsert:
				default:
					PreRegisterFormLoad();
                    break;
            }
        }

		protected void PreRegisterFormLoad() 
        {
			ContactUsFormPanel.Visible = true;
			if (contactUs == null) 
            {
				welcomeTextPanel.Visible = true;
			}
			Array tournamentTypes = Enum.GetValues(typeof(Tournament.TournamentTypes));
            if (tournamentType.Items.Count < 2) 
            {
                foreach (Enum type in tournamentTypes) 
                {
                    if (EnumExtensions.GetIntValue(type) > 0)
                    {
                        tournamentType.Items.Add(new ListItem(EnumExtensions.GetStringValue(type), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
			if (contactUs != null && !IsPostBack) 
            {
				firstName.Text = contactUs.FirstName;
				lastName.Text = contactUs.LastName;
				email.Text = contactUs.Email;
				organisation.Text = contactUs.Organisation;
				telephoneNumber.Text = contactUs.TelephoneNumber;
				tournamentType.SelectedValue = EnumExtensions.GetIntValue(contactUs.TournamentType).ToString();
				additionalInformation.Text = contactUs.AdditionalInformation;
				contactUsIDHidden.Value = contactUs.ID.ToString();
				var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
				if (user != null && identityHelper.RoleExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "Administrator")) 
                {
					deleteButton.Visible = true;
				}
			}
			else 
            {
				contactUsIDHidden.Value = "0";
			}
		}

		protected void SaveButton_Click(object sender, EventArgs e) 
        {
			Feedback contactUsToSave = new Feedback(
				id: Int32.Parse(contactUsIDHidden.Value),
				firstName : firstName.Text,
				lastName : lastName.Text,
				email : email.Text,
				organisation : organisation.Text,
				telephoneNumber : telephoneNumber.Text,
				tournamentType : (Tournament.TournamentTypes)Int32.Parse(tournamentType.SelectedValue) ,
				additionalInformation : additionalInformation.Text,
				feedbackDate : DateTime.Now
            );

			if (contactUsToSave.ID == 0) 
            {
	            iContactUs.SQLInsert<Feedback>(contactUsToSave);
				Response.Redirect("~/UI/About/ContactUsForm.aspx?version=2");
			}
			else 
            {
	            iContactUs.SQLUpdate<Feedback>(contactUsToSave);
				Response.Redirect("~/UI/Admin/ContactUsList");
			}
            EmailNotificationOfNewContact();
		}

		protected void DeleteButton_Click(object sender, EventArgs e) 
        {
			iContactUs.SQLDelete<Feedback>(contactUs);
			Response.Redirect("~/UI/Admin/ContactUsList");
		
		}

        protected void EmailNotificationOfNewContact() 
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.EnableSsl = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Timeout = 20000;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("noreply@gotournamental.com", "GT@1Pellings!");
            smtpClient.Host = "smtp.WebSiteLive.net";
            smtpClient.Port = 587;
            MailAddress mailFrom = new MailAddress("noreply@gotournamental.com", "Gotournamental");
            MailAddress mailTo = new MailAddress("robin.boyett@hotmail.com", "Robin Boyett");
            MailMessage mailMessage = new MailMessage(mailFrom, mailTo);
            mailMessage.Subject = "New Contact Us Entry For GT";
            mailMessage.Body = "http://www.gotournamental.com/UI/Admin/ContactUsList";
            smtpClient.Send(mailMessage);

            smtpClient.Dispose();

        }


	}

}