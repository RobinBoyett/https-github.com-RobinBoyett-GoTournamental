using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using System.Collections.Generic;
using GoTournamental.API.Utilities;

namespace GoTournamental.ORM.Utilities {

    public class ExceptionHandlerDbContext : DbContext {
        public DbSet<ExceptionHandler> ExceptionHandlers { get; set; }
        public ExceptionHandlerDbContext()
            : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString) {
            Database.SetInitializer<ExceptionHandlerDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new ExceptionHandlerOzoneConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class ExceptionHandlerOzoneConfiguration : EntityTypeConfiguration<ExceptionHandler> {
        public ExceptionHandlerOzoneConfiguration()
            : base() {
            HasKey(i => i.ID);
            Property(i => i.ID).HasColumnName("ID");
            Property(i => i.UserID).HasColumnName("UserID");
            Property(i => i.UserIPAddress).HasColumnName("UserIPAddress");
            Property(i => i.LoggedDate).HasColumnName("LoggedDate");
            Property(i => i.ReferringURL).HasColumnName("ReferringURL");
            Property(i => i.RequestedURL).HasColumnName("RequestedURL");
            Property(i => i.TypeName).HasColumnName("TypeName");
            Property(i => i.Message).HasColumnName("Message");
            Property(i => i.StackTrace).HasColumnName("StackTrace");
            ToTable("Administration.Exceptions");
        }
    }

}

