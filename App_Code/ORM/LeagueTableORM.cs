using System.Data.Entity;
using System.Configuration;
using System.Collections.Generic;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.ORM.Organiser 
{

    public class LeagueTableDbContext : DbContext 
    {
        public DbSet<LeagueTable> LeagueTables { get; set; }
        public LeagueTableDbContext() : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString) 
        {
                Database.SetInitializer<LeagueTableDbContext>(null);
        }
        public IEnumerable<LeagueTable> GetLeagueTableForGroup(int groupID) 
        {
            IEnumerable<LeagueTable> leagueTable = this.Database.SqlQuery<LeagueTable>("EXEC Planner.GroupLeagueTable @groupID = {0}", groupID);
            return leagueTable;
        }
        public IEnumerable<LeagueTable> GetLeagueWinnersForCompetition(int competitionID) 
        {
            IEnumerable<LeagueTable> leagueTable = this.Database.SqlQuery<LeagueTable>("EXEC Planner.CompetitionLeagueWinners @CompetitionID = {0}", competitionID);
            return leagueTable;
        }        
    }
 
}

