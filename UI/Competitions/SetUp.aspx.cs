using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.API.Identity;
using GoTournamental.BLL.Organiser;
using GoTournamental.BLL.Planner;


namespace GoTournamental.UI.Organiser 
{

    public partial class SetUp : Page 
    {

        #region Declare domain objects
 		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
		Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
        List<Competition> competitions = new List<Competition>();
		ICompetition iCompetition = new Competition();
		List<Club> clubs = new List<Club>();
		IClub iClub = new Club();
		List<GoTournamental.BLL.Organiser.Contact> contacts = new List<GoTournamental.BLL.Organiser.Contact>();
		GoTournamental.BLL.Organiser.IContact iContact = new GoTournamental.BLL.Organiser.Contact();
		#endregion
		#region Declare page controls
		Label competitionsListTitle = new Label();
		HyperLink linkToCompetitionsAdd = new HyperLink();
		Label playingAreaType = new Label();
		Label noPitchesAvailable = new Label();
		Label turnaround = new Label();
		Label startTime = new Label();
		Label days = new Label();
		Label sessions = new Label();
		Label fixtures = new Label();
        #endregion

        protected void Page_Load(object sender, EventArgs e) 
        {

			AssignControlsAll();

            if (Request.QueryString.Get("TournamentID") != null) 
            {
	            tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
 				competitionsListTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
				competitions = iCompetition.SQLSelectForTournament(tournament.ID, false);
				clubs = iClub.SQLSelectClubsForTournament(tournament.ID);
				contacts = iContact.SQLSelectForTournament(tournament.ID);

                if (tournament.ID > 1 && !identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) 
                {
                    throw new Exception("Unauthorised access to tournament admin page.");
                }

            }
			playingAreaType.Text = tournament.PlayingAreaType.ToString();
			noPitchesAvailable.Text = EnumExtensions.GetIntValue(tournament.NoOfPlayingAreas).ToString();
			turnaround.Text = EnumExtensions.GetStringValue(tournament.FixtureTurnaround).ToString();
			startTime.Text = tournament.StartTime.Value.ToShortTimeString();
			days.Text = (tournament.Duration.Days+1).ToString();
            if (tournament.RotatorSession == Competition.Sessions.AMOnly || tournament.RotatorSession == Competition.Sessions.PMOnly)
            {
                sessions.Text = "1";
            }
            else 
            {
    			sessions.Text = ((tournament.Duration.Days+1)*2).ToString();
            }

			fixtures.Text = ((((8 * 60) / EnumExtensions.GetIntValue(tournament.FixtureTurnaround))*((tournament.Duration.Days+1)))*EnumExtensions.GetIntValue(tournament.NoOfPlayingAreas)).ToString();

            CompetitionsListGridView.DataSource = competitions;
            CompetitionsListGridView.DataBind();

        }

		protected void AssignControlsAll() 
        {
			playingAreaType = (Label)CompetitionsListPanel.FindControl("PlayingAreaType");
			noPitchesAvailable = (Label)CompetitionsListPanel.FindControl("NoPitchesAvailable");
			turnaround = (Label)CompetitionsListPanel.FindControl("Turnaround");
			startTime = (Label)CompetitionsListPanel.FindControl("StartTime");
			days = (Label)CompetitionsListPanel.FindControl("Days");
 			sessions = (Label)CompetitionsListPanel.FindControl("Sessions");
			fixtures = (Label)CompetitionsListPanel.FindControl("Fixtures");
       }

        protected void CompetitionsListGridView_RowDataBound(Object sender, GridViewRowEventArgs e) 
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                Competition competition = (Competition)e.Row.DataItem;
                HyperLink competitionLink = (HyperLink)e.Row.FindControl("CompetitionViewLink");
				int teamsRequired = 0;
                competitionLink.Text = EnumExtensions.GetStringValue(competition.AgeBand);
                competitionLink.NavigateUrl = "~/UI/Competitions/CompetitionView?TournamentID="+tournament.ID.ToString()+"&competition_id=" + competition.ID.ToString();

                #region Assigning Text To Columns
                e.Row.Cells[5].Text = competition.CountHostTeamsAttendingCompetition().ToString();
				if (competition.FixtureTurnaround == Tournament.FixtureTurnarounds.Fifteen || (competition.FixtureTurnaround == Tournament.FixtureTurnarounds.Undefined && tournament.FixtureTurnaround == Tournament.FixtureTurnarounds.Fifteen)) 
                {
					if (competition.CountHostTeamsAttendingCompetition() == 4) 
                    {
						teamsRequired = 24;
						e.Row.Cells[1].Text = "4 Groups of 6 - 24 teams";
						e.Row.Cells[2].Text = "Use 4";
						if ((competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()) > 0) 
                        {
							e.Row.Cells[6].Text = (competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()).ToString();
						}
						if (competition.CountTeamsAcceptedInviteForCompetition() > 0) 
                        {
							e.Row.Cells[7].Text = competition.CountTeamsAcceptedInviteForCompetition().ToString();						
						}
                        if ((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())) > 0) 
                        {
						    e.Row.Cells[8].Text = (teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())).ToString() + " Available places";
                        }
                        else if ((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())) == 0) 
                        {
						    e.Row.Cells[8].Text = "Fully subscribed";
                        }
                        else
                        {
						    e.Row.Cells[8].Text = "Oversubscribed by " + Math.Abs((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()))).ToString();
                        }
					}
					else if (competition.CountHostTeamsAttendingCompetition() == 3) 
                    {
						teamsRequired = 18;
						e.Row.Cells[1].Text = "3 Groups of 6 - 18 teams";
						e.Row.Cells[2].Text = "Use 3";
						if ((competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()) > 0)
                        {
							e.Row.Cells[6].Text = (competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()).ToString();
						}
						if (competition.CountTeamsAcceptedInviteForCompetition() > 0)
                        {
							e.Row.Cells[7].Text = competition.CountTeamsAcceptedInviteForCompetition().ToString();						
						}
                        if ((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())) > 0)
                        {
						    e.Row.Cells[8].Text = (teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())).ToString() + " Available places";
                        }
                        else if ((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())) == 0) 
                        {
						    e.Row.Cells[8].Text = "Fully subscribed";
                        }
                        else 
                        {
						    e.Row.Cells[8].Text = "Oversubscribed by " + Math.Abs((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()))).ToString();
                        }
					}
					else if (competition.CountHostTeamsAttendingCompetition() == 2 || competition.CountHostTeamsAttendingCompetition() == 1) 
                    {
						teamsRequired = 12;
						e.Row.Cells[1].Text = "2 Groups of 6 - 12 teams";
						e.Row.Cells[2].Text = "Use 2";
						if ((competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()) > 0)
                        {
							e.Row.Cells[6].Text = (competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()).ToString();
						}
						if (competition.CountTeamsAcceptedInviteForCompetition() > 0) 
                        {
							e.Row.Cells[7].Text = competition.CountTeamsAcceptedInviteForCompetition().ToString();
						}
                        if ((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())) > 0) 
                        {
						    e.Row.Cells[8].Text = (teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())).ToString() + " Available places";
                        }
                        else if ((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())) == 0) 
                        {
						    e.Row.Cells[8].Text = "Fully subscribed";
                        }
                        else
                        {
						    e.Row.Cells[8].Text = "Oversubscribed by " + Math.Abs((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()))).ToString();
                        }

					}
					if (competition.CountFixturesForCompetition() > 0 && competition.FixtureTurnaround != Tournament.FixtureTurnarounds.Undefined)
                    {
						e.Row.Cells[4].Text = ((EnumExtensions.GetIntValue(competition.FixtureTurnaround)*15)/60).ToString() + " Hours " + ((EnumExtensions.GetIntValue(competition.FixtureTurnaround)*15)%60).ToString() + " mins";
					}
					else if (competition.CountFixturesForCompetition() > 0)
                    {
						e.Row.Cells[4].Text = ((EnumExtensions.GetIntValue(tournament.FixtureTurnaround)*15)/60).ToString() + " Hours " + ((EnumExtensions.GetIntValue(tournament.FixtureTurnaround)*15)%60).ToString() + " mins";
					}
				}
				else
                {
					if (competition.CountHostTeamsAttendingCompetition() == 4) 
                    {
						teamsRequired = 20;
						e.Row.Cells[1].Text = "4 Groups of 5 - 20 teams";
						e.Row.Cells[2].Text = "Use 4";
						if ((competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()) > 0)
                        {
							e.Row.Cells[6].Text = (competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()).ToString();
						}
						if (competition.CountTeamsAcceptedInviteForCompetition() > 0)
                        {
							e.Row.Cells[7].Text = competition.CountTeamsAcceptedInviteForCompetition().ToString();						
						}
                        if ((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())) > 0) 
                        {
						    e.Row.Cells[8].Text = (teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())).ToString() + " Available places";
                        }
                        else if ((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())) == 0)
                        {
						    e.Row.Cells[8].Text = "Fully subscribed";
                        }
                        else 
                        {
						    e.Row.Cells[8].Text = "Oversubscribed by " + Math.Abs((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()))).ToString();
                        }
					}
					else if (competition.CountHostTeamsAttendingCompetition() == 3) 
                    {
						teamsRequired = 15;
						e.Row.Cells[1].Text = "3 Groups of 5 - 15 teams";
						e.Row.Cells[2].Text = "Use 3";
						if ((competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()) > 0) 
                        {
							e.Row.Cells[6].Text = (competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()).ToString();
						}
						if (competition.CountTeamsAcceptedInviteForCompetition() > 0)
                        {
							e.Row.Cells[7].Text = competition.CountTeamsAcceptedInviteForCompetition().ToString();						
						}
                        if ((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())) > 0)
                        {
						    e.Row.Cells[8].Text = (teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())).ToString() + " Available places";
                        }
                        else if ((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())) == 0)
                        {
						    e.Row.Cells[8].Text = "Fully subscribed";
                        }
                        else
                        {
						    e.Row.Cells[8].Text = "Oversubscribed by " + Math.Abs((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()))).ToString();
                        }
					}
					else if (competition.CountHostTeamsAttendingCompetition() == 2 || competition.CountHostTeamsAttendingCompetition() == 1)
                    {
						teamsRequired = 10;
						e.Row.Cells[1].Text = "2 Groups of 5 - 10 teams";
						e.Row.Cells[2].Text = "Use 2";
						if ((competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()) > 0)
                        {
							e.Row.Cells[6].Text = (competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()).ToString();
						}
						if (competition.CountTeamsAcceptedInviteForCompetition() > 0) 
                        {
							e.Row.Cells[7].Text = competition.CountTeamsAcceptedInviteForCompetition().ToString();						
						}
                        if ((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())) > 0) 
                        {
						    e.Row.Cells[8].Text = (teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())).ToString() + " Available places";
                        }
                        else if ((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition())) == 0)
                        {
						    e.Row.Cells[8].Text = "Fully subscribed";
                        }
                        else 
                        {
						    e.Row.Cells[8].Text = "Oversubscribed by " + Math.Abs((teamsRequired - competition.CountHostTeamsAttendingCompetition() - competition.CountTeamsAcceptedInviteForCompetition() -(competition.CountTeamsAttendingCompetition() - competition.CountHostTeamsAttendingCompetition()))).ToString();
                        }
					}

					if (competition.CountFixturesForCompetition() > 0 && competition.FixtureTurnaround != Tournament.FixtureTurnarounds.Undefined)
                    {
						e.Row.Cells[4].Text = ((EnumExtensions.GetIntValue(competition.FixtureTurnaround)*10)/60).ToString() + " Hours " + ((EnumExtensions.GetIntValue(competition.FixtureTurnaround)*10)%60).ToString() + " mins";
					}
					else if (competition.CountFixturesForCompetition() > 0) 
                    {
						e.Row.Cells[4].Text = ((EnumExtensions.GetIntValue(tournament.FixtureTurnaround)*10)/60).ToString() + " Hours " + ((EnumExtensions.GetIntValue(tournament.FixtureTurnaround)*10)%60).ToString() + " mins";
					}
				}

				if (competition.FixtureTurnaround != Tournament.FixtureTurnarounds.Undefined) 
                {
					e.Row.Cells[3].Text = EnumExtensions.GetStringValue(competition.FixtureTurnaround);
				}
				else
                {
					e.Row.Cells[3].Text = EnumExtensions.GetStringValue(tournament.FixtureTurnaround);
                }
                #endregion
           
            }
        }

    }

}

