using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using System.Collections.Generic;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.ORM.Organiser {

    public class ContactDbContext : DbContext {
        public DbSet<Contact> Contacts { get; set; }
        public ContactDbContext()
            : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString) {
                Database.SetInitializer<ContactDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new ContactConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
    public class ContactConfiguration : EntityTypeConfiguration<Contact> {
        public ContactConfiguration()
            : base() {
            HasKey(i => i.ID);
            Property(i => i.TournamentID).HasColumnName("TournamentID");
            Property(i => i.Type).HasColumnName("Type");
            Property(i => i.Title).HasColumnName("Title");
            Property(i => i.FirstName).HasColumnName("FirstName");         
            Property(i => i.LastName).HasColumnName("LastName");
            Property(i => i.TelephoneNumber).HasColumnName("TelephoneNumber");
            Property(i => i.Email).HasColumnName("Email");
            Property(i => i.DateOfBirth).HasColumnName("DateOfBirth");
            Property(i => i.SquadNumber).HasColumnName("SquadNumber");
            ToTable("Planner.Contacts");
        }
    }
}

