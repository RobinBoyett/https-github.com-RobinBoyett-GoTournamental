using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.API;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser {

    public partial class CompetitionForm : Page {

        #region Declare Domain Objects & Page Variables
 		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
        Competition competition = new Competition();
        ICompetition iCompetition = new Competition();
        Competition competitionToSave = new Competition();
        IFixture iFixture = new Fixture();


		private string hourText = "";
		private string minuteText = "";
		private string startTimeText = "";
		private int groupsInCompetition = 0;
		private int groupID = 0;
        bool fixtureOverRun = false;		

        private RequestVersion pageVersion = RequestVersion.Undefined;
        protected enum RequestVersion {
            Undefined = 0,
            CompetitionEdit = 1,
			TeamDelete = 2
        }
        #endregion

        #region Declare page controls
		Label competitionTitle = new Label();
		Label ageBand = new Label();
		HyperLink linkToCompetitionSummary = new HyperLink();
 		Label noTeamsAttending = new Label();
		DropDownList competitionStartDate = new DropDownList();
		DropDownList competitionStartHour = new DropDownList();
		DropDownList competitionStartMinute = new DropDownList();
		DropDownList session = new DropDownList();
		DropDownList fixtureTurnaround = new DropDownList();
		DropDownList fixtureHalvesNumber = new DropDownList();
		DropDownList fixtureHalvesLength = new DropDownList();
		DropDownList teamSize = new DropDownList();
 		DropDownList squadSize = new DropDownList();
		DropDownList competitionFormat = new DropDownList();
		Button saveButton = new Button();
		#endregion

        protected void Page_Load(object sender, EventArgs e) {

            AssignControlsAll();

			if (Request.QueryString.Get("version") != null) {
                pageVersion = (RequestVersion)Int32.Parse(Request.QueryString.Get("version"));
            }
            if (Request.QueryString.Get("TournamentID") != null) {
	            tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
				//playingAreaList = iPlayingArea.SQLSelectForTournament(tournament.ID);
            }
			if (Request.QueryString.Get("competition_id") != null) {
				competition = iCompetition.SQLSelect<Competition, int>(Int32.Parse(Request.QueryString.Get("competition_id")));
				competitionTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
                //if (competition.CompetitionFormat == Competition.CompetitionFormats.Cup) {
                //    linkToCompetitionSummary.NavigateUrl = "~/UI/KnockoutView?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competition.ID.ToString();
                //}
                //else {
                linkToCompetitionSummary.NavigateUrl = "~/UI/Competitions/CompetitionView.aspx?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competition.ID.ToString();
                //}
				//playingAreasInUseInSession = iPlayingArea.SQLSelectInUseForTournamentSession(tournament.ID, competition.ID);
            }        
			//if (Request.QueryString.Get("team_id") != null) {
			//	team = iTeam.SQLSelect<Team, int>(Int32.Parse(Request.QueryString.Get("team_id")));
			//}

            ManagePageVersion(pageVersion);

        }
		protected void AssignControlsAll() {
			competitionTitle = (Label)CompetitionFormPanel.FindControl("CompetitionTitle");
			ageBand = (Label)CompetitionFormPanel.FindControl("AgeBand");
			linkToCompetitionSummary = (HyperLink)CompetitionFormPanel.FindControl("LinkToCompetitionSummary");
			noTeamsAttending = (Label)CompetitionFormPanel.FindControl("NoTeamsAttending");
			competitionStartDate = (DropDownList)CompetitionFormPanel.FindControl("CompetitionStartDate");
			competitionStartHour = (DropDownList)CompetitionFormPanel.FindControl("CompetitionStartHour");
			competitionStartMinute = (DropDownList)CompetitionFormPanel.FindControl("CompetitionStartMinute");
			session = (DropDownList)CompetitionFormPanel.FindControl("Session"); 
			fixtureTurnaround = (DropDownList)CompetitionFormPanel.FindControl("FixtureTurnaround"); 
			fixtureHalvesNumber = (DropDownList)CompetitionFormPanel.FindControl("FixtureHalvesNumber"); 
			fixtureHalvesLength = (DropDownList)CompetitionFormPanel.FindControl("FixtureHalvesLength"); 
 			teamSize = (DropDownList)CompetitionFormPanel.FindControl("TeamSize"); 
			squadSize = (DropDownList)CompetitionFormPanel.FindControl("SquadSize"); 
			competitionFormat = (DropDownList)CompetitionFormPanel.FindControl("CompetitionFormat");
			saveButton = (Button)CompetitionFormPanel.FindControl("SaveButton");
        }
        protected void ManagePageVersion(RequestVersion pageVersion) {
			switch (pageVersion) {
				//case RequestVersion.TeamDelete:
				//	iTeam.SQLDeleteWithCascade<Team>(team);
				//	Response.Redirect("~/UI/Competitions/CompetitionView.aspx?TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString());
				//	break;
                case RequestVersion.CompetitionEdit:
                    CompetitionEditFormLoad();
                    break;
            }
        }

        protected void CompetitionEditFormLoad() {
			CompetitionStartDateLoad();
			CompetitionStartHourLoad();
			CompetitionStartHourMinuteLoad();
			SessionLoad();
			FixtureTurnaroundLoad();
            FixtureHalvesNumberLoad();
            FixtureHalvesLengthLoad();
			TeamSizeLoad();
			SquadSizeLoad();
 			CompetitionFormatLoad();

			ageBand.Text = EnumExtensions.GetStringValue(competition.AgeBand);
			if (!IsPostBack) {
				noTeamsAttending.Text = competition.CountTeamsAttendingCompetition().ToString();
				if (competition.StartTime.HasValue) {

					competitionStartDate.SelectedValue = competition.StartTime.Value.ToShortDateString();

					hourText = competition.StartTime.Value.Hour.ToString();
					if (hourText.Length == 1) {
						hourText = "0" + hourText;
					}
					foreach (ListItem li in competitionStartHour.Items) {
						if (li.Value == hourText) {
							li.Selected = true;
						}
					}
					minuteText = competition.StartTime.Value.Minute.ToString();
					if (minuteText.Length == 1) {
						minuteText = "0" + minuteText;
					}
					foreach (ListItem li in competitionStartMinute.Items) {
						if (li.Value == minuteText) {
							li.Selected = true;
						}
					}
				}
				session.SelectedValue = EnumExtensions.GetIntValue(competition.Session).ToString();
				fixtureTurnaround.SelectedValue = EnumExtensions.GetIntValue(competition.FixtureTurnaround).ToString();
				fixtureHalvesNumber.SelectedValue = EnumExtensions.GetIntValue(competition.FixtureHalvesNumber).ToString();
				fixtureHalvesLength.SelectedValue = EnumExtensions.GetIntValue(competition.FixtureHalvesLength).ToString();
				teamSize.SelectedValue = EnumExtensions.GetIntValue(competition.TeamSize).ToString();
				squadSize.SelectedValue = EnumExtensions.GetIntValue(competition.SquadSize).ToString();
				competitionFormat.SelectedValue = EnumExtensions.GetIntValue(competition.CompetitionFormat).ToString();
			
			}

		}
        
		protected void CompetitionStartDateLoad() {
			competitionStartDate.Items.Add(new ListItem(tournament.StartTime.Value.ToShortDateString(), tournament.StartTime.Value.ToShortDateString()));
			if (tournament.EndTime.HasValue) {
				DateTime loopEnd = (DateTime)tournament.StartTime;
				do {
					loopEnd = loopEnd.AddDays(1);
					competitionStartDate.Items.Add(new ListItem(loopEnd.ToShortDateString(), loopEnd.ToShortDateString()));
				}
				while (loopEnd <= tournament.EndTime);
			}
			else {
				competitionStartDate.SelectedValue = tournament.StartTime.Value.ToShortDateString();
			}
		}
		protected void CompetitionStartHourLoad() {
			for (int i = 6; i <= 20; i++ ) {
				hourText = i.ToString();
				if (hourText.Length == 1) {
					hourText = "0" + hourText;
				}
				competitionStartHour.Items.Add(new ListItem(hourText, hourText));
			}
		}
		protected void CompetitionStartHourMinuteLoad() {
			for (int i = 0; i <= 60; i = i + 10 ) {
				minuteText = i.ToString();
				if (minuteText.Length == 1) {
					minuteText = "0" + minuteText;
				}
				competitionStartMinute.Items.Add(new ListItem(minuteText, minuteText));
			}
		}		
		protected void SessionLoad() {
			Array sessionEnum = Enum.GetValues(typeof(Competition.Sessions));
            if (session.Items.Count < 2) {
                foreach (Enum type in sessionEnum) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        session.Items.Add(new ListItem(EnumExtensions.GetStringValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
		}		
		protected void FixtureTurnaroundLoad() {
			Array fixtureTurnaroundEnum = Enum.GetValues(typeof(Tournament.FixtureTurnarounds));
            if (fixtureTurnaround.Items.Count < 2) {
                foreach (Enum type in fixtureTurnaroundEnum) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        fixtureTurnaround.Items.Add(new ListItem(EnumExtensions.GetIntValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
		}						
 		protected void FixtureHalvesNumberLoad() {
        	Array fixtureHalvesNumberEnum = Enum.GetValues(typeof(Tournament.FixtureHalvesNumbers));
            if (fixtureHalvesNumber.Items.Count < 2) {
                foreach (Enum type in fixtureHalvesNumberEnum) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        fixtureHalvesNumber.Items.Add(new ListItem(EnumExtensions.GetIntValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
        }       
  		protected void FixtureHalvesLengthLoad() {
			Array fixtureHalvesLengthEnum = Enum.GetValues(typeof(Tournament.FixtureHalvesLengths));
            if (fixtureHalvesLength.Items.Count < 2) {
                foreach (Enum type in fixtureHalvesLengthEnum) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        fixtureHalvesLength.Items.Add(new ListItem(EnumExtensions.GetIntValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
        }       
	
		protected void TeamSizeLoad() {
			Array teamSizeEnum = Enum.GetValues(typeof(Domains.NumberOfParticipants));
            if (teamSize.Items.Count < 2) {
				if (tournament.TournamentType == Tournament.TournamentTypes.FootballJunior && (competition.AgeBand == Competition.AgeBands.Under7s || competition.AgeBand == Competition.AgeBands.Under8s)) {
					teamSize.Items.Add(new ListItem("4", "4"));
					teamSize.Items.Add(new ListItem("5", "5"));
					teamSize.Items.Add(new ListItem("6", "6"));
				}
				else if (tournament.TournamentType == Tournament.TournamentTypes.FootballJunior && (competition.AgeBand == Competition.AgeBands.Under9s || competition.AgeBand == Competition.AgeBands.Under10s)) {
					teamSize.Items.Add(new ListItem("5", "5"));
					teamSize.Items.Add(new ListItem("6", "6"));
					teamSize.Items.Add(new ListItem("7", "7"));
				}
				else {
					foreach (Enum type in teamSizeEnum) {
						if (tournament.TournamentType == Tournament.TournamentTypes.FootballJunior && EnumExtensions.GetIntValue(type) > 4 && EnumExtensions.GetIntValue(type) <= 11) {
							teamSize.Items.Add(new ListItem(EnumExtensions.GetIntValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
						}
					}
				}
            }
		}		
		protected void SquadSizeLoad() {
			Array squadSizeEnum = Enum.GetValues(typeof(Domains.NumberOfParticipants));
            if (squadSize.Items.Count < 2) {
                foreach (Enum type in squadSizeEnum) {
                    if (tournament.TournamentType == Tournament.TournamentTypes.FootballJunior && EnumExtensions.GetIntValue(type) > 4 && EnumExtensions.GetIntValue(type) <= 13) {
                        squadSize.Items.Add(new ListItem(EnumExtensions.GetIntValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
		}			
		protected void CompetitionFormatLoad() {
            Array enumValues = Enum.GetValues(typeof(Competition.CompetitionFormats));
            if (competitionFormat.Items.Count < 2) {
                foreach (Enum type in enumValues) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        competitionFormat.Items.Add(new ListItem(EnumExtensions.GetStringValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
		}

		protected bool SavePageData() {
            if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
			    bool reCalculateFixtures = false;

			    if (competitionStartDate.SelectedValue != "") {
				    startTimeText = competitionStartDate.SelectedValue;
			    }
			    if (competitionStartDate.SelectedValue != "" && competitionStartHour.SelectedValue != "" && competitionStartMinute.SelectedValue != "") {
				    startTimeText = startTimeText + " " + competitionStartHour.SelectedValue + ":"+competitionStartMinute.SelectedValue+":00";
			    }
                if ((Int32.Parse(fixtureHalvesNumber.SelectedValue)*Int32.Parse(fixtureHalvesLength.SelectedValue)) > Int32.Parse(fixtureTurnaround.SelectedValue)) {
                    fixtureOverRun = true;
                }
                competitionToSave = new Competition(
				    id : competition.ID ,
				    tournamentID : tournament.ID ,
				    ageBand : Competition.AgeBands.Undefined ,
				    startTime : startTimeText.Length > 0 ? DateTime.Parse(startTimeText) : (Nullable<DateTime>)null ,
				    session : (Competition.Sessions)Int32.Parse(session.SelectedValue) ,
				    competitionFormat : (Competition.CompetitionFormats)Int32.Parse(competitionFormat.SelectedValue) ,
				    fixtureTurnaround : (Tournament.FixtureTurnarounds)Int32.Parse(fixtureTurnaround.SelectedValue) ,
                    fixtureHalvesNumber : fixtureOverRun == true ? Tournament.FixtureHalvesNumbers.Undefined : (Tournament.FixtureHalvesNumbers)Int32.Parse(fixtureHalvesNumber.SelectedValue) ,
                    fixtureHalvesLength : fixtureOverRun == true ? Tournament.FixtureHalvesLengths.Undefined : (Tournament.FixtureHalvesLengths)Int32.Parse(fixtureHalvesLength.SelectedValue) ,
				    teamSize : (Domains.NumberOfParticipants)Int32.Parse(teamSize.SelectedValue) ,
				    squadSize : (Domains.NumberOfParticipants)Int32.Parse(squadSize.SelectedValue) 
                );

			    //if (!iFixture.FixturesUnderway(competition) == true &&
			    //	(competition.FixtureTurnaround != (Tournament.FixtureTurnarounds)Int32.Parse(fixtureTurnaround.SelectedValue) ||
			    //	competition.StartTime != DateTime.Parse(startTimeText) ||
			    //	competition.CompetitionFormat != (Competition.CompetitionFormats)Int32.Parse(competitionFormat.SelectedValue))) {
			    //	reCalculateFixtures = true;
			    //}

			    iCompetition.SQLUpdate<Competition>(competitionToSave);

			    return reCalculateFixtures;
            }
		}
		
		protected void SaveButton_Click(object sender, EventArgs e) {
            if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
			    bool reCalculateFixtures = false;
			    reCalculateFixtures = SavePageData();
			    //if (reCalculateFixtures == true) {
			    //	Response.Redirect("~/UI/Competitions/GroupAllocationForm?version=3&TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString());
			    //}
			    //else {
			    //	Response.Redirect("~/UI/Competitions/GroupAllocationForm?version=1&TournamentID="+tournament.ID.ToString()+"&competition_id="+competition.ID.ToString());
			    //}
                //if (competition.CompetitionFormat == Competition.CompetitionFormats.Cup) {
                //    Response.Redirect("~/UI/KnockoutView?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competition.ID.ToString());
                //}
                //else {

                if (fixtureOverRun) {
                    Response.Write("<script language=javascript>alert('The fixture lengths selected are longer than the turnaround');</script>");
                }
                else {
                    Response.Redirect("~/UI/Competitions/CompetitionView?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competition.ID.ToString());
                }
                //}
            }
        }

    }

}

