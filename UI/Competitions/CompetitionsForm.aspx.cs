using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using GoTournamental.BLL.Planner;

namespace GoTournamental.UI.Organiser 
{

    public partial class CompetitionsForm : Page
    {

        #region Declare Domain Objects & Page Variables
 		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
 		List<Competition> competitions = new List<Competition>();
		ICompetition iCompetition = new Competition();
		List<Club> clubs = new List<Club>();
		IClub iClub = new Club();
		List<GoTournamental.BLL.Organiser.Contact> contacts = new List<GoTournamental.BLL.Organiser.Contact>();
		GoTournamental.BLL.Organiser.IContact iContact = new GoTournamental.BLL.Organiser.Contact();

        private RequestVersion pageVersion = RequestVersion.Undefined;
        protected enum RequestVersion
        {
            Undefined = 0,
            SponsorInsert = 1,
            SponsorEdit = 2
        }
        #endregion
        #region Declare page controls
		Label competitionsFormTitle = new Label();
		CheckBoxList ageBandsList = new CheckBoxList();
		#endregion

        protected void Page_Load(object sender, EventArgs e) 
        {

            AssignControlsAll();

			if (Request.QueryString.Get("TournamentID") != null) 
            {
	            tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
				competitionsFormTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
				competitions = iCompetition.SQLSelectForTournament(tournament.ID, false);
				clubs = iClub.SQLSelectClubsForTournament(tournament.ID);
				contacts = iContact.SQLSelectForTournament(tournament.ID);
            }

			competitions = iCompetition.SQLSelectForTournament(tournament.ID, false);
			Array enumValues = Enum.GetValues(typeof(Competition.AgeBands));
			if (ageBandsList.Items.Count < 2) 
            {
				foreach (Enum type in enumValues) 
                {
					if (EnumExtensions.GetIntValue(type) > 0) 
                    {
						ageBandsList.Items.Add(new ListItem("&nbsp;" + EnumExtensions.GetStringValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
					}
				}
			}
			for (int i = 0; i < ageBandsList.Items.Count; i++ )
            {
				foreach (Competition competition in competitions)
                {
					if (ageBandsList.Items[i].Value == EnumExtensions.GetIntValue(competition.AgeBand).ToString()) 
                    {
						ageBandsList.Items[i].Selected = true; 
					}
				}
			}


        }
		protected void AssignControlsAll()
        {
			competitionsFormTitle = (Label)CompetitionsFormPanel.FindControl("CompetitionsFormTitle");
			ageBandsList = (CheckBoxList)CompetitionsFormPanel.FindControl("AgeBandsList");
		}

        protected void SaveButton_Click(object sender, EventArgs e) 
        {
            if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString()))
            {

			    foreach (ListItem li in ageBandsList.Items) 
                {
				    if (li.Selected == true) 
                    {

					    bool ageBandExists = true;
					    ageBandExists = iCompetition.SQLAgeBandExistsForTournament(tournament.ID, (Competition.AgeBands)Int32.Parse(li.Value));

					    if (ageBandExists == false)
                        {
						    Competition competition = new Competition(
							    tournamentID : tournament.ID , 
							    ageBand : (Competition.AgeBands)Int32.Parse(li.Value)
						    );
						    iCompetition.SQLInsert<Competition>(competition);
					    }

				    }

			    }
            }
            Response.Redirect("~/UI/Competitions/CompetitionsList.aspx?TournamentID="+tournament.ID.ToString());

        }

    }

}

