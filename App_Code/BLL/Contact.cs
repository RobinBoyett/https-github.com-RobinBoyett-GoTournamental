using System;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel;
using OfficeOpenXml;
using GoTournamental.API.Cryptography;
using GoTournamental.API.Interface;
using GoTournamental.API.Utilities;
using GoTournamental.ORM.Organiser;

namespace GoTournamental.BLL.Organiser {

    public class Contact: IContact {

        #region Member Enumerations & Collections
        public enum ContactTypes {
            Undefined = 0,
            [DescriptionAttribute("Tournament Organiser")] TournamentOrganiser = 1,
            [DescriptionAttribute("Tournament Contact")] TournamentContact = 2,
            [DescriptionAttribute("Club Contact")] ClubContact = 3,
            [DescriptionAttribute("Team Contact")] TeamContact = 4,
            Player = 6,
            [DescriptionAttribute("Referee")] PrimaryFixtureOfficial = 6,
            [DescriptionAttribute("Assistant Referee 1")] AssistantFixtureOfficial1 = 7,
            [DescriptionAttribute("Assistant Referee 2")] AssistantFixtureOfficial2 = 8,
            [DescriptionAttribute("Caterer")] Caterer = 9,
            [DescriptionAttribute("Printer")] Printer = 10,
            [DescriptionAttribute("Photographer")] Photographer = 11,
            [DescriptionAttribute("Car Park Marshall")] CarParkMarshall = 12
        }
        #endregion
        
        #region Constructors
        public Contact() { }
        public Contact(
            int id, int tournamentID, ContactTypes type, string title, string firstName, string lastName, string telephoneNumber, string email, 
            DateTime? dateOfBirth, int? squadNumber
        ) {
			this.ID = id;
			this.TournamentID = tournamentID;
			this.Type = type;
			this.Title = title;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.TelephoneNumber = telephoneNumber;
			this.Email = email;
		}
        #endregion

        #region Properties
        public int ID { get; set; }
        public int TournamentID { get; set; }
        public ContactTypes Type { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? SquadNumber { get; set; }
        #endregion

        #region Methods
        public override string ToString() {
            return string.Format("{0} {1} {2}", Title, FirstName, LastName);
        }
        public void SQLInsert<T>(T input) {
            if (ObjectExtensions.ObjectTypesMatch<Contact, T>(input)) {
                ContactDbContext context = new ContactDbContext();
                Contact contact = (Contact)(object)input;
                ConvertContactZeroLengthsStringsToNull(contact);
                EncryptPersonalData(contact);
                context.Contacts.Add(contact);
                context.SaveChanges();
            }
        }       	
        public int SQLInsertAndReturnID<T>(T input) {
            int ret = 0;
            if (ObjectExtensions.ObjectTypesMatch<Contact, T>(input)) {
                ContactDbContext context = new ContactDbContext();
                Contact contact = (Contact)(object)input;
                ConvertContactZeroLengthsStringsToNull(contact);
                EncryptPersonalData(contact);
                context.Contacts.Add(contact);
                context.SaveChanges();
                ret = ((Contact)(object)input).ID;
            }
            return ret;
        }		
		public T SQLSelect<T, U>(U id) {
            ContactDbContext context = new ContactDbContext();
            Contact selected = context.Contacts.Where(i => i.ID == (int)(object)id).SingleOrDefault();
            if (selected != null) {
                DecryptPersonalData(selected);
            }
            return (T)(object)selected;
        }
        public List<Contact> SQLSelectForTournament(int tournamentID) {
            ContactDbContext context = new ContactDbContext();
            List<Contact> contactsList = context.Contacts.Where(i => i.TournamentID == tournamentID).OrderBy(i => i.LastName).ThenBy(i => i.FirstName).ToList();
            foreach (Contact contact in contactsList) {
                DecryptPersonalData(contact);
            }
            return contactsList;
        }
		public Contact GetTournamentContact(int tournamentID) {
            ContactDbContext context = new ContactDbContext();
			Contact contact = context.Contacts.Where(i => i.TournamentID == tournamentID && i.Type == ContactTypes.TournamentContact).SingleOrDefault();
            if (contact != null) {
                DecryptPersonalData(contact);
            }
            return contact;
		}
		public void SQLUpdate<T>(T input) {
            if (ObjectExtensions.ObjectTypesMatch<Contact, T>(input)) {
                ContactDbContext context = new ContactDbContext();
                Contact updated = (Contact)(object)input;
                ConvertContactZeroLengthsStringsToNull(updated);
                EncryptPersonalData(updated);
                Contact selected = context.Contacts.Single(i => i.ID == updated.ID);
                selected.Type = updated.Type;
				selected.FirstName = updated.FirstName;
 				selected.LastName = updated.LastName;
				selected.TelephoneNumber = updated.TelephoneNumber;
				selected.Email = updated.Email;
                selected.DateOfBirth = updated.DateOfBirth;
                selected.SquadNumber = updated.SquadNumber;
                context.SaveChanges();
            }
        }		
		
        private static Contact ConvertContactZeroLengthsStringsToNull(Contact contact) {
            if (contact.FirstName == "") {
                contact.FirstName = null;
            };
            if (contact.LastName == "") {
                contact.LastName = null;
            };
            if (contact.TelephoneNumber == "") {
                contact.TelephoneNumber = null;
            };
            if (contact.Email == "") {
                contact.Email = null;
            };
            return contact;
        } 
        public static Contact EncryptPersonalData(Contact unencrypted) {
            Contact encrypted = unencrypted;
            encrypted.FirstName = GoTournamentalCryptography.Encrypt(encrypted.FirstName, GoTournamentalCryptography.TournamentPassword(encrypted.TournamentID));
            encrypted.LastName = GoTournamentalCryptography.Encrypt(encrypted.LastName, GoTournamentalCryptography.TournamentPassword(encrypted.TournamentID));
            if (encrypted.TelephoneNumber != null && encrypted.TelephoneNumber != "") {
			    encrypted.TelephoneNumber = GoTournamentalCryptography.Encrypt(encrypted.TelephoneNumber, GoTournamentalCryptography.TournamentPassword(encrypted.TournamentID));
            }
            if (encrypted.Email != null && encrypted.Email != "") {
    			encrypted.Email = GoTournamentalCryptography.Encrypt(encrypted.Email, GoTournamentalCryptography.TournamentPassword(encrypted.TournamentID));
            }
            return encrypted;
        }
        public static Contact DecryptPersonalData(Contact encrypted) {
            Contact decrypted = encrypted;
            decrypted.FirstName = GoTournamentalCryptography.Decrypt(encrypted.FirstName, GoTournamentalCryptography.TournamentPassword(decrypted.TournamentID));
            decrypted.LastName = GoTournamentalCryptography.Decrypt(encrypted.LastName, GoTournamentalCryptography.TournamentPassword(decrypted.TournamentID));
            decrypted.TelephoneNumber = GoTournamentalCryptography.Decrypt(encrypted.TelephoneNumber, GoTournamentalCryptography.TournamentPassword(decrypted.TournamentID));
            decrypted.Email = GoTournamentalCryptography.Decrypt(encrypted.Email, GoTournamentalCryptography.TournamentPassword(decrypted.TournamentID));
            return decrypted;
        }        
        #endregion

    }

    public interface IContact : ISQLInsertable, ISQLInsertableReturningID, ISQLSelectable, ISQLUpdateable  {
        int ID { get; }
        int TournamentID { get; }
        Contact.ContactTypes Type { get; }
        string Title { get; }
        string FirstName { get; }
        string LastName { get; }
        string TelephoneNumber { get; }
        string Email { get; }
        DateTime? DateOfBirth { get; }
        int? SquadNumber { get; }
        List<Contact> SQLSelectForTournament(int tournamentID);
		Contact GetTournamentContact(int tournamentID);
    }

}