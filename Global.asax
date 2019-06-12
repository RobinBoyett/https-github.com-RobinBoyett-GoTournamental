<%@ Application Language="C#" %>
<%@ Import Namespace="GoTournamental" %>
<%@ Import Namespace="GoTournamental.API.Identity" %>
<%@ Import Namespace="GoTournamental.API.Utilities" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);

        GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();

        identityHelper.CreateRole("Administrator");
        identityHelper.CreateRole("TournamentOwner");
        identityHelper.CreateRole("TournamentOwnerPremium");

        identityHelper.CreateUserWithRole("Admin", "Pellings136", "admin@gotournamental.com", "Administrator");

        identityHelper.CreateUser("Rob", "Pellings136", "rob@gotournamental.com");
        identityHelper.CreateUser("Martin", "Pellings136", "martin@gotournamental.com");
        identityHelper.CreateUser("guest", "guest", "noreply@gotournamental.com");

        identityHelper.AddRoleForUser("Rob", "rob@gotournamental.com", "TournamentOwner");
        identityHelper.AddRoleForUser("Rob", "rob@gotournamental.com", "TournamentOwnerPremium");
        identityHelper.AddRoleForUser("Martin", "martin@gotournamental.com", "TournamentOwner");
        identityHelper.AddRoleForUser("Martin", "martin@gotournamental.com", "TournamentOwnerPremium");

    }

    protected void Application_Error(object sender, EventArgs e) {

        string redirectAddress = "";
        HttpException httpException = Server.GetLastError() as HttpException;
        Exception exception = httpException;
        if (httpException.InnerException != null)
        {
            exception = httpException.InnerException;
        }
        IExceptionHandler iExceptionHandler = new ExceptionHandler();
        ExceptionHandler exceptionToSave = new ExceptionHandler(
            id: 0,
            userID: HttpContext.Current.User.Identity.GetUserId(),
            userIPAddress: HttpContext.Current.Request.UserHostAddress,
            loggedDate: DateTime.Now,
            referringURL: HttpContext.Current.Request.UrlReferrer != null ? HttpContext.Current.Request.UrlReferrer.AbsolutePath : "no URLReferrer recorded",
            requestedURL: HttpContext.Current.Request.Url.ToString(),
            typeName: exception.GetType().ToString(),
            message: exception.Message,
            stackTrace: exception.StackTrace
        );
        redirectAddress = iExceptionHandler.HandleApplicationError(exceptionToSave);
        if (redirectAddress != "")
        {
            Response.Redirect(redirectAddress);
        }

    }

</script>
