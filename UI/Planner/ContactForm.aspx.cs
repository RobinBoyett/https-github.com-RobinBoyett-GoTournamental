using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using GoTournamental.BLL.Planner;

namespace GoTournamental.UI.Planner {

    public partial class ContactForm : Page {

        #region Declare Domain Objects & Page Variables
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
		List<Competition> competitions = new List<Competition>();
		ICompetition iCompetition = new Competition();
		List<Club> clubs = new List<Club>();
		Club club = new Club();
		IClub iClub = new Club();
		Team team = new Team();
		ITeam iTeam = new Team();
		IContact iContact = new Contact();
		List<Contact> contacts = new List<Contact>();
        Contact contact = new Contact();
        int contactID = 0;
		GoTournamental.BLL.Organiser.Contact.ContactTypes contactTypeSelected = GoTournamental.BLL.Organiser.Contact.ContactTypes.Undefined;
		int clubID = 0;

        private RequestVersion pageVersion = RequestVersion.Undefined;
        protected enum RequestVersion {
            Undefined = 0,
            ContactInsert = 1,
            ContactEdit = 2
        }
        #endregion

        #region Declare page controls
        Label contactFormTitle = new Label();
		Label formTitle = new Label();
		HiddenField contactIDHidden = new HiddenField();
		DropDownList contactType = new DropDownList();
		TextBox firstName = new TextBox();
 		TextBox lastName = new TextBox();
		TextBox telephoneNumber = new TextBox();
		TextBox email = new TextBox();
		#endregion

        protected void Page_Load(object sender, EventArgs e) {

            AssignControlsAll();
            if (Request.QueryString.Get("TournamentID") != null) {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
				contactFormTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
				competitions = iCompetition.SQLSelectForTournament(tournament.ID, false);
				clubs = iClub.SQLSelectClubsForTournament(tournament.ID);
				contacts = iContact.SQLSelectForTournament(tournament.ID);
            }
            if (Request.QueryString.Get("version") != null) {
                pageVersion = (RequestVersion)Int32.Parse(Request.QueryString.Get("version"));
            }
            if (Request.QueryString.Get("contact_id") != null) {
				contact = iContact.SQLSelect<Contact, int>(Int32.Parse(Request.QueryString.Get("contact_id"))); 
            }
            if (Request.QueryString.Get("ContactType") != null) {
				contactTypeSelected = (GoTournamental.BLL.Organiser.Contact.ContactTypes)Int32.Parse(Request.QueryString.Get("ContactType")); 
            }
			if (Request.QueryString.Get("team_id") != null) {
				team = iTeam.SQLSelect<Team, int>(Int32.Parse(Request.QueryString.Get("team_id")));
			}
			if (Request.QueryString.Get("club_id") != null) {
				club = iClub.SQLSelect<Club, int>(Int32.Parse(Request.QueryString.Get("club_id"))); 
            }


            ManagePageVersion(pageVersion);

        }
		protected void AssignControlsAll() {
			contactFormTitle = (Label)ContactFormPanel.FindControl("ContactFormTitle");
			formTitle = (Label)ContactFormPanel.FindControl("FormTitle");
			contactIDHidden = (HiddenField)ContactFormPanel.FindControl("ContactIDHidden");
			contactType = (DropDownList)ContactFormPanel.FindControl("ContactType");
            firstName = (TextBox)ContactFormPanel.FindControl("FirstName"); 
            lastName = (TextBox)ContactFormPanel.FindControl("LastName");
			telephoneNumber = (TextBox)ContactFormPanel.FindControl("TelephoneNumber");
			email = (TextBox)ContactFormPanel.FindControl("Email");
		}
        protected void ManagePageVersion(RequestVersion pageVersion) {
			switch (pageVersion) {
				case RequestVersion.ContactEdit:
                    ContactEditFormLoad();
					formTitle.Text = "Edit Contact";
                    break;
				case RequestVersion.ContactInsert:
                    ContactEditFormLoad();
					formTitle.Text = "Add Contact";
                    break;
            }
        }

        protected void ContactEditFormLoad() {
            Array enumValues = Enum.GetValues(typeof(GoTournamental.BLL.Organiser.Contact.ContactTypes));
            if (contactType.Items.Count < 2) {
                foreach (Enum type in enumValues) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        contactType.Items.Add(new ListItem(EnumExtensions.GetStringValue(type), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
			if (!IsPostBack) {
				contactIDHidden.Value = contact.ID.ToString();
				contactType.SelectedValue = EnumExtensions.GetIntValue(contact.Type).ToString();
				firstName.Text = contact.FirstName;
				lastName.Text = contact.LastName;
				telephoneNumber.Text = contact.TelephoneNumber;
				email.Text = contact.Email;
			}
			if (Request.QueryString.Get("team_id") != null) {
				contactType.SelectedValue = EnumExtensions.GetIntValue(Contact.ContactTypes.TeamContact).ToString();
			}		
			else if (Request.QueryString.Get("club_id") != null)  {
				contactType.SelectedValue = EnumExtensions.GetIntValue(Contact.ContactTypes.ClubContact).ToString();
			}
 			else if (contactTypeSelected != GoTournamental.BLL.Organiser.Contact.ContactTypes.Undefined) {
				contactType.SelectedValue = EnumExtensions.GetIntValue(contactTypeSelected).ToString();
				contactType.Enabled = false;
			}
		}

        protected void SaveButton_Click(object sender, EventArgs e) {
            if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {

			    Contact contactToSave = new Contact(
				    id: Int32.Parse(contactIDHidden.Value),
				    tournamentID: tournament.ID,
				    type: (Contact.ContactTypes)Int32.Parse(contactType.SelectedValue),
				    title: null,
				    firstName : firstName.Text,
				    lastName : lastName.Text,
				    telephoneNumber : telephoneNumber.Text,
				    email : email.Text,
                    dateOfBirth : (Nullable<DateTime>)null,
                    squadNumber : null
			    );
			    if (contactToSave.ID == 0) {
				    if (Request.QueryString.Get("team_id") != null) {
					    contactID = iContact.SQLInsertAndReturnID<Contact>(contactToSave);
					    iTeam.SQLUpdatePrimaryContactID(team.ID, contactID);
				    }
				    else if (Request.QueryString.Get("club_id") != null) {
					    contactID = iContact.SQLInsertAndReturnID<Contact>(contactToSave);
					    iClub.SQLUpdatePrimaryContactID(club.ID,contactID);
				    }			
				    else {
					    iContact.SQLInsert<Contact>(contactToSave);			
				    }
			    }
			    else {
				    iContact.SQLUpdate<Contact>(contactToSave);
			    }
            }
			if (Request.QueryString.Get("team_id") != null) {
				Response.Redirect("~/UI/Teams/TeamForm.aspx?version=2&TournamentID="+tournament.ID.ToString()+"&club_id="+club.ID.ToString()+"&team_id="+team.ID.ToString());
			}
			else if (Request.QueryString.Get("club_id") != null) {
				Response.Redirect("~/UI/Planner/ClubForm.aspx?version=2&TournamentID="+tournament.ID.ToString()+"&club_id="+club.ID.ToString());
			}
			else if (contactTypeSelected == GoTournamental.BLL.Organiser.Contact.ContactTypes.TournamentContact) {
				Response.Redirect("~/UI/Planner/TournamentView?TournamentID="+tournament.ID.ToString());
			}
			else {
				Response.Redirect("~/UI/Planner/ContactsList.aspx?TournamentID="+tournament.ID.ToString());
			}

        }

    }

}

