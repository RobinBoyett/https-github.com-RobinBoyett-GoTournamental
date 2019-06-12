using System.Linq;
using System.Collections.Generic;
using GoTournamental.API;
using GoTournamental.API.Interface;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;
using GoTournamental.ORM.Planner;

namespace GoTournamental.BLL.Planner 
{

    public class Team: ITeam 
    {

		#region Constructors
		public Team() {}
        public Team(
            int id, int clubID, int? competitionID, int? groupID, string name, Domains.AttendanceTypes attendanceType, int? primaryContactID, bool? registered
        )
        {
            this.ID = id;
            this.ClubID = clubID;
			this.CompetitionID = competitionID;
            this.GroupID = groupID;
            this.Name = name;
            this.AttendanceType = attendanceType;
			this.PrimaryContactID = primaryContactID;
            this.Registered = registered;
        }
        #endregion

        #region Properties
        public int ID { get; set; }
        public int ClubID { get; set; }
        public Club Club 
        {
            get 
            {
                IClub iClub = new Club();
                Club club = iClub.SQLSelect<Club, int?>(this.ClubID);
                return club;
            }
        }
        public int? CompetitionID { get; set; }
        public int? GroupID { get; set; }
        public string Name { get; set; }
        public Domains.AttendanceTypes AttendanceType { get; set; }
        public int? PrimaryContactID { get; set; }
        public Contact PrimaryContact
        {
            get 
            {
                Contact contact = new Contact();
                IContact iContact = new Contact();
                if (this.PrimaryContactID != null) 
                {
                    contact = iContact.SQLSelect<Contact, int?>(PrimaryContactID);
                }
                return contact;
            }
        }
        public bool? Registered { get; set; }
        #endregion

        #region Methods
        public override string ToString() 
        {
            return string.Format("{0}", Name);
        }	
        public void SQLInsert<T>(T input) 
        {
            if (ObjectExtensions.ObjectTypesMatch<Team, T>(input))
            {
                TeamDbContext context = new TeamDbContext();
                context.Teams.Add((Team)(object)input);
                context.SaveChanges();
            }
        }
        public int SQLInsertAndReturnID<T>(T input) 
        {
            int ret = 0;
            if (ObjectExtensions.ObjectTypesMatch<Team, T>(input))
            {
                TeamDbContext context = new TeamDbContext();
                context.Teams.Add((Team)(object)input);
                context.SaveChanges();
                ret = ((Team)(object)input).ID;
            }
            return ret;
        }  
        public T SQLSelect<T, U>(U id) 
        {
            TeamDbContext context = new TeamDbContext();
            Team selected = context.Teams.Where(i => i.ID == (int)(object)id).SingleOrDefault();
            return (T)(object)selected;
        }
        
		public List<Team> SQLSelectForGroup(int groupID) 
        {
            TeamDbContext context = new TeamDbContext();
            List<Team> selectedList = context.Teams.Where(i => i.GroupID == groupID).OrderBy(i => i.ID).ToList();
            return selectedList;
        }
        public List<Team> GetCompetitionTeamsAll(int competitionID) 
        {
            TeamDbContext context = new TeamDbContext();
            List<Team> selectedList = context.GetCompetitionTeamsAll(competitionID).OrderBy(i => i.ID).ToList();
            return selectedList;
        }	       
        public List<Team> GetCompetitionFinalsTeams(int competitionID) 
        {
            TeamDbContext context = new TeamDbContext();
            List<Team> selectedList = context.GetCompetitionFinalsTeams(competitionID).OrderBy(i => i.ID).ToList();
            return selectedList;
        }	       
        public List<Team> SQLSelectForTournament(int tournamentID) 
        {
            TeamDbContext context = new TeamDbContext();
            List<Team> selectedList = context.GetTeamsForTournament(tournamentID).OrderBy(i => i.ID).ToList();
            return selectedList;
        } 		
		
		public void SQLUpdate<T>(T input) 
        {
            if (ObjectExtensions.ObjectTypesMatch<Team, T>(input))
            {
                TeamDbContext context = new TeamDbContext();
                Team updated = (Team)(object)input;
                Team selected = context.Teams.Single(i => i.ID == updated.ID);
                selected.Name = updated.Name;
                selected.AttendanceType = updated.AttendanceType;
				selected.CompetitionID = updated.CompetitionID;
                selected.PrimaryContactID = updated.PrimaryContactID;
                context.SaveChanges();
            }
        }    
		public void SQLUpdateGroupID(int id, int groupID) 
        {
            TeamDbContext context = new TeamDbContext();
            Team selected = context.Teams.Single(i => i.ID == id);
			selected.GroupID = groupID;
            context.SaveChanges();
		}	
		public void SQLUpdatePrimaryContactID(int id, int primaryContactID) 
        {
            TeamDbContext context = new TeamDbContext();
            Team selected = context.Teams.Single(i => i.ID == id);
			selected.PrimaryContactID = primaryContactID;
            context.SaveChanges();
		}
        public void SQLUpdateAttendanceType(int id, Domains.AttendanceTypes attendanceType)
        {
            TeamDbContext context = new TeamDbContext();
            Team selected = context.Teams.Single(i => i.ID == id);
            selected.AttendanceType = attendanceType;
            context.SaveChanges();
        }			
        public void SQLUpdateRegistration(int id, bool registration) 
        {
            TeamDbContext context = new TeamDbContext();
            Team selected = context.Teams.Single(i => i.ID == id);
            selected.Registered = registration;
            context.SaveChanges();
        }
        public void SQLDeleteWithCascade<T>(T input)
        {
            TeamDbContext context = new TeamDbContext();
            Team teamToDelete = (Team)(object)input;
            context.ExecuteTeamDeleteWithCascade(teamToDelete.ID);
		}		
		public Team SQLGetTeamForPrimaryContactID(int? id) 
        {
            Team team = new Team();
            TeamDbContext context = new TeamDbContext();
            team = context.Teams.Where(i => i.PrimaryContactID == id).SingleOrDefault();
            return team;
        }
		public Competition GetCompetition() 
        {
			ICompetition iCompetition = new Competition();
			Competition competition = new Competition();
			if (this.CompetitionID != null) 
            {
				competition = iCompetition.SQLSelect<Competition, int>((int)this.CompetitionID);
			}
			return competition;
		}
		#endregion

    }

    public interface ITeam : ISQLInsertable, ISQLInsertableReturningID, ISQLSelectable, ISQLUpdateable, ISQLDeleteCascadable  
    {
        int ID { get; }
        int ClubID { get; }
        Club Club { get; }
		int? CompetitionID { get; }
        int? GroupID { get; }
        string Name { get; }
        bool? Registered { get; }
        Domains.AttendanceTypes AttendanceType { get; }
        int? PrimaryContactID { get; }
        Contact PrimaryContact { get; }
        List<Team> SQLSelectForGroup(int groupID);
        List<Team> GetCompetitionTeamsAll(int competitionID);
        List<Team> GetCompetitionFinalsTeams(int competitionID);
        List<Team> SQLSelectForTournament(int tournamentID);
		void SQLUpdateGroupID(int id, int groupID);
		void SQLUpdatePrimaryContactID(int id, int primaryContactID);
        void SQLUpdateAttendanceType(int id, Domains.AttendanceTypes attendanceType);
        void SQLUpdateRegistration(int id, bool registration);
        Team SQLGetTeamForPrimaryContactID(int? id);
		Competition GetCompetition();
    }

}