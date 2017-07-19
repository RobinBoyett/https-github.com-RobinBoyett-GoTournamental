using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using System.Collections.Generic;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.ORM.Organiser {

    public class TermsSignatoryDbContext : DbContext {
        public DbSet<TermsSignatory> TermsSignatories { get; set; }
        public TermsSignatoryDbContext()
            : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString) {
                Database.SetInitializer<TermsSignatoryDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new TermsSignatoryConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
    public class TermsSignatoryConfiguration : EntityTypeConfiguration<TermsSignatory> {
        public TermsSignatoryConfiguration()
            : base() {
            HasKey(i => i.ID);
            Property(i => i.UserID).HasColumnName("UserID");
            Property(i => i.UserName).HasColumnName("UserName");
            ToTable("Administration.TermsSignatories");
        }
    }

}

