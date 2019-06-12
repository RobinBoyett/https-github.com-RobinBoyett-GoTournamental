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

namespace GoTournamental.BLL.Organiser 
{

    public class Feedback: IFeedback 
    {

        #region Constructors
		public Feedback() {}
		public Feedback(
			int id, string firstName, string lastName, string email, string organisation, string telephoneNumber, Tournament.TournamentTypes tournamentType, string additionalInformation, DateTime? feedbackDate
		) 
        {
			this.ID = id;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Email = email;
			this.Organisation = organisation;
			this.TelephoneNumber = telephoneNumber;
			this.TournamentType = tournamentType;
			this.AdditionalInformation = additionalInformation;
			this.FeedbackDate = feedbackDate;
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
        public DateTime? FeedbackDate { get; set; }
		#endregion

        #region Methods
        public void SQLInsert<T>(T input) 
        {
            if (ObjectExtensions.ObjectTypesMatch<Feedback, T>(input)) 
            {
                FeedbackDbContext context = new FeedbackDbContext();
				Feedback feedback = (Feedback)(object)input;
                ConvertFeedbackZeroLengthsStringsToNull(feedback);
                EncryptPersonalData(feedback);
                context.Feedback.Add(feedback);
                context.SaveChanges();
            }
        }
        public T SQLSelect<T, U>(U id)
        {
            FeedbackDbContext context = new FeedbackDbContext();
            Feedback selected = context.Feedback.Where(i => i.ID == (int)(object)id).SingleOrDefault();
            if (selected != null)
            {
                DecryptPersonalData(selected);
            }
            return (T)(object)selected;
        }
        public List<T> SQLSelectAll<T>()
        {
            FeedbackDbContext context = new FeedbackDbContext();
            IEnumerable<Feedback> selectedList = context.Feedback.ToList();
            List<T> selectedTList = new List<T>();
            foreach (Feedback cu in selectedList)
            {
                DecryptPersonalData(cu);
                selectedTList.Add((T)((object)cu));
            }
            return selectedTList;
        }
        public void SQLUpdate<T>(T input)
        {
            if (ObjectExtensions.ObjectTypesMatch<Feedback, T>(input))
            {
                FeedbackDbContext context = new FeedbackDbContext();
                Feedback updated = (Feedback)(object)input;
                ConvertFeedbackZeroLengthsStringsToNull(updated);
                Feedback selected = context.Feedback.Single(i => i.ID == updated.ID);
                selected.AdditionalInformation = updated.AdditionalInformation;
                context.SaveChanges();
            }
        }
		public void SQLDelete<T>(T input) 
        {
			if (ObjectExtensions.ObjectTypesMatch<Feedback, T>(input)) 
            {
				FeedbackDbContext context = new FeedbackDbContext();
				Feedback itemToDelete = (Feedback)(object)input;	
				Feedback selected = context.Feedback.Single(i => i.ID == itemToDelete.ID);
                context.Feedback.Remove(selected);
                context.SaveChanges();
			}
		}

        private static Feedback ConvertFeedbackZeroLengthsStringsToNull(Feedback feedback)
        {
            if (feedback.FirstName == "") 
            {
                feedback.FirstName = null;
            };
            if (feedback.LastName == "") 
            {
                feedback.LastName = null;
            };
            if (feedback.Email == "") 
            {
                feedback.Email = null;
            };
            if (feedback.Organisation == "") 
            {
                feedback.Organisation = null;
            };
            if (feedback.TelephoneNumber == "") 
            {
                feedback.TelephoneNumber = null;
            };
            return feedback;
        } 
        public static Feedback EncryptPersonalData(Feedback unencrypted)
        {
            Feedback encrypted = unencrypted;
			encrypted.FirstName = GoTournamentalCryptography.Encrypt(encrypted.FirstName, GoTournamentalCryptography.TournamentPassword());
			encrypted.LastName = GoTournamentalCryptography.Encrypt(encrypted.LastName, GoTournamentalCryptography.TournamentPassword());
            if (encrypted.TelephoneNumber != null) 
            {
    			encrypted.TelephoneNumber = GoTournamentalCryptography.Encrypt(encrypted.TelephoneNumber, GoTournamentalCryptography.TournamentPassword());
            }
            if (encrypted.Email != null) 
            {
    			encrypted.Email = GoTournamentalCryptography.Encrypt(encrypted.Email, GoTournamentalCryptography.TournamentPassword());
            }
            return encrypted;
        }
        public static Feedback DecryptPersonalData(Feedback encrypted)
        {
            Feedback decrypted = encrypted;
            decrypted.FirstName = GoTournamentalCryptography.Decrypt(encrypted.FirstName, GoTournamentalCryptography.TournamentPassword());
            decrypted.LastName = GoTournamentalCryptography.Decrypt(encrypted.LastName, GoTournamentalCryptography.TournamentPassword());
            decrypted.TelephoneNumber = GoTournamentalCryptography.Decrypt(encrypted.TelephoneNumber, GoTournamentalCryptography.TournamentPassword());
            decrypted.Email = GoTournamentalCryptography.Decrypt(encrypted.Email, GoTournamentalCryptography.TournamentPassword());
            return decrypted;
        } 	
		#endregion

    }
    public interface IFeedback: ISQLInsertable, ISQLSelectable, ISQLAllSelectable, ISQLUpdateable, ISQLDeletable 
    {
        int ID { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        string Organisation { get; }
		string TelephoneNumber { get; }
        Tournament.TournamentTypes TournamentType { get; }
		string AdditionalInformation { get; }
		DateTime? FeedbackDate { get; }
    }

}

