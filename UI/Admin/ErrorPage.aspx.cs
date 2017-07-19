using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoTournamental.BLL.Organiser;


namespace GoTournamental.UI.Organiser {

    public partial class ErrorPage : Page {

        #region Declare Domain Objects & Page Variables
        private ErrorType errorType = ErrorType.Undefined;
        protected enum ErrorType {
            Undefined = 0,
            PageNotFound = 1
        }
        #endregion

        #region Declare page controls
        Label errorName = new Label();
        Label errorDescription = new Label();
        #endregion

        protected void Page_Load(object sender, EventArgs e) {

            AssignControlsAll();

            if (Request.QueryString.Get("Error") != null) {
                errorType = (ErrorType)Int32.Parse(Request.QueryString.Get("Error"));
            }
            ManagePageVersion(errorType);

        }

        protected void AssignControlsAll() {
            errorName = (Label)ErrorPanel.FindControl("ErrorName");
            errorDescription = (Label)ErrorPanel.FindControl("ErrorDescription");
        }

        protected void ManagePageVersion(ErrorType errorType) {
            switch (errorType) {
                case ErrorType.PageNotFound:
                    errorName.Text = "Page Not Found";
                    errorDescription.Text = "The page you asked for has not been found - are you sure the address requested is correct?";
                    break;
                default:
                    errorName.Text = "GoTournamental has encountered an error";
                    errorDescription.Text = "The error has been logged - if you are a registered user, we will contact you as soon as possible.";
                    break;

            }
        }


    }

}