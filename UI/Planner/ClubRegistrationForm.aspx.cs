using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Planner;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Planner {

    public partial class ClubRegistrationForm : Page {

        #region Declare Domain Objects & Page Variables
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        ITournament iTournament = new Tournament();
        Tournament tournament = new Tournament();
        ICompetition iCompetition = new Competition();
        Competition competition = new Competition();
        List<Competition> competitionsInTournament = new List<Competition>();
		IClub iClub = new Club();
		Club club = new Club();
		ITeam iTeam = new Team();
		List<Team> teams = new List<Team>();
		Team team = new Team();
		IContact iContact = new Contact();
        Contact contact = new Contact();
		int contactID = 0;
        string userID = null;

        private RequestVersion pageVersion = RequestVersion.Undefined;
        protected enum RequestVersion {
            Undefined = 0,
            RegistrationInsertOrEdit = 1,
			RegistrationConfirm = 2,
			ErrorMessage = 3
        }

		bool userApproved = new bool();
		#endregion

        #region Declare page controls
		Label clubRegistrationFormTitle = new Label();
		HiddenField clubIDHidden = new HiddenField();
		Label clubName = new Label();
		Panel securedPanel = new Panel();
		DropDownList clubColourPrimary = new DropDownList();
		DropDownList clubColourSecondary = new DropDownList();
		DropDownList affiliation = new DropDownList();
		TextBox affiliationNumber = new TextBox();
		DropDownList contactType = new DropDownList();
		HiddenField contactIDHidden = new HiddenField();
		TextBox firstName = new TextBox();
 		TextBox lastName = new TextBox();
		TextBox telephoneNumber = new TextBox();
		TextBox email = new TextBox();
		Panel teamsRegistrationPanel = new Panel();
        DataList teamsListForClub = new DataList();
		DropDownList ageBands = new DropDownList();
		TextBox teamName = new TextBox();
		TextBox teamContactFirstName = new TextBox();
		TextBox teamContactLastName = new TextBox();
		TextBox teamContactTelephoneNumber = new TextBox();
		TextBox teamContactEmail = new TextBox();
		#endregion

        protected void Page_Load(object sender, EventArgs e) {

            AssignControlsAll();

			if (Request.QueryString.Get("TournamentID") != null) {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
				if (tournament != null) {
					clubRegistrationFormTitle.Text = tournament.HostClub.Name + " " + tournament.Name + " - Registration Form";
                    competitionsInTournament = iCompetition.SQLSelectForTournament(tournament.ID, false);
				}
                if (Request.QueryString.Get("UserID") != null) {
                    userID = Request.QueryString.Get("UserID");
                }
            }
            if (Request.QueryString.Get("version") != null) {
                pageVersion = (RequestVersion)Int32.Parse(Request.QueryString.Get("version"));
            }
            if (Request.QueryString.Get("club_id") != null) {
				club = iClub.SQLSelect<Club, int>(Int32.Parse(Request.QueryString.Get("club_id")));
            }

			if (tournament == null || (tournament != null && tournament.ID == 0) || club == null || (club != null && club.ID == 0)) {
				pageVersion = RequestVersion.ErrorMessage;
			}

            if (!identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
				SetUpMenuControl.Visible = false;
                ValidateUserSecurityCode();
			}
			ManagePageVersion(pageVersion);
		}

		protected void AssignControlsAll() {
			clubRegistrationFormTitle = (Label)ClubRegistrationFormPanel.FindControl("ClubRegistrationFormTitle");
			clubIDHidden = (HiddenField)ClubRegistrationFormPanel.FindControl("ClubIDHidden");
			clubName = (Label)ClubRegistrationFormPanel.FindControl("ClubName");
			securedPanel = (Panel)ClubRegistrationFormPanel.FindControl("SecuredPanel");
			clubColourPrimary = (DropDownList)ClubRegistrationFormPanel.FindControl("ClubColourPrimary");
			clubColourSecondary = (DropDownList)ClubRegistrationFormPanel.FindControl("ClubColourSecondary");
			affiliation = (DropDownList)ClubRegistrationFormPanel.FindControl("Affiliation");
			affiliationNumber = (TextBox)ClubRegistrationFormPanel.FindControl("AffiliationNumber");
			contactType = (DropDownList)ClubRegistrationFormPanel.FindControl("ContactType");
			contactIDHidden = (HiddenField)ClubRegistrationFormPanel.FindControl("ContactIDHidden");
            firstName = (TextBox)ClubRegistrationFormPanel.FindControl("FirstName"); 
            lastName = (TextBox)ClubRegistrationFormPanel.FindControl("LastName");
			telephoneNumber = (TextBox)ClubRegistrationFormPanel.FindControl("TelephoneNumber");
			email = (TextBox)ClubRegistrationFormPanel.FindControl("Email");
			teamsRegistrationPanel = (Panel)ClubRegistrationFormPanel.FindControl("TeamsRegistrationPanel");
			teamsListForClub = (DataList)ClubRegistrationFormPanel.FindControl("TeamsListForClub");
			ageBands = (DropDownList)ClubRegistrationFormPanel.FindControl("AgeBands");
			teamName = (TextBox)ClubRegistrationFormPanel.FindControl("TeamName");
			teamContactFirstName = (TextBox)ClubRegistrationFormPanel.FindControl("TeamContactFirstName");
			teamContactLastName = (TextBox)ClubRegistrationFormPanel.FindControl("TeamContactLastName");
			teamContactTelephoneNumber = (TextBox)ClubRegistrationFormPanel.FindControl("TeamContactTelephoneNumber");
			teamContactEmail = (TextBox)ClubRegistrationFormPanel.FindControl("TeamContactEmail");
		}

        protected void ManagePageVersion(RequestVersion pageVersion) {
			switch (pageVersion) {
				case RequestVersion.RegistrationConfirm:
					ConfirmationMessagePanel.Visible = true;
					break;
				case RequestVersion.ErrorMessage:
					ErrorMessageLoad();
					break;
				case RequestVersion.RegistrationInsertOrEdit:
					ClubEditFormLoad();
                    if (userApproved == true) {
                        CompetitionsListLoad();
                    }
					break;
			}
        }
        protected void ValidateUserSecurityCode() {
			if (club != null && userID == iClub.GenerateClubSecurityCode(club)) {
				userApproved = true;
            }
            else {
                userApproved = false;
                pageVersion = RequestVersion.ErrorMessage;
            }
        }

		protected void ErrorMessageLoad() {
			ErrorMessagePanel.Visible = true;
		}

        protected void ClubEditFormLoad() {
			ClubRegistrationFormPanel.Visible = true;
			clubIDHidden.Value = club.ID.ToString();
			clubName.Text = club.Name;
			if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString()) || userApproved == true) {
				securedPanel.Visible = true;
				teamsRegistrationPanel.Visible = true;
			}
            Array kitColourEnumValues = Enum.GetValues(typeof(Domains.KitColours));
			if (clubColourPrimary.Items.Count < 2) {
                foreach (Enum type in kitColourEnumValues) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        clubColourPrimary.Items.Add(new ListItem(EnumExtensions.GetStringValue(type), EnumExtensions.GetStringValue(type).ToString()));
                    }
                }
			}
            foreach (ListItem item in clubColourPrimary.Items) {
                item.Attributes.Add("style", "background-color:" + item.Value + "; color:" + item.Value);
			}  
   
			if (clubColourSecondary.Items.Count < 2) {
                foreach (Enum type in kitColourEnumValues) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        clubColourSecondary.Items.Add(new ListItem(EnumExtensions.GetStringValue(type), EnumExtensions.GetStringValue(type).ToString()));
                    }
                }
			}
            foreach (ListItem item in clubColourSecondary.Items) {
                item.Attributes.Add("style", "background-color:" + item.Value + "; color:" + item.Value);
            }  

            Array englishFAEnumValues = Enum.GetValues(typeof(Domains.EnglishCountyFAs));
			if (affiliation.Items.Count < 2) {
                foreach (Enum type in englishFAEnumValues) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        affiliation.Items.Add(new ListItem(EnumExtensions.GetStringValue(type), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
			}
            Array enumValues = Enum.GetValues(typeof(GoTournamental.BLL.Organiser.Contact.ContactTypes));
            if (contactType.Items.Count < 2) {
                foreach (Enum type in enumValues) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        contactType.Items.Add(new ListItem(EnumExtensions.GetStringValue(type), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
            if (ageBands.Items.Count < 2) {
				foreach (Competition comp in competitionsInTournament) {
					ageBands.Items.Add(new ListItem(EnumExtensions.GetStringValue(comp.AgeBand),EnumExtensions.GetIntValue(comp.AgeBand).ToString()));
				}
			}
			if (!IsPostBack && identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString()) && (Int32.Parse(clubIDHidden.Value) == tournament.HostClub.ID)) {
				clubColourPrimary.SelectedValue = tournament.HostClub.ColourPrimary;
				clubColourSecondary.SelectedValue = tournament.HostClub.ColourSecondary;
				affiliation.SelectedValue = tournament.HostClub.Affiliation.ToString();
				affiliationNumber.Text = tournament.HostClub.AffiliationNumber;
				contactType.SelectedValue = EnumExtensions.GetIntValue(GoTournamental.BLL.Organiser.Contact.ContactTypes.ClubContact).ToString();
				contactType.Enabled = false;
				if (tournament.HostClub.PrimaryContactID != null) {
					contact = iContact.SQLSelect<Contact, int>((int)tournament.HostClub.PrimaryContactID);
					if (contact != null) {
						contactIDHidden.Value = contact.ID.ToString();
						firstName.Text = contact.FirstName;
						lastName.Text = contact.LastName;
						telephoneNumber.Text = contact.TelephoneNumber;
						email.Text = contact.Email;
					}
				}
				else {
					contactIDHidden.Value = "0";
				}
			}
			else if (!IsPostBack && (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString()) || userApproved == true)) {
				clubColourPrimary.SelectedValue = club.ColourPrimary;
				clubColourSecondary.SelectedValue = club.ColourSecondary;
				affiliation.SelectedValue = club.Affiliation.ToString();
				affiliationNumber.Text = club.AffiliationNumber;
				contactType.SelectedValue = EnumExtensions.GetIntValue(GoTournamental.BLL.Organiser.Contact.ContactTypes.ClubContact).ToString();
				contactType.Enabled = false;
				if (club.PrimaryContactID != null) {
					contact = iContact.SQLSelect<Contact, int>((int)club.PrimaryContactID);
					if (contact != null) {
						contactIDHidden.Value = contact.ID.ToString();
						firstName.Text = contact.FirstName;
						lastName.Text = contact.LastName;
						telephoneNumber.Text = contact.TelephoneNumber;
						email.Text = contact.Email;
					}
				}
				else {
					contactIDHidden.Value = "0";
				}
			}

			//teamsListForClub.DataSource = club.Teams.OrderBy(i => i.GetCompetition().AgeBand).ThenBy(i => i.Name);
			//teamsListForClub.DataBind();

        }

        protected void CompetitionsListLoad() {
            CompetitionsListPanel.Visible = true;
            CompetitionsListGridView.DataSource = competitionsInTournament;
            CompetitionsListGridView.DataBind();
        }
        protected void CompetitionsListGridView_RowDataBound(Object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                Competition competition = (Competition)e.Row.DataItem;
                e.Row.Cells[0].Text = EnumExtensions.GetStringValue(competition.AgeBand);
				if (competition.StartTime != null && competition.CountFixturesForCompetition() > 0) {
					e.Row.Cells[1].Text = competition.StartTime.Value.ToString("ddd d MMM,") + "&nbsp;&nbsp;&nbsp;" + competition.StartTime.Value.ToShortTimeString() + " - " ;
				}				
				if (competition.StartTime != null) {
	                e.Row.Cells[1].Text = competition.StartTime.Value.ToString("ddd d MMM,") + "&nbsp;&nbsp;&nbsp;" + competition.StartTime.Value.ToShortTimeString();
				}
                e.Row.Cells[2].Text = EnumExtensions.GetStringValue(competition.Session);
            }
        }

        protected void SaveClubButton_Click(object sender, EventArgs e) {
			Contact contactToSave = null;
			if (firstName.Text != "" || lastName.Text != "" || telephoneNumber.Text != "" || email.Text != "") {
				contactToSave = new Contact(
					id: Int32.Parse(contactIDHidden.Value),
					tournamentID: tournament.ID,
					type: Contact.ContactTypes.ClubContact,
					title: null,
					firstName : firstName.Text,
					lastName : lastName.Text,
					telephoneNumber : telephoneNumber.Text,
					email : email.Text,
                    dateOfBirth : (Nullable<DateTime>)null,
                    squadNumber : null
				);
			}
			// tournament organiser and host club
			if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString()) && (Int32.Parse(clubIDHidden.Value) == tournament.HostClub.ID)) {			
				if (contactToSave != null && contactToSave.ID == 0) {
					contactID = iContact.SQLInsertAndReturnID<Contact>(contactToSave);
					iClub.SQLUpdatePrimaryContactID(club.ID,contactID);
				}
				else if (contactToSave != null) {
					iContact.SQLUpdate<Contact>(contactToSave);
				}	
				Club clubToSave = new Club(
					id: Int32.Parse(clubIDHidden.Value),
					tournamentID: tournament.ID,
					name: tournament.HostClub.Name,
					attendanceType: Domains.AttendanceTypes.HostClub,
					websiteURL : tournament.HostClub.WebsiteURL ,
					logoFile : tournament.HostClub.LogoFile ,
					twitter : tournament.HostClub.Twitter,
					colourPrimary : clubColourPrimary.SelectedValue,
					colourSecondary : clubColourSecondary.SelectedValue,
					affiliation : Int32.Parse(affiliation.SelectedValue) ,
					affiliationNumber : affiliationNumber.Text ,
					primaryContactID : tournament.HostClub.PrimaryContactID
				);
				iClub.SQLUpdate<Club>(clubToSave);
			}
			else if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString()) || userApproved == true) { 
				if (contactToSave != null && contactToSave.ID == 0) {
					contactID = iContact.SQLInsertAndReturnID<Contact>(contactToSave);
					//iClub.SQLUpdatePrimaryContactID(club.ID,contactID);
				}
				else if (contactToSave != null) {
					iContact.SQLUpdate<Contact>(contactToSave);
				}	
				Club clubToSave = new Club(
					id: Int32.Parse(clubIDHidden.Value),
					tournamentID: tournament.ID,
					name: clubName.Text,
					attendanceType: Domains.AttendanceTypes.Accepted,
					websiteURL : null ,
					logoFile : null ,
					twitter : null ,
					colourPrimary : clubColourPrimary.SelectedValue,
					colourSecondary : clubColourSecondary.SelectedValue,
					affiliation : Int32.Parse(affiliation.SelectedValue) ,
					affiliationNumber : affiliationNumber.Text ,
					primaryContactID :  contactToSave.ID != 0 ? contactToSave.ID : (Nullable<int>)null
				);
				iClub.SQLUpdate<Club>(clubToSave);
			}

        }

		protected void TeamsListForClub_ItemDataBound(Object sender, DataListItemEventArgs e) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                
				Team team = (Team)e.Item.DataItem;
				Club club = iClub.SQLSelect<Club, int>(team.ClubID);
                HyperLink linkToTeamEdit = (HyperLink)e.Item.FindControl("LinkToTeamEdit");

                linkToTeamEdit.Text = team.Name;
				if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
					linkToTeamEdit.NavigateUrl = "~/UI/Competitions/TeamForm.aspx?version="+tournament.ID.ToString()+"&TournamentID="+tournament.ID.ToString()+"&club_id="+club.ID.ToString()+"&team_id="+team.ID.ToString();
				}
				
				Label competitionName = (Label)e.Item.FindControl("CompetitionName");
				Label contactName = (Label)e.Item.FindControl("ContactName");
				Label contactTelephone = (Label)e.Item.FindControl("ContactTelephone");
				HyperLink contactEmail = (HyperLink)e.Item.FindControl("ContactEmail");
                Competition competition = new Competition();
				ICompetition iCompetition = new Competition();

				if (team.CompetitionID != null) {
					competition = iCompetition.SQLSelect<Competition, int>((int)team.CompetitionID);
					if (competition != null) {
						competitionName.Text = EnumExtensions.GetStringValue(competition.AgeBand);
					}
				}

				if (team.PrimaryContactID != null) {
					contactName.Text = team.PrimaryContact.FirstName + " " + team.PrimaryContact.LastName;
					contactTelephone.Text = team.PrimaryContact.TelephoneNumber;
                    if (team.PrimaryContact.Email != null && team.PrimaryContact.Email != "") {
	    				contactEmail.Text = team.PrimaryContact.Email;
                        contactEmail.NavigateUrl = "mailto:"+team.PrimaryContact.Email;
                    }
				}

            }
        }

        protected void SaveTeamButton_Click(object sender, EventArgs e) {

			SaveClubButton_Click(sender, e);

            if (teamName.Text != "" && Int32.Parse(ageBands.SelectedValue) > 0) {
			    Contact contactToSave = new Contact(
				    id: 0,
				    tournamentID: tournament.ID,
				    type: Contact.ContactTypes.TeamContact,
				    title: null,
				    firstName : teamContactFirstName.Text,
				    lastName : teamContactLastName.Text,
				    telephoneNumber : teamContactTelephoneNumber.Text,
				    email : teamContactEmail.Text,
                    dateOfBirth : (Nullable<DateTime>)null,
                    squadNumber : null
			    );
			    int contactID = iContact.SQLInsertAndReturnID<Contact>(contactToSave);
			    if (!iCompetition.SQLAgeBandExistsForTournament(tournament.ID, (Competition.AgeBands)Int32.Parse(ageBands.SelectedValue))) {
				    Competition competitionToSave = new Competition(
					    tournamentID : tournament.ID ,
					    ageBand : (Competition.AgeBands)Int32.Parse(ageBands.SelectedValue)
				    );
				    iCompetition.SQLInsert<Competition>(competitionToSave);
			    }
			    if (Int32.Parse(clubIDHidden.Value) == tournament.HostClub.ID) {
				    Team teamToSave = new Team(
					    id: 0,
					    clubID: Int32.Parse(clubIDHidden.Value),
					    competitionID: iCompetition.SQLCompetitionIDForAgeBand(tournament.ID, Int32.Parse(ageBands.SelectedValue)),
					    groupID: null,
					    name: teamName.Text,
					    attendanceType: Domains.AttendanceTypes.HostClub,
					    primaryContactID: contactID ,
                        registered : false
				    );
				    iTeam.SQLInsert<Team>(teamToSave);
			    }
			    else {
				    Team teamToSave = new Team(
					    id: 0,
					    clubID: Int32.Parse(clubIDHidden.Value),
					    competitionID: iCompetition.SQLCompetitionIDForAgeBand(tournament.ID, Int32.Parse(ageBands.SelectedValue)),
					    groupID: null,
					    name: teamName.Text,
					    attendanceType: Domains.AttendanceTypes.Accepted ,
					    primaryContactID: contactID ,
                        registered : false
				    );
				    iTeam.SQLInsert<Team>(teamToSave);
			    }
            }

			Response.Redirect("ClubRegistrationForm?TournamentID="+tournament.ID.ToString()+"&version=1&club_id="+clubIDHidden.Value+"&UserID="+userID);

        }

    }

}

