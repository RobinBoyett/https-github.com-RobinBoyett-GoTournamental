using System;
using System.Web.UI.WebControls;
using System.IO;
using GoTournamental.BLL.Organiser;


namespace GoTournamental.UI.Organiser 
{

    public partial class AdvertPanel : System.Web.UI.UserControl 
    {

        private Advertiser advertiser = new Advertiser();
        private IAdvertiser iAdvertiser = new Advertiser();
		private Advert advert = new Advert();
		private IAdvert iAdvert = new Advert();
		public Advert.GraphicFileStyles graphicFileStyle = Advert.GraphicFileStyles.Undefined;
		public int tournamentID = 0;

		protected void Page_Load(object sender, EventArgs e) 
        {
			Image advertImage = (Image)AdvertImagePanel.FindControl("AdvertImage");
			advert = iAdvert.GetAdvert(graphicFileStyle, tournamentID);
			if (File.Exists(Server.MapPath(advert.GraphicFilePath))) 
            {
				advertImage.ImageUrl = advert.GraphicFilePath;
			}
			else 
            {
				AdvertImagePanel.Visible = false;
			}

		}

		protected void AdvertLink_Click(object sender, EventArgs e) 
        {
            advertiser = iAdvertiser.SQLSelect<Advertiser, int>(advert.AdvertiserID);
			iAdvert.AddClickThrough(advert.ID);
			Response.Write("<script>");
			Response.Write("window.open('"+advertiser.WebsiteURL+"','_blank')");
			Response.Write("</script>");
		}

	}

}
