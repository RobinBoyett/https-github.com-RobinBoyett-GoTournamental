using System;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using GoTournamental.API.Interface;
using GoTournamental.API.Utilities;
using GoTournamental.ORM.Organiser;

namespace GoTournamental.BLL.Organiser {

    public class AdministrativeTask: IAdministrativeTask {

		#region Member Enumerations & Collections
        public enum TaskTypes {
            Undefined = 0,
            Participation = 1,
            Facilities = 2,
            Communication = 3,
            Catering = 4,
            Safety = 5
        }
        public enum ParticipationTaskTypes {
            Undefined = 0,
            [DescriptionAttribute("Invite Clubs")] ParticipantInvitiation = 1,
            [DescriptionAttribute("Collect Fees")] FeeCollection = 2,
            [DescriptionAttribute("Order Trophies")] Trophies = 3,
            [DescriptionAttribute("Book Match Officials")] MatchOfficials = 4
        }
		public enum FacilitiesTaskTypes {
            Undefined = 0,
            [DescriptionAttribute("Transport Access, Road Closures etc")] TransportAccess = 1,
            Parking = 2,
            Toilets = 3,
            [DescriptionAttribute("Mark Out and Check Pitches etc")] PlayingAreaSetUp = 4,
            [DescriptionAttribute("Public Address System")] PublicAddress = 5,
            [DescriptionAttribute("Litter Collection")] LitterCollection = 6
        } 
        public enum CommunicationTaskTypes {
            Undefined = 0,
            [DescriptionAttribute("Liaison With Neighbours etc")] NeighbourLiaison = 1,
            [DescriptionAttribute("Advertising And Sponsorship")] AdvertisingAndSponsorship = 2,
            [DescriptionAttribute("Press Coverage")] PressCoverage = 3,
            Photography = 4,
            [DescriptionAttribute("Programme Printing")] ProgrammePrinting = 5
        }
        public enum CateringTaskTypes {
            Undefined = 0
        }
        public enum SafetyTaskTypes {
            Undefined = 0,
            Insurance = 1,
            [DescriptionAttribute("First Aid")] FirstAid = 2
        }
        public enum TaskStatuses {
            Undefined = 0,
            NotRequired = 1,
            Allocated = 2,
            Ongoing = 3,
            Completed = 4
        }
		#endregion

		#region Constructors
		public AdministrativeTask() {}
        public AdministrativeTask(int id, int tournamentID, TaskTypes taskType, int typeID, TaskStatuses taskStatus) {
            this.ID = id;
            this.TournamentID = tournamentID;
            this.TaskType = taskType;
            this.TypeID = typeID;
            this.TaskStatus = taskStatus;
        }
        #endregion

        #region Properties
        public int ID { get; set; }
        public int TournamentID { get; set; }
        public TaskTypes TaskType { get; set; }
        public int TypeID { get; set; }
        public TaskStatuses TaskStatus { get; set; }
        #endregion

        #region Methods
        public void SQLInsert<T>(T input) {
            if (ObjectExtensions.ObjectTypesMatch<AdministrativeTask, T>(input)) {
                AdministrativeTaskDbContext context = new AdministrativeTaskDbContext();
                context.AdministrativeTasks.Add((AdministrativeTask)(object)input);
                context.SaveChanges();
            }
        }
        public List<AdministrativeTask> SQLSelectForTournament(int tournamentID) {
            AdministrativeTaskDbContext context = new AdministrativeTaskDbContext();
            List<AdministrativeTask> selectedList = context.AdministrativeTasks.Where(i => i.TournamentID == tournamentID).OrderBy(i => i.ID).ToList();
            return selectedList;
        }
        #endregion

    }

    public interface IAdministrativeTask :ISQLInsertable {
        int ID { get; }
        int TournamentID { get; }
        AdministrativeTask.TaskTypes TaskType { get; }
        int TypeID { get; }
        AdministrativeTask.TaskStatuses TaskStatus { get; }
        List<AdministrativeTask> SQLSelectForTournament(int tournamentID);
    }

}