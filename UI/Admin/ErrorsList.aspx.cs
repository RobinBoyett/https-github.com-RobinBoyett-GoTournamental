using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;


namespace GoTournamental.UI.Organiser
{

    public partial class ErrorsList : Page 
    {

        #region Declare Domain Objects & Page Variables
        IExceptionHandler iExceptionHandler = new ExceptionHandler();
        List<ExceptionHandler> exceptionHandlers = new List<ExceptionHandler>();
	    GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        #endregion

        protected void Page_Load(object sender, EventArgs e) 
        {
            exceptionHandlers = iExceptionHandler.SQLSelectAll<ExceptionHandler>();
            ErrorsListGridView.DataSource = exceptionHandlers;
            ErrorsListGridView.DataBind();
        }

        protected void ErrorsListGridView_RowDataBound(Object sender, GridViewRowEventArgs e) 
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                ExceptionHandler thisRow = (ExceptionHandler)e.Row.DataItem;
                e.Row.Cells[2].Text = identityHelper.GetUserName(thisRow.UserID);
                HyperLink requestDeleteLink = (HyperLink)e.Row.FindControl("RequestDeleteLink");
                requestDeleteLink.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this error?')");
                requestDeleteLink.NavigateUrl = "ErrorView.aspx?Version=2&ID=" + thisRow.ID.ToString();
            }
        }

    }

}