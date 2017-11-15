using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using System.Collections.Generic;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.ORM.Organiser {

    public class CompetitionDbContext : DbContext {
        public DbSet<Competition> Competitions { get; set; }
        public CompetitionDbContext()
            : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString) {
                Database.SetInitializer<CompetitionDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new CompetitionConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public IEnumerable<int> SQLCompetitionIDForAgeBand(int tournamentID, int ageBand) {
            IEnumerable<int> competitionID = this.Database.SqlQuery<int>("SELECT Planner.CompetitionIDForAgeBand({0}, {1})", tournamentID, ageBand);
            return competitionID;
        }		
        public IEnumerable<int> CountTeamsAttendingCompetition(int competitionID) {
            IEnumerable<int> teams = this.Database.SqlQuery<int>("SELECT Planner.CompetitionCountTeamsAttending({0})", competitionID);
            return teams;
        }
        public IEnumerable<int> CountTeamsRegisteredAtCompetition(int competitionID) {
            IEnumerable<int> teams = this.Database.SqlQuery<int>("SELECT Planner.CompetitionCountTeamsRegistered({0})", competitionID);
            return teams;
        }
        public IEnumerable<int> CountTeamsAcceptedInviteForCompetition(int competitionID) {
            IEnumerable<int> teams = this.Database.SqlQuery<int>("SELECT Planner.CompetitionCountTeamsAccepted({0})", competitionID);
            return teams;
        }        
		public IEnumerable<int> CountHostTeamsAttendingCompetition(int competitionID) {
            IEnumerable<int> teams = this.Database.SqlQuery<int>("SELECT Planner.CompetitionCountHostTeamsAttending({0})", competitionID);
            return teams;
        }       		
		public IEnumerable<int> CountGroupsForCompetition(int competitionID) {
            IEnumerable<int> teams = this.Database.SqlQuery<int>("SELECT Planner.CompetitionCountGroups({0})", competitionID);
            return teams;
        }
		public IEnumerable<int> CountGroupsForCompetitionWhereFixturesUnderway(int competitionID) {
            IEnumerable<int> teams = this.Database.SqlQuery<int>("SELECT dbo.CountGroupsForCompetitionWhereFixturesUnderway({0})", competitionID);
            return teams;
        }
        public IEnumerable<int> CountPlayingAreasForCompetition(int competitionID) {
            IEnumerable<int> teams = this.Database.SqlQuery<int>("SELECT Planner.CompetitionCountPlayingAreas({0})", competitionID);
            return teams;
        }		
        public IEnumerable<int> CountFixturesForCompetition(int competitionID) {
            IEnumerable<int> fixtures = this.Database.SqlQuery<int>("SELECT Planner.CompetitionCountFixtures({0})", competitionID);
            return fixtures;
        }
        public IEnumerable<bool> CompetitionAllLeaguesFixturesCompleted(int competitionID) {
            IEnumerable<bool> completed = this.Database.SqlQuery<bool>("SELECT Planner.CompetitionAllLeagueFixturesCompleted({0})", competitionID);
            return completed;
        }
        public void SwapTeamsBetweenGroupsWithCascadeToFixtures(int teamOneID, int teamTwoID) {
			this.Database.ExecuteSqlCommand("EXEC Planner.GroupsSwapTeamsWithCascadeToFixtures {0}, {1}", teamOneID, teamTwoID);
		}
		public void DeleteGroupsForCompetitionWithCascadeToFixtures(int competitionID) {
			this.Database.ExecuteSqlCommand("EXEC Planner.GroupsInCompetitionDeleteWithCascadeToFixtures {0}", competitionID);
		}


    }
    public class CompetitionConfiguration : EntityTypeConfiguration<Competition> {
        public CompetitionConfiguration()
            : base() {
            HasKey(i => i.ID);
            Property(i => i.TournamentID).HasColumnName("TournamentID");
            Property(i => i.AgeBand).HasColumnName("AgeBand");
            Property(i => i.StartTime).HasColumnName("StartTime");
            Property(i => i.Session).HasColumnName("Session");
            Property(i => i.CompetitionFormat).HasColumnName("CompetitionFormat");
            Property(i => i.FixtureTurnaround).HasColumnName("FixtureTurnaround");
            Property(i => i.FixtureHalvesNumber).HasColumnName("FixtureHalvesNumber");
            Property(i => i.FixtureHalvesLength).HasColumnName("FixtureHalvesLength");
            Property(i => i.TeamSize).HasColumnName("TeamSize");
            Property(i => i.SquadSize).HasColumnName("SquadSize");
            ToTable("Planner.Competitions");
        }
    }

}

