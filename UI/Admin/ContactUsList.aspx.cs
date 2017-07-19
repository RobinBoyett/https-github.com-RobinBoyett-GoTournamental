using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Admin {

    public partial class ContactUsList : Page {

        #region Declare Domain Objects & Page Variables
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
		IContactUs iContactUs = new ContactUs();
		List<ContactUs> queryList = new List<ContactUs>();
		#endregion

        #region Declare page controls

		#endregion
		
        protected void Page_Load(object sender, EventArgs e) {

			queryList = iContactUs.SQLSelectAll<ContactUs>();

			ContactUsListGridView.DataSource = queryList;
			ContactUsListGridView.DataBind();

        }

        protected void ContactUsListGridView_RowDataBound(Object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                ContactUs query = (ContactUs)e.Row.DataItem;
                if (query.ContactDate.HasValue && query.ContactDate != null) {
				    e.Row.Cells[1].Text = query.ContactDate.Value.ToShortDateString();
                }
                e.Row.Cells[2].Text = query.FirstName + ' ' + query.LastName;
				if (query.AdditionalInformation.Length >= 50) {
					e.Row.Cells[4].Text = query.AdditionalInformation.Substring(0,50);
				}
				else {
					e.Row.Cells[4].Text = query.AdditionalInformation;
				}
            }
        }
   
	}

}



