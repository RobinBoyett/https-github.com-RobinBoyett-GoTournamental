using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser {

    public partial class ClubsInvitedForm : Page {

        #region Declare Domain Objects & Page Variables
 		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
		Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
		IClub iClub = new Club();
		List<Club> clubsList = new List<Club>();
		IContact iContact = new Contact();
        Contact contact = new Contact();
		int contactID = 0;
        #endregion

        #region Declare page controls
        Label clubsInvitedFormTitle = new Label();
        Label hostClubName = new Label();
        Label hostClubContactName = new Label();
        Label hostClubContactTelephone= new Label();
        Label hostClubContactEmail = new Label();
        HyperLink importClubsLink = new HyperLink();
		DataList clubsInvitedList = new DataList();
		TextBox clubName = new TextBox();
		TextBox clubContactFirstName = new TextBox();
		TextBox clubContactLastName = new TextBox();
		TextBox clubContactTelephoneNumber = new TextBox();
		TextBox clubContactEmail = new TextBox();
        GridView clubsInvitedGridView = new GridView();
		#endregion

        protected void Page_Load(object sender, EventArgs e) {

            AssignControlsAll();

            if (Request.QueryString.Get("TournamentID") != null) {
	            tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
                hostClubName.Text = tournament.HostClub.Name;
                hostClubContactName.Text = tournament.HostClub.PrimaryContact.FirstName + " " + tournament.HostClub.PrimaryContact.LastName;
                hostClubContactTelephone.Text = tournament.HostClub.PrimaryContact.TelephoneNumber;
                hostClubContactEmail.Text = tournament.HostClub.PrimaryContact.Email;
                importClubsLink.NavigateUrl = "~/UI/IO/ImportData.aspx?Version=1&TournamentID="+tournament.ID.ToString();
				clubsInvitedFormTitle.Text = tournament.HostClub.Name + " " + tournament.Name;

                if (!IsPostBack) {
                    BindClubs();
                }

			}

        }

		protected void AssignControlsAll() {
			clubsInvitedFormTitle = (Label)ClubsInvitedFormPanel.FindControl("ClubsInvitedFormTitle");
            hostClubName = (Label)ClubsInvitedFormPanel.FindControl("HostClubName");
            hostClubContactName = (Label)ClubsInvitedFormPanel.FindControl("HostClubContactName");
            hostClubContactTelephone = (Label)ClubsInvitedFormPanel.FindControl("HostClubContactTelephone");
            hostClubContactEmail = (Label)ClubsInvitedFormPanel.FindControl("HostClubContactEmail");
            importClubsLink = (HyperLink)ClubsInvitedFormPanel.FindControl("ImportClubsLink");
			clubsInvitedList = (DataList)ClubsInvitedFormPanel.FindControl("ClubsInvitedList");
			clubName = (TextBox)ClubsInvitedFormPanel.FindControl("ClubName");
			clubContactFirstName = (TextBox)ClubsInvitedFormPanel.FindControl("ClubContactFirstName");
			clubContactLastName = (TextBox)ClubsInvitedFormPanel.FindControl("ClubContactLastName");
			clubContactTelephoneNumber = (TextBox)ClubsInvitedFormPanel.FindControl("ClubContactTelephoneNumber");
			clubContactEmail = (TextBox)ClubsInvitedFormPanel.FindControl("ClubContactEmail");
            clubsInvitedGridView = (GridView)ClubsInvitedFormPanel.FindControl("ClubsInvitedGridView");
		}

        protected void BindClubs() {
            clubsList =iClub.SQLSelectClubsForTournament(tournament.ID).Where(i => i.AttendanceType != Domains.AttendanceTypes.HostClub).ToList();
            clubsInvitedGridView.DataSource = clubsList;
            clubsInvitedGridView.DataBind();
        }

        protected void ClubsInvitedGridView_RowDataBound(Object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                Club club = (Club)e.Row.DataItem;
                HyperLink linkToClubEdit = (HyperLink)e.Row.FindControl("LinkToClubEdit");
                HyperLink contactEmail = (HyperLink)e.Row.FindControl("ContactEmail");
				HyperLink inviteEmail = (HyperLink)e.Row.FindControl("InviteEmail");

                if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
                    linkToClubEdit.Text = club.Name;
					linkToClubEdit.NavigateUrl = "~/UI/Clubs/ClubForm.aspx?version=2&TournamentID="+tournament.ID.ToString()+"&club_id="+club.ID.ToString();

                    string mailTo = "?subject=Invitation%20to%20"+tournament.HostClub.Name + "%20" + tournament.Name + "&body=[INSERT%20YOUR%20TEXT%20]";
                    mailTo += "%0D%0DThis%20year%20we%20are%20using%20GoTournamental%20to%20organise%20our%20tournament.";
                    mailTo += "%0D%0DThis%20means%20that%20you%20can%20register%20your%20teams%20and%20players%20online%20%20as%20well%20as%20follow%20your%20itinerary%20on%20the%20day%20on%20your%20phone%20or%20tablet.";
                    mailTo += "%0D%0DPlease%20copy%20and%20paste%20the%20link%20below%20into%20your%20browser%20address%20bar%20to%20get%20further%20details%20and%20to%20register%20teams%20for%20" + club.Name.Replace("&","%26") + ".";
                    mailTo += "%0D%0Dhttp://www.gotournamental.com/UI/Clubs/ClubRegistrationForm?TournamentID="+tournament.ID.ToString()+"%26version=1%26club_id="+club.ID.ToString()+"%26UserID="+ iClub.GenerateClubSecurityCode(club);
                    mailTo += "%0D%0DPlease%20refer%20to%20the%20Help%20page%20at%20http://www.gotournamental.com/%20to%20find%20%22how%20to%22%20videos%20in%20case%20you%20need%20help%20registering%20your%20teams";

                    if (club.PrimaryContact.Email != null && club.PrimaryContact.Email != "") {
                        inviteEmail.NavigateUrl = "mailto:"+club.PrimaryContact.Email + mailTo;
                    }
                    else {
                        inviteEmail.Visible = false;
                        inviteEmail.NavigateUrl = "mailto:[INSERT EMAIL TO]" + mailTo;
                    }

                }
                e.Row.Cells[1].Text = iClub.GenerateClubSecurityCode(club);

				if (club.PrimaryContact != null) {
					e.Row.Cells[2].Text = club.PrimaryContact.FirstName + " " + club.PrimaryContact.LastName;
					e.Row.Cells[3].Text = club.PrimaryContact.TelephoneNumber;
					if (club.PrimaryContact.Email != null && club.PrimaryContact.Email != "") {
	    				contactEmail.Text = club.PrimaryContact.Email;
						contactEmail.NavigateUrl = "mailto:"+club.PrimaryContact.Email;
					}
				}

                if (clubsInvitedGridView.EditIndex == -1) { // gridview NOT in edit mode
                    Label attendanceLabel = (Label)e.Row.FindControl("AttendanceLabel");
                    attendanceLabel.Text = EnumExtensions.GetStringValue(club.AttendanceType);
                }
                if ((e.Row.RowState & DataControlRowState.Edit) > 0) {
                    HiddenField clubIDHidden = (HiddenField)e.Row.FindControl("ClubIDHidden");
                    DropDownList attendanceTypesList = (DropDownList)e.Row.FindControl("AttendanceTypesList");
                    clubIDHidden.Value = club.ID.ToString();

                    Array enumValues = Enum.GetValues(typeof(Domains.AttendanceTypes));
                    foreach (Enum type in enumValues) {
                        if (EnumExtensions.GetIntValue(type) > 0 && EnumExtensions.GetStringValue(type) != "Deleted") {
                            attendanceTypesList.Items.Add(new ListItem(EnumExtensions.GetStringValue(type), EnumExtensions.GetIntValue(type).ToString()));
                        }
                    }
                    attendanceTypesList.SelectedValue = EnumExtensions.GetIntValue(club.AttendanceType).ToString();
                }


            }
        }
        protected void ClubsInvitedGridView_RowEditing(object sender, GridViewEditEventArgs e) {
            clubsInvitedGridView.EditIndex = e.NewEditIndex;
            BindClubs();
        }
        protected void ClubsInvitedGridView_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            HiddenField clubIDHidden = (HiddenField)clubsInvitedGridView.Rows[e.RowIndex].FindControl("ClubIDHidden");
            DropDownList attendanceTypesList = (DropDownList)clubsInvitedGridView.Rows[e.RowIndex].FindControl("AttendanceTypesList");
            iClub.SQLUpdateAttendanceType(Int32.Parse(clubIDHidden.Value), (Domains.AttendanceTypes)Int32.Parse(attendanceTypesList.SelectedValue));
            clubsInvitedGridView.EditIndex = -1;
            BindClubs();
        }
        protected void ClubsInvitedGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            clubsInvitedGridView.EditIndex = -1;
            BindClubs();
        }
	
        protected void SaveButton_Click(object sender, EventArgs e) {

			if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
				if (clubContactFirstName.Text != "" || clubContactLastName.Text != "" || clubContactTelephoneNumber.Text != "" || clubContactEmail.Text != "") {
					Contact contactToSave = new Contact(
						id: 0,
						tournamentID: tournament.ID,
						type: Contact.ContactTypes.ClubContact,
						title: null,
						firstName : clubContactFirstName.Text,
						lastName : clubContactLastName.Text,
						telephoneNumber : clubContactTelephoneNumber.Text,
						email : clubContactEmail.Text,
                        dateOfBirth : (Nullable<DateTime>)null,
                        squadNumber : null
					);
					contactID = iContact.SQLInsertAndReturnID<Contact>(contactToSave);
				}
				Club clubToSave = new Club(
					id: 0,
					tournamentID: tournament.ID,
					name: clubName.Text,
					attendanceType: Domains.AttendanceTypes.Pending,
					websiteURL : null ,
					logoFile : null ,
					twitter : null ,
					colourPrimary : null ,
					colourSecondary : null ,
					affiliation : null ,
					affiliationNumber : null ,
					primaryContactID : contactID != 0 ? contactID : (Nullable<int>)null
				);
				iClub.SQLInsert<Club>(clubToSave);
			}
			Response.Redirect("ClubsInvitedForm?TournamentID="+tournament.ID.ToString());
		
        }

    }

}

