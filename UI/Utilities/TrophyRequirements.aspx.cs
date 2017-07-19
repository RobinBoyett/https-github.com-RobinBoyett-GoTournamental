using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser {

    public partial class TrophyRequirements : Page {

        #region Declare Domain Objects & Page Variables
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();

		#endregion

        #region Declare page controls
		Label trophyRequirementsTitle = new Label();
		#endregion
		
        protected void Page_Load(object sender, EventArgs e) {

            AssignControlsAll();


        }

		protected void AssignControlsAll() {
			trophyRequirementsTitle = (Label)TrophyRequirementsPanel.FindControl("SponsorsListTitle");
		}


   
	}

}



