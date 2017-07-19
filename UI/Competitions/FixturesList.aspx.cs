using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser {

    public partial class FixturesList : Page {

        #region Declare Domain Objects
		Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
 		List<Competition> competitions = new List<Competition>();
		Competition competition = new Competition();
		ICompetition iCompetition = new Competition();
        List<Fixture> fixturesList = new List<Fixture>();
        IFixture iFixture = new Fixture();       
        Fixture.OrderListBy orderBy = new Fixture.OrderListBy();
        GoTournamental.BLL.Organiser.Contact contact = new GoTournamental.BLL.Organiser.Contact();
        GoTournamental.BLL.Organiser.IContact iContact = new GoTournamental.BLL.Organiser.Contact();
        Club club = new Club();
        IClub iClub = new Club();
        Team team = new Team();
        ITeam iTeam = new Team();
        PlayingArea playingArea = new PlayingArea();
        IPlayingArea iPlayingArea = new PlayingArea();
        int contactID = 0;
        int clubID = 0;
        int teamID = 0;
		#endregion

		#region Declare page controls
		DropDownList ageBands = new DropDownList();
		Label fixturesListTitle = new Label();
		Label fixturesTypeTitle = new Label();
		DropDownList orderBySelect = new DropDownList();
        Label listTypeLabel = new Label();
		AdvertPanel advert728By90 = new AdvertPanel();
		#endregion


		protected void Page_Load(object sender, EventArgs e) {

			AssignControlsAll();

			if (Request.QueryString.Get("TournamentID") != null) {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
 				competitions = iCompetition.SQLSelectForTournament(tournament.ID, false);
				fixturesListTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
				fixturesTypeTitle.Text = "Fixtures";
			}
			if (Request.QueryString.Get("contact_id") != null) {
                contactID = Int32.Parse(Request.QueryString.Get("contact_id"));
                contact = iContact.SQLSelect<GoTournamental.BLL.Organiser.Contact, int>(contactID);
                Page.Title = "Itinerary for " + contact.FirstName + " " + contact.LastName;
				fixturesTypeTitle.Text = "Fixture Itinerary for " + contact.FirstName + " " + contact.LastName;
				ageBands.Visible = false;
            }
            if (Request.QueryString.Get("club_id") != null) {
                clubID = Int32.Parse(Request.QueryString.Get("club_id"));
                club = iClub.SQLSelect<Club, int>(clubID);
                Page.Title = "Itinerary for " + club.Name;
				ageBands.Visible = false;
				fixturesTypeTitle.Text = "Fixture Itinerary for " + club.Name;
            }
            if (Request.QueryString.Get("team_id") != null) {
                teamID = Int32.Parse(Request.QueryString.Get("team_id"));
                team = iTeam.SQLSelect<Team, int>(teamID);
                Page.Title = "Itinerary for " + club.Name + " " + team.Name;
				ageBands.Visible = false;
				fixturesTypeTitle.Text = "Fixture Itinerary for " + club.Name + " " + team.Name;
            }

 			if (ageBands.Items.Count < 2) {
				foreach (Competition comp in competitions) {
					ageBands.Items.Add(new ListItem(EnumExtensions.GetStringValue(comp.AgeBand).ToString(), comp.ID.ToString()));				
				}
			}

			orderBy = Fixture.OrderListBy.StartTime;

            Array enumValues = Enum.GetValues(typeof(Fixture.OrderListBy));
            if (orderBySelect.Items.Count == 0) {
                foreach (Enum type in enumValues) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        orderBySelect.Items.Add(new ListItem(EnumExtensions.GetStringValue(type), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
            if (IsPostBack) {
				competition = iCompetition.SQLSelect<Competition, int>(Int32.Parse(ageBands.SelectedValue));
                orderBy = (Fixture.OrderListBy)Int32.Parse(orderBySelect.SelectedValue);
            }

            GridView fixturesListGridView = (GridView)FixturesListPanel.FindControl("FixturesListGridView");

            fixturesList = iFixture.GetSearchFixturesForTournament(tournament.ID, competition, orderBy, contact, club, team);
			if (fixturesList.Count > 0) {
	            fixturesListGridView.DataSource = fixturesList;
		        fixturesListGridView.DataBind();
			}

			advert728By90.graphicFileStyle = Advert.GraphicFileStyles.Advert728By90;
			if (tournament.ID != null && tournament.ID != 0) {
				advert728By90.tournamentID = tournament.ID;
			}

        }

		protected void AssignControlsAll() {
			ageBands = (DropDownList)FixturesListPanel.FindControl("AgeBands");
            orderBySelect = (DropDownList)FixturesListPanel.FindControl("OrderBy");
			fixturesListTitle = (Label)FixturesListPanel.FindControl("FixturesListTitle");
			fixturesTypeTitle = (Label)FixturesListPanel.FindControl("FixturesTypeTitle");
 			advert728By90 = (AdvertPanel)FixturesListPanel.FindControl("advert728By90");
       }

        protected void FixturesList_RowDataBound(Object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                Fixture fixture = (Fixture)e.Row.DataItem;
                Club club = new Club();
                Competition competition = new Competition();
				if (fixture.Group != null && fixture.Group.ID != 0) {
					competition = iCompetition.SQLSelect<Competition, int>(fixture.Group.CompetitionID);
				}
				else if (fixture.CompetitionID != null && fixture.CompetitionID != 0) {
					competition = iCompetition.SQLSelect<Competition, int>((int)fixture.CompetitionID);
				}

				if (competition != null) {
					e.Row.Cells[0].Text = EnumExtensions.GetStringValue(competition.AgeBand).ToString();
				}

                e.Row.Cells[1].Text = fixture.Group.Name;
                e.Row.Cells[3].Text = fixture.StartTime.Value.ToShortTimeString();
                club = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID);
				Table homeColourTable = (Table)e.Row.FindControl("HomeColourTable");
                TableRow homeColourTableRow = (TableRow)homeColourTable.FindControl("HomeColourTableRow");
                TableCell homeColourPrimaryCell = (TableCell)homeColourTableRow.FindControl("HomeColourPrimaryCell");
				if (club != null && club.ColourPrimary != null) {
	                homeColourPrimaryCell.BackColor = Color.FromName(club.ColourPrimary.ToString());
				}
                TableCell homeColourSecondaryCell = (TableCell)homeColourTableRow.FindControl("HomeColourSecondaryCell");
				if (club != null && club.ColourSecondary != null) {
	                homeColourSecondaryCell.BackColor = Color.FromName(club.ColourSecondary.ToString());
				}

				if (fixture.HomeTeamID == null || fixture.HomeTeamID == 0) {
					e.Row.Cells[5].Text = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Home);
				}
				else if (fixture.HomeTeam.Name == EnumExtensions.GetStringValue(competition.AgeBand)) {
					e.Row.Cells[5].Text = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID).Name;
				}
				else {
					e.Row.Cells[5].Text = iClub.SQLSelect<Club, int>(fixture.HomeTeam.ClubID).Name + " " + fixture.HomeTeam.Name;
				}

                if ((contactID > 0 && contactID == fixture.HomeTeam.PrimaryContactID) || (clubID > 0 && clubID == fixture.HomeTeam.ClubID)) {
                    e.Row.Cells[5].ForeColor = Color.DarkRed;
					e.Row.Cells[5].Font.Bold = true;
                }

				if (competition.CompetitionFormat != Competition.CompetitionFormats.LeagueNonCompetitive) {
	                e.Row.Cells[6].Text = fixture.HomeTeamScore.ToString();
				}

                e.Row.Cells[7].Text = "V";
                club = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID);
				if (competition.CompetitionFormat != Competition.CompetitionFormats.LeagueNonCompetitive) {
	                e.Row.Cells[8].Text = fixture.AwayTeamScore.ToString();
				}

				if (fixture.AwayTeamID == null || fixture.AwayTeamID == 0) {
					e.Row.Cells[9].Text = fixture.GetTeamNameForFixture(fixture.Competition, fixture.Name, Fixture.Venue.Away);
				}
				else if (fixture.AwayTeam.Name == EnumExtensions.GetStringValue(competition.AgeBand)) {
					e.Row.Cells[9].Text = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID).Name;
				}
				else {
					e.Row.Cells[9].Text = iClub.SQLSelect<Club, int>(fixture.AwayTeam.ClubID).Name + " " + fixture.AwayTeam.Name;
				}
                if ((contactID > 0 && contactID == fixture.AwayTeam.PrimaryContactID) || (clubID > 0 && clubID == fixture.AwayTeam.ClubID)) {
                    e.Row.Cells[9].ForeColor = Color.DarkRed;
					e.Row.Cells[9].Font.Bold = true;
                }

                Table awayColourTable = (Table)e.Row.FindControl("AwayColourTable");
                TableRow awayColourTableRow = (TableRow)awayColourTable.FindControl("AwayColourTableRow");
                TableCell awayColourPrimaryCell = (TableCell)awayColourTableRow.FindControl("AwayColourPrimaryCell");
				if (club != null && club.ColourPrimary != null) {
	                awayColourPrimaryCell.BackColor = Color.FromName(club.ColourPrimary.ToString());
				}
                TableCell awayColourSecondaryCell = (TableCell)awayColourTableRow.FindControl("AwayColourSecondaryCell");
				if (club != null && club.ColourSecondary != null) {
	                awayColourSecondaryCell.BackColor = Color.FromName(club.ColourSecondary.ToString());
				}
				if (fixture.PlayingAreaID != null) {
					playingArea = iPlayingArea.SQLSelect<PlayingArea, int>((int)fixture.PlayingAreaID);
		            e.Row.Cells[13].Text = playingArea.Name;
				}

            }
        }

    }

}

