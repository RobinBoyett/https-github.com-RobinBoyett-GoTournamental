using System;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using GoTournamental.API.Interface;
using GoTournamental.API.Utilities;
using GoTournamental.ORM.Organiser;

namespace GoTournamental.BLL.Organiser {

    public class Group: IGroup {

        #region Member Enumerations & Collections    
        public enum NumberOfGroups {
            Undefined = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4
        }
		#endregion

		#region Constructors
        public Group() { }
        public Group(int id, int competitionID, string name, Tournament.FixtureTurnarounds fixtureTurnaround, bool? fixturesUnderWay) {
            this.ID = id;
            this.CompetitionID = competitionID;
            this.Name = name;
            this.FixtureTurnaround = fixtureTurnaround;
            this.FixturesUnderWay = fixturesUnderWay;
        }

        #endregion

        #region Properties
        public int ID { get; set; }
        public int CompetitionID { get; set; }
        public string Name { get; set; }
        public Tournament.FixtureTurnarounds FixtureTurnaround { get; set; }
        public bool? FixturesUnderWay { get; set; }
        #endregion

        #region Methods
        public void SQLInsert<T>(T input) {
            if (ObjectExtensions.ObjectTypesMatch<Group, T>(input)) {
                GroupDbContext context = new GroupDbContext();
                context.Groups.Add((Group)(object)input);
                context.SaveChanges();
            }
        }
        public int SQLInsertAndReturnID<T>(T input) {
            int ret = 0;
            if (ObjectExtensions.ObjectTypesMatch<Group, T>(input)) {
                GroupDbContext context = new GroupDbContext();
                context.Groups.Add((Group)(object)input);
                context.SaveChanges();
                ret = ((Group)(object)input).ID;
            }
            return ret;
        }
		public T SQLSelect<T, U>(U id) {
            GroupDbContext context = new GroupDbContext();
            Group selected = context.Groups.Where(i => i.ID == (int)(object)id).SingleOrDefault();
            return (T)(object)selected;
        }    
        public List<Group> SQLSelectForCompetition(int competitionID) {
            GroupDbContext context = new GroupDbContext();
            List<Group> selectedList = context.Groups.Where(i => i.CompetitionID == competitionID).OrderBy(i => i.ID).ToList();
            return selectedList;
        }
        public int GetNumberOfTeamsInGroup() {
            GroupDbContext context = new GroupDbContext();
            int noTeams = context.GetNumberOfTeamsInGroup(this.ID).SingleOrDefault();
            return noTeams;
        }        	
        public int GetNumberOfTeamsRegisteredInGroup() {
            GroupDbContext context = new GroupDbContext();
            int noTeams = context.GetNumberOfTeamsRegisteredInGroup(this.ID).SingleOrDefault();
            return noTeams;
        }                
        public void SQLUpdateFixturesUnderway(int id, bool fixturesUnderway) {
            GroupDbContext context = new GroupDbContext();
            Group selected = context.Groups.Single(i => i.ID == id);
            selected.FixturesUnderWay = fixturesUnderway;
            context.SaveChanges();
        }
        public void SQLUpdateFixtureTurnaround(int id, Tournament.FixtureTurnarounds turnaround) {
            GroupDbContext context = new GroupDbContext();
            Group selected = context.Groups.Single(i => i.ID == id);
            selected.FixtureTurnaround = turnaround;
            context.SaveChanges();
        }
        #endregion

    }

    public interface IGroup : ISQLInsertable, ISQLInsertableReturningID, ISQLSelectable {
        int ID { get; }
        int CompetitionID { get; }
        string Name { get; }
        Tournament.FixtureTurnarounds FixtureTurnaround { get; }
        bool? FixturesUnderWay { get; }
        List<Group> SQLSelectForCompetition(int competitionID);
        int GetNumberOfTeamsInGroup();
        int GetNumberOfTeamsRegisteredInGroup();
        void SQLUpdateFixturesUnderway(int id, bool fixturesUnderway);
        void SQLUpdateFixtureTurnaround(int id, Tournament.FixtureTurnarounds turnaround);
    }

}