using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser {

	public partial class WhoWeAre : Page {

		AdvertPanel advert300x250 = new AdvertPanel();

		protected void Page_Load(object sender, EventArgs e) {

			advert300x250 = (AdvertPanel)WhoWeArePanel.FindControl("Advert300x250");
			advert300x250.graphicFileStyle = Advert.GraphicFileStyles.Advert300By250;
			advert300x250.tournamentID = 0;

		}

	}

}