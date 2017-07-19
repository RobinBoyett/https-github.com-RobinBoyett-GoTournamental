using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;


namespace GoTournamental.UI.Organiser {

	public partial class About : Page {

		AdvertPanel advert120x600 = new AdvertPanel();

		protected void Page_Load(object sender, EventArgs e) {

			advert120x600 = (AdvertPanel)AboutPanel.FindControl("Advert120x600");
			advert120x600.graphicFileStyle = Advert.GraphicFileStyles.Advert120By600;
			advert120x600.tournamentID = 0;

		}

	}

}