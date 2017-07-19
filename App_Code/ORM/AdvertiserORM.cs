using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using System.Collections.Generic;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.ORM.Organiser {

    public class AdvertiserDbContext : DbContext {
        public DbSet<Advertiser> Advertisers { get; set; }
        public AdvertiserDbContext()
            : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString) {
                Database.SetInitializer<AdvertiserDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new AdvertisementConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
    public class AdvertisementConfiguration : EntityTypeConfiguration<Advertiser> {
        public AdvertisementConfiguration()
            : base() {
            HasKey(i => i.ID);
            Property(i => i.TournamentID).HasColumnName("TournamentID");
            Property(i => i.AdvertiserName).HasColumnName("AdvertiserName");
            Property(i => i.WebsiteURL).HasColumnName("WebsiteURL");
            Property(i => i.TooltipText).HasColumnName("TooltipText");
            ToTable("Planner.Advertisers");
        }
    }

}

