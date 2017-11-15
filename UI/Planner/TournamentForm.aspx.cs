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

namespace GoTournamental.UI.Planner {

    public partial class TournamentForm : Page {

        #region Declare Domain Objects & Page Variables
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
		List<Club> clubs = new List<Club>();
		IClub iClub = new Club();
		IPlayingArea iPlayingArea = new PlayingArea();
		PlayingArea playingArea = new PlayingArea();

		int tournamentID = 0;
		private string hourText = "";
		private string minuteText = "";
		private DateTime? startTime = new DateTime();
		private string startTimeText = "";
		int noPlayingAreasInTournament = 0;
        int maxTeamSize = 0;
        int maxSquadSize = 0;
        bool fixtureOverRun = false;

        private RequestVersion pageVersion = RequestVersion.Undefined;
        protected enum RequestVersion {
            Undefined = 0,
            TournamentInsert = 1,
            TournamentEdit = 2,
			FeatureNotAvailable = 3
        }
        #endregion

        #region Declare page controls
		Label featureUnavailableLabel = new Label();
		Label tournamentFormTitle = new Label();
        HiddenField hostClubIDHidden = new HiddenField();
		Label formTitle = new Label();
		DropDownList tournamentType = new DropDownList();
        TextBox hostClubName = new TextBox();
        TextBox tournamentName = new TextBox();
        TextBox tournamentStartDate = new TextBox();
 		DropDownList tournamentStartHour = new DropDownList();
		DropDownList tournamentStartMinute = new DropDownList();
		TextBox tournamentEndDate = new TextBox();
        TextBox tournamentVenue = new TextBox();
        TextBox tournamentPostcode = new TextBox();
        TextBox tournamentGoogleMapsURL = new TextBox();
        DropDownList tournamentNoPlayingAreas = new DropDownList();
		DropDownList fixtureTurnaround = new DropDownList();
		DropDownList fixtureHalvesNumber = new DropDownList();
		DropDownList fixtureHalvesLength = new DropDownList();
		DropDownList teamSize = new DropDownList();
 		DropDownList squadSize = new DropDownList();
	 	DropDownList rotatorDate = new DropDownList();
		DropDownList rotatorSession = new DropDownList();
		#endregion

        protected void Page_Load(object sender, EventArgs e) {

            AssignControlsAll();

			if (Request.QueryString.Get("version") != null) {
                pageVersion = (RequestVersion)Int32.Parse(Request.QueryString.Get("version"));
            }

                        
            string rawID = Request.QueryString.Get("TournamentID");
            if (!String.IsNullOrEmpty(rawID) && Int32.TryParse(rawID, out tournamentID)) {
 	            tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(rawID));
				tournamentID = tournament.ID;
				tournamentFormTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
				clubs = iClub.SQLSelectClubsForTournament(tournament.ID);
            }
            if (tournamentID != 1) {
    			ManageRoleSecurity();
            }

            Array tournamentTypes = Enum.GetValues(typeof(Tournament.TournamentTypes));
            if (tournamentType.Items.Count < 2) {
                foreach (Enum type in tournamentTypes) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        tournamentType.Items.Add(new ListItem(EnumExtensions.GetStringValue(type), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }          
            Array playingAreaEnum = Enum.GetValues(typeof(Tournament.NumberOfPlayingAreas));
            if (tournamentNoPlayingAreas.Items.Count < 2) {
                foreach (Enum type in playingAreaEnum) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        tournamentNoPlayingAreas.Items.Add(new ListItem(EnumExtensions.GetIntValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
			Array fixtureTurnaroundEnum = Enum.GetValues(typeof(Tournament.FixtureTurnarounds));
            if (fixtureTurnaround.Items.Count < 2) {
                foreach (Enum type in fixtureTurnaroundEnum) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        fixtureTurnaround.Items.Add(new ListItem(EnumExtensions.GetIntValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
			Array fixtureHalvesNumberEnum = Enum.GetValues(typeof(Tournament.FixtureHalvesNumbers));
            if (fixtureHalvesNumber.Items.Count < 2) {
                foreach (Enum type in fixtureHalvesNumberEnum) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        fixtureHalvesNumber.Items.Add(new ListItem(EnumExtensions.GetIntValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
			Array fixtureHalvesLengthEnum = Enum.GetValues(typeof(Tournament.FixtureHalvesLengths));
            if (fixtureHalvesLength.Items.Count < 2) {
                foreach (Enum type in fixtureHalvesLengthEnum) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        fixtureHalvesLength.Items.Add(new ListItem(EnumExtensions.GetIntValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }


			if (tournament.StartTime.HasValue && tournament.StartTime != null) {
				rotatorDate.Items.Add(new ListItem(tournament.StartTime.Value.ToShortDateString(), tournament.StartTime.Value.ToShortDateString()));
			}
			if (tournament.EndTime.HasValue) {
				DateTime loopEnd = (DateTime)tournament.StartTime;
				do {
					loopEnd = loopEnd.AddDays(1);
					rotatorDate.Items.Add(new ListItem(loopEnd.ToShortDateString(), loopEnd.ToShortDateString()));
				}
				while (loopEnd <= tournament.EndTime);
			}
			else if (tournament.StartTime.HasValue && tournament.StartTime != null) {
				rotatorDate.SelectedValue = tournament.StartTime.Value.ToShortDateString();
			}
			Array sessionEnum = Enum.GetValues(typeof(Competition.Sessions));
            if (rotatorSession.Items.Count < 2) {
                foreach (Enum type in sessionEnum) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        rotatorSession.Items.Add(new ListItem(EnumExtensions.GetStringValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }

            ManagePageVersion(pageVersion);

        }
		protected void AssignControlsAll() {
			featureUnavailableLabel = (Label)FeatureUnavailablePanel.FindControl("FeatureUnavailableLabel");
			tournamentFormTitle = (Label)TournamentFormPanel.FindControl("TournamentFormTitle");
			formTitle = (Label)TournamentFormPanel.FindControl("FormTitle");
			hostClubIDHidden = (HiddenField)TournamentFormPanel.FindControl("HostClubIDHidden");
			tournamentType = (DropDownList)TournamentFormPanel.FindControl("TournamentType");
            hostClubName = (TextBox)TournamentFormPanel.FindControl("HostClubName");
            tournamentName = (TextBox)TournamentFormPanel.FindControl("TournamentName");
            tournamentStartDate = (TextBox)TournamentFormPanel.FindControl("TournamentStartDate");
			tournamentStartHour = (DropDownList)TournamentFormPanel.FindControl("TournamentStartHour");
			tournamentStartMinute = (DropDownList)TournamentFormPanel.FindControl("TournamentStartMinute");
            tournamentEndDate = (TextBox)TournamentFormPanel.FindControl("TournamentEndDate");
            tournamentVenue = (TextBox)TournamentFormPanel.FindControl("TournamentVenue");
            tournamentPostcode = (TextBox)TournamentFormPanel.FindControl("TournamentPostcode");
            tournamentGoogleMapsURL = (TextBox)TournamentFormPanel.FindControl("TournamentGoogleMapsURL");
            tournamentNoPlayingAreas = (DropDownList)TournamentFormPanel.FindControl("TournamentNoPlayingAreas"); 
			fixtureTurnaround = (DropDownList)TournamentFormPanel.FindControl("FixtureTurnaround"); 
			fixtureHalvesNumber = (DropDownList)TournamentFormPanel.FindControl("FixtureHalvesNumber"); 
			fixtureHalvesLength = (DropDownList)TournamentFormPanel.FindControl("FixtureHalvesLength"); 
 			teamSize = (DropDownList)TournamentFormPanel.FindControl("TeamSize"); 
			squadSize = (DropDownList)TournamentFormPanel.FindControl("SquadSize");
			rotatorDate = (DropDownList)TournamentFormPanel.FindControl("RotatorDate");
			rotatorSession = (DropDownList)TournamentFormPanel.FindControl("RotatorSession");
       }
		
        protected void ManageRoleSecurity() {
			if (!identityHelper.RoleExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentOwner")) {
				pageVersion = RequestVersion.FeatureNotAvailable;
				featureUnavailableLabel.Text = "This feature is unavailable unless you are registered as a Tournament Owner.<br>In order to complete your registration, please read our Terms and Conditions";
			}
		}

		protected void ManageClaimSecurity() {
			if (!identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournamentID.ToString())) {
				pageVersion = RequestVersion.FeatureNotAvailable;
				featureUnavailableLabel.Text = "This page is unavailable as you are the registered Owner for this Tournament";
			}
		}
		
		protected void ManagePageVersion(RequestVersion pageVersion) {
			switch (pageVersion) {
				case RequestVersion.FeatureNotAvailable:
					FeatureUnavailablePanel.Visible = true;
					break;
                case RequestVersion.TournamentInsert:
					TournamentFormPanel.Visible = true;
                    TournamentEditFormLoad();
					formTitle.Text = "Create Tournament";
                    break;
                case RequestVersion.TournamentEdit:
					ManageClaimSecurity();
					TournamentFormPanel.Visible = true;
                    tournament = iTournament.SQLSelect<Tournament, int>(tournamentID);
					TournamentEditFormLoad();
					formTitle.Text = "Edit Tournament";
					break;
            }
        }

        protected void TournamentEditFormLoad() {
			TournamentStartHourLoad();
			TournamentStartHourMinuteLoad();

			if (tournament != null && !IsPostBack) {
	    		TeamSizeLoad(tournament.TournamentType);
	    		SquadSizeLoad();
				if (tournament.HostClub != null) {
					hostClubIDHidden.Value = tournament.HostClub.ID.ToString();
					hostClubName.Text = tournament.HostClub.Name;
					hostClubName.Enabled = false;
					tournamentType.Enabled = false;
				}
				tournamentType.SelectedValue = EnumExtensions.GetIntValue(tournament.TournamentType).ToString();
				tournamentName.Text = tournament.Name;

				if (tournament.StartTime.HasValue) {
					tournamentStartDate.Text = tournament.StartTime.Value.ToShortDateString();
					hourText = tournament.StartTime.Value.Hour.ToString();
					if (hourText.Length == 1) {
						hourText = "0" + hourText;
					}
					foreach (ListItem li in tournamentStartHour.Items) {
						if (li.Value == hourText) {
							li.Selected = true;
						}
					}
					minuteText = tournament.StartTime.Value.Minute.ToString();
					if (minuteText.Length == 1) {
						minuteText = "0" + minuteText;
					}
					foreach (ListItem li in tournamentStartMinute.Items) {
						if (li.Value == minuteText) {
							li.Selected = true;
						}
					}
				}
				if (tournament.EndTime.HasValue) {
                    tournamentEndDate.Text = tournament.EndTime.Value.ToShortDateString();
                }					
				tournamentVenue.Text = tournament.Venue;
				tournamentPostcode.Text = tournament.Postcode;
				tournamentGoogleMapsURL.Text = tournament.GoogleMapsURL ;
				tournamentNoPlayingAreas.SelectedValue = EnumExtensions.GetIntValue(tournament.NoOfPlayingAreas).ToString();
				fixtureTurnaround.SelectedValue = EnumExtensions.GetIntValue(tournament.FixtureTurnaround).ToString();
                fixtureHalvesNumber.SelectedValue = EnumExtensions.GetIntValue(tournament.FixtureHalvesNumber).ToString();
                fixtureHalvesLength.SelectedValue = EnumExtensions.GetIntValue(tournament.FixtureHalvesLength).ToString();
				teamSize.SelectedValue = EnumExtensions.GetIntValue(tournament.TeamSize).ToString();
				squadSize.SelectedValue = EnumExtensions.GetIntValue(tournament.SquadSize).ToString();
				if (tournament.RotatorDate.HasValue && tournament.RotatorDate != null) {
					rotatorDate.SelectedValue = tournament.RotatorDate.Value.ToShortDateString();
				}
				rotatorSession.SelectedValue = EnumExtensions.GetIntValue(tournament.RotatorSession).ToString();
			}
     
        }

		protected void TournamentStartHourLoad() {
			if (tournamentStartHour.Items.Count < 2) {
				for (int i = 6; i <= 20; i++ ) {
					hourText = i.ToString();
					if (hourText.Length == 1) {
						hourText = "0" + hourText;
					}
					tournamentStartHour.Items.Add(new ListItem(hourText, hourText));
				}
			}
		}
		protected void TournamentStartHourMinuteLoad() {
			if (tournamentStartMinute.Items.Count < 2) {
				for (int i = 0; i <= 50; i = i + 10 ) {
					minuteText = i.ToString();
					if (minuteText.Length == 1) {
						minuteText = "0" + minuteText;
					}
					tournamentStartMinute.Items.Add(new ListItem(minuteText, minuteText));
				}
			}
		}
		protected void TeamSizeLoad(Tournament.TournamentTypes tournamentType) {
            switch (tournamentType) {
                case Tournament.TournamentTypes.FootballJunior:
                    maxTeamSize = Tournament.footballMaxTeamSize;
                    break;
                case Tournament.TournamentTypes.RugbyJunior:
                    maxTeamSize = Tournament.rugbyMaxTeamSize;
                    break;
            }
            Array teamSizeEnum = Enum.GetValues(typeof(Domains.NumberOfParticipants));
            if (teamSize.Items.Count < 2) {
                foreach (Enum type in teamSizeEnum) {
                    if (EnumExtensions.GetIntValue(type) > 4 && EnumExtensions.GetIntValue(type) <= maxTeamSize) {
                        teamSize.Items.Add(new ListItem(EnumExtensions.GetIntValue(type).ToString()  + " Players", EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
		}		
		protected void SquadSizeLoad() {
			Array squadSizeEnum = Enum.GetValues(typeof(Domains.NumberOfParticipants));
            if (squadSize.Items.Count < 2) {
                foreach (Enum type in squadSizeEnum) {
                    if (EnumExtensions.GetIntValue(type) > 4 && EnumExtensions.GetIntValue(type) <= (maxTeamSize + 4)) {
                        squadSize.Items.Add(new ListItem(EnumExtensions.GetIntValue(type).ToString()  + " Players", EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
		}	

        //protected void ValidateFixtureDuration(object sender, ServerValidateEventArgs e) {
        //    int turnaround = Int32.Parse(fixtureTurnaround.SelectedValue);
        //    int halvesNumber = Int32.Parse(fixtureHalvesNumber.SelectedValue);
        //    int halvesLength = Int32.Parse(fixtureHalvesLength.SelectedValue);
        //    if (turnaround > (halvesNumber * halvesLength)) {
        //        e.IsValid = true;
        //    }
        //    else {
        //        e.IsValid = false;
        //    }
        //}

 		protected void TournamentType_SelectedIndexChanged(object sender, EventArgs e) {
            DropDownList tournamentTypeMenu = (DropDownList)TournamentFormPanel.FindControl("TournamentType");
            Tournament.TournamentTypes tournamentType = (Tournament.TournamentTypes)Int32.Parse(tournamentTypeMenu.SelectedValue);
			TeamSizeLoad(tournamentType);
            SquadSizeLoad();
		}
       
        protected void SaveButton_Click(object sender, EventArgs e) {
 
            if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
			    if (tournamentStartDate.Text != "") {
				    startTimeText = tournamentStartDate.Text;
			    }
			    if (tournamentStartDate.Text != "" && tournamentStartHour.SelectedValue != "" && tournamentStartMinute.SelectedValue != "") {
				    startTimeText = startTimeText + " " + tournamentStartHour.SelectedValue + ":"+ tournamentStartMinute.SelectedValue+":00";
			    }
			    else {
                    startTimeText = startTimeText + " 09:00:00";
                }
                if ((Int32.Parse(fixtureHalvesNumber.SelectedValue)*Int32.Parse(fixtureHalvesLength.SelectedValue)) > Int32.Parse(fixtureTurnaround.SelectedValue)) {
                    fixtureOverRun = true;
                }
			    Tournament tournamentToSave = new Tournament(
				    id: tournamentID ,
				    tournamentType: (Tournament.TournamentTypes)Int32.Parse(tournamentType.SelectedValue) ,
				    name: tournamentName.Text ,
				    affiliation : null ,
				    startTime: startTimeText.Length > 0 ? DateTime.Parse(startTimeText) : (Nullable<DateTime>)null ,
				    endTime: tournamentEndDate.Text == "" ? (Nullable<DateTime>)null : DateTime.Parse(tournamentEndDate.Text),
				    venue: tournamentVenue.Text,
				    postcode: tournamentPostcode.Text ,
				    googleMapsURL: iTournament.GetSourceForGoogleMapEmbedString(tournamentGoogleMapsURL.Text) ,
				    noOfPlayingAreas: (Tournament.NumberOfPlayingAreas)Int32.Parse(tournamentNoPlayingAreas.SelectedValue) ,
				    fixtureTurnaround : (Tournament.FixtureTurnarounds)Int32.Parse(fixtureTurnaround.SelectedValue) ,
                    fixtureHalvesNumber : fixtureOverRun == true ? Tournament.FixtureHalvesNumbers.Undefined : (Tournament.FixtureHalvesNumbers)Int32.Parse(fixtureHalvesNumber.SelectedValue) ,
                    fixtureHalvesLength : fixtureOverRun == true ? Tournament.FixtureHalvesLengths.Undefined : (Tournament.FixtureHalvesLengths)Int32.Parse(fixtureHalvesLength.SelectedValue) ,
				    teamSize : (Domains.NumberOfParticipants)Int32.Parse(teamSize.SelectedValue) ,
				    squadSize : (Domains.NumberOfParticipants)Int32.Parse(squadSize.SelectedValue) ,
				    rotatorDate : rotatorDate.SelectedValue != "" ? DateTime.Parse(rotatorDate.SelectedValue) : (Nullable<DateTime>)null  ,
				    rotatorSession : (Competition.Sessions)Int32.Parse(rotatorSession.SelectedValue)
                );

                if (tournamentToSave.ID == 0) {
                    tournamentID = iTournament.SQLInsertAndReturnID<Tournament>(tournamentToSave);
				    identityHelper.AddClaimForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournamentID.ToString());
				    Club hostClub = new Club(
					    id: 0,
					    tournamentID: tournamentID,
					    name: hostClubName.Text,
                        attendanceType: Domains.AttendanceTypes.HostClub,
					    websiteURL: null,
					    logoFile: null,
					    twitter: null,
					    colourPrimary: null,
					    colourSecondary: null,
					    affiliation : null ,
					    affiliationNumber : null ,
					    primaryContactID : null
				    );
				    iClub.SQLInsert<Club>(hostClub);
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/Uploads/Tournament" + tournamentID));
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/Uploads/Tournament" + tournamentID+"/Adverts"));
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/Uploads/Tournament" + tournamentID + "/Logos"));
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/Uploads/Tournament" + tournamentID + "/Documents"));
                }
                else {
                    iTournament.SQLUpdate<Tournament>(tournamentToSave);
                }

			    noPlayingAreasInTournament = iTournament.CountPlayingAreasForTournament(tournamentToSave.ID);
                if (noPlayingAreasInTournament == 0) {
                    //noPlayingAreasInTournament = EnumExtensions.GetIntValue(tournamentToSave.NoOfPlayingAreas);
                    for (int i = 1; i <= EnumExtensions.GetIntValue(tournamentToSave.NoOfPlayingAreas); i++) {
                        PlayingArea playingArea = new PlayingArea(id: 0, tournamentID: tournamentID, name: "Pitch " + i.ToString());
                        iPlayingArea.SQLInsert<PlayingArea>(playingArea);
                    }
                }
                else if (noPlayingAreasInTournament <= EnumExtensions.GetIntValue(tournamentToSave.NoOfPlayingAreas)) {
                     for (int i = noPlayingAreasInTournament+1; i <= EnumExtensions.GetIntValue(tournamentToSave.NoOfPlayingAreas); i++) {
                        PlayingArea playingArea = new PlayingArea(id: 0, tournamentID: tournamentID, name: "Pitch " + i.ToString());
                        iPlayingArea.SQLInsert<PlayingArea>(playingArea);
                    }           
                }
            }

            if (fixtureOverRun) {
                Response.Write("<script language=javascript>alert('The fixture lengths selected are longer than the turnaround');</script>");
            }
            else {
                Response.Redirect("~/UI/Planner/TournamentView.aspx?TournamentID="+tournamentID.ToString());
            }

        }

    }

}

