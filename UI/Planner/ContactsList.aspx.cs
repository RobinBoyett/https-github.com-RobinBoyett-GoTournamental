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

	public partial class ContactsList : Page {

		#region Declare Domain Objects & Page Variables
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
		Tournament tournament = new Tournament();
		ITournament iTournament = new Tournament();
		List<Competition> competitions = new List<Competition>();
		ICompetition iCompetition = new Competition();
		List<Club> clubs = new List<Club>();
		IClub iClub = new Club();
		ITeam iTeam = new Team();
		IContact iContact = new Contact();
		List<Contact> contacts = new List<Contact>();
		#endregion

		#region Declare page controls
		Label contactsListTitle = new Label();
		#endregion

		protected void Page_Load(object sender, EventArgs e) {
			AssignControlsAll();

			if (Request.QueryString.Get("TournamentID") != null) {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
				contactsListTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
				contacts = iContact.SQLSelectForTournament(tournament.ID);
			}
	
			LinkToContactAdd.NavigateUrl = "~/UI/Planner/ContactForm.aspx?version=1&TournamentID=" + tournament.ID.ToString();
			if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
				LinkToContactAdd.Visible = true;
			}

			GridView contactsListGridView = (GridView)ContactsListPanel.FindControl("ContactsListGridView");
			contactsListGridView.DataSource = contacts;
			contactsListGridView.DataBind();

		}

		protected void AssignControlsAll() {
			contactsListTitle = (Label)ContactsListPanel.FindControl("ContactsListTitle");
		}

		protected void ContactsList_DataBound(object sender, EventArgs e) {
			GridView contactsListGridView = (GridView)ContactsListPanel.FindControl("ContactsListGridView");
			if (!identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
				contactsListGridView.Columns[3].Visible = false;
				contactsListGridView.Columns[4].Visible = false;
			}
		}

		protected void ContactsList_RowDataBound(Object sender, GridViewRowEventArgs e) {
			if (e.Row.RowType == DataControlRowType.DataRow) {
				Contact contact = (Contact)e.Row.DataItem;
				HyperLink editContactLink = (HyperLink)e.Row.FindControl("EditContactLink");
				editContactLink.Text = contact.FirstName + " " + contact.LastName;
				if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
					editContactLink.NavigateUrl = "~/UI/Planner/ContactForm.aspx?version=2&TournamentID=" + tournament.ID.ToString() + "&contact_id=" + contact.ID.ToString();
				}
				if (contact.Type == Contact.ContactTypes.ClubContact) {
					Club club = iClub.GetClubForPrimaryContactID(contact.ID);
                    if (club != null) {
                        e.Row.Cells[1].Text = club.Name + " " + EnumExtensions.GetStringValue(contact.Type);
                    }
				}
				else if (contact.Type == Contact.ContactTypes.TeamContact) {
					Team team = iTeam.SQLGetTeamForPrimaryContactID(contact.ID);
					if (team != null) {
						Club club = iClub.SQLSelect<Club, int>(team.ClubID);
						if (club != null) {
							 e.Row.Cells[1].Text = club.Name + " " + team.Name + " " + EnumExtensions.GetStringValue(contact.Type);
						}
						else {
							 e.Row.Cells[1].Text = team.Name + " " + EnumExtensions.GetStringValue(contact.Type);
						}
                    }
				}
				else {
					e.Row.Cells[1].Text = EnumExtensions.GetStringValue(contact.Type);
				}
				HyperLink linkToItinary = (HyperLink)e.Row.FindControl("LinkToItinary");
				linkToItinary.Text = ">>";
				linkToItinary.NavigateUrl = "~/UI/Competitions/FixturesList.aspx?TournamentID="+tournament.ID.ToString()+"&contact_id=" + contact.ID.ToString();



			}
		}

	}
}