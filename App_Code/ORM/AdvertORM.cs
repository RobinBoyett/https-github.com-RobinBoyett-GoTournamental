using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using System.Collections.Generic;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.ORM.Organiser {

    public class AdvertDbContext : DbContext {
        public DbSet<Advert> Adverts { get; set; }
        public AdvertDbContext()
            : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString) {
                Database.SetInitializer<AdvertDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new AdvertConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public IEnumerable<Advert> GetAdvertsForGoTournamental() {
            IEnumerable<Advert> adverts = this.Database.SqlQuery<Advert>("EXEC Planner.AdvertsGoTournamental");
            return adverts;
        }	
		public IEnumerable<Advert> GetAdvertsForTournament(int tournamentID) {
            IEnumerable<Advert> adverts = this.Database.SqlQuery<Advert>("EXEC Planner.AdvertsTournament @tournamentID = {0}", tournamentID);
            return adverts;
        }		
	}
    public class AdvertConfiguration : EntityTypeConfiguration<Advert> {
        public AdvertConfiguration()
            : base() {
            HasKey(i => i.ID);
            Property(i => i.AdvertiserID).HasColumnName("AdvertiserID");
            Property(i => i.GraphicFileName).HasColumnName("GraphicFileName");
            Property(i => i.GraphicFileType).HasColumnName("GraphicFileType");
            Property(i => i.GraphicStyle).HasColumnName("GraphicStyle");
            Property(i => i.ClicksThrough).HasColumnName("ClicksThrough");
            ToTable("Planner.Adverts");
        }
    }

}

