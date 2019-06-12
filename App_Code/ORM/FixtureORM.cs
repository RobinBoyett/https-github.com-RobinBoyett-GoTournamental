using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using System.Collections.Generic;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.ORM.Organiser
{

    public class FixtureDbContext : DbContext
    {
        public DbSet<Fixture> Fixtures { get; set; }
        public FixtureDbContext() : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString)
        {
            Database.SetInitializer<FixtureDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FixtureConfiguration());
            base.OnModelCreating(modelBuilder);
        }
		public IEnumerable<Fixture> GetFixturesForTournament(int tournamentID)
        {
			IEnumerable<Fixture> fixtures = this.Database.SqlQuery<Fixture>("EXEC Planner.TournamentFixturesAll @tournamentID = {0}", tournamentID);
			return fixtures;
		}
		public IEnumerable<DateTime?> GetLastLeagueFixtureTimeForCompetition(int competitionID)
        {
            IEnumerable<DateTime?> starttime = this.Database.SqlQuery<DateTime?>("SELECT Planner.CompetitionLastLeagueFixtureTime({0})", competitionID);
			return starttime;
        }	
		public void AdjustToAvoidConsecutiveTeamFixtures(int groupID)
        {
			this.Database.ExecuteSqlCommand("EXEC Planner.FixtureAdjustToAvoidConsecutiveTeams {0}", groupID);
		}
		public void AdjustFixtureTimesInGroupOfFour(int groupID)
        {
			this.Database.ExecuteSqlCommand("EXEC Planner.FixtureAdjustTimesInGroupOfFour {0}", groupID);
		}
		public void AdjustFixtureTurnaroundForGroup(int groupID, int fixtureTurnaround)
        {
			this.Database.ExecuteSqlCommand("EXEC Planner.GroupUpdateFixtureTurnaround {0}, {1}", groupID, fixtureTurnaround);
		}
        public void ReplaceCancelledTeamInFixtures(int targetTeamID, int replacementTeamID)
        {
			this.Database.ExecuteSqlCommand("EXEC Planner.TeamReplaceCancelled {0}, {1}", targetTeamID, replacementTeamID);
		}
		public void ReplaceFinalistTeamInFixtures(int targetTeamID, int replacementTeamID)
        {
			this.Database.ExecuteSqlCommand("EXEC Planner.FixtureReplaceFinalistTeam  {0}, {1}", targetTeamID, replacementTeamID);
		}
		public void DeleteFixturesForCompetition(int competitionID)
        {
			this.Database.ExecuteSqlCommand("DELETE FROM Planner.Fixtures WHERE CompetitionID = {0}", competitionID);
		}
	
	}
    public class FixtureConfiguration : EntityTypeConfiguration<Fixture>
    {
        public FixtureConfiguration() : base()
        {
            HasKey(i => i.ID);
            Property(i => i.CompetitionID).HasColumnName("CompetitionID");
            Property(i => i.GroupID).HasColumnName("GroupID");
            Property(i => i.IsLeagueFixture).HasColumnName("IsLeagueFixture");
            Property(i => i.PlayingAreaID).HasColumnName("PlayingAreaID");
            Property(i => i.Name).HasColumnName("Name");
            Property(i => i.StartTime).HasColumnName("StartTime");
            Property(i => i.HomeTeamID).HasColumnName("HomeTeamID");
            Property(i => i.HomeTeamScore).HasColumnName("HomeTeamScore");
            Property(i => i.HomeTeamPenaltiesScore).HasColumnName("HomeTeamPenaltiesScore");
            Property(i => i.AwayTeamID).HasColumnName("AwayTeamID");
            Property(i => i.AwayTeamScore).HasColumnName("AwayTeamScore");
            Property(i => i.AwayTeamPenaltiesScore).HasColumnName("AwayTeamPenaltiesScore");
            Property(i => i.PrimaryOfficialID).HasColumnName("PrimaryOfficialID");
            ToTable("Planner.Fixtures");
        }
    }

}

