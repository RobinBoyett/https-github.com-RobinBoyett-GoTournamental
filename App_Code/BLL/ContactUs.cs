using System;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using OfficeOpenXml;
using GoTournamental.API.Cryptography;
using GoTournamental.API.Interface;
using GoTournamental.API.Utilities;
using GoTournamental.ORM.Organiser;

namespace GoTournamental.BLL.Organiser {

    public class ContactUs: IContactUs {

        #region Member Enumerations & Collections
        public enum Statuses {
            Undefined = 0,
            New = 1
        }
		#endregion

        #region Constructors
		public ContactUs() {}
		public ContactUs(
			int id, string firstName, string lastName, string email, string organisation, string telephoneNumber, Tournament.TournamentTypes tournamentType, string additionalInformation, DateTime? contactDate, Statuses status
		) {
			this.ID = id;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Email = email;
			this.Organisation = organisation;
			this.TelephoneNumber = telephoneNumber;
			this.TournamentType = tournamentType;
			this.AdditionalInformation = additionalInformation;
			this.ContactDate = contactDate;
			this.Status = status;
		}
		#endregion

        #region Properties
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Organisation { get; set; }
		public string TelephoneNumber { get; set; }
        public Tournament.TournamentTypes TournamentType { get; set; }
		public string AdditionalInformation { get; set; }
        public DateTime? ContactDate { get; set; }
		public Statuses Status { get; set; }
		#endregion

        #region Methods
        public void SQLInsert<T>(T input) {
            if (ObjectExtensions.ObjectTypesMatch<ContactUs, T>(input)) {
                ContactUsDbContext context = new ContactUsDbContext();
				ContactUs contactUs = (ContactUs)(object)input;
                ConvertContactUsZeroLengthsStringsToNull(contactUs);
                EncryptPersonalData(contactUs);
                context.ContactedUs.Add(contactUs);
                context.SaveChanges();
            }
        }
        public T SQLSelect<T, U>(U id) {
            ContactUsDbContext context = new ContactUsDbContext();
            ContactUs selected = context.ContactedUs.Where(i => i.ID == (int)(object)id).SingleOrDefault();
            if (selected != null) {
                DecryptPersonalData(selected);
            }
            return (T)(object)selected;
        }
        public List<T> SQLSelectAll<T>() {
            ContactUsDbContext context = new ContactUsDbContext();
            IEnumerable<ContactUs> selectedList = context.ContactedUs.ToList();
            List<T> selectedTList = new List<T>();
            foreach (ContactUs cu in selectedList) {
                DecryptPersonalData(cu);
                selectedTList.Add((T)((object)cu));
            }
            return selectedTList;
        }
        public void SQLUpdate<T>(T input) {
            if (ObjectExtensions.ObjectTypesMatch<ContactUs, T>(input)) {
                ContactUsDbContext context = new ContactUsDbContext();
                ContactUs updated = (ContactUs)(object)input;
                ConvertContactUsZeroLengthsStringsToNull(updated);
                ContactUs selected = context.ContactedUs.Single(i => i.ID == updated.ID);
                selected.AdditionalInformation = updated.AdditionalInformation;
                selected.Status = updated.Status;
                context.SaveChanges();
            }
        }
		public void SQLDelete<T>(T input) {
			if (ObjectExtensions.ObjectTypesMatch<ContactUs, T>(input)) {
				ContactUsDbContext context = new ContactUsDbContext();
				ContactUs itemToDelete = (ContactUs)(object)input;	
				ContactUs selected = context.ContactedUs.Single(i => i.ID == itemToDelete.ID);
                context.ContactedUs.Remove(selected);
                context.SaveChanges();
			}
		}

        private static ContactUs ConvertContactUsZeroLengthsStringsToNull(ContactUs contactUs) {
            if (contactUs.FirstName == "") {
                contactUs.FirstName = null;
            };
            if (contactUs.LastName == "") {
                contactUs.LastName = null;
            };
            if (contactUs.Email == "") {
                contactUs.Email = null;
            };
            if (contactUs.Organisation == "") {
                contactUs.Organisation = null;
            };
            if (contactUs.TelephoneNumber == "") {
                contactUs.TelephoneNumber = null;
            };
            return contactUs;
        } 
        public static ContactUs EncryptPersonalData(ContactUs unencrypted) {
            ContactUs encrypted = unencrypted;
			encrypted.FirstName = GoTournamentalCryptography.Encrypt(encrypted.FirstName, GoTournamentalCryptography.TournamentPassword());
			encrypted.LastName = GoTournamentalCryptography.Encrypt(encrypted.LastName, GoTournamentalCryptography.TournamentPassword());
            if (encrypted.TelephoneNumber != null) {
    			encrypted.TelephoneNumber = GoTournamentalCryptography.Encrypt(encrypted.TelephoneNumber, GoTournamentalCryptography.TournamentPassword());
            }
            if (encrypted.Email != null) {
    			encrypted.Email = GoTournamentalCryptography.Encrypt(encrypted.Email, GoTournamentalCryptography.TournamentPassword());
            }
            return encrypted;
        }
        public static ContactUs DecryptPersonalData(ContactUs encrypted) {
            ContactUs decrypted = encrypted;
            decrypted.FirstName = GoTournamentalCryptography.Decrypt(encrypted.FirstName, GoTournamentalCryptography.TournamentPassword());
            decrypted.LastName = GoTournamentalCryptography.Decrypt(encrypted.LastName, GoTournamentalCryptography.TournamentPassword());
            decrypted.TelephoneNumber = GoTournamentalCryptography.Decrypt(encrypted.TelephoneNumber, GoTournamentalCryptography.TournamentPassword());
            decrypted.Email = GoTournamentalCryptography.Decrypt(encrypted.Email, GoTournamentalCryptography.TournamentPassword());
            return decrypted;
        } 	
		#endregion

    }
    public interface IContactUs: ISQLInsertable, ISQLSelectable, ISQLAllSelectable, ISQLUpdateable, ISQLDeletable {
        int ID { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        string Organisation { get; }
		string TelephoneNumber { get; }
        Tournament.TournamentTypes TournamentType { get; }
		string AdditionalInformation { get; }
		DateTime? ContactDate { get; }
		ContactUs.Statuses Status { get; }
    }

}

