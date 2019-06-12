using System;
using System.Web.UI;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser
{

	public partial class GDPR : Page 
    {

		AdvertPanel advert300x250 = new AdvertPanel();

		protected void Page_Load(object sender, EventArgs e) 
        {

			advert300x250 = (AdvertPanel)GDPRPanel.FindControl("Advert300x250");
			advert300x250.graphicFileStyle = Advert.GraphicFileStyles.Advert300By250;
			advert300x250.tournamentID = 0;

		}

	}

}