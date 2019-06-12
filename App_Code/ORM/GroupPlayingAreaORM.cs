using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.ORM.Organiser 
{

    public class GroupPlayingAreaDbContext : DbContext 
    {
        public DbSet<GroupPlayingArea> GroupPlayingAreas { get; set; }
        public GroupPlayingAreaDbContext() : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString) 
        {
            Database.SetInitializer<GroupPlayingAreaDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            modelBuilder.Configurations.Add(new GroupPlayingAreaConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
    public class GroupPlayingAreaConfiguration : EntityTypeConfiguration<GroupPlayingArea> 
    {
        public GroupPlayingAreaConfiguration() : base()
        {
            HasKey(i => i.ID);
            Property(i => i.GroupID).HasColumnName("GroupID");
            Property(i => i.PlayingAreaID).HasColumnName("PlayingAreaID");
            ToTable("Planner.GroupsPlayingAreas");
        }
    }

}

