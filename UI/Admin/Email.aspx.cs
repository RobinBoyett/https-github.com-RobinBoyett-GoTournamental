using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoTournamental.API.Identity;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Administration 
{

	public partial class Email : Page 
    {

		#region Declare Domain Objects & Page Variables
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
		ITournament iTournament = new Tournament();
        Tournament tournament = new Tournament();
        List<Tournament> tournamentsList = new List<Tournament>();
		IContact iContact = new Contact();
		List<Contact> contactsList = new List<Contact>();
		#endregion

		#region Declare page controls
        DropDownList tournamentsDropDown = new DropDownList();
        #endregion


		protected void Page_Load(object sender, EventArgs e) 
        {
            AssignControlsAll();
            if (tournamentsDropDown.Items.Count < 2) 
            {
                tournamentsList = iTournament.SQLSelectAll<Tournament>();
                foreach (Tournament tournament in tournamentsList) 
                {
                    tournamentsDropDown.Items.Add(new ListItem(tournament.HostClub.Name + " - " + tournament.Name, tournament.ID.ToString()));
                }
            }

		}
        protected void AssignControlsAll() 
        {
			tournamentsDropDown = (DropDownList)StandardEmailsPanel.FindControl("TournamentsDropDown");
        }


        protected void EmailTest_Click(object sender, EventArgs e) 
        {

            if (tournamentsDropDown.SelectedValue != "0") 
            {
                tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(tournamentsDropDown.SelectedValue));
            }
            if (tournament.ID != 0)
            {
                contactsList = iContact.SQLSelectForTournament(tournament.ID);
                if (contactsList.Count > 0)
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
                    foreach (Contact contact in contactsList) 
                    {
                        if (contact.Type == Contact.ContactTypes.TeamContact && contact.Email != null && contact.Email != "") 
                        {
                            MailAddress mailTo = new MailAddress("robin.boyett@hotmail.com", "Robin Boyett");
                            MailMessage mailMessage = new MailMessage(mailFrom, mailTo);
                            mailMessage.Subject = tournament.HostClub.Name + " - " + tournament.Name;
                            mailMessage.Body = contact.Email;
                            smtpClient.Send(mailMessage);                        
                        }
                    }
                    smtpClient.Dispose();
                }
            }
        }
       

	}

}