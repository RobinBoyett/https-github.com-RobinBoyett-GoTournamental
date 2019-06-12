using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.ORM.Organiser
{

    public class DocumentDbContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DocumentDbContext() : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString)
        {
            Database.SetInitializer<DocumentDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            modelBuilder.Configurations.Add(new DocumentConfiguration());
            base.OnModelCreating(modelBuilder);
        }
  
	}
    public class DocumentConfiguration : EntityTypeConfiguration<Document>
    {
        public DocumentConfiguration() : base() 
        {
            HasKey(i => i.ID);
			Property(i => i.TournamentID).HasColumnName("TournamentID");
			Property(i => i.DocumentType).HasColumnName("DocumentType");
			Property(i => i.FileName).HasColumnName("FileName");
			ToTable("Planner.Documents");
        }
    }

}

