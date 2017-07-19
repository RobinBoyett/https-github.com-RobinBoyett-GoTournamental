using System;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using OfficeOpenXml;
using GoTournamental.API.Interface;
using GoTournamental.API.Utilities;
using GoTournamental.ORM.Organiser;

namespace GoTournamental.BLL.Organiser {

    public class TermsSignatory: ITermsSignatory {

		#region Constructors
		public TermsSignatory() {}
        public TermsSignatory(int id, string userID, string userName) {
			this.ID = id;
            this.UserID = userID;
            this.UserName = userName;
		}
        #endregion

        #region Properties
        public int ID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        #endregion

        #region Methods
        public void SQLInsert<T>(T input) {
            if (ObjectExtensions.ObjectTypesMatch<TermsSignatory, T>(input)) {
                TermsSignatoryDbContext context = new TermsSignatoryDbContext();
                TermsSignatory existing = context.TermsSignatories.Where(i => i.UserID == ((TermsSignatory)(object)input).UserID).SingleOrDefault();
                if (existing == null) {
                    context.TermsSignatories.Add((TermsSignatory)(object)input);
                    context.SaveChanges();
                }
            }
        }
        public T SQLSelect<T, U>(U id) {
            TermsSignatoryDbContext context = new TermsSignatoryDbContext();
            TermsSignatory selected = context.TermsSignatories.Where(i => i.ID == (int)(object)id).SingleOrDefault();
            return (T)(object)selected;
        }
        public void SQLDelete<T>(T input) {
            if (ObjectExtensions.ObjectTypesMatch<TermsSignatory, T>(input)) {
                TermsSignatoryDbContext context = new TermsSignatoryDbContext();
                TermsSignatory itemToDelete = (TermsSignatory)(object)input;
                TermsSignatory selected = context.TermsSignatories.Single(i => i.ID == itemToDelete.ID);
                context.TermsSignatories.Remove(selected);
                context.SaveChanges();
            }
        }
		#endregion

    }
    public interface ITermsSignatory :ISQLInsertable, ISQLSelectable, ISQLDeletable {
        int ID { get; }
        string UserID { get; }
        string UserName { get; }
    }

}
