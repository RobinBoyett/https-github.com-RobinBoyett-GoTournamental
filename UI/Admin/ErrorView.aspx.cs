using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;


namespace GoTournamental.UI.Organiser {

    public partial class ErrorView : Page {

        #region Declare Domain Objects & Page Variables
        IExceptionHandler iExceptionHandler = new ExceptionHandler();
        ExceptionHandler exceptionHandler = new ExceptionHandler();
	    GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        int exceptionID = 0;

        private RequestVersion pageVersion = RequestVersion.Undefined;
        protected enum RequestVersion {
            Undefined = 0,
            ErrorView = 1,
            ErrorDelete = 2
        }
        #endregion

        #region Declare page controls
        Label exceptionIDLabel = new Label();
        Label user = new Label();
        HyperLink mailToLink = new HyperLink();
        Label loggedDate = new Label();
        Label typeName = new Label();
        Label message = new Label();
        Label stackTrace = new Label();
        #endregion

        protected void Page_Load(object sender, EventArgs e) {

            if (Request.QueryString.Get("ID") != null) {
                exceptionID = Int32.Parse(Request.QueryString.Get("ID"));
                exceptionHandler = iExceptionHandler.SQLSelect<ExceptionHandler, int>(exceptionID);
            }
            if (Request.QueryString.Get("Version") != null) {
                pageVersion = (RequestVersion)Int32.Parse(Request.QueryString.Get("Version"));
            }

            AssignControlsAll();
            ManagePageVersion(pageVersion);

        }

        protected void AssignControlsAll() {
            exceptionIDLabel = (Label)ErrorViewPanel.FindControl("ExceptionIDLabel");
            user = (Label)ErrorViewPanel.FindControl("User");
            mailToLink = (HyperLink)ErrorViewPanel.FindControl("MailToLink");
            loggedDate = (Label)ErrorViewPanel.FindControl("LoggedDate");
            typeName = (Label)ErrorViewPanel.FindControl("TypeName");
            message = (Label)ErrorViewPanel.FindControl("Message");
            stackTrace = (Label)ErrorViewPanel.FindControl("StackTrace");
        }

        protected void ManagePageVersion(RequestVersion pageVersion) {
            switch (pageVersion) {
                case RequestVersion.ErrorDelete:
                    ErrorDelete();
                    break;
                case RequestVersion.ErrorView:
                    ErrorViewPanelLoad();
                    break;
            }
        }

        protected void ErrorViewPanelLoad() {
            exceptionIDLabel.Text = exceptionHandler.ID.ToString();
            user.Text = identityHelper.GetUserName(exceptionHandler.UserID);
            mailToLink.NavigateUrl = "mailto:" + identityHelper.GetUserEmail(exceptionHandler.UserID) + "?subject=RE: GoTournamental error logged on " + exceptionHandler.LoggedDate.ToShortDateString();
            loggedDate.Text = exceptionHandler.LoggedDate.ToString();
            typeName.Text = exceptionHandler.TypeName;
            message.Text = exceptionHandler.Message;
            stackTrace.Text = exceptionHandler.StackTrace;
        }

        protected void ErrorDelete() {
            iExceptionHandler.SQLDelete(exceptionHandler);
            Response.Redirect("ErrorsList.aspx");
        }

        protected void DeleteButton_Click(object sender, EventArgs e) {
            ErrorDelete();
        }

    }



}