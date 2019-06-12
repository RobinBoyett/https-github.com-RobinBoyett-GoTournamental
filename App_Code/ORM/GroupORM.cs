using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using System.Collections.Generic;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.ORM.Organiser
{

    public class GroupDbContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public GroupDbContext() : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString)
        {
            Database.SetInitializer<GroupDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GroupConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public IEnumerable<int> GetNumberOfTeamsInGroup(int groupID)
        {
            IEnumerable<int> noTeams = this.Database.SqlQuery<int>("SELECT COUNT(*) FROM Planner.Teams WHERE GroupID = {0}", groupID);
            return noTeams;
        }	
        public IEnumerable<int> GetNumberOfTeamsRegisteredInGroup(int groupID)
        {
            IEnumerable<int> noTeams = this.Database.SqlQuery<int>("SELECT COUNT(*) FROM Planner.Teams WHERE GroupID = {0} AND Registered = 'True'", groupID);
            return noTeams;
        }

    }
    public class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration() : base()
        {
            HasKey(i => i.ID);
            Property(i => i.Name).HasColumnName("Name");
            Property(i => i.CompetitionID).HasColumnName("CompetitionID");
            Property(i => i.FixtureTurnaround).HasColumnName("FixtureTurnaround");
            Property(i => i.FixturesUnderWay).HasColumnName("FixturesUnderWay");
            ToTable("Planner.Groups");
        }
    }

}

