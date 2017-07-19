using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using System.Collections.Generic;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.ORM.Organiser {

    public class ContactUsDbContext : DbContext {
        public DbSet<ContactUs> ContactedUs { get; set; }
        public ContactUsDbContext()
            : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString) {
                Database.SetInitializer<ContactUsDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new ContactUsConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
    public class ContactUsConfiguration : EntityTypeConfiguration<ContactUs> {
        public ContactUsConfiguration()
            : base() {
            HasKey(i => i.ID);
            Property(i => i.FirstName).HasColumnName("FirstName");
            Property(i => i.LastName).HasColumnName("LastName");
            Property(i => i.Email).HasColumnName("Email");
            Property(i => i.Organisation).HasColumnName("Organisation");
            Property(i => i.TelephoneNumber).HasColumnName("TelephoneNumber");
            Property(i => i.TournamentType).HasColumnName("TournamentType");
            Property(i => i.AdditionalInformation).HasColumnName("AdditionalInformation");
            Property(i => i.ContactDate).HasColumnName("ContactDate");
            Property(i => i.Status).HasColumnName("Status");
			ToTable("Administration.ContactUs");
        }
    }



}

