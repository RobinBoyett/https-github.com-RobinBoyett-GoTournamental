using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNet.Identity;
using GoTournamental.API;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser {

    public partial class KnockoutForm : Page {

        #region Declare Domain Objects & Page Variables
        GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
        Competition competition = new Competition();
        ICompetition iCompetition = new Competition();
        IClub iClub = new Club();
        List<Club> clubs = new List<Club>();
        ITeam iTeam = new Team();
        List<Team> teamsList = new List<Team>();
        List<PlayingArea> playingAreaList = new List<PlayingArea>();
        List<PlayingArea> playingAreasInUseInSession = new List<PlayingArea>();
        IPlayingArea iPlayingArea = new PlayingArea();

        string hourString = "";
        string minuteString = "";
        #endregion

        #region Declare page controls
        Label competitionTitle = new Label();
        HyperLink linkToCompetitionSummary = new HyperLink();
        Label ageBand = new Label();
        HyperLink noTeamsAttending = new HyperLink();
        DataList competitorsList = new DataList();
        CheckBoxList playingAreasList = new CheckBoxList();
        CustomValidator playingAreasMandatory = new CustomValidator();
        #endregion
		
        protected void Page_Load(object sender, EventArgs e) {

            AssignControlsAll();

            if (Request.QueryString.Get("TournamentID") != null) {
                tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
                playingAreaList = iPlayingArea.SQLSelectForTournament(tournament.ID);
                competitionTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
            }
            if (Request.QueryString.Get("competition_id") != null) {
                competition = iCompetition.SQLSelect<Competition, int>(Int32.Parse(Request.QueryString.Get("competition_id")));
                teamsList = iTeam.SQLSelectForCompetition(competition.ID).Where(i => i.AttendanceType == Domains.AttendanceTypes.HostClub || i.AttendanceType == Domains.AttendanceTypes.Attending).ToList();
                linkToCompetitionSummary.NavigateUrl = "~/UI/Competitions/CompetitionView.aspx?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competition.ID.ToString();
            }
            if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
                linkToCompetitionSummary.Visible = true;
            }
            
            CompetitionViewLoad();

        }

		protected void AssignControlsAll() {
            competitionTitle = (Label)KnockoutViewPanel.FindControl("CompetitionTitle");
            linkToCompetitionSummary = (HyperLink)KnockoutViewPanel.FindControl("LinkToCompetitionSummary");
            ageBand = (Label)KnockoutViewPanel.FindControl("AgeBand");
            noTeamsAttending = (HyperLink)KnockoutViewPanel.FindControl("NoTeamsAttending");
            playingAreasList = (CheckBoxList)KnockoutViewPanel.FindControl("PlayingAreasList");
            playingAreasMandatory = (CustomValidator)KnockoutViewPanel.FindControl("PlayingAreasMandatory");
            competitorsList = (DataList)KnockoutViewPanel.FindControl("CompetitorsList");
        }

        protected void CompetitionViewLoad() {
            ageBand.Text = EnumExtensions.GetStringValue(competition.AgeBand);
            if (competition.CountTeamsAttendingCompetition() != 0) {
                noTeamsAttending.Text = competition.CountTeamsAttendingCompetition().ToString();
                noTeamsAttending.NavigateUrl = "~/UI/Clubs/ClubsList?version=1&TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competition.ID.ToString();
            }
            int i = 0;
            foreach (PlayingArea playingArea in playingAreaList) {
                playingAreasList.Items.Add(new ListItem("&nbsp;" + playingArea.Name, playingArea.ID.ToString()));
                foreach (PlayingArea playingAreaUsed in playingAreasInUseInSession) {
                    if (playingArea.ID == playingAreaUsed.ID) {
                        playingAreasList.Items[i].Enabled = false;
                    }
                }
                i++;
            }

            competitorsList.DataSource = teamsList;
            competitorsList.DataBind();


        }        
        protected void CompetitorsList_ItemDataBound(Object sender, DataListItemEventArgs e) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                Team team = (Team)e.Item.DataItem;
                Club club = new Club();
                club = iClub.SQLSelect<Club, int>(team.ClubID);
                Table colourTable = (Table)e.Item.FindControl("ColourTable");
                TableRow colourTableRow = (TableRow)colourTable.FindControl("ColourTableRow");
                TableCell clubAndTeamNameCell = (TableCell)colourTableRow.FindControl("ClubAndTeamNameCell");
                Label clubNameLabel = (Label)clubAndTeamNameCell.FindControl("ClubNameLabel");
                Label teamNameLabel = (Label)clubAndTeamNameCell.FindControl("TeamNameLabel");
                clubNameLabel.Text = club.Name;
                teamNameLabel.Text = team.Name;

                TableCell colourPrimaryCell = (TableCell)colourTableRow.FindControl("ColourPrimaryCell");
                if (club.ColourPrimary != null) {
                    colourPrimaryCell.BackColor = Color.FromName(club.ColourPrimary.ToString());
                }
                TableCell colourSecondaryCell = (TableCell)colourTableRow.FindControl("ColourSecondaryCell");
                if (club.ColourSecondary != null) {
                    colourSecondaryCell.BackColor = Color.FromName(club.ColourSecondary.ToString());
                }
            }
        }

 
        protected void MakeDrawButton_Click(object sender, EventArgs e) {

        }

	}


}



