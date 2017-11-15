using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using System.Collections.Generic;
using GoTournamental.BLL.Planner;

namespace GoTournamental.ORM.Planner {

    public class TeamDbContext : DbContext {
        public DbSet<Team> Teams { get; set; }
        public TeamDbContext()
            : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString) {
                Database.SetInitializer<TeamDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new TeamConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public void ExecuteTeamDeleteWithCascade(int teamID) {
            this.Database.ExecuteSqlCommand("EXEC Planner.TeamDeleteWithCascade @teamID = {0}", teamID);
        }
        public IEnumerable<Team> GetCompetitionTeamsAll(int competitionID) {
            IEnumerable<Team> teams = this.Database.SqlQuery<Team>("EXEC Planner.CompetitionTeamsAll @CompetitionID = {0}", competitionID);
            return teams;
        }
        public IEnumerable<Team> GetCompetitionFinalsTeams(int competitionID) {
            IEnumerable<Team> teams = this.Database.SqlQuery<Team>("EXEC Planner.TeamsInCompetitionFinals @competitionID = {0}", competitionID);
            return teams;
        }


        public IEnumerable<Team> GetTeamsForTournament(int tournamentID) {
            IEnumerable<Team> teams = this.Database.SqlQuery<Team>("EXEC Planner.TournamentTeamsAll @tournamentID = {0}", tournamentID);
            return teams;
        }	

    }
    public class TeamConfiguration : EntityTypeConfiguration<Team> {
        public TeamConfiguration()
            : base() {
            HasKey(i => i.ID);
            Property(i => i.ClubID).HasColumnName("ClubID");
            Property(i => i.GroupID).HasColumnName("GroupID");
			Property(i => i.CompetitionID).HasColumnName("CompetitionID");
            Property(i => i.Name).HasColumnName("Name");
            Property(i => i.AttendanceType).HasColumnName("AttendanceType");
            Property(i => i.PrimaryContactID).HasColumnName("PrimaryContactID");
            Property(i => i.Registered).HasColumnName("Registered");
            ToTable("Planner.Teams");
        }
    }

}

