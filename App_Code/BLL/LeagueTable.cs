using System.Linq;
using System.Collections.Generic;
using GoTournamental.BLL.Planner;
using GoTournamental.ORM.Organiser;

namespace GoTournamental.BLL.Organiser
{

    public class LeagueTable : ILeagueTable
    {

		#region Constructors
        public LeagueTable() { }
        //public LeagueTable(int id, int position, int teamID, int goalsFor, int goalsAgainst, int goalDifference, int points) 
        //{
        //    this.ID = id;
        //    this.Position = position;
        //    this.TeamID = teamID;
        //    this.GoalsFor = goalsFor;
        //    this.GoalsAgainst = goalsAgainst;
        //    this.GoalDifference = goalDifference;
        //    this.Points = points;
        //}
        #endregion

        #region Properties
        public int ID { get; set; }
        public int Position { get; set; }
        public int TeamID { get; set; }
        public Team Team
        {
            get
            {
                Team team = new Team();
                ITeam iTeam = new Team();
                team = iTeam.SQLSelect<Team, int>(TeamID);
                return team;
            }
        }
        public int Played { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Defeats { get; set; }        
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }
        #endregion

        #region Methods
        public List<LeagueTable> GetLeagueTableForGroup(int groupID) 
        {
            LeagueTableDbContext context = new LeagueTableDbContext();
            List<LeagueTable> leagueTables = context.GetLeagueTableForGroup(groupID).ToList();
            return leagueTables;
        }
        public List<LeagueTable> GetLeagueWinnersForCompetition(int competitionID)
        {
            LeagueTableDbContext context = new LeagueTableDbContext();
            List<LeagueTable> leagueTables = context.GetLeagueWinnersForCompetition(competitionID).ToList();
            return leagueTables;
        }
		#endregion

    }

    public interface ILeagueTable
    {
        int ID { get; }
        int Position { get; }
        int TeamID { get; }
        Team Team { get; }
        int Played { get; }
        int Wins { get; }
        int Draws { get; }
        int Defeats { get; }
        int GoalsFor { get; }
        int GoalsAgainst { get; }
        int GoalDifference { get; }
        int Points { get; }
        List<LeagueTable> GetLeagueTableForGroup(int groupID);
        List<LeagueTable> GetLeagueWinnersForCompetition(int competitionID);
    }

}