using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using GoTournamental.BLL.Planner;

namespace GoTournamental.ORM.Planner
{

    public class AdministrativeTaskDbContext : DbContext 
    {
        public DbSet<AdministrativeTask> AdministrativeTasks { get; set; }
        public AdministrativeTaskDbContext() : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString)
        {
            Database.SetInitializer<AdministrativeTaskDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            modelBuilder.Configurations.Add(new AdministrativeTaskConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
    public class AdministrativeTaskConfiguration : EntityTypeConfiguration<AdministrativeTask>
    {
        public AdministrativeTaskConfiguration() : base()
        {
            HasKey(i => i.ID);
            Property(i => i.TournamentID).HasColumnName("TournamentID");
            Property(i => i.TaskType).HasColumnName("TaskType");
            Property(i => i.TypeID).HasColumnName("TypeID");
            Property(i => i.TaskStatus).HasColumnName("TaskStatus");
            ToTable("Planner.AdministrativeTasks");
        }
    }

}

