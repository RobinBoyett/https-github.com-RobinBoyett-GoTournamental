using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoTournamental.API.Identity;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Admin 
{

    public partial class ContactUsList : Page 
    {

        #region Declare Domain Objects & Page Variables
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
		IFeedback iContactUs = new Feedback();
		List<Feedback> queryList = new List<Feedback>();
		#endregion

        #region Declare page controls

		#endregion
		
        protected void Page_Load(object sender, EventArgs e)
        {

			queryList = iContactUs.SQLSelectAll<Feedback>();

			ContactUsListGridView.DataSource = queryList;
			ContactUsListGridView.DataBind();

        }

        protected void ContactUsListGridView_RowDataBound(Object sender, GridViewRowEventArgs e) 
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                Feedback query = (Feedback)e.Row.DataItem;
                if (query.FeedbackDate.HasValue && query.FeedbackDate != null) 
                {
				    e.Row.Cells[1].Text = query.FeedbackDate.Value.ToShortDateString();
                }
                e.Row.Cells[2].Text = query.FirstName + ' ' + query.LastName;
				if (query.AdditionalInformation.Length >= 50) 
                {
					e.Row.Cells[4].Text = query.AdditionalInformation.Substring(0,50);
				}
				else 
                {
					e.Row.Cells[4].Text = query.AdditionalInformation;
				}
            }
        }
   
	}

}



