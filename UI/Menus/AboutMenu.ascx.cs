using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

public partial class AboutMenu : System.Web.UI.UserControl {

    #region Declare Domain Objects & Page Variables
    Tournament tournament = new Tournament();
    ITournament iTournament = new Tournament();
	List<Competition> competitions = new List<Competition>();
	ICompetition iCompetition = new Competition();
	//List<Club> clubs = new List<Club>();
	//IClub iClub = new Club();
	List<Contact> contacts = new List<Contact>();
	IContact iContact = new Contact();
	#endregion
		
	#region Declare UI Controls

	#endregion

	protected void Page_Load(object sender, EventArgs e) {

		AssignUIControls();



	}
	protected void AssignUIControls() {
		//linkToTournament = (HyperLink)TournamentNavigationPanel.FindControl("LinkToTournament");

	}


}
