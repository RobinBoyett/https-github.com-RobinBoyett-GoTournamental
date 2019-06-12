using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser 
{

    public partial class DocumentsList : Page 
    {

		//AdvertPanel advert300x600 = new AdvertPanel();

        #region Declare Domain Objects & Page Variables
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
		IDocument iDocument = new Document();
		List<Document> documentsList = new List<Document>();

		#endregion

        #region Declare page controls
		Label documentsListTitle = new Label();
		DataList documentsDataList = new DataList();
		#endregion
		
        protected void Page_Load(object sender, EventArgs e) 
        {

            AssignControlsAll();

            if (Request.QueryString.Get("TournamentID") != null) 
            {
				tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
 				documentsListTitle.Text = tournament.HostClub.Name + " " + tournament.Name;
			}

			documentsList = iDocument.GetDocumentsForTournament(tournament.ID);
			documentsDataList.DataSource = documentsList;
			documentsDataList.DataBind();

			//advert300x600 = (AdvertPanel)DocumentsListPanel.FindControl("Advert300x600");
			//advert300x600.graphicFileStyle = Advert.GraphicFileStyles.Advert300By600;
			//advert300x600.tournamentID = tournament.ID;

        }

		protected void AssignControlsAll()
        {
			documentsListTitle = (Label)DocumentsListPanel.FindControl("DocumentsListTitle");
			documentsDataList = (DataList)DocumentsListPanel.FindControl("DocumentsDataList");
		}

		protected void DocumentsDataList_ItemDataBound(Object sender, DataListItemEventArgs e)
        {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
				Document document = (Document)e.Item.DataItem;
				HyperLink documentLink = (HyperLink)e.Item.FindControl("DocumentLink");
				documentLink.Text = EnumExtensions.GetStringValue(document.DocumentType);
				documentLink.NavigateUrl = "~/Uploads/Tournament"+tournament.ID.ToString()+"/Documents/"+document.FileName;
			}
		}
 
	}

}



