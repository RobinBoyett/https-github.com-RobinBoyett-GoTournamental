using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using System.Collections.Generic;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.ORM.Organiser {

    public class ClubDbContext : DbContext {
        public DbSet<Club> Clubs { get; set; }
        public ClubDbContext()
            : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString) {
                Database.SetInitializer<ClubDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new ClubConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public void SQLClubDeleteWithCascade(int clubID) {
            this.Database.ExecuteSqlCommand("EXEC Planner.ClubDeleteWithCascade @clubID = {0}", clubID);
        }
        public IEnumerable<Club> SQLGetClubsForCompetition(int competitionID) {
            IEnumerable<Club> clubs = this.Database.SqlQuery<Club>("EXEC Planner.CompetitionClubsAll {0}", competitionID);
            return clubs;
        }
        public IEnumerable<int> SQLGetClubIDForClubName(int tournamentID, string clubName) {
            IEnumerable<int> clubID = this.Database.SqlQuery<int>("SELECT Planner.ClubIDForClubName({0}, {1})", tournamentID, clubName);
            return clubID;
        }

    }
    public class ClubConfiguration : EntityTypeConfiguration<Club> {
        public ClubConfiguration()
            : base() {
            HasKey(i => i.ID);
            Property(i => i.TournamentID).HasColumnName("TournamentID");
            Property(i => i.Name).HasColumnName("Name");
            Property(i => i.AttendanceType).HasColumnName("AttendanceType");         
            Property(i => i.WebsiteURL).HasColumnName("WebsiteURL");
            Property(i => i.LogoFile).HasColumnName("LogoFile");
            Property(i => i.Twitter).HasColumnName("Twitter");
            Property(i => i.ColourPrimary).HasColumnName("ColourPrimary");
            Property(i => i.ColourSecondary).HasColumnName("ColourSecondary");
            Property(i => i.Affiliation).HasColumnName("Affiliation");
            Property(i => i.AffiliationNumber).HasColumnName("AffiliationNumber");
            Property(i => i.PrimaryContactID).HasColumnName("PrimaryContactID");
            ToTable("Planner.Clubs");
            HasMany<Team>(i => i.Teams).WithRequired(i => i.Club).HasForeignKey(i => i.ClubID);
        }
    }

}

