using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using GoTournamental.BLL.Planner;

namespace GoTournamental.UI.Organiser 
{

    public partial class TeamForm : Page 
    {

        #region Declare Domain Objects & Page Variables
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
 		List<Competition> competitions = new List<Competition>();
		Competition competition = new Competition();
		ICompetition iCompetition = new Competition();
		List<Club> clubs = new List<Club>();
		Club club = new Club();
		IClub iClub = new Club();
		Team team = new Team();
		ITeam iTeam = new Team();
		List<GoTournamental.BLL.Organiser.Contact> contacts = new List<GoTournamental.BLL.Organiser.Contact>();
		GoTournamental.BLL.Organiser.IContact iContact = new GoTournamental.BLL.Organiser.Contact();

		Team teamToSave = new Team();

        private RequestVersion pageVersion = RequestVersion.Undefined;
        protected enum RequestVersion 
        {
            Undefined = 0,
            TeamInsert = 1,
            TeamEdit = 2
        }
        #endregion

        #region Declare page controls
        Label teamFormTitle = new Label();
		Label formTitle = new Label();
		Label clubName = new Label();
		TextBox teamName = new TextBox();
        DropDownList attendanceType = new DropDownList();
		DropDownList ageBands = new DropDownList();
		HiddenField clubIDHidden = new HiddenField();
		HiddenField teamIDHidden = new HiddenField();
		HiddenField primaryContactID = new HiddenField();
		LinkButton linkToContactAdd = new LinkButton();
		Label primaryContact = new Label();
		HyperLink linkToContactEdit = new HyperLink();
		Label primaryContactPhone = new Label();
		Label primaryContactEmail = new Label();
        CheckBox registered = new CheckBox();
		#endregion

        protected void Page_Load(object sender, EventArgs e) 
        {

            AssignControlsAll();
            if (Request.QueryString.Get("TournamentID") != null) 
            {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
				teamFormTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
				competitions = iCompetition.SQLSelectForTournament(tournament.ID, false);
            }
            if (Request.QueryString.Get("version") != null)
            {
                pageVersion = (RequestVersion)Int32.Parse(Request.QueryString.Get("version"));
            }
            if (Request.QueryString.Get("club_id") != null)
            {
				club = iClub.SQLSelect<Club, int>(Int32.Parse(Request.QueryString.Get("club_id"))); 
            }
            if (Request.QueryString.Get("team_id") != null)
            {
				team = iTeam.SQLSelect<Team, int>(Int32.Parse(Request.QueryString.Get("team_id"))); 
            }
            if( !IsPostBack )
            {
                ViewState["ReferrerURL"] = Request.UrlReferrer.ToString();
            }

			
            ManagePageVersion(pageVersion);

        }
		protected void AssignControlsAll()
        {
			teamFormTitle = (Label)TeamFormPanel.FindControl("TeamFormTitle");
			formTitle = (Label)TeamFormPanel.FindControl("FormTitle");
			clubName = (Label)TeamFormPanel.FindControl("ClubName");
			teamName = (TextBox)TeamFormPanel.FindControl("TeamName");
            attendanceType = (DropDownList)TeamFormPanel.FindControl("AttendanceType");
			ageBands = (DropDownList)TeamFormPanel.FindControl("AgeBands");
			clubIDHidden = (HiddenField)TeamFormPanel.FindControl("ClubIDHidden");
			teamIDHidden = (HiddenField)TeamFormPanel.FindControl("TeamIDHidden");
			primaryContactID = (HiddenField)TeamFormPanel.FindControl("PrimaryContactID");
			linkToContactAdd = (LinkButton)TeamFormPanel.FindControl("LinkToContactAdd");
			primaryContact = (Label)TeamFormPanel.FindControl("PrimaryContact");
			linkToContactEdit = (HyperLink)TeamFormPanel.FindControl("LinkToContactEdit");
			primaryContactPhone = (Label)TeamFormPanel.FindControl("PrimaryContactPhone");
			primaryContactEmail = (Label)TeamFormPanel.FindControl("PrimaryContactEmail");
            registered = (CheckBox)TeamFormPanel.FindControl("Registered");
		}
        protected void ManagePageVersion(RequestVersion pageVersion)
        {
			switch (pageVersion)
            {
				case RequestVersion.TeamEdit:
                    TeamEditFormLoad();
					formTitle.Text = "Edit Team";
                    break;
				case RequestVersion.TeamInsert:
                    TeamEditFormLoad();
					formTitle.Text = "Add Team";
                    break;
            }
        }

        protected void TeamEditFormLoad() 
        {

			clubName.Text = club.Name;
			Array enumValues = Enum.GetValues(typeof(Competition.AgeBands));

            enumValues = Enum.GetValues(typeof(Domains.AttendanceTypes));
            if (attendanceType.Items.Count < 2)
            {
                foreach (Enum type in enumValues)
                {
                    if (EnumExtensions.GetIntValue(type) > 0) 
                    {
                        attendanceType.Items.Add(new ListItem(EnumExtensions.GetStringValue(type), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }

			if (ageBands.Items.Count < 2)
            {
				foreach (Competition comp in competitions) 
                {
					ageBands.Items.Add(new ListItem(EnumExtensions.GetStringValue(comp.AgeBand).ToString(), comp.ID.ToString()));				
				}
			}

			if (team.PrimaryContactID == null || team.PrimaryContactID == 0)
            {
				linkToContactAdd.Visible = true;
				//linkToContactAdd.NavigateUrl = "~/UI/Planner/ContactForm.aspx?version=1&TournamentID="+tournament.ID.ToString()+"&club_id="+club.ID.ToString()+"&team_id="+team.ID.ToString();
				//linkToContactAdd.PostBackUrl = "~/UI/Planner/ContactForm.aspx?version=1&TournamentID="+tournament.ID.ToString()+"&club_id="+club.ID.ToString()+"&team_id="+team.ID.ToString();
			}
			else if (team.PrimaryContactID > 0) 
            {
				primaryContact.Visible = true;
				primaryContact.Text = team.PrimaryContact.ToString();
				linkToContactEdit.Visible = true;
				linkToContactEdit.NavigateUrl = "~/UI/Planner/ContactForm.aspx?version=2&TournamentID="+tournament.ID.ToString()+"&club_id="+club.ID.ToString()+"&contact_id="+team.PrimaryContactID.ToString()+"&team_id="+team.ID.ToString();
			}
	
			if (!IsPostBack)
            {
				clubIDHidden.Value = club.ID.ToString();
				teamIDHidden.Value = team.ID.ToString();
				clubName.Text = club.Name;
				teamName.Text = team.Name;
				attendanceType.SelectedValue = EnumExtensions.GetIntValue(team.AttendanceType).ToString();
				ageBands.SelectedValue = team.CompetitionID.ToString();
				primaryContactID.Value = team.PrimaryContactID == null ? "0" : team.PrimaryContactID.ToString();
				if (team.PrimaryContact.TelephoneNumber != null && team.PrimaryContact.TelephoneNumber!= "")
                {
					primaryContactPhone.Text = team.PrimaryContact.TelephoneNumber;
					primaryContactPhone.Visible = true;
				}
				if (team.PrimaryContact.Email != null && team.PrimaryContact.Email!= "")
                {
					primaryContactEmail.Text = team.PrimaryContact.Email;
					primaryContactEmail.Visible = true;
				}
                registered.Checked = team.Registered == true ? true : false;
			}
            if (club.AttendanceType == Domains.AttendanceTypes.HostClub) 
            {
                attendanceType.SelectedValue = EnumExtensions.GetIntValue(Domains.AttendanceTypes.HostClub).ToString();
                //attendanceType.Enabled = false;
            }
		
        }

		protected int TeamSave()
        {
		    int savedTeamID = 0;
 		    if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString()))
            {

			    teamToSave = new Team(
				    id : Int32.Parse(teamIDHidden.Value), 
				    clubID : Int32.Parse(clubIDHidden.Value), 
				    competitionID : Int32.Parse(ageBands.SelectedValue), 
				    groupID : null, 
				    name : TeamName.Text , 
                    attendanceType : (Domains.AttendanceTypes)Int32.Parse(attendanceType.SelectedValue) ,
				    primaryContactID : primaryContactID.Value == "0" ? (int?)null : Int32.Parse(primaryContactID.Value),
                    registered : registered.Checked == true ? true : false
			    );

			    if (teamToSave.Name == null || teamToSave.Name == "")
                {
				    if (teamToSave.CompetitionID != null)
                    {
					    competition = iCompetition.SQLSelect<Competition, int>((int)teamToSave.CompetitionID);
					    teamToSave.Name = "'" + EnumExtensions.GetStringValue(competition.AgeBand) + "'";
				    }
				    else 
                    {
					    teamToSave.Name = "[Undefined]";
				    }
			    }
			    if (teamToSave.ID == 0)
                {
				    savedTeamID = iTeam.SQLInsertAndReturnID<Team>(teamToSave);
			    }
			    else
                {
				    iTeam.SQLUpdate<Team>(teamToSave);
				    savedTeamID = Int32.Parse(teamIDHidden.Value);
			    }

            }
		    return savedTeamID;
		}

        protected void LinkToContactAdd_Click(object sender, EventArgs e) 
        {
			int savedTeamID = 0;
			savedTeamID = TeamSave();
			Response.Redirect("~/UI/Planner/ContactForm.aspx?version=1&TournamentID="+tournament.ID.ToString()+"&club_id="+club.ID.ToString()+"&team_id="+savedTeamID.ToString());
        }
		
        protected void SaveButton_Click(object sender, EventArgs e)
        {
			int placeholder = 0;
			placeholder = TeamSave();

            if (ViewState["ReferrerURL"].ToString().Contains("TeamAttendanceForm"))
            {
				Response.Redirect(ViewState["ReferrerURL"].ToString());
            }
			else if (team.AttendanceType != teamToSave.AttendanceType)
            {
                //iCompetition.DeleteGroupsForCompetitionWithCascadeToFixtures((int)teamToSave.CompetitionID);
                //Response.Redirect("~/UI/Competitions/GroupAllocationForm?version=4&TournamentID="+tournament.ID.ToString()+"&competition_id="+teamToSave.CompetitionID.ToString());
			}
			else
            {
				Response.Redirect("~/UI/Planner/ClubsList.aspx?version=1&TournamentID="+tournament.ID.ToString());
			}
	
        }

    }

}

