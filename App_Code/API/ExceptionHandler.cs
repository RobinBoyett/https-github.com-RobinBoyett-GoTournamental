using System;
using System.Linq;
using System.Collections.Generic;
using GoTournamental.API.Interface;
using GoTournamental.API.Utilities;
using GoTournamental.ORM.Utilities;

namespace GoTournamental.API.Utilities {

    public class ExceptionHandler : IExceptionHandler {

        #region Constructor
        public ExceptionHandler() { }
        public ExceptionHandler(
            int id, string userID, string userIPAddress, DateTime loggedDate, string referringURL, string requestedURL, string typeName, string message, string stackTrace
        ) {
            this.ID = id;
            this.UserID = userID;
            this.UserIPAddress = userIPAddress;
            this.LoggedDate = loggedDate;
            this.ReferringURL = referringURL;
            this.RequestedURL = requestedURL;
            this.TypeName = typeName;
            this.Message = message;
            this.StackTrace = stackTrace;
        }
        #endregion

        #region Properties
        public int ID { get; set; }
        public string UserID { get; set; }
        public string UserIPAddress { get; set; }
        public DateTime LoggedDate { get; set; }
        public string ReferringURL { get; set; }
        public string RequestedURL { get; set; }
        public string TypeName { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        #endregion

        #region Methods
        public void SQLInsert<T>(T input) {
            if (ObjectExtensions.ObjectTypesMatch<ExceptionHandler, T>(input)) {
                ExceptionHandlerDbContext context = new ExceptionHandlerDbContext();
                context.ExceptionHandlers.Add((ExceptionHandler)(object)input);
                context.SaveChanges();
            }
        }
        public T SQLSelect<T, U>(U id) {
            ExceptionHandlerDbContext context = new ExceptionHandlerDbContext();
            ExceptionHandler selected = context.ExceptionHandlers.Where(i => i.ID == (int)(object)id).SingleOrDefault();
            return (T)(object)selected;
        }
        public List<T> SQLSelectAll<T>() {
            ExceptionHandlerDbContext context = new ExceptionHandlerDbContext();
            List<ExceptionHandler> exceptions = context.ExceptionHandlers.ToList();
            List<T> selectedTList = new List<T>();
            foreach (ExceptionHandler ex in exceptions) {
                selectedTList.Add((T)((object)ex));
            }
            return selectedTList;
        }
        public void SQLDelete<T>(T input) {
            if (ObjectExtensions.ObjectTypesMatch<ExceptionHandler, T>(input)) {
                ExceptionHandlerDbContext context = new ExceptionHandlerDbContext();
                ExceptionHandler itemToDelete = (ExceptionHandler)(object)input;
                ExceptionHandler selected = context.ExceptionHandlers.Single(i => i.ID == itemToDelete.ID);
                context.ExceptionHandlers.Remove(selected);
                context.SaveChanges();
            }
        }
        

        public string HandleApplicationError(ExceptionHandler errorToHandle) {
            string redirectAddress = "";
            switch (errorToHandle.TypeName) {                                                        
                case "System.Web.HttpException":
                    if (errorToHandle.RequestedURL.Contains("This is an invalid script resource request")) {
                        // This is probably a search engine robot - ignore it
                    }
                    else if (errorToHandle.RequestedURL.Contains("This file") && errorToHandle.RequestedURL.Contains("does not exist")) {
                        this.SQLInsert<ExceptionHandler>(errorToHandle);   // broken link error - save it
                    }
                    break;
                default:
                    this.SQLInsert<ExceptionHandler>(errorToHandle);                               
                    break;
            }
            return redirectAddress;
        }
        
        #endregion

    }
    public interface IExceptionHandler : ISQLInsertable, ISQLSelectable, ISQLAllSelectable, ISQLDeletable {
        int ID { get; }
        string UserID { get; }
        string UserIPAddress { get; }
        DateTime LoggedDate { get; }
        string ReferringURL { get; }
        string RequestedURL { get; }
        string TypeName { get; }
        string Message { get; }
        string StackTrace { get; }
        string HandleApplicationError(ExceptionHandler errorToHandle);
    }

}