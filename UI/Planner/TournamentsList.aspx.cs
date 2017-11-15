using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.API;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Planner {

    public partial class TournamentsList : Page {

        GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        List<Tournament> tournamentsList = new List<Tournament>();
        ITournament iTournament = new Tournament();
		Tournament.TournamentTypes selectedType = Tournament.TournamentTypes.Undefined;
		//AdvertPanel advert300By250 = new AdvertPanel();
        string searchFor = "";

        protected void Page_Load(object sender, EventArgs e) {
			DropDownList tournamentType = (DropDownList)TournamentsListPanel.FindControl("TournamentType");
            Array enumValues = Enum.GetValues(typeof(Tournament.TournamentTypes));
            if (tournamentType.Items.Count < 2) {
                foreach (Enum type in enumValues) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        tournamentType.Items.Add(new ListItem(EnumExtensions.GetStringValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
			if (!IsPostBack) {
				tournamentType.SelectedValue = EnumExtensions.GetIntValue(Tournament.TournamentTypes.FootballJunior).ToString();
			}
			selectedType = (Tournament.TournamentTypes)Int32.Parse(tournamentType.SelectedValue);
			TextBox searchText = (TextBox)TournamentsListPanel.FindControl("SearchText");
            if (IsPostBack) {
                searchFor = searchText.Text;
            }
            //if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated) {
                tournamentsList = iTournament.SQLSelectSearch(selectedType, searchFor);
            //}
            //else {
            //    tournamentsList = iTournament.SQLSelectSearch(selectedType, searchFor).Where(i => i.ID == 1).ToList();
            //}

            TournamentsListGridView.DataSource = tournamentsList;
            TournamentsListGridView.DataBind();

			//advert300By250 = (AdvertPanel)TournamentsListPanel.FindControl("Advert300By250");
			//advert300By250.graphicFileStyle = Advert.GraphicFileStyles.Advert300By250;
			//advert300By250.tournamentID = 0;
 
		}


        protected void TournamentsListGridView_RowDataBound(Object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                Tournament tournament = (Tournament)e.Row.DataItem;
                HyperLink tournamentLink = (HyperLink)e.Row.FindControl("TournamentLink");
                string linkText = "";
                if (tournament.HostClub != null) {
                    linkText = tournament.HostClub.Name;
                }
                linkText += " - " + tournament.Name;
                tournamentLink.Text = linkText;
                tournamentLink.NavigateUrl = "/UI/Planner/TournamentView.aspx?TournamentID="+tournament.ID.ToString();
                //if (tournament.DaysDuration > 1) {
                e.Row.Cells[1].Text = String.Format("{0:MMMM d, yyyy}", tournament.StartTime);
                //}
                //else {
                //    e.Row.Cells[1].Text = String.Format("{0:MMMM d, yyyy}", tournament.StartTime);
                //}
            }
        }

    }

}

