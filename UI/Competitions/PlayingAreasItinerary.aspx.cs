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

    public partial class PlayingAreasItinerary : Page {

        #region Declare Domain Objects
		Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
        ICompetition iCompetition = new Competition();
        List<PlayingArea> playingAreaList = new List<PlayingArea>();
        IPlayingArea iPlayingArea = new PlayingArea();
        IFixture iFixture = new Fixture();
        List<Fixture> fixturesList = new List<Fixture>();
		DateTime scheduledDay = new DateTime();

        DateTime firstFixture = new DateTime();
        DateTime lastFixture = new DateTime();
		#endregion

		#region Declare page controls
		DataList scheduledDaysList = new DataList();
		#endregion

		protected void Page_Load(object sender, EventArgs e) {

			AssignControlsAll();

			if (Request.QueryString.Get("TournamentID") != null) {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
 				FixturesListTitle.Text = tournament.PlayingAreaType.ToString() + " Itinerary";
				playingAreaList = iPlayingArea.SQLSelectForTournament(tournament.ID);
			}

			scheduledDaysList.DataSource = tournament.ScheduledDays;
			scheduledDaysList.DataBind();

        }

		protected void AssignControlsAll() {
			scheduledDaysList = (DataList)PlayingAreasItineraryPanel.FindControl("ScheduledDaysList");
		}

		protected void ScheduledDaysList_ItemDataBound(Object sender, DataListItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                scheduledDay = (DateTime)e.Item.DataItem;
                Label scheduledDayLabel = (Label)e.Item.FindControl("ScheduledDayLabel");
				scheduledDayLabel.Text = scheduledDay.ToString("ddd d MMM");
				DataList playingAreasList = (DataList)e.Item.FindControl("PlayingAreasList");
				playingAreasList.DataSource = playingAreaList;
				playingAreasList.DataBind();	
			}
		}
		protected void PlayingAreasList_ItemDataBound(Object sender, DataListItemEventArgs e) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                PlayingArea playingArea = (PlayingArea)e.Item.DataItem;
                Label playingAreaName = (Label)e.Item.FindControl("PlayingAreaName");
				playingAreaName.Text = playingArea.Name;
                fixturesList = iFixture.SQLSelectForPlayingArea(playingArea.ID, scheduledDay);
                firstFixture = (DateTime)tournament.StartTime;
                int loopEnd = 40;
                Table fixtureItineraryTable = (Table)e.Item.FindControl("FixtureItineraryTable");
                
                for (int i = 0; i < loopEnd; i++) {
                    TableRow fixtureItineraryTableRow = new TableRow();
                    fixtureItineraryTableRow.Height = 10;
                    TableCell fixtureNameCell = new TableCell();
                    foreach (Fixture fixture in fixturesList) {
                        if (fixture.StartTime.Value.ToShortTimeString() == firstFixture.ToShortTimeString()) {
                            fixtureNameCell.Text = firstFixture.ToShortTimeString() + ": " + fixture.Competition.AgeBand.ToString().Replace("Under","U"); 
                            if (fixture.Group.Name != null && fixture.Group.Name != "") {
                                fixtureNameCell.Text += " " + fixture.Group.Name.Replace("Group","Gp");
                            }
                            fixtureNameCell.Text += " " + fixture.Name.Replace("Semi-Final","S-F");
                            break;
                        }
                        else {
                           fixtureNameCell.Text = firstFixture.ToShortTimeString();
                        }
                    }

                    fixtureNameCell.Width = 160;
                    fixtureNameCell.Height = 10;
                    fixtureNameCell.Font.Size = 7;
                    fixtureItineraryTableRow.Cells.Add(fixtureNameCell);
                    fixtureItineraryTable.Rows.Add(fixtureItineraryTableRow);
                    firstFixture = firstFixture.AddMinutes(EnumExtensions.GetIntValue(tournament.FixtureTurnaround));
                }
		
			}
        }
		protected void ItineraryForPlayingArea_ItemDataBound(Object sender, DataListItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				Fixture fixture = (Fixture)e.Item.DataItem;
				Competition competition = iCompetition.SQLSelect<Competition, int>(fixture.Group.CompetitionID);
				Table fixtureItineraryTable = (Table)e.Item.FindControl("FixtureItineraryTable");
				TableRow fixtureItineraryTableRow = (TableRow)fixtureItineraryTable.FindControl("FixtureItineraryTableRow");
				TableCell fixtureNameCell = (TableCell)fixtureItineraryTableRow.FindControl("FixtureNameCell");
				fixtureNameCell.Text += fixture.StartTime.Value.ToShortTimeString();
                if (competition != null) {
                    fixtureNameCell.Text += " " + EnumExtensions.GetStringValue(competition.AgeBand);
                }
                if (fixture.Group.Name != null) {
                    fixtureNameCell.Text += " " + fixture.Group.Name;
                }
			}
		}



    }

}

