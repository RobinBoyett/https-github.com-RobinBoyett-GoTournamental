using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using System.Collections.Generic;
using GoTournamental.API;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.ORM.Organiser {

    public class TournamentDbContext : DbContext {
        public DbSet<Tournament> Tournaments { get; set; }
        public TournamentDbContext()
            : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString) {
            Database.SetInitializer<TournamentDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new TournamentConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public void SQLTournamentDeleteFileImportWithCascade(int tournamentID) {
            this.Database.ExecuteSqlCommand("EXEC dbo.TournamentDeleteFileImportWithCascade @tournamentID = {0}", tournamentID);
        }

        public IEnumerable<int> CountPlayingAreasForTournament(int tournamentID) {
            IEnumerable<int> areas = this.Database.SqlQuery<int>("SELECT Planner.TournamentCountPlayingAreas({0})", tournamentID);
            return areas;
        }
        public IEnumerable<int> CountCompetitionsForTournament(int tournamentID) {
            IEnumerable<int> competitions = this.Database.SqlQuery<int>("SELECT Planner.TournamentCountCompetitions({0})", tournamentID);
            return competitions;
        }
        public IEnumerable<int> CountTeamsForTournament(int tournamentID) {
            IEnumerable<int> teams = this.Database.SqlQuery<int>("SELECT Planner.TournamentCountTeams({0})", tournamentID);
            return teams;
        }
		public IEnumerable<int> CountTeamsForTournamentByAttendanceType(int tournamentID, Domains.AttendanceTypes attendanceType) {
            IEnumerable<int> teams = this.Database.SqlQuery<int>("SELECT Planner.TournamentCountTeamsForAttendanceType({0},{1})", tournamentID, attendanceType);
            return teams;
        }
        public IEnumerable<int> CountFixturesScheduledForTournament(int tournamentID) {
            IEnumerable<int> fixtures = this.Database.SqlQuery<int>("SELECT Planner.TournamentCountFixtures({0})", tournamentID);
            return fixtures;
        }

    }
    public class TournamentConfiguration : EntityTypeConfiguration<Tournament> {
        public TournamentConfiguration() : base() {
            HasKey(i => i.ID);
            Property(i => i.TournamentType).HasColumnName("Type");
            Property(i => i.Name).HasColumnName("Name");
            Property(i => i.Affiliation).HasColumnName("Affiliation");
            Property(i => i.StartTime).HasColumnName("StartTime");
            Property(i => i.EndTime).HasColumnName("EndTime");
            Property(i => i.Venue).HasColumnName("Venue");
            Property(i => i.GoogleMapsURL).HasColumnName("GoogleMapsURL");
            Property(i => i.NoOfPlayingAreas).HasColumnName("NoOfPlayingAreas");
            Property(i => i.FixtureTurnaround).HasColumnName("FixtureTurnaround");
            Property(i => i.FixtureHalvesNumber).HasColumnName("FixtureHalvesNumber");
            Property(i => i.FixtureHalvesLength).HasColumnName("FixtureHalvesLength");
            Property(i => i.TeamSize).HasColumnName("TeamSize");
            Property(i => i.SquadSize).HasColumnName("SquadSize");
            Property(i => i.RotatorDate).HasColumnName("RotatorDate");
            Property(i => i.RotatorSession).HasColumnName("RotatorSession");
            ToTable("Planner.Tournaments");
        }
    }

}

