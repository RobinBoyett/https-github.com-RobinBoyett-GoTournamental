using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using System.Collections.Generic;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.ORM.Organiser {

    public class PlayingAreaDbContext : DbContext {
        public DbSet<PlayingArea> PlayingAreas { get; set; }
        public PlayingAreaDbContext()
            : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString) {
                Database.SetInitializer<PlayingAreaDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new PlayingAreaConfiguration());
            base.OnModelCreating(modelBuilder);
        }
       public IEnumerable<PlayingArea> GetPlayingAreasInUseForTournamentSession(int tournamentID, int competitionID) {
            IEnumerable<PlayingArea> playingAreas = this.Database.SqlQuery<PlayingArea>("EXEC Planner.PlayingAreasUSedInTournamentSession @tournamentID = {0}, @competitionID = {1}", tournamentID, competitionID);
            return playingAreas;
        }	

    }
    public class PlayingAreaConfiguration : EntityTypeConfiguration<PlayingArea> {
        public PlayingAreaConfiguration()
            : base() {
            HasKey(i => i.ID);
            Property(i => i.TournamentID).HasColumnName("TournamentID");
            Property(i => i.Name).HasColumnName("Name");
            ToTable("Planner.PlayingAreas");
        }
    }



}

