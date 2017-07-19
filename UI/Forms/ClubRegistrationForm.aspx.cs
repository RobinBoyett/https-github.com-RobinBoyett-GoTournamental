using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser {

    public partial class ClubRegistrationForm : Page {


        protected void Page_Load(object sender, EventArgs e) {

            if (Request.Url != null) {
                string newURL = Request.Url.ToString();
                newURL = newURL.Replace("/Forms/","/Clubs/");
                Response.Redirect(newURL);
            }
		}



    }

}

