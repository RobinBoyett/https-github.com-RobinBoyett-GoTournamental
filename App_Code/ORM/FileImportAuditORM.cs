using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using System.Collections.Generic;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.ORM.Organiser {

    public class FileImportAuditDbContext : DbContext {
        public DbSet<FileImportAudit> FileImportAudits { get; set; }
        public FileImportAuditDbContext()
            : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString) {
                Database.SetInitializer<FileImportAuditDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new FileImportAuditConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
    public class FileImportAuditConfiguration : EntityTypeConfiguration<FileImportAudit> {
        public FileImportAuditConfiguration()
            : base() {
            HasKey(i => i.ID);
            Property(i => i.TournamentID).HasColumnName("TournamentID");
            Property(i => i.FileType).HasColumnName("FileType");
            Property(i => i.NoClubs).HasColumnName("NoClubs");
            Property(i => i.NoCompetitions).HasColumnName("NoCompetitions");
            Property(i => i.NoTeams).HasColumnName("NoTeams");
            Property(i => i.NoPrimaryOfficials).HasColumnName("NoPrimaryOfficials");
            Property(i => i.NoSponsors).HasColumnName("NoSponsors");
            ToTable("Administration.FileImportAudits");
        }
    }

}

