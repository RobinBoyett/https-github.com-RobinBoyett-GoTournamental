using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoTournamental.API;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser {

    public partial class ClubForm : Page {

        #region Declare Domain Objects & Page Variables
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
 		List<Competition> competitions = new List<Competition>();
		ICompetition iCompetition = new Competition();
		List<Club> clubs = new List<Club>();
		Club club = new Club();
		IClub iClub = new Club();
		List<GoTournamental.BLL.Organiser.Contact> contacts = new List<GoTournamental.BLL.Organiser.Contact>();
		GoTournamental.BLL.Organiser.IContact iContact = new GoTournamental.BLL.Organiser.Contact();

        private int clubID = 0;
        private RequestVersion pageVersion = RequestVersion.Undefined;
        protected enum RequestVersion {
            Undefined = 0,
            ClubInsert = 1,
            ClubEdit = 2
        }
        #endregion

        #region Declare page controls
        Label clubFormTitle = new Label();
		Label formTitle = new Label();
		HiddenField clubIDHidden = new HiddenField();
		TextBox clubName = new TextBox();
		DropDownList attendanceType = new DropDownList();
		DropDownList clubColourPrimary = new DropDownList();
		DropDownList clubColourSecondary = new DropDownList();
		HiddenField primaryContactID = new HiddenField();
        Button addContactButton = new Button();
		Label primaryContact = new Label();
        Button editContactButton = new Button();
        Label primaryContactPhone = new Label();
		Label primaryContactEmail = new Label();
		#endregion

        protected void Page_Load(object sender, EventArgs e) {

            AssignControlsAll();
            if (Request.QueryString.Get("TournamentID") != null) {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
				clubFormTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
				competitions = iCompetition.SQLSelectForTournament(tournament.ID, false);
				clubs = iClub.SQLSelectClubsForTournament(tournament.ID);
				contacts = iContact.SQLSelectForTournament(tournament.ID);
            }
            if (Request.QueryString.Get("version") != null) {
                pageVersion = (RequestVersion)Int32.Parse(Request.QueryString.Get("version"));
            }
            if (Request.QueryString.Get("club_id") != null) {
				club = iClub.SQLSelect<Club, int>(Int32.Parse(Request.QueryString.Get("club_id"))); 
            }
			
            ManagePageVersion(pageVersion);

        }
		protected void AssignControlsAll() {
			clubFormTitle = (Label)ClubFormPanel.FindControl("ClubFormTitle");
			formTitle = (Label)ClubFormPanel.FindControl("FormTitle");
			clubIDHidden = (HiddenField)ClubFormPanel.FindControl("ClubIDHidden");
			clubName = (TextBox)ClubFormPanel.FindControl("ClubName");
			attendanceType = (DropDownList)ClubFormPanel.FindControl("AttendanceType");
			clubColourPrimary = (DropDownList)ClubFormPanel.FindControl("ClubColourPrimary");
			clubColourSecondary = (DropDownList)ClubFormPanel.FindControl("ClubColourSecondary");
			primaryContactID = (HiddenField)ClubFormPanel.FindControl("PrimaryContactID");
            addContactButton = (Button)ClubFormPanel.FindControl("AddContactButton");
			primaryContact = (Label)ClubFormPanel.FindControl("PrimaryContact");
            editContactButton = (Button)ClubFormPanel.FindControl("EditContactButton");
            primaryContactPhone = (Label)ClubFormPanel.FindControl("PrimaryContactPhone");
			primaryContactEmail = (Label)ClubFormPanel.FindControl("PrimaryContactEmail");
		}
        protected void ManagePageVersion(RequestVersion pageVersion) {
			switch (pageVersion) {
				case RequestVersion.ClubEdit:
                    ClubEditFormLoad();
					formTitle.Text = "Edit Club";
                    break;
				case RequestVersion.ClubInsert:
                    ClubEditFormLoad();
					formTitle.Text = "Add Club";
                    break;
            }
        }

        protected void ClubEditFormLoad() {
            Array attendanceTypeEnumValues = Enum.GetValues(typeof(Domains.AttendanceTypes));
            if (attendanceType.Items.Count < 2) {
                foreach (Enum type in attendanceTypeEnumValues) {
                    if (EnumExtensions.GetIntValue(type) > 0 &&  EnumExtensions.GetStringValue(type) != "Deleted") {
                        attendanceType.Items.Add(new ListItem(EnumExtensions.GetStringValue(type), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
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

    		if (club.PrimaryContactID == null || club.PrimaryContactID == 0) {
                addContactButton.Visible = true;
			}
			else if (club.PrimaryContactID > 0) {
				primaryContact.Visible = true;
				primaryContact.Text = club.PrimaryContact.ToString();
                editContactButton.Visible = true;
                //linkToContactEdit.NavigateUrl = "~/UI/Contacts/ContactForm.aspx?version=2&TournamentID="+tournament.ID.ToString()+"&club_id="+club.ID.ToString()+"&contact_id="+club.PrimaryContactID.ToString();
			}
	
			if (!IsPostBack) {
				clubIDHidden.Value = club.ID.ToString();
				clubName.Text = club.Name;
				attendanceType.SelectedValue = EnumExtensions.GetIntValue(club.AttendanceType).ToString();
                if (club.AttendanceType == Domains.AttendanceTypes.HostClub) {
                    attendanceType.Enabled = false;
                }
				clubColourPrimary.SelectedValue = club.ColourPrimary;
				clubColourSecondary.SelectedValue = club.ColourSecondary;
				primaryContactID.Value = club.PrimaryContactID == null ? "0" : club.PrimaryContactID.ToString();
				if (club.PrimaryContact.TelephoneNumber != null && club.PrimaryContact.TelephoneNumber!= "") {
					primaryContactPhone.Text = club.PrimaryContact.TelephoneNumber;
					primaryContactPhone.Visible = true;
				}
				if (club.PrimaryContact.Email != null && club.PrimaryContact.Email!= "") {
					primaryContactEmail.Text = club.PrimaryContact.Email;
					primaryContactEmail.Visible = true;
				}
			}		
        }

        protected void SaveClubData() {
            Club clubToSave = new Club(
                id: Int32.Parse(clubIDHidden.Value),
                tournamentID: tournament.ID,
                name: clubName.Text,
                attendanceType: (Domains.AttendanceTypes)Int32.Parse(attendanceType.SelectedValue),
                websiteURL: null,
                logoFile: null,
                twitter: null,
                colourPrimary: clubColourPrimary.SelectedValue,
                colourSecondary: clubColourSecondary.SelectedValue,
                affiliation: null,
                affiliationNumber: null,
                primaryContactID: primaryContactID.Value == "0" ? (int?)null : Int32.Parse(primaryContactID.Value)
            );
            bool alreadyExists = false;
            alreadyExists = (clubToSave.ID != 0 || iClub.SQLClubExistsForTournament(tournament.ID, clubName.Text));
            if (alreadyExists) {
                iClub.SQLUpdate<Club>(clubToSave);
                Response.Write("<script language=javascript>alert('There is already a Club with this name in the Tournament.');</script>");
            }
            else {
                clubID = iClub.SQLInsertAndReturnID<Club>(clubToSave);
            }

        }


        protected void AddContactButton_Click(object sender, EventArgs e) {
            SaveClubData();
            Response.Redirect("~/UI/Contacts/ContactForm.aspx?version=1&TournamentID="+tournament.ID.ToString()+"&club_id="+clubID.ToString());
        }
        protected void EditContactButton_Click(object sender, EventArgs e) {
            SaveClubData();
            Response.Redirect("~/UI/Contacts/ContactForm.aspx?version=2&TournamentID="+tournament.ID.ToString()+"&club_id="+club.ID.ToString()+"&contact_id="+club.PrimaryContactID.ToString());
        }
        protected void SaveButton_Click(object sender, EventArgs e) {
            SaveClubData();
			Response.Redirect("~/UI/Clubs/ClubsList.aspx?version=1&TournamentID="+tournament.ID.ToString());
        }

    }

}

